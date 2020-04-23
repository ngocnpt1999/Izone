using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Izone.ViewModel
{
    public class ListMemberViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Model.Member> listMember = new ObservableCollection<Model.Member>();
        public ObservableCollection<Model.Member> ListMember
        {
            get => listMember;
            private set
            {
                listMember = value;
                OnPropertyChanged();
            }
        }

        public ListMemberViewModel()
        {
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListMemberAsync()).Result;
                ListMember = new ObservableCollection<Model.Member>(data);
                IsRefreshing = false;
            });
        }

        //
        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public Command RefreshCommand { get; }

        public void ExcuteRefreshCommand()
        {
            ListMember.Clear();
            Load();
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}