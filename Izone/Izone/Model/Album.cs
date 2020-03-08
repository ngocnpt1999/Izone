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
        private string imageUri;
        private ObservableCollection<Single> singles;

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
            set
            {
                singles = value;
                OnPropertyChanged("Singles");
            }
        }

        public void ShuffleListSingle()
        {
            Random rnd = new Random();
            var randomList = Singles.OrderBy(x => rnd.Next()).ToList();
            Singles.Clear();
            foreach(var item in randomList)
            {
                Singles.Add(item);
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}