using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Izone.ViewModel
{
    public sealed class MembersManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Model.Member> members = new ObservableCollection<Model.Member>();
        public ObservableCollection<Model.Member> Members
        {
            get => members;
            private set
            {
                members = value;
                OnPropertyChanged("Members");
            }
        }

        private MembersManagerViewModel()
        {
            CreateListMember();
            //
            RefreshListCommand = new Command(ExcuteRefreshListCommand);
        }

        private async void CreateListMember()
        {
            var helper = new Helper.FirebaseHelper();
            var data = await helper.GetMembersAsync();
            foreach(var item in data)
            {
                Members.Add(item);
            }
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
            Members.Clear();
            CreateListMember();
            IsRefreshing = false;
        }

        //
        private static readonly object padlock = new object();
        private static MembersManagerViewModel instance = null;

        public static MembersManagerViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MembersManagerViewModel();
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