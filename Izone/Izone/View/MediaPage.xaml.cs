using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPage : ContentPage
    {
        private ViewModel.MediaPageViewModel viewModel;

        private bool cancelToken = false;

        private bool isRunning = true;

        public MediaPage()
        {
            InitializeComponent();
        }

        public MediaPage(List<Model.Single> listSingle, int index = 0)
        {
            InitializeComponent();
            viewModel = new ViewModel.MediaPageViewModel(listSingle, index);
            BindingContext = viewModel;
            MediaManager.CrossMediaManager.Current.StateChanged += Current_StateChanged;
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            isRunning = false;
            await MediaManager.CrossMediaManager.Current.Stop();
        }

        private async void Current_StateChanged(object sender, MediaManager.Playback.StateChangedEventArgs e)
        {
            switch (e.State)
            {
                case MediaManager.Player.MediaPlayerState.Playing:
                    StartAnimation();
                    viewModel.IsRefreshing = false;
                    break;
                case MediaManager.Player.MediaPlayerState.Stopped:
                    if (viewModel.IsRefreshing == false && isRunning)
                    {
                        StopAnimation();
                        await MediaManager.CrossMediaManager.Current.Pause();
                        viewModel.PlayNextSingle();
                    }
                    break;
            }
        }

        private async void StartAnimation()
        {
            cancelToken = false;
            while (!cancelToken)
            {
                await ffimageCD.RotateTo(360, 15000);
                await ffimageCD.RotateTo(0, 0);
            }
        }

        private void StopAnimation()
        {
            cancelToken = true;
            ViewExtensions.CancelAnimations(ffimageCD);
        }

        private async void btnPrevious_Clicked(object sender, EventArgs e)
        {
            if (viewModel.IsRefreshing)
            {
                return;
            }

            StopAnimation();
            await MediaManager.CrossMediaManager.Current.Pause();
            viewModel.PlayPreviousSingle();
        }

        private async void btnNext_Clicked(object sender, EventArgs e)
        {
            if (viewModel.IsRefreshing)
            {
                return;
            }

            StopAnimation();
            await MediaManager.CrossMediaManager.Current.Pause();
            viewModel.PlayNextSingle();
        }

        private void refreshView_Refreshing(object sender, EventArgs e)
        {
            ffimageCD.Rotation = 0;
        }

        private async void pickerSingle_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopAnimation();
            await MediaManager.CrossMediaManager.Current.Pause();
            viewModel.PlaySelectedSingle();
        }
    }
}