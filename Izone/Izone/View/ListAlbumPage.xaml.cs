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
        public ListAlbumPage()
        {
            InitializeComponent();
            BindingContext = ViewModel.AlbumsManagerViewModel.Instance;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var album = ((CollectionView)sender).SelectedItem as Model.Album;
            if (album != null)
            {
                await Navigation.PushAsync(new ListSingleInAlbumPage(album.ID));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}