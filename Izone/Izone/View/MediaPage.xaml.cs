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
    [QueryProperty("IdAlbum", "idAlbum")]
    [QueryProperty("Index", "index")]
    public partial class MediaPage : ContentPage
    {
        private string idAlbum;
        private string index;
        public string IdAlbum
        {
            get => idAlbum;
            set => idAlbum = Uri.UnescapeDataString(value);
        }
        public string Index
        {
            get => index;
            set => index = Uri.UnescapeDataString(value);
        }

        private ViewModel.SingleInAlbumViewModel viewModel;

        public MediaPage()
        {
            InitializeComponent();
        }

        public MediaPage(int idAlbum, int index)
        {
            InitializeComponent();
            this.idAlbum = idAlbum.ToString();
            this.index = index.ToString();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.idAlbum != null && this.index != null)
            {
                viewModel = new ViewModel.SingleInAlbumViewModel(int.Parse(this.idAlbum));
                BindingContext = viewModel;
                pickerSingle.SelectedIndex = int.Parse(this.index);
            }
        }

        private void mediaView_MediaOpened(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = false;
        }

        private void mediaView_MediaEnded(object sender, EventArgs e)
        {
            if (pickerSingle.SelectedIndex < pickerSingle.ItemsSource.Count - 1)
            {
                pickerSingle.SelectedIndex++;
            }
        }

        private void mediaView_MediaFailed(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = false;
        }

        private void btnPrevious_Clicked(object sender, EventArgs e)
        {
            if (pickerSingle.SelectedIndex > 0)
            {
                pickerSingle.SelectedIndex--;
            }
            else
            {
                pickerSingle.SelectedIndex = pickerSingle.ItemsSource.Count - 1;
            }
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            if (pickerSingle.SelectedIndex < pickerSingle.ItemsSource.Count - 1)
            {
                pickerSingle.SelectedIndex++;
            }
            else
            {
                pickerSingle.SelectedIndex = 0;
            }
        }

        private void pickerSingle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerSingle.SelectedIndex < 0)
            {
                return;
            }
            var singles = (ObservableCollection<Model.Single>)pickerSingle.ItemsSource;
            var uri = new Uri(singles[pickerSingle.SelectedIndex].Mp3Uri);
            mediaView.Source = MediaSource.FromUri(uri);
            refreshView.IsRefreshing = true;
        }
    }
}