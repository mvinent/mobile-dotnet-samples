﻿
using System;
using System.Collections.Generic;
using Carto.Core;
using Carto.DataSources;
using Carto.Geocoding;
using Carto.Geometry;
using Carto.Layers;
using Carto.Projections;
using Carto.Styles;
using Carto.Ui;
using CoreGraphics;
using Shared;
using Shared.iOS;
using UIKit;

namespace AdvancedMap.iOS
{
    public class BaseGeocodingView : UIView
    {
        public MapView MapView { get; private set; }

        LocalVectorDataSource source;

        PopupButton PackageButton;

        Projection Projection
        {
            get { return MapView.Options.BaseProjection; }
        }

        public BaseGeocodingView()
        {
            MapView = new MapView();
            AddSubview(MapView);

            var layer = new CartoOnlineVectorTileLayer(CartoBaseMapStyle.CartoBasemapStyleVoyager);
            MapView.Layers.Add(layer);

            source = new LocalVectorDataSource(Projection);
            var objectLayer = new VectorLayer(source);
            MapView.Layers.Add(objectLayer);

            PackageButton = new PopupButton("icons/icon_global.png");
            AddButton(PackageButton);
        }

        nfloat bottomLabelHeight = 40;
        nfloat smallPadding = 5;

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            MapView.Frame = Bounds;

            int count = buttons.Count;

            nfloat buttonWidth = 60;
            nfloat innerPadding = 25;
            nfloat totalArea = buttonWidth * count + (innerPadding * (count - 1));

            var w = buttonWidth;
            var h = w;
            var y = Frame.Height - (bottomLabelHeight + h + smallPadding);
            var x = Frame.Width / 2 - totalArea / 2;

            foreach (PopupButton button in buttons)
            {
                button.Frame = new CGRect(x, y, w, h);
                x += w + innerPadding;
            }
        }

        readonly List<PopupButton> buttons = new List<PopupButton>();

        public void AddButton(PopupButton button)
        {
            buttons.Add(button);
            AddSubview(button);
        }

        public string Folder { get; set; } = "";

        public void UpdatePackages(List<Package> packages)
        {
            Console.WriteLine(packages);
        }
    }
}
