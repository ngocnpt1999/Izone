using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Izone.Helper
{
    public class Option : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Option Current = new Option();

        private bool mp4Mode = false;

        public bool Mp4Mode
        {
            get => mp4Mode;
            set
            {
                mp4Mode = value;
                OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}