using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Izone.Model;

namespace Izone.ViewModel
{
    public sealed class MembersManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Member> members;
        public ObservableCollection<Member> Members
        {
            get => members;
            set
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
            Members = new ObservableCollection<Member>()
            {
                new Member()
                {
                    ID=1,
                    Avatar="https://drive.google.com/uc?export=download&id=1KF4N4N1rb0v7s71UtEdjxgLcZKMjn0P0",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://drive.google.com/uc?export=download&id=17U5N1K6_s8HM8mXA7DdyLDgXnSqQxBJu",
                        @"https://i.pinimg.com/564x/30/b8/d2/30b8d217c3c379cf24fb902403fce3a4.jpg",
                        @"https://drive.google.com/uc?export=download&id=19Rvk9Je_bWAJtbjBx8V_1i2b54SAvpCT"
                    },
                    FullName="Kwon Eunbi",
                    NickName="Eunbi",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Nhóm trưởng",
                        "Nhảy(Dẫn)",
                        "Vocal(Dẫn)"
                    },
                    DateOfBirth="27/09/1995",
                    Height="1m6",
                    Weight="46kg",
                    BloodType="A"
                },
                new Member()
                {
                    ID=2,
                    Avatar="https://drive.google.com/uc?export=download&id=1D6V2znjWlKoGtSzw46YtinPJrWyh2dwR",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/85/bc/f1/85bcf1aa36c4a39539b42c896ba2fe8f.jpg",
                        @"https://drive.google.com/uc?export=download&id=1GtVkBGJgXErU3F-CV9nchzh-vgq5e13G",
                        @"https://drive.google.com/uc?export=download&id=1xUvWeOBtb7JuuVXfX5XYiDRqQpT9mx7x"
                    },
                    FullName="Miyawaki Sakura",
                    NickName="Sakura",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Visual",
                        "Vocal"
                    },
                    DateOfBirth="19/03/1998",
                    Height="1m63",
                    Weight="46kg",
                    BloodType="A"
                },
                new Member()
                {
                    ID=3,
                    Avatar="https://drive.google.com/uc?export=download&id=1gKblrHC1L7UbmW3_Wjg8N2sjEpmxvrYV",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/93/96/e6/9396e66714226a544e68c3304b3deda4.jpg",
                        @"https://i.pinimg.com/564x/a7/77/7d/a7777d543aba34aad0757322e5db23d3.jpg",
                        @"https://i.pinimg.com/564x/ce/1d/a8/ce1da81f19cfbaa1f2fa99c1dd559cd8.jpg"
                    },
                    FullName="Kang Hyewon",
                    NickName="Hyewon",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Rap(Dẫn)",
                        "Visual",
                        "Vocal"
                    },
                    DateOfBirth="05/07/1999",
                    Height="1m63",
                    Weight="43kg",
                    BloodType="B"
                },
                new Member()
                {
                    ID=4,
                    Avatar="https://drive.google.com/uc?export=download&id=1n3UgTVEGSNxKc_tTuz7oue3rRxBQG3QJ",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/2a/c4/02/2ac402632c1170b4d715c5ccce8f8ed4.jpg",
                        @"https://i.pinimg.com/564x/0c/a0/9c/0ca09c34c360dffd8a238ffa9e180a43.jpg",
                        @"https://i.pinimg.com/564x/8a/92/d4/8a92d4523d2c7280ee1b48b3a3aed177.jpg"
                    },
                    FullName="Choi Yena",
                    NickName="Yena",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Nhảy(Dẫn)",
                        "Rap chính",
                        "Vocal(Dẫn)"
                    },
                    DateOfBirth="29/09/1999",
                    Height="1m63",
                    Weight="45kg",
                    BloodType="A"
                },
                new Member()
                {
                    ID=5,
                    Avatar="https://drive.google.com/uc?export=download&id=1-2Y9vDrO0rIqJqpQUeq62YNfgDqdTZD6",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/ba/3f/17/ba3f17ab5fc6f62e7221c424ef9b04f5.jpg",
                        @"https://i.pinimg.com/564x/3b/c1/78/3bc17809b91d0385edd1bfc06cc70aaa.jpg",
                        @"https://i.pinimg.com/564x/4c/50/2f/4c502fbf8fc8c4f950ef080b5ee01306.jpg"
                    },
                    FullName="Lee Chaeyeon",
                    NickName="Chaeyeon",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Vocal(Hỗ trợ)",
                        "Nhảy chính"
                    },
                    DateOfBirth="11/01/2000",
                    Height="1m64",
                    Weight="47kg",
                    BloodType="A"
                },
                new Member()
                {
                    ID=6,
                    Avatar="https://drive.google.com/uc?export=download&id=15B22TBFTjIpWFLjAyQpPTZsWM5P8yuVu",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/86/9d/2d/869d2dcd0c626a93fd35355faa6afc47.jpg",
                        @"https://i.pinimg.com/564x/9b/29/17/9b29172b4ad67942d124670beb86873f.jpg",
                        @"https://i.pinimg.com/564x/83/52/82/8352829073dd4e6dee7a6ac62e25cd9d.jpg"
                    },
                    FullName="Kim Chaewon",
                    NickName="Chaewon",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Vocal(Dẫn)",
                        "Nhảy(Dẫn)"
                    },
                    DateOfBirth="01/08/2000",
                    Height="1m63",
                    Weight="42kg",
                    BloodType="B"
                },
                new Member()
                {
                    ID=7,
                    Avatar="https://drive.google.com/uc?export=download&id=17JN6pzH6tUPGmYJdfjXMZLQKRWdniE93",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/93/b9/6c/93b96c5cb51dfdfbfa62468879255b05.jpg",
                        @"https://i.pinimg.com/564x/f4/41/36/f441364dc71a21335dc4bf82bce0e5a8.jpg",
                        @"https://i.pinimg.com/564x/49/1a/e4/491ae4bf129d0e587150429359c44993.jpg"
                    },
                    FullName="Kim Minjoo",
                    NickName="Minjoo",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Vocal",
                        "Visual"
                    },
                    DateOfBirth="05/02/2001",
                    Height="1m65",
                    Weight="45kg",
                    BloodType="AB"
                },
                new Member()
                {
                    ID=8,
                    Avatar="https://drive.google.com/uc?export=download&id=1G55K1nZx_oc5818SWI3Fw2CkO6cs24Bb",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/b2/45/61/b245618db776fb5bdfedf9d74d1e3d15.jpg",
                        @"https://i.pinimg.com/564x/8e/d4/6d/8ed46d06df36e824825a9aa9f4a7eda0.jpg",
                        @"https://i.pinimg.com/564x/2e/d1/96/2ed196e9af949b0f5430d7c588d2c004.jpg"
                    },
                    FullName="Yabuki Nako",
                    NickName="Nako",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Vocal"
                    },
                    DateOfBirth="18/06/2001",
                    Height="1m49",
                    Weight="40kg",
                    BloodType="..."
                },
                new Member()
                {
                    ID=9,
                    Avatar="https://drive.google.com/uc?export=download&id=1jZhNXChhwtF6M1FmqBJ_-zb2Y2cBMHOz",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/b8/bd/70/b8bd70250dd56e2682e41bf81832e91a.jpg",
                        @"https://i.pinimg.com/564x/7c/16/91/7c1691dddf0d89391a07166d75bf945c.jpg",
                        @"https://i.pinimg.com/564x/23/1e/87/231e87d0f796b2d6e6330d2c1c0d24d3.jpg"
                    },
                    FullName="Honda Hitomi",
                    NickName="Hitomi",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Nhảy(Dẫn)",
                        "Vocal",
                        "Rap"
                    },
                    DateOfBirth="06/10/2001",
                    Height="1m58",
                    Weight="44kg",
                    BloodType="A"
                },
                new Member()
                {
                    ID=10,
                    Avatar="https://drive.google.com/uc?export=download&id=1ozVWhV9wNEt6d3gEGl8QKWqDjSiKt5fc",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/fb/12/aa/fb12aad2145cf0e24444f6f4b80271fe.jpg",
                        @"https://i.pinimg.com/564x/0a/88/65/0a886571251e5c9cd48d24ba38d2e37d.jpg",
                        @"https://i.pinimg.com/564x/5c/ed/51/5ced51ebe2affd6080a7dd592ad36537.jpg"
                    },
                    FullName="Jo Yuri",
                    NickName="Yuri",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Giọng ca chính"
                    },
                    DateOfBirth="22/10/2001",
                    Height="1m6",
                    Weight="45kg",
                    BloodType="AB"
                },
                new Member()
                {
                    ID=11,
                    Avatar="https://drive.google.com/uc?export=download&id=1wgXMV0nWD4m_zCbzFXSX8eWehllzzxD1",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/41/c0/cc/41c0cc9eaf6b1bdb0c26b521ed7d592e.jpg",
                        @"https://i.pinimg.com/564x/e2/31/1c/e2311c72499c5e236e3bb1bbfb5e56a7.jpg",
                        @"https://i.pinimg.com/564x/d0/aa/7f/d0aa7f39e46e299629140fe6692f02a8.jpg"
                    },
                    FullName="Ahn Yujin",
                    NickName="Yujin",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Nhảy(Dẫn)",
                        "Vocal(Hỗ trợ)"
                    },
                    DateOfBirth="01/09/2003",
                    Height="1m68",
                    Weight="48kg",
                    BloodType="A"
                },
                new Member()
                {
                    ID=12,
                    Avatar="https://drive.google.com/uc?export=download&id=1u39RM0_Maps4pV76QUiV7B1HNWzbXkj5",
                    ImagesUri=new ObservableCollection<string>()
                    {
                        @"https://i.pinimg.com/564x/99/9a/92/999a923555b3557764ac6bfa56605862.jpg",
                        @"https://i.pinimg.com/564x/14/95/80/1495802524bac79211f6cc7caa449a8c.jpg",
                        @"https://i.pinimg.com/564x/79/18/f6/7918f65bb23ad9865a11a37bc5af24cf.jpg"
                    },
                    FullName="Jang Wonyoung",
                    NickName="Wonyoung",
                    ListRole=new ObservableCollection<string>()
                    {
                        "Vocal",
                        "Visual",
                        "Maknae"
                    },
                    DateOfBirth="31/08/2004",
                    Height="1m68",
                    Weight="47kg",
                    BloodType="O"
                }
            };
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