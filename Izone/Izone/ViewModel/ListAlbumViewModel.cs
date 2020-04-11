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
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void LoadData()
        {
            var data = await Helper.FirebaseHelper.Instance.GetListAlbumAsync();
            foreach (var item in data)
            {
                Albums.Add(item);
                if (item == data[data.Count - 1])
                {
                    IsRefreshing = false;
                }
            }
        }

        //
        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public Command RefreshCommand { get; }

        public void ExcuteRefreshCommand()
        {
            Albums.Clear();
            LoadData();
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}