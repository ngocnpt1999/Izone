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

        private void CreateListMember()
        {
            //
            Model.Member member_1 = new Model.Member()
            {
                ID = 1,
                Avatar = "https://drive.google.com/uc?export=download&id=1KF4N4N1rb0v7s71UtEdjxgLcZKMjn0P0",
                FullName = "Kwon Eunbi",
                NickName = "Eunbi",
                DateOfBirth = "27/09/1995",
                Height = "1m6",
                Weight = "46kg",
                BloodType = "A"
            };
            member_1.ImagesUri.Add(@"https://drive.google.com/uc?export=download&id=17U5N1K6_s8HM8mXA7DdyLDgXnSqQxBJu");
            member_1.ImagesUri.Add(@"https://i.pinimg.com/564x/30/b8/d2/30b8d217c3c379cf24fb902403fce3a4.jpg");
            member_1.ImagesUri.Add(@"https://drive.google.com/uc?export=download&id=19Rvk9Je_bWAJtbjBx8V_1i2b54SAvpCT");
            member_1.ListRole.Add("Nhóm trưởng");
            member_1.ListRole.Add("Nhảy(Dẫn)");
            member_1.ListRole.Add("Vocal(Dẫn)");
            //
            Model.Member member_2 = new Model.Member()
            {
                ID = 2,
                Avatar = "https://drive.google.com/uc?export=download&id=1D6V2znjWlKoGtSzw46YtinPJrWyh2dwR",
                FullName = "Miyawaki Sakura",
                NickName = "Sakura",
                DateOfBirth = "19/03/1998",
                Height = "1m63",
                Weight = "46kg",
                BloodType = "A"
            };
            member_2.ImagesUri.Add(@"https://i.pinimg.com/564x/85/bc/f1/85bcf1aa36c4a39539b42c896ba2fe8f.jpg");
            member_2.ImagesUri.Add(@"https://drive.google.com/uc?export=download&id=1GtVkBGJgXErU3F-CV9nchzh-vgq5e13G");
            member_2.ImagesUri.Add(@"https://drive.google.com/uc?export=download&id=1xUvWeOBtb7JuuVXfX5XYiDRqQpT9mx7x");
            member_2.ListRole.Add("Visual");
            member_2.ListRole.Add("Vocal");
            //
            Model.Member member_3 = new Model.Member()
            {
                ID = 3,
                Avatar = "https://drive.google.com/uc?export=download&id=1gKblrHC1L7UbmW3_Wjg8N2sjEpmxvrYV",
                FullName = "Kang Hyewon",
                NickName = "Hyewon",
                DateOfBirth = "05/07/1999",
                Height = "1m63",
                Weight = "43kg",
                BloodType = "B"
            };
            member_3.ImagesUri.Add(@"https://i.pinimg.com/564x/93/96/e6/9396e66714226a544e68c3304b3deda4.jpg");
            member_3.ImagesUri.Add(@"https://i.pinimg.com/564x/a7/77/7d/a7777d543aba34aad0757322e5db23d3.jpg");
            member_3.ImagesUri.Add(@"https://i.pinimg.com/564x/ce/1d/a8/ce1da81f19cfbaa1f2fa99c1dd559cd8.jpg");
            member_3.ListRole.Add("Rap(Dẫn)");
            member_3.ListRole.Add("Visual");
            member_3.ListRole.Add("Vocal");
            //
            Model.Member member_4 = new Model.Member()
            {
                ID = 4,
                Avatar = "https://drive.google.com/uc?export=download&id=1n3UgTVEGSNxKc_tTuz7oue3rRxBQG3QJ",
                FullName = "Choi Yena",
                NickName = "Yena",
                DateOfBirth = "29/09/1999",
                Height = "1m63",
                Weight = "45kg",
                BloodType = "A"
            };
            member_4.ImagesUri.Add(@"https://i.pinimg.com/564x/2a/c4/02/2ac402632c1170b4d715c5ccce8f8ed4.jpg");
            member_4.ImagesUri.Add(@"https://i.pinimg.com/564x/0c/a0/9c/0ca09c34c360dffd8a238ffa9e180a43.jpg");
            member_4.ImagesUri.Add(@"https://i.pinimg.com/564x/8a/92/d4/8a92d4523d2c7280ee1b48b3a3aed177.jpg");
            member_4.ListRole.Add("Nhảy(Dẫn)");
            member_4.ListRole.Add("Rap chính");
            member_4.ListRole.Add("Vocal(Dẫn)");
            //
            Model.Member member_5 = new Model.Member()
            {
                ID = 5,
                Avatar = "https://drive.google.com/uc?export=download&id=1-2Y9vDrO0rIqJqpQUeq62YNfgDqdTZD6",
                FullName = "Lee Chaeyeon",
                NickName = "Chaeyeon",
                DateOfBirth = "11/01/2000",
                Height = "1m64",
                Weight = "47kg",
                BloodType = "A"
            };
            member_5.ImagesUri.Add(@"https://i.pinimg.com/564x/ba/3f/17/ba3f17ab5fc6f62e7221c424ef9b04f5.jpg");
            member_5.ImagesUri.Add(@"https://i.pinimg.com/564x/3b/c1/78/3bc17809b91d0385edd1bfc06cc70aaa.jpg");
            member_5.ImagesUri.Add(@"https://i.pinimg.com/564x/4c/50/2f/4c502fbf8fc8c4f950ef080b5ee01306.jpg");
            member_5.ListRole.Add("Vocal(Hỗ trợ)");
            member_5.ListRole.Add("Nhảy chính");
            //
            Model.Member member_6 = new Model.Member()
            {
                ID = 6,
                Avatar = "https://drive.google.com/uc?export=download&id=15B22TBFTjIpWFLjAyQpPTZsWM5P8yuVu",
                FullName = "Kim Chaewon",
                NickName = "Chaewon",
                DateOfBirth = "01/08/2000",
                Height = "1m63",
                Weight = "42kg",
                BloodType = "B"
            };
            member_6.ImagesUri.Add(@"https://i.pinimg.com/564x/86/9d/2d/869d2dcd0c626a93fd35355faa6afc47.jpg");
            member_6.ImagesUri.Add(@"https://i.pinimg.com/564x/9b/29/17/9b29172b4ad67942d124670beb86873f.jpg");
            member_6.ImagesUri.Add(@"https://i.pinimg.com/564x/83/52/82/8352829073dd4e6dee7a6ac62e25cd9d.jpg");
            member_6.ListRole.Add("Vocal(Dẫn)");
            member_6.ListRole.Add("Nhảy(Dẫn)");
            //
            Model.Member member_7 = new Model.Member()
            {
                ID = 7,
                Avatar = "https://drive.google.com/uc?export=download&id=17JN6pzH6tUPGmYJdfjXMZLQKRWdniE93",
                FullName = "Kim Minjoo",
                NickName = "Minjoo",
                DateOfBirth = "05/02/2001",
                Height = "1m65",
                Weight = "45kg",
                BloodType = "AB"
            };
            member_7.ImagesUri.Add(@"https://i.pinimg.com/564x/93/b9/6c/93b96c5cb51dfdfbfa62468879255b05.jpg");
            member_7.ImagesUri.Add(@"https://i.pinimg.com/564x/f4/41/36/f441364dc71a21335dc4bf82bce0e5a8.jpg");
            member_7.ImagesUri.Add(@"https://i.pinimg.com/564x/49/1a/e4/491ae4bf129d0e587150429359c44993.jpg");
            member_7.ListRole.Add("Vocal");
            member_7.ListRole.Add("Visual");
            //
            Model.Member member_8 = new Model.Member()
            {
                ID = 8,
                Avatar = "https://drive.google.com/uc?export=download&id=1G55K1nZx_oc5818SWI3Fw2CkO6cs24Bb",
                FullName = "Yabuki Nako",
                NickName = "Nako",
                DateOfBirth = "18/06/2001",
                Height = "1m49",
                Weight = "40kg",
                BloodType = "..."
            };
            member_8.ImagesUri.Add(@"https://i.pinimg.com/564x/b2/45/61/b245618db776fb5bdfedf9d74d1e3d15.jpg");
            member_8.ImagesUri.Add(@"https://i.pinimg.com/564x/8e/d4/6d/8ed46d06df36e824825a9aa9f4a7eda0.jpg");
            member_8.ImagesUri.Add(@"https://i.pinimg.com/564x/2e/d1/96/2ed196e9af949b0f5430d7c588d2c004.jpg");
            member_8.ListRole.Add("Vocal");
            //
            Model.Member member_9 = new Model.Member()
            {
                ID = 9,
                Avatar = "https://drive.google.com/uc?export=download&id=1jZhNXChhwtF6M1FmqBJ_-zb2Y2cBMHOz",
                FullName = "Honda Hitomi",
                NickName = "Hitomi",
                DateOfBirth = "06/10/2001",
                Height = "1m58",
                Weight = "44kg",
                BloodType = "A"
            };
            member_9.ImagesUri.Add(@"https://i.pinimg.com/564x/b8/bd/70/b8bd70250dd56e2682e41bf81832e91a.jpg");
            member_9.ImagesUri.Add(@"https://i.pinimg.com/564x/7c/16/91/7c1691dddf0d89391a07166d75bf945c.jpg");
            member_9.ImagesUri.Add(@"https://i.pinimg.com/564x/23/1e/87/231e87d0f796b2d6e6330d2c1c0d24d3.jpg");
            member_9.ListRole.Add("Nhảy(Dẫn)");
            member_9.ListRole.Add("Vocal");
            member_9.ListRole.Add("Rap");
            //
            Model.Member member_10 = new Model.Member()
            {
                ID = 10,
                Avatar = "https://drive.google.com/uc?export=download&id=1ozVWhV9wNEt6d3gEGl8QKWqDjSiKt5fc",
                FullName = "Jo Yuri",
                NickName = "Yuri",
                DateOfBirth = "22/10/2001",
                Height = "1m6",
                Weight = "45kg",
                BloodType = "AB"
            };
            member_10.ImagesUri.Add(@"https://i.pinimg.com/564x/fb/12/aa/fb12aad2145cf0e24444f6f4b80271fe.jpg");
            member_10.ImagesUri.Add(@"https://i.pinimg.com/564x/0a/88/65/0a886571251e5c9cd48d24ba38d2e37d.jpg");
            member_10.ImagesUri.Add(@"https://i.pinimg.com/564x/5c/ed/51/5ced51ebe2affd6080a7dd592ad36537.jpg");
            member_10.ListRole.Add("Giọng ca chính");
            //
            Model.Member member_11 = new Model.Member()
            {
                ID = 11,
                Avatar = "https://drive.google.com/uc?export=download&id=1wgXMV0nWD4m_zCbzFXSX8eWehllzzxD1",
                FullName = "Ahn Yujin",
                NickName = "Yujin",
                DateOfBirth = "01/09/2003",
                Height = "1m68",
                Weight = "48kg",
                BloodType = "A"
            };
            member_11.ImagesUri.Add(@"https://i.pinimg.com/564x/41/c0/cc/41c0cc9eaf6b1bdb0c26b521ed7d592e.jpg");
            member_11.ImagesUri.Add(@"https://i.pinimg.com/564x/e2/31/1c/e2311c72499c5e236e3bb1bbfb5e56a7.jpg");
            member_11.ImagesUri.Add(@"https://i.pinimg.com/564x/d0/aa/7f/d0aa7f39e46e299629140fe6692f02a8.jpg");
            member_11.ListRole.Add("Nhảy(Dẫn)");
            member_11.ListRole.Add("Vocal(Hỗ trợ)");
            //
            Model.Member member_12 = new Model.Member()
            {
                ID = 12,
                Avatar = "https://drive.google.com/uc?export=download&id=1u39RM0_Maps4pV76QUiV7B1HNWzbXkj5",
                FullName = "Jang Wonyoung",
                NickName = "Wonyoung",
                DateOfBirth = "31/08/2004",
                Height = "1m68",
                Weight = "47kg",
                BloodType = "O"
            };
            member_12.ImagesUri.Add(@"https://i.pinimg.com/564x/99/9a/92/999a923555b3557764ac6bfa56605862.jpg");
            member_12.ImagesUri.Add(@"https://i.pinimg.com/564x/14/95/80/1495802524bac79211f6cc7caa449a8c.jpg");
            member_12.ImagesUri.Add(@"https://i.pinimg.com/564x/79/18/f6/7918f65bb23ad9865a11a37bc5af24cf.jpg");
            member_12.ListRole.Add("Vocal");
            member_12.ListRole.Add("Visual");
            member_12.ListRole.Add("Maknae");
            //
            Members.Add(member_1);
            Members.Add(member_2);
            Members.Add(member_3);
            Members.Add(member_4);
            Members.Add(member_5);
            Members.Add(member_6);
            Members.Add(member_7);
            Members.Add(member_8);
            Members.Add(member_9);
            Members.Add(member_10);
            Members.Add(member_11);
            Members.Add(member_12);
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