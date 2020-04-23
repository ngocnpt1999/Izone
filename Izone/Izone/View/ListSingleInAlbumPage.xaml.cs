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
    public partial class ListSingleInAlbumPage : ContentPage
    {
        private ViewModel.ListSingleInAlbumViewModel viewModel;

        public ListSingleInAlbumPage()
        {
            InitializeComponent();
        }

        public ListSingleInAlbumPage(string albumName)
        {
            InitializeComponent();
            viewModel = new ViewModel.ListSingleInAlbumViewModel(albumName);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    searchSingle.SearchBoxVisibility = SearchBoxVisibility.Expanded;
                    break;
                case Device.Android:
                    searchSingle.SearchBoxVisibility = SearchBoxVisibility.Collapsible;
                    break;
            }
            viewModel.IsRefreshing = true;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var single = ((ListView)sender).SelectedItem as Model.Single;
            if (single != null)
            {
                int index = viewModel.ListSingle.IndexOf(single);
                await Navigation.PushAsync(new View.MediaPage(viewModel.ListSingle.ToList(), index));
                ((ListView)sender).SelectedItem = null;
            }
        }

        private async void playIcon_Clicked(object sender, EventArgs e)
        {
            var listCheckedSingle = viewModel.ListSingle.Where(x => x.IsChecked == true).ToList();
            if (listCheckedSingle.Count == 0)
            {
                await Navigation.PushAsync(new MediaPage(viewModel.ListSingle.ToList()));
            }
            else
            {
                await Navigation.PushAsync(new MediaPage(listCheckedSingle));
            }
        }
    }
}