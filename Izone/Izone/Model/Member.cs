using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.ComponentModel;

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
                OnPropertyChanged("ID");
            }
        }
        public string Avatar
        {
            get => avatar;
            set
            {
                avatar = value;
                OnPropertyChanged("Avatar");
            }
        }
        public string[] ImagesUri
        {
            get => imagesUri;
            set
            {
                imagesUri = value;
                OnPropertyChanged("ImagesUri");
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string NickName
        {
            get => nickName;
            set
            {
                nickName = value;
                OnPropertyChanged("NickName");
            }
        }
        public string[] ListRole
        {
            get => listRole;
            set
            {
                listRole = value;
                OnPropertyChanged("ListRole");
            }
        }
        public string Birthday
        {
            get => birthday;
            set
            {
                birthday = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public string Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }
        public string Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged("Weight");
            }
        }
        public string BloodType
        {
            get => bloodType;
            set
            {
                bloodType = value;
                OnPropertyChanged("BloodType");
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

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}