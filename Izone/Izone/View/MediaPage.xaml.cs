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
    [QueryProperty("AlbumName", "albumName")]
    [QueryProperty("Index", "index")]
    public partial class MediaPage : ContentPage
    {
        private string albumName;
        private string index;
        public string AlbumName
        {
            get => albumName;
            set => albumName = Uri.UnescapeDataString(value);
        }
        public string Index
        {
            get => index;
            set => index = Uri.UnescapeDataString(value);
        }

        private ViewModel.SingleInAlbumViewModel viewModel;

        private bool cancelToken = false;

        public MediaPage()
        {
            InitializeComponent();
        }

        public MediaPage(string albumName, int index)
        {
            InitializeComponent();
            this.albumName = albumName;
            this.index = index.ToString();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.albumName != null && this.index != null)
            {
                viewModel = new ViewModel.SingleInAlbumViewModel(this.albumName, int.Parse(this.index));
                BindingContext = viewModel;
            }
        }

        private async void StartAnimation()
        {
            cancelToken = false;
            while (!cancelToken)
            {
                await ffimageCD.RotateTo(360, 10000);
                await ffimageCD.RotateTo(0, 0);
            }
        }

        private void StopAnimation()
        {
            cancelToken = true;
            ViewExtensions.CancelAnimations(ffimageCD);
        }

        private void mediaView_MediaOpened(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = false;
            StartAnimation();
        }

        private void mediaView_MediaEnded(object sender, EventArgs e)
        {
            viewModel.NextSingle();
            StopAnimation();
        }

        private void mediaView_MediaFailed(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = false;
        }

        private void btnPrevious_Clicked(object sender, EventArgs e)
        {
            StopAnimation();
            viewModel.PreviousSingle();
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            StopAnimation();
            viewModel.NextSingle();
        }

        private void pickerSingle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerSingle.SelectedIndex < 0)
            {
                return;
            }
            refreshView.IsRefreshing = true;
        }

        private void refreshView_Refreshing(object sender, EventArgs e)
        {
            ffimageCD.Rotation = 0;
        }
    }
}