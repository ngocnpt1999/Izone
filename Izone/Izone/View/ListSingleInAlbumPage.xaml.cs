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
    [QueryProperty("ID", "id")]
    public partial class ListSingleInAlbumPage : ContentPage
    {
        private string id;
        public string ID
        {
            get => id;
            set => id = Uri.UnescapeDataString(value);
        }

        public ListSingleInAlbumPage()
        {
            InitializeComponent();
        }

        public ListSingleInAlbumPage(Model.Album album)
        {
            InitializeComponent();
            BindingContext = album;
            searchSingle.Album = album;
            refreshView.Command = new Command(ExcuteRefreshListSingleCommand);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.id != null)
            {
                var album = ViewModel.AlbumsManagerViewModel.Instance.Albums.Where(x => x.ID == int.Parse(this.id)).FirstOrDefault();
                BindingContext = album;
                searchSingle.Album = album;
                refreshView.Command = new Command(ExcuteRefreshListSingleCommand);
            }
        }

        private void ExcuteRefreshListSingleCommand()
        {
            ((Model.Album)BindingContext).ShuffleListSingle();
            refreshView.IsRefreshing = false;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var single = ((ListView)sender).SelectedItem as Model.Single;
            if (single != null)
            {
                Model.Album album = BindingContext as Model.Album;
                int index = album.Singles.IndexOf(single);
                await Navigation.PushAsync(new MediaPage(album, index));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}