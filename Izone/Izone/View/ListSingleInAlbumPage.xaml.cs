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
    public partial class ListSingleInAlbumPage : ContentPage
    {
        private string albumName;
        public string AlbumName
        {
            get => albumName;
            set => albumName = Uri.UnescapeDataString(value);
        }

        private ViewModel.SingleInAlbumViewModel viewModel;

        public ListSingleInAlbumPage()
        {
            InitializeComponent();
        }

        public ListSingleInAlbumPage(string albumName)
        {
            InitializeComponent();
            this.albumName = albumName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.albumName != null)
            {
                viewModel = new ViewModel.SingleInAlbumViewModel(this.albumName);
                BindingContext = viewModel;
                searchSingle.AlbumName = viewModel.AlbumName;
                searchSingle.Singles = viewModel.Singles;
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var single = ((ListView)sender).SelectedItem as Model.Single;
            if (single != null)
            {
                int index = viewModel.Singles.IndexOf(single);
                await Navigation.PushAsync(new MediaPage(this.albumName, index));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}