using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Izone.ViewModel
{
    public class ListAlbumViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Model.Album> listAlbum = new ObservableCollection<Model.Album>();

        public ObservableCollection<Model.Album> ListAlbum
        {
            get => listAlbum;
            private set
            {
                listAlbum = value;
                OnPropertyChanged();
            }
        }

        public ListAlbumViewModel()
        {
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListAlbumAsync()).Result;
                ListAlbum = new ObservableCollection<Model.Album>(data);
                IsRefreshing = false;
            });
        }

        //
        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public Command RefreshCommand { get; }

        public void ExcuteRefreshCommand()
        {
            ListAlbum.Clear();
            Load();
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}