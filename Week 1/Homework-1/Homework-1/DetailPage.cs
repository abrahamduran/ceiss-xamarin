using System;

using Xamarin.Forms;

namespace Homework1
{
    public class DetailPage : ContentPage
    {
        public DetailPage(String title, Color backgroundColor)
        {
            Title = "Result";

            var label = new Label
            {
                Text = title,
                TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = Application.Current.MainPage.Width,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var layout = new RelativeLayout
            {
                BackgroundColor = backgroundColor,
                Children = {
                    {
                        label,
                        Constraint.Constant(0),
                        Constraint.RelativeToParent(x => x.Height / 2)
                    }
                }
            };

            Content = layout;
        }
    }
}

