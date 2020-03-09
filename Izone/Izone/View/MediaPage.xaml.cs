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
        private Model.Album album;
        private int indexOfSingle;

        public MediaPage(Model.Album album, int index)
        {
            InitializeComponent();
            this.album = album;
            indexOfSingle = index;
            BindingContext = this.album.Singles[indexOfSingle];
            refreshView.IsRefreshing = true;
        }

        private void mediaView_MediaOpened(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = false;
        }

        private void mediaView_MediaEnded(object sender, EventArgs e)
        {
            int count = this.album.Singles.Count;
            if (indexOfSingle < count - 1)
            {
                indexOfSingle++;
                BindingContext = this.album.Singles[indexOfSingle];
                refreshView.IsRefreshing = true;
            }
        }

        private void mediaView_MediaFailed(object sender, EventArgs e)
        {
            refreshView.IsRefreshing = false;
        }

        private void btnPrevious_Clicked(object sender, EventArgs e)
        {
            if (indexOfSingle > 0)
            {
                indexOfSingle--;
                BindingContext = this.album.Singles[indexOfSingle];
            }
            else
            {
                indexOfSingle = this.album.Singles.Count - 1;
                BindingContext = this.album.Singles[indexOfSingle];
            }
            refreshView.IsRefreshing = true;
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            int count = this.album.Singles.Count;
            if (indexOfSingle < count - 1)
            {
                indexOfSingle++;
                BindingContext = this.album.Singles[indexOfSingle];
            }
            else
            {
                indexOfSingle = 0;
                BindingContext = this.album.Singles[indexOfSingle];
            }
            refreshView.IsRefreshing = true;
        }
    }
}