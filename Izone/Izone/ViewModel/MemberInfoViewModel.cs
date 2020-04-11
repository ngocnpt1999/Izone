using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Izone.ViewModel
{
    public class MemberInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private Model.Member member;

        public Model.Member Member
        {
            get => member;
            set
            {
                member = value;
                OnPropertyChanged("Member");
            }
        }

        public MemberInfoViewModel(int id)
        {
            this.id = id;
            member = Task.Run(async () => (await Helper.FirebaseHelper.Instance.GetListMemberAsync()).Find(x => x.ID == this.id)).Result;
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}