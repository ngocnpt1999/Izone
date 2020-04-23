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

        public MediaPage()
        {
            InitializeComponent();
        }

        public MediaPage(List<Model.Single> listSingle, int index)
        {
            InitializeComponent();
            viewModel = new ViewModel.MediaPageViewModel(listSingle, index);
            BindingContext = viewModel;
        }

        public MediaPage(List<Model.Single> listSingle)
        {
            InitializeComponent();
            viewModel = new ViewModel.MediaPageViewModel(listSingle);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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
            viewModel.IsRefreshing = false;
            StartAnimation();
        }

        private void mediaView_MediaEnded(object sender, EventArgs e)
        {
            viewModel.NextSingle();
            StopAnimation();
        }

        private void mediaView_MediaFailed(object sender, EventArgs e)
        {
            viewModel.IsRefreshing = false;
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

        private void refreshView_Refreshing(object sender, EventArgs e)
        {
            ffimageCD.Rotation = 0;
        }

        private void pickerSingle_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopAnimation();
            viewModel.IsRefreshing = true;
        }
    }
}