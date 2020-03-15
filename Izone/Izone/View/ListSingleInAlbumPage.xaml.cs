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
    public partial class ListSingleInAlbumPage : ContentPage
    {
        public ListSingleInAlbumPage(Model.Album album)
        {
            InitializeComponent();
            BindingContext = album;
            searchSingle.Album = album;
            refreshView.Command = new Command(ExcuteRefreshListSingleCommand);
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