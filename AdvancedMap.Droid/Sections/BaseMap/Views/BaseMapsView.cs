﻿
using System;
using Android.Animation;
using Android.Content;
using Android.Views;
using Android.Widget;
using Carto.Layers;
using Carto.Ui;
using Shared.Droid;

namespace AdvancedMap.Droid
{
	public class BaseMapsView : RelativeLayout
	{
		public MapView MapView { get; set; }

		public MenuButton Button { get; set; }

		public BaseMapSectionMenu Menu { get; set; }

		public BaseMapsView(Context context) : base(context)
		{
			MapView = new MapView(context);

			var baseLayer = new CartoOnlineVectorTileLayer(CartoBaseMapStyle.CartoBasemapStyleDefault);
			MapView.Layers.Add(baseLayer);

			MapView.LayoutParameters = new ViewGroup.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

			AddView(MapView);

			Button = new MenuButton(Resource.Drawable.icon_menu_round, context);
			AddView(Button);

			Menu = new BaseMapSectionMenu(context);
			AddView(Menu);
		}
	}
}

