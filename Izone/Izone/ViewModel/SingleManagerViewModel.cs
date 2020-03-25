using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Izone.ViewModel
{
    public sealed class SingleManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private SingleManagerViewModel()
        {
            CreateListSingle();
            //
            RefreshListCommand = new Command(ExcuteRefreshListCommand);
        }

        private async void CreateListSingle()
        {
            var helper = new Helper.FirebaseHelper();
            var data = await helper.GetSinglesAsync();
            foreach(var item in data)
            {
                Singles.Add(item);
            }
        }

        public List<Model.Single> GetSinglesByAlbum(int idAlbum)
        {
            return Singles.Where(x => x.IdAlbum == idAlbum).OrderBy(x => x.ID).ToList();
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
            CreateListSingle();
            IsRefreshing = false;
        }

        //
        private static readonly object padlock = new object();
        private static SingleManagerViewModel instance = null;

        public static SingleManagerViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingleManagerViewModel();
                    }
                    return instance;
                }
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}