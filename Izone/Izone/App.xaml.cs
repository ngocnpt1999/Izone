﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "MediaElement_Experimental", "CarouselView_Experimental", "IndicatorView_Experimental" });

            ViewModel.MembersManagerViewModel membersManager = ViewModel.MembersManagerViewModel.Instance;
            ViewModel.AlbumsManagerViewModel albumsManager = ViewModel.AlbumsManagerViewModel.Instance;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            Routing.RegisterRoute("memberprofile", typeof(View.ShowMemberInfoPage));
            Routing.RegisterRoute("media", typeof(View.MediaPage));
            Routing.RegisterRoute("listsingle", typeof(View.ListSingleInAlbumPage));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
