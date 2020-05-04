using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone
{
    public partial class App : Application
    {
        public static double frameHeight = (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density) / 2 + 35;

        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "MediaElement_Experimental", "CarouselView_Experimental",
                "IndicatorView_Experimental", "Shell_UWP_Experimental" });

            var helper = Helper.FirebaseHelper.Instance;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
