using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "MediaElement_Experimental" });

            ViewModel.MembersManagerViewModel membersManager = ViewModel.MembersManagerViewModel.Instance;
            ViewModel.AlbumsManagerViewModel albumsManager = ViewModel.AlbumsManagerViewModel.Instance;

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
