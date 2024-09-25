using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmPage : ContentPage
    {
        public AlarmPage()
        {
            InitializeComponent();
            GetContent();
        }

        public void GetContent()
        {
            var datePickerText = new Label { Text = "Дата запуска", Margin = new Thickness(0, 20, 0, 10), HorizontalOptions = LayoutOptions.Center };
            var datePicker = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7),
            };
            layout.Children.Add(datePickerText);
            layout.Children.Add(datePicker);

            var timePickerText = new Label { Text = "Время запуска", Margin = new Thickness(0, 20, 0, 10), HorizontalOptions = LayoutOptions.Center };
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(13, 0, 0)
            };
            layout.Children.Add(timePickerText);
            layout.Children.Add(timePicker);

            Slider volume = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30.0,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray,
            };
            var volumeText = new Label { Text = $"Громкость: {volume.Value}", Margin = new Thickness(0, 20, 0, 10), HorizontalOptions = LayoutOptions.Center };
            volume.ValueChanged += (sender, e) => TempChangedHandler(sender, e, volumeText);
            layout.Children.Add(volumeText);
            layout.Children.Add(volume);

            var repeatText = new Label { Text = "Повторять ежедневно", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 5, 0, 0) };
            Switch repeat = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue,

            };
            layout.Children.Add(repeatText);
            layout.Children.Add(repeat);

            layout.Children.Add(new Button { Text = "Сохранить", BackgroundColor = Color.Silver, CornerRadius = 15 });
        }

        private void TempChangedHandler(object sender, ValueChangedEventArgs e, Label volumeText)
        {
            volumeText.Text = String.Format("Громкость: {0:F1}", e.NewValue);
        }
    }
}