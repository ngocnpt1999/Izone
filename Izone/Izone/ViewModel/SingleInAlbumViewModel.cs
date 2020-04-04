using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Izone.ViewModel
{
    public class SingleInAlbumViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string albumName;
        private ObservableCollection<Model.Single> singles = new ObservableCollection<Model.Single>();

        public string AlbumName
        {
            get => albumName;
            private set
            {
                albumName = value;
                OnPropertyChanged("AlbumName");
            }
        }
        public ObservableCollection<Model.Single> Singles
        {
            get => singles;
            private set
            {
                singles = value;
                OnPropertyChanged("Singles");
            }
        }

        public SingleInAlbumViewModel(string albumName)
        {
            this.albumName = albumName;
            LoadListSingle(this.albumName);
            //
            RefreshListCommand = new Command(ExcuteRefreshListCommand);
        }

        private void LoadListSingle(string albumName)
        {
            var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetSinglesByAlbumAsync(albumName)).Result;
            foreach(var item in data)
            {
                Singles.Add(item);
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

        public Command RefreshListCommand { get; }

        public void ExcuteRefreshListCommand()
        {
            LoadListSingle(this.albumName);
            IsRefreshing = false;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}