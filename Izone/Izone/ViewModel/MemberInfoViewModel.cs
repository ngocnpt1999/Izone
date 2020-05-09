using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;

namespace Izone.ViewModel
{
    public class MemberInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int idMember;

        private Model.Member member;

        public Model.Member Member
        {
            get => member;
            set
            {
                member = value;
                OnPropertyChanged();
            }
        }

        public MemberInfoViewModel(int idMember)
        {
            this.idMember = idMember;
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListMemberAsync()).Result;
                Member = data.Where(x => x.ID == idMember).FirstOrDefault();
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
            Load();
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}