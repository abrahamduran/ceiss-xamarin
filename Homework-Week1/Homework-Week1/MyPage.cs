using System;

using Xamarin.Forms;

namespace HomeworkWeek1
{
    public class MyPage : ContentPage
    {
        Label label;
        Entry entry;

        public MyPage()
        {
            label = new Label();
            entry = new Entry();

            var redButton = GetButton("Red", Color.Red);
            var blueButton = GetButton("Blue", Color.Blue);
            var greenButton = GetButton("Green", Color.Green);

            var buttons = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            buttons.Children.Add(redButton);
            buttons.Children.Add(blueButton);
            buttons.Children.Add(greenButton);

            var layout = new StackLayout()
            {
                Margin = 15,
                VerticalOptions = LayoutOptions.Center
            };
            layout.Children.Add(entry);
            layout.Children.Add(buttons);
            layout.Children.Add(label);

            Content = layout;
        }

        Button GetButton(String text, Color color)
        {
            var button = new Button()
            {
                Text = text,
                TextColor = Color.White,
                BackgroundColor = color,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            button.Clicked += ClickHandler;

            return button;
        }

        void ClickHandler(Object sender, EventArgs e) 
        {
			var title = "unknow color";
			var color = ((Button)sender).BackgroundColor;

            if (color == Color.Red) title = "Red";
            else if (color == Color.Blue) title = "Blue";
            else if (color == Color.Green) title = "Green";

            label.Text = entry.Text;
            label.TextColor = color;

            var detailPage = new DetailPage(title, color);

            Navigation.PushAsync(detailPage);
        }
    }
}