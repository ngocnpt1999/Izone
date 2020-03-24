using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace Izone.Model
{
    public class Album : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string name;
        private DateTime releaseDate;
        private string imageUri;
        private ObservableCollection<Single> singles = new ObservableCollection<Single>();

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public DateTime ReleaseDate
        {
            get => releaseDate;
            set
            {
                releaseDate = value;
                OnPropertyChanged("ReleaseDate");
            }
        }
        public string ImageUri
        {
            get => imageUri;
            set
            {
                imageUri = value;
                OnPropertyChanged("ImageUri");
            }
        }
        public ObservableCollection<Single> Singles
        {
            get => singles;
            private set
            {
                singles = value;
                OnPropertyChanged("Singles");
            }
        }

        public void ShuffleListSingle()
        {
            Random rnd = new Random();
            Singles = new ObservableCollection<Single>(Singles.OrderBy(x => rnd.Next()));
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}