using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Izone.ViewModel
{
    public class MediaPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string albumName;
        private ObservableCollection<Model.Single> singles = new ObservableCollection<Model.Single>();
        private int selectedSingleIndex = -1;
        private Model.Single selectedSingle;

        public ObservableCollection<Model.Single> Singles
        {
            get => singles;
            private set
            {
                singles = value;
                OnPropertyChanged("Singles");
            }
        }
        public int SelectedSingleIndex
        {
            get => selectedSingleIndex;
            set
            {
                selectedSingleIndex = value;
                OnPropertyChanged("SelectedSingleIndex");
            }
        }
        public Model.Single SelectedSingle
        {
            get => selectedSingle;
            set
            {
                selectedSingle = value;
                OnPropertyChanged("SelectedSingle");
            }
        }

        public MediaPageViewModel(string albumName, int index)
        {
            this.albumName = albumName;
            LoadListSingle(index);
        }

        private async void LoadListSingle(int index)
        {
            IsRefreshing = true;
            await Task.Run(() =>
            {
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListSingleByAlbumAsync(this.albumName)).Result;
                Singles = new ObservableCollection<Model.Single>(data);
                SelectedSingleIndex = index;
            });
        }

        public void NextSingle()
        {
            IsRefreshing = true;
            if (SelectedSingleIndex == Singles.Count - 1)
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
                SelectedSingleIndex = Singles.Count - 1;
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
                OnPropertyChanged("IsRefreshing");
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}