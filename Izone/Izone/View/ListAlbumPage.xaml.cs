using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAlbumPage : ContentPage
    {
        private ViewModel.ListAlbumViewModel viewModel;

        public ListAlbumPage()
        {
            InitializeComponent();
            viewModel = new ViewModel.ListAlbumViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    searchAlbum.SearchBoxVisibility = SearchBoxVisibility.Expanded;
                    break;
                case Device.Android:
                    searchAlbum.SearchBoxVisibility = SearchBoxVisibility.Collapsible;
                    break;
            }
            viewModel.IsRefreshing = true;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var album = ((CollectionView)sender).SelectedItem as Model.Album;
            if (album != null)
            {
                await Navigation.PushAsync(new ListSingleInAlbumPage(album.Name));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}