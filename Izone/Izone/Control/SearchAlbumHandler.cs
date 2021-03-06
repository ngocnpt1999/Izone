﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Izone.Control
{
    public class SearchAlbumHandler : SearchHandler
    {
        public static readonly BindableProperty ListAlbumProperty =
            BindableProperty.Create(nameof(ListAlbum), typeof(ObservableCollection<Model.Album>), typeof(SearchAlbumHandler));

        public ObservableCollection<Model.Album> ListAlbum
        {
            get => (ObservableCollection<Model.Album>)GetValue(ListAlbumProperty);
            set => SetValue(ListAlbumProperty, value);
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrEmpty(newValue) || string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = ListAlbum.Where(x => x.Name.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            string albumName = ((Model.Album)item).Name;
            await Task.Delay(500);
            await Shell.Current.Navigation.PushAsync(new View.ListSingleInAlbumPage(albumName));
        }
    }
}