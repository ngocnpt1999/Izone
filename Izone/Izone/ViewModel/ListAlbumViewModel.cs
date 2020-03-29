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

        private ObservableCollection<Model.Album> albums;

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

        private void LoadListAlbum()
        {
            var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetAlbumsAsync()).Result;
            Albums = new ObservableCollection<Model.Album>(data);
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