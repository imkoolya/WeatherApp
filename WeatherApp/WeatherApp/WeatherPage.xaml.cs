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
            grid.BackgroundColor = Color.Black;

            var upperBox = new BoxView { BackgroundColor = Color.Bisque };
            var upperHeader = new Label() { Text = $"{Environment.NewLine}Внутри", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start, FontSize = 40, TextColor = Color.Black };
            var upperText = new Label() { Text = $"{Environment.NewLine}+ 26 °C  ", HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, Padding = new Thickness(0, 0, 15, 0), FontSize = 75, TextColor = Color.Black };
            grid.Children.Add(upperBox, 0, 0);
            grid.Children.Add(upperHeader, 0, 0);
            grid.Children.Add(upperText, 0, 0);

            var middleBox = new BoxView { BackgroundColor = Color.LightBlue };
            var middleHeader = new Label() { Text = $"{Environment.NewLine}Снаружи", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Start, FontSize = 40, TextColor = Color.Black };
            var middleText = new Label() { Text = $"{Environment.NewLine}- 15 °C  ", HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, Padding = new Thickness(0, 0, 15, 0), FontSize = 75, TextColor = Color.Black };
            grid.Children.Add(middleBox, 0, 1);
            grid.Children.Add(middleHeader, 0, 1);
            grid.Children.Add(middleText, 0, 1);

            var bottomBox = new BoxView { BackgroundColor = Color.DarkCyan };
            var bottomHeader = new Label() { Text = $"{Environment.NewLine}Давление", HorizontalTextAlignment = TextAlignment.Center, FontSize = 40, TextColor = Color.Black };
            var bottomText = new Label() { Text = $"{Environment.NewLine}760 mm ", HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, Padding = new Thickness(0, 0, 15, 0), FontSize = 75, TextColor = Color.Black };
            grid.Children.Add(bottomBox, 0, 2);
            grid.Children.Add(bottomHeader, 0, 2);
            grid.Children.Add(bottomText, 0, 2);
        }
    }
}