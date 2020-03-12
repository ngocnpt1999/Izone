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
    public partial class MediaPage : ContentPage
    {
        public MediaPage(Model.Album album, int index)
        {
            InitializeComponent();
            BindingContext = album;
            pickerSingle.SelectedIndex = index;
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
            var album = (Model.Album)BindingContext;
            var uri = new Uri(album.Singles[pickerSingle.SelectedIndex].Mp3Uri);
            mediaView.Source = MediaSource.FromUri(uri);
            refreshView.IsRefreshing = true;
        }
    }
}