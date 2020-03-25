﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace Izone.ViewModel
{
    public class AlbumsManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Model.Album> albums = new ObservableCollection<Model.Album>();

        public ObservableCollection<Model.Album> Albums
        {
            get => albums;
            private set
            {
                albums = value;
                OnPropertyChanged("Albums");
            }
        }

        private AlbumsManagerViewModel()
        {
            CreateListAlbum();
            RefreshListAlbumCommand = new Command(ExcuteRefreshListAlbumCommand);
        }

        private async void CreateListAlbum()
        {
            var helper = new Helper.FirebaseHelper();
            var data = await helper.GetAlbumsAsync();
            foreach(var item in data)
            {
                Albums.Add(item);
            }
        }

        //
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public Command RefreshListAlbumCommand { get; }

        public void ExcuteRefreshListAlbumCommand()
        {
            Albums.Clear();
            CreateListAlbum();
            IsRefreshing = false;
        }

        private static readonly object padlock = new object();
        private static AlbumsManagerViewModel instance = null;

        public static AlbumsManagerViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AlbumsManagerViewModel();
                    }
                    return instance;
                }
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}