﻿using Carto.Core;
using Carto.DataSources;
using Carto.Layers;
using Carto.Projections;
using Carto.Services;
using Carto.Styles;

using Carto.Ui;
using Carto.VectorElements;
using System;
using Windows.System.Threading;

namespace HelloMap.WindowsPhone
{
    public static class MapExtensions
    {
        public static async void AddMarkerToPosition(this MapView map, MapPos position)
        {
            await ThreadPool.RunAsync(delegate
            {
                // Initialize a local vector data source
                Projection projection = map.Options.BaseProjection;
                LocalVectorDataSource datasource = new LocalVectorDataSource(projection);

                // Initialize a vector layer with the previous data source
                VectorLayer layer = new VectorLayer(datasource);

                // Add layer to map
                map.Layers.Add(layer);

                MarkerStyleBuilder builder = new MarkerStyleBuilder();
                builder.Size = 20;
                builder.Color = new Carto.Graphics.Color(0, 255, 0, 255);
                
                MarkerStyle style = builder.BuildStyle();

                // Create marker and add it to the source
                Marker marker = new Marker(position, style);


                // Add text element to same location
                TextStyleBuilder MyStyleBuilder = new TextStyleBuilder
                {
                    OrientationMode = BillboardOrientation.BillboardOrientationGround,
                    FontSize = 12.0f,
                    CausesOverlap = false,
                    Color = new Carto.Graphics.Color(255, 0, 0, 255),
                    ScalingMode = BillboardScaling.BillboardScalingWorldSize,
                    Flippable = false,
                    HideIfOverlapped = false,
                    RenderScale = 8.0f
                };

                Text text = new Text(position, MyStyleBuilder.BuildStyle(), "TEXT");

                datasource.Add(marker);
                datasource.Add(text);
            });
        }
    }
}
