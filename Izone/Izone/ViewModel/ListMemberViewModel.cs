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

        public ListMemberViewModel()
        {
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void LoadData()
        {
            var data = await Helper.FirebaseHelper.Instance.GetListMemberAsync();
            foreach (var item in data)
            {
                Members.Add(item);
                if (item == data[data.Count - 1])
                {
                    IsRefreshing = false;
                }
            }
        }

        //
        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public Command RefreshCommand { get; }

        public void ExcuteRefreshCommand()
        {
            Members.Clear();
            LoadData();
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}