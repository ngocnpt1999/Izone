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
    [QueryProperty("ID", "id")]
    public partial class ListSingleInAlbumPage : ContentPage
    {
        private string id;
        public string ID
        {
            get => id;
            set => id = Uri.UnescapeDataString(value);
        }

        private ViewModel.SingleInAlbumViewModel viewModel;

        public ListSingleInAlbumPage()
        {
            InitializeComponent();
        }

        public ListSingleInAlbumPage(int idAlbum)
        {
            InitializeComponent();
            this.id = idAlbum.ToString();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.id != null)
            {
                viewModel = new ViewModel.SingleInAlbumViewModel(int.Parse(this.id));
                BindingContext = viewModel;
                searchSingle.Singles = viewModel.Singles;
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var single = ((ListView)sender).SelectedItem as Model.Single;
            if (single != null)
            {
                int index = (((ListView)sender).ItemsSource as ObservableCollection<Model.Single>).IndexOf(single);
                await Navigation.PushAsync(new MediaPage(single.IdAlbum, index));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}