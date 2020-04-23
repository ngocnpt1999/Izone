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
    public class ListSingleInAlbumViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string albumName;

        private ObservableCollection<Model.Single> listSingle = new ObservableCollection<Model.Single>();

        public ObservableCollection<Model.Single> ListSingle
        {
            get => listSingle;
            private set
            {
                listSingle = value;
                OnPropertyChanged();
            }
        }

        public ListSingleInAlbumViewModel(string albumName)
        {
            this.albumName = albumName;
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListSingleByAlbumAsync(this.albumName)).Result;
                ListSingle = new ObservableCollection<Model.Single>(data);
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
            ListSingle.Clear();
            Load();
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}