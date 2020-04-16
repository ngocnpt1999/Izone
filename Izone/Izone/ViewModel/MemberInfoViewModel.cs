using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

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
                OnPropertyChanged();
            }
        }

        public MemberInfoViewModel(int id)
        {
            this.id = id;
            member = Task.Run(async () => (await Helper.FirebaseHelper.Instance.GetListMemberAsync()).Where(x => x.ID == this.id).FirstOrDefault()).Result;
        }

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}