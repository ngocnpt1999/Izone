using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Izone.ViewModel
{
    public class ListAlbumViewModel : INotifyPropertyChanged
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

        public ListAlbumViewModel()
        {
            LoadListAlbum();
            RefreshListAlbumCommand = new Command(ExcuteRefreshListAlbumCommand);
        }

        private async void LoadListAlbum()
        {
            var data = await Helper.FirebaseHelper.Instance.GetAlbumsAsync();
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
            LoadListAlbum();
            IsRefreshing = false;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}