using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Izone.ViewModel
{
    public class ListMemberViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Model.Member> members;
        public ObservableCollection<Model.Member> Members
        {
            get => members;
            private set
            {
                members = value;
                OnPropertyChanged("Members");
            }
        }

        public ListMemberViewModel()
        {
            LoadListMember();
            //
            RefreshListCommand = new Command(ExcuteRefreshListCommand);
        }

        private void LoadListMember()
        {
            var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetMembersAsync()).Result;
            Members = new ObservableCollection<Model.Member>(data);
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
            LoadListMember();
            IsRefreshing = false;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}