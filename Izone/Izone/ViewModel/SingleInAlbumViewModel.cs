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

        private int idAlbum;
        private ObservableCollection<Model.Single> singles;
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

        private void LoadListSingle(int idAlbum)
        {
            var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetSinglesByAlbumAsync(idAlbum)).Result;
            Singles = new ObservableCollection<Model.Single>(data);
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
            LoadListSingle(this.idAlbum);
            IsRefreshing = false;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}