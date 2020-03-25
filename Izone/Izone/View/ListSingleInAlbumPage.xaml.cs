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

        public ListSingleInAlbumPage(int idAlbum)
        {
            InitializeComponent();
            this.id = idAlbum.ToString();
            BindingContext = ViewModel.SingleManagerViewModel.Instance.GetSinglesByAlbum(idAlbum);
            searchSingle.Singles = BindingContext as List<Model.Single>;
            refreshView.Command = new Command(ExcuteRefreshListSingleCommand);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.id != null)
            {
                BindingContext = ViewModel.SingleManagerViewModel.Instance.GetSinglesByAlbum(int.Parse(this.id));
                searchSingle.Singles = BindingContext as List<Model.Single>;
                refreshView.Command = new Command(ExcuteRefreshListSingleCommand);
            }
        }

        private void ExcuteRefreshListSingleCommand()
        {
            BindingContext = null;
            BindingContext = ViewModel.SingleManagerViewModel.Instance.GetSinglesByAlbum(int.Parse(this.id));
            refreshView.IsRefreshing = false;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var single = ((ListView)sender).SelectedItem as Model.Single;
            if (single != null)
            {
                int index = (BindingContext as List<Model.Single>).IndexOf(single);
                await Navigation.PushAsync(new MediaPage(single.IdAlbum, index));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}