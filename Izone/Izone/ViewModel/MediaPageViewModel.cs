using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace Izone.ViewModel
{
    public class MediaPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string albumName;
        private ObservableCollection<Model.Single> listSingle = new ObservableCollection<Model.Single>();
        private int selectedSingleIndex = -1;
        private Model.Single selectedSingle;

        public ObservableCollection<Model.Single> ListSingle
        {
            get => listSingle;
            private set
            {
                listSingle = value;
                OnPropertyChanged();
            }
        }
        public int SelectedSingleIndex
        {
            get => selectedSingleIndex;
            set
            {
                selectedSingleIndex = value;
                OnPropertyChanged();
            }
        }
        public Model.Single SelectedSingle
        {
            get => selectedSingle;
            set
            {
                selectedSingle = value;
                OnPropertyChanged();
            }
        }

        public MediaPageViewModel(string albumName, int index)
        {
            LoadListSingle(albumName, index);
        }

        public MediaPageViewModel(List<Model.Single> listSingle)
        {
            LoadListSingle(listSingle);
        }

        private async void LoadListSingle(string albumName, int index)
        {
            IsRefreshing = true;
            await Task.Run(() =>
            {
                this.albumName = albumName;
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListSingleByAlbumAsync(this.albumName)).Result;
                ListSingle = new ObservableCollection<Model.Single>(data);
                SelectedSingleIndex = index;
                SelectedSingle = ListSingle[index];
            });
        }

        private async void LoadListSingle(List<Model.Single> listSingle)
        {
            IsRefreshing = true;
            await Task.Run(() =>
            {
                ListSingle = new ObservableCollection<Model.Single>(listSingle);
                SelectedSingleIndex = 0;
                SelectedSingle = ListSingle[0];
            });
        }

        public void NextSingle()
        {
            IsRefreshing = true;
            if (SelectedSingleIndex == ListSingle.Count - 1)
            {
                SelectedSingleIndex = 0;
            }
            else
            {
                SelectedSingleIndex++;
            }
        }

        public void PreviousSingle()
        {
            IsRefreshing = true;
            if (SelectedSingleIndex == 0)
            {
                SelectedSingleIndex = ListSingle.Count - 1;
            }
            else
            {
                SelectedSingleIndex--;
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
                OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}