using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            Weather();
        }

        private void Weather()
        {
            var upperBox = new BoxView { BackgroundColor = Color.FromRgb(242, 192, 116) };
            var upperHeader = new Label() 
            { 
                Text = $"{Environment.NewLine}Внутри:",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Padding = 20,
                FontSize = 75, 
                TextColor = Color.FromRgb(163, 129, 77) 
            };
            var upperText = new Label() 
            { 
                Text = $"{Environment.NewLine}+ 26 °C", 
                HorizontalTextAlignment = TextAlignment.Center, 
                VerticalTextAlignment = TextAlignment.Center, 
                Padding = 20,
                FontSize = 75, 
                TextColor = Color.FromRgb(163, 129, 77) 
            };
            grid.Children.Add(upperBox, 0, 0);
            grid.Children.Add(upperHeader, 0, 0);
            grid.Children.Add(upperText, 0, 0);

            var middleBox = new BoxView { BackgroundColor = Color.FromRgb(158, 225, 240) };
            var middleHeader = new Label()
            {
                Text = $"{Environment.NewLine}Снаружи:",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Padding = 20,
                FontSize = 75,
                TextColor = Color.FromRgb(88, 124, 133)
            };
            var middleText = new Label()
            {
                Text = $"{Environment.NewLine}- 15 °C",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                Padding = 20,
                FontSize = 75,
                TextColor = Color.FromRgb(88, 124, 133)
            };
            grid.Children.Add(middleBox, 0, 1);
            grid.Children.Add(middleHeader, 0, 1);
            grid.Children.Add(middleText, 0, 1);

            var bottomBox = new BoxView { BackgroundColor = Color.FromRgb(118, 173, 133) };
            var bottomHeader = new Label() 
            { 
                Text = $"{Environment.NewLine}Давление:", 
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                Padding = 20,
                FontSize = 75, 
                TextColor = Color.FromRgb(66, 97, 74) 
            };
            var bottomText = new Label() 
            { 
                Text = $"{Environment.NewLine}760 mm", 
                HorizontalTextAlignment = TextAlignment.Center, 
                VerticalTextAlignment = TextAlignment.Center,
                Padding = 20,
                FontSize = 75, 
                TextColor = Color.FromRgb(66, 97, 74) 
            };
            grid.Children.Add(bottomBox, 0, 2);
            grid.Children.Add(bottomHeader, 0, 2);
            grid.Children.Add(bottomText, 0, 2);
        }
    }
}