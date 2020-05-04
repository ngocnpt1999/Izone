using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace Izone.ViewModel
{
    public class GroupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string[] image;
        private ObservableCollection<Model.Member> listMember = new ObservableCollection<Model.Member>();
        private ObservableCollection<Model.Album> listAlbum = new ObservableCollection<Model.Album>();

        public string[] Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Model.Member> ListMember
        {
            get => listMember;
            set
            {
                listMember = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Model.Album> ListAlbum
        {
            get => listAlbum;
            set
            {
                listAlbum = value;
                OnPropertyChanged();
            }
        }

        public GroupViewModel()
        {
            RefreshCommand = new Command(ExcuteRefreshCommand);
        }

        private async void Load()
        {
            Image = new string[]
            {
                "izone_ver3_2200x1500.jpg",
                "izone_ver2_2400x1600.jpg",
                "izone_ver3_2400x1800.jpg"
            };
            await Task.Run(() =>
            {
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListMemberAsync()).Result.ToList().GetRange(0, 4);
                data.Add(new Model.Member() { Avatar = "icons8_plus_512.png" });
                ListMember = new ObservableCollection<Model.Member>(data);
            });
            await Task.Run(() =>
            {
                var data = Task.Run(async () => await Helper.FirebaseHelper.Instance.GetListAlbumAsync()).Result.ToList().GetRange(0, 4);
                data.Add(new Model.Album() { ImageUri = "icons8_plus_512.png" });
                ListAlbum = new ObservableCollection<Model.Album>(data);
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
            ListAlbum.Clear();
            Load();
            IsRefreshing = false;
        }

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}