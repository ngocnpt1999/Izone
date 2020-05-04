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
        private string mp4Uri;
        private string singleImage;

        private bool isChecked = false;

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
        public string Mp4Uri
        { 
            get => mp4Uri;
            set
            {
                mp4Uri = value;
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

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}