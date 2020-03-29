using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Izone.ViewModel
{
    public class SingleInAlbumViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int idAlbum;
        private ObservableCollection<Model.Single> singles = new ObservableCollection<Model.Single>();
        public ObservableCollection<Model.Single> Singles
        {
            get => singles;
            private set
            {
                singles = value;
                OnPropertyChanged("Singles");
            }
        }

        public SingleInAlbumViewModel(int idAlbum)
        {
            this.idAlbum = idAlbum;
            LoadListSingle(this.idAlbum);
            //
            RefreshListCommand = new Command(ExcuteRefreshListCommand);
        }

        private async void LoadListSingle(int idAlbum)
        {
            var data = await Helper.FirebaseHelper.Instance.GetSinglesByAlbumAsync(idAlbum);
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
            Singles.Clear();
            LoadListSingle(this.idAlbum);
            IsRefreshing = false;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}