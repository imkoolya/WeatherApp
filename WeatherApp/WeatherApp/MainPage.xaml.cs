using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void GetWeather(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherPage());
        }
        async void SetAlarm(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlarmPage());
        }
    }
}
