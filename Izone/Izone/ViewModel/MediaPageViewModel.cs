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

        public MediaPageViewModel(List<Model.Single> listSingle, int index = 0)
        {
            Load(listSingle, index);
        }

        private async void Load(List<Model.Single> listSingle, int index = 0)
        {
            IsRefreshing = true;
            await Task.Run(() =>
            {
                ListSingle = new ObservableCollection<Model.Single>(listSingle);
                SelectedSingleIndex = index;
                SelectedSingle = ListSingle[index];
                MediaManager.CrossMediaManager.Current.Play(SelectedSingle.Mp4Uri);
            });
        }

        public async void PlayNextSingle()
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
            await MediaManager.CrossMediaManager.Current.Play(SelectedSingle.Mp4Uri);
        }

        public async void PlayPreviousSingle()
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
            await MediaManager.CrossMediaManager.Current.Play(SelectedSingle.Mp4Uri);
        }

        public async void PlaySelectedSingle()
        {
            IsRefreshing = true;
            await MediaManager.CrossMediaManager.Current.Play(SelectedSingle.Mp4Uri);
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