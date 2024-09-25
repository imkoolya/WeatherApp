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
            var datePickerText = new Label { Text = "Дата запуска", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            var datePicker = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7),
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            datePicker.PropertyChanged += (sender, e) => DateChanged(sender, e, datePicker);
            layout.Children.Add(datePickerText);
            layout.Children.Add(datePicker);

            var timePickerText = new Label { Text = "Время запуска", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(13, 0, 0),
                Style = (Style)App.Current.Resources["ValidInputStyle"]
            };
            timePicker.PropertyChanged += (sender, e) => TimeChanged(sender, e, timePicker);
            layout.Children.Add(timePickerText);
            layout.Children.Add(timePicker);

            Slider volume = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 30,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 300
            };
            var volumeText = new Label { Text = $"Громкость: {volume.Value}", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            volume.ValueChanged += (sender, e) => TempChangedHandler(sender, e, volumeText);
            layout.Children.Add(volumeText);
            layout.Children.Add(volume);
            
            var repeatText = new Label { Text = "Повторять ежедневно", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            Switch repeat = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue,
            };
            layout.Children.Add(repeatText);
            layout.Children.Add(repeat);

            var saveButton = new Button 
            { 
                Text = "Сохранить",
                FontSize = 20, 
                BackgroundColor = Color.Silver, 
                CornerRadius = 20, 
                VerticalOptions = LayoutOptions.Center, 
                HorizontalOptions = LayoutOptions.Center, 
                WidthRequest = 250,

            };
            saveButton.Clicked += (sender, eventArgs) => SaveButtonClicked(sender, eventArgs, new View[]
            {
                datePicker,
                timePicker,
                volume,
                repeat
            });
            saveButton.Clicked += (s, e) => SaveAlarmHandler(s, e, datePicker.Date + timePicker.Time);
            layout.Children.Add(saveButton);
        }

        private void TempChangedHandler(object sender, ValueChangedEventArgs e, Label volumeText)
        {
            volumeText.Text = String.Format("Громкость: {0}", e.NewValue);
        }

        void SaveAlarmHandler(object sender, EventArgs e, DateTime alarmDate)
        {
            var dateHeader = new Label { Text = $"Будильник сработает:", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
            var dateText = new Label { Text = $"{alarmDate.Day}.{alarmDate.Month}.{alarmDate.Year} в {alarmDate.Hour}:{alarmDate.Minute}", FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };

            layout.Children.Add(dateHeader);
            layout.Children.Add(dateText);
        }

        private void DateChanged(object sender, EventArgs e, DatePicker datePicker)
        {
            if (datePicker.Date <= DateTime.Now)
                VisualStateManager.GoToState(datePicker, "Invalid");

            else
                VisualStateManager.GoToState(datePicker, "Valid");
        }

        private void TimeChanged(object sender, EventArgs e, TimePicker timePicker)
        {
            if (timePicker.Time <= DateTime.Now.TimeOfDay)
                VisualStateManager.GoToState(timePicker, "Invalid");

            else
                VisualStateManager.GoToState(timePicker, "Valid");
        }

        private void SaveButtonClicked(object sender, EventArgs e, View[] views)
        {
            foreach (var view in views)
                view.IsEnabled = false;
        }
    }
}