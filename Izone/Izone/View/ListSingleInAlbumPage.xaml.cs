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
        public ListSingleInAlbumPage(int id)
        {
            InitializeComponent();
            BindingContext = ViewModel.AlbumsManagerViewModel.Instance.Albums.Where(x => x.ID == id).FirstOrDefault();
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
                await Navigation.PushAsync(new MediaPage(single.Mp3Uri));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}