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
        private int selectedSingleIndex = -1;
        private Model.Single selectedSingle;

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

        public SingleInAlbumViewModel(string albumName)
        {
            this.albumName = albumName;
            LoadListSingle();
            //
            RefreshListCommand = new Command(ExcuteRefreshListCommand);
        }

        public SingleInAlbumViewModel(string albumName, int index)
        {
            this.albumName = albumName;
            SelectedSingleIndex = index;
            LoadListSingle();
            //
            RefreshListCommand = new Command(ExcuteRefreshListCommand);
        }

        private async void LoadListSingle()
        {
            var data = await Helper.FirebaseHelper.Instance.GetSinglesByAlbumAsync(this.albumName);
            foreach(var item in data)
            {
                Singles.Add(item);
                if (item == data[data.Count - 1])
                {
                    int temp = SelectedSingleIndex;
                    SelectedSingleIndex = -1;
                    SelectedSingleIndex = temp;
                }
            }
        }

        public void NextSingle()
        {
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
            LoadListSingle();
            IsRefreshing = false;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}