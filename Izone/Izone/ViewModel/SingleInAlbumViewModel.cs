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
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void LoadData()
        {
            var data = await Helper.FirebaseHelper.Instance.GetListSingleByAlbumAsync(this.albumName);
            foreach (var item in data)
            {
                Singles.Add(item);
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
            Singles.Clear();
            LoadData();
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}