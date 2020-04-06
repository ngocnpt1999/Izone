using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Izone.Model
{
    public class Single : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string name;
        private string mp3Uri;
        private string singleImage;

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
        public string Mp3Uri 
        { 
            get => mp3Uri;
            set
            {
                mp3Uri = value;
                OnPropertyChanged("Mp3Uri");
            }
        }
        public string SingleImage
        {
            get => singleImage;
            set
            {
                singleImage = value;
                OnPropertyChanged("SingleImage");
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}