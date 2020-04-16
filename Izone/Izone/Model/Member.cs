using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Izone.Model
{
    public class Member : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string avatar;
        private string[] imagesUri;
        private string fullName;
        private string nickName;
        private string[] listRole;
        private string birthday;
        private string height;
        private string weight;
        private string bloodType;

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Avatar
        {
            get => avatar;
            set
            {
                avatar = value;
                OnPropertyChanged();
            }
        }
        public string[] ImagesUri
        {
            get => imagesUri;
            set
            {
                imagesUri = value;
                OnPropertyChanged();
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged();
            }
        }
        public string NickName
        {
            get => nickName;
            set
            {
                nickName = value;
                OnPropertyChanged();
            }
        }
        public string[] ListRole
        {
            get => listRole;
            set
            {
                listRole = value;
                OnPropertyChanged();
            }
        }
        public string Birthday
        {
            get => birthday;
            set
            {
                birthday = value;
                OnPropertyChanged();
            }
        }
        public string Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged();
            }
        }
        public string Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }
        public string BloodType
        {
            get => bloodType;
            set
            {
                bloodType = value;
                OnPropertyChanged();
            }
        }

        //Get string formatted of ListRole
        public string Role
        {
            get
            {
                return string.Join(", ", ListRole.ToArray());
            }
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}