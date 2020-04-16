using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                OnPropertyChanged();
            }
        }
        public string Name 
        { 
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Mp3Uri 
        { 
            get => mp3Uri;
            set
            {
                mp3Uri = value;
                OnPropertyChanged();
            }
        }
        public string SingleImage
        {
            get => singleImage;
            set
            {
                singleImage = value;
                OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}