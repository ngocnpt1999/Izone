﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("AlbumID", "albumid")]
    [QueryProperty("Index", "index")]
    public partial class MediaPage : ContentPage
    {
        private string albumid;
        private string index;
        public string AlbumID
        {
            get => albumid;
            set => albumid = Uri.UnescapeDataString(value);
        }
        public string Index
        {
            get => index;
            set => index = Uri.UnescapeDataString(value);
        }

        public MediaPage()
        {
            InitializeComponent();
        }

        public MediaPage(int idAlbum, int index)
        {
            InitializeComponent();
            BindingContext = ViewModel.SingleManagerViewModel.Instance.GetSinglesByAlbum(idAlbum);
            pickerSingle.SelectedIndex = index;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.albumid != null && this.index != null)
            {
                BindingContext = ViewModel.SingleManagerViewModel.Instance.GetSinglesByAlbum(int.Parse(this.albumid));
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
            var singles = (List<Model.Single>)BindingContext;
            var uri = new Uri(singles[pickerSingle.SelectedIndex].Mp3Uri);
            mediaView.Source = MediaSource.FromUri(uri);
            refreshView.IsRefreshing = true;
        }
    }
}