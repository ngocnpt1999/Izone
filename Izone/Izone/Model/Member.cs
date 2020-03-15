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
        private ObservableCollection<string> imagesUri = new ObservableCollection<string>();
        private string fullName;
        private string nickName;
        private ObservableCollection<string> listRole = new ObservableCollection<string>();
        private string dateOfBirth;
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
        public ObservableCollection<string> ImagesUri
        {
            get => imagesUri;
            private set
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
        public ObservableCollection<string> ListRole
        {
            get => listRole;
            private set
            {
                listRole = value;
                OnPropertyChanged("ListRole");
            }
        }
        public string DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
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