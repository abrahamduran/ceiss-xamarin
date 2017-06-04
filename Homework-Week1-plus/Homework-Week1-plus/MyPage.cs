using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HomeworkWeek1plus
{
    public class MyPage : ContentPage
    {
        StackLayout _layout;
        Label label;
        Entry textEntry;
        Picker sizePicker;

        Dictionary<string, double> sizes = new Dictionary<string, double>
        {
            { "Small", 18 }, { "Medium", 24 }, { "Big", 32 }
        };

        public MyPage()
        {

            sizePicker = new Picker
            {
                Title = "Size",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string size in sizes.Keys)
            {
                sizePicker.Items.Add(size);
            }
            sizePicker.SelectedIndex = 0;

            label = new Label
            {
                FormattedText = new FormattedString()
            };

            var textLabel = new Label
            {
                Text = "Text",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            textEntry = new Entry { Margin = 3 };

            var sizeLabel = new Label
            {
                Text = "Size",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
                     
            var entries = new RelativeLayout
            {
                Margin = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            entries.Children.Add(
                textLabel,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(p => p.Width * 0.25),
                Constraint.Constant(35)
            );
            entries.Children.Add(
                textEntry,
                Constraint.RelativeToView(textLabel, (p, s) => s.Width),
                Constraint.Constant(0),
                Constraint.RelativeToParent(p => p.Width * 0.75),
                Constraint.Constant(35)
            );
            entries.Children.Add(
                sizeLabel,
                Constraint.RelativeToView(textLabel, (p, s) => s.X),
                Constraint.RelativeToView(textLabel, (p, s) => s.Height * 1.7),
                Constraint.RelativeToView(textLabel, (p, s) => s.Width),
                Constraint.RelativeToView(textLabel, (p, s) => s.Height)
            );
            entries.Children.Add(
                sizePicker,
                Constraint.RelativeToView(sizeLabel, (p, s) => s.Width),
                Constraint.RelativeToView(sizeLabel, (p, s) => s.Y),
                Constraint.RelativeToParent(p => p.Width * 0.75),
                Constraint.Constant(35)
            );

            var redButton = GetButton("Red", Color.Red);
            var blueButton = GetButton("Blue", Color.Blue);
            var greenButton = GetButton("Green", Color.Green);

            var buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            buttons.Children.Add(redButton);
            buttons.Children.Add(blueButton);
            buttons.Children.Add(greenButton);

            _layout = new StackLayout
            {
                Margin = 15,
                VerticalOptions = LayoutOptions.Start
            };
			_layout.Children.Add(entries);
            _layout.Children.Add(buttons);
            _layout.Children.Add(label);

            Content = _layout;
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
            var color = ((Button)sender).BackgroundColor;
            var key = (String)sizePicker.SelectedItem;
            var size = sizes[key];
            var span = new Span
            {
                Text = textEntry.Text,
                ForegroundColor = color,
                FontSize = size
            };
            label.FormattedText.Spans.Add(span);
        }
    }
}

