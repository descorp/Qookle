﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using QookleApp;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Droid.Controls.CircleImage;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(RoundedImage), typeof(CircleImageRenderer))]
namespace Xamarin.Forms.Labs.Droid.Controls.CircleImage
{
	public class CircleImageRenderer : ImageRenderer
	{
        public CircleImageRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);

                if (Control != null && Control.Clip == null)
                {
                    var min = Math.Min(Element.Width, Element.Height)/2.0f;

                    if (min <= 0)
                        return;

                    Control.Clip = new EllipseGeometry
                    {
                        Center = new System.Windows.Point(min, min),
                        RadiusX = min,
                        RadiusY = min
                    };
                }
            }
            catch (Exception)
            {}
        }
    }
}


