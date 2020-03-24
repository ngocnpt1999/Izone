using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace Izone.ViewModel
{
    public class AlbumsManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Model.Album> albums = new ObservableCollection<Model.Album>();

        public ObservableCollection<Model.Album> Albums
        {
            get => albums;
            private set
            {
                albums = value;
                OnPropertyChanged("Albums");
            }
        }

        private AlbumsManagerViewModel()
        {
            CreateListAlbum();
            RefreshListAlbumCommand = new Command(ExcuteRefreshListAlbumCommand);
        }

        public void CreateListAlbum()
        {
            //Album COLOR*IZ
            Model.Album album_1 = new Model.Album()
            {
                ID = 1,
                Name = "COLOR*IZ",
                ReleaseDate = new DateTime(2018, 10, 29),
                ImageUri = "https://drive.google.com/uc?export=download&id=1eJ7Tewku5XEEv3zUb1gjjtkQcttxXidX"
            };
            album_1.Singles.Add(
                new Model.Single()
                {
                    ID = 1,
                    Name = "Colors",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1qmgru_zrNogwMHwYuyMZS58qoeJ269iC"
                }
            );
            album_1.Singles.Add(
                new Model.Single()
                {
                    ID = 2,
                    Name = "O' My!",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=15EoEJxExvEJj-DE-Q-IFrjMSFIOEftWb"
                }
            );
            album_1.Singles.Add(
                new Model.Single()
                {
                    ID = 3,
                    Name = "La Vie en Rose",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1NsJNox5OUcs0JYYjrV7NsGQga54Em2AQ"
                }
            );
            album_1.Singles.Add(
                new Model.Single()
                {
                    ID = 4,
                    Name = "Memory",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1J99dGEK4gWJAMM-QsjHMuegAXpNCqEKl"
                }
            );
            album_1.Singles.Add(
                new Model.Single()
                {
                    ID = 5,
                    Name = "We Together (Iz One ver.)",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1Qlbu77XDyZq2IIzivSjnTKEoYDMAl8Mx"
                }
            );
            album_1.Singles.Add(
                new Model.Single()
                {
                    ID = 6,
                    Name = "Suki ni Nacchau Darō? (Iz One ver.)",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1VPBMSyk3fh7IIADArkuD31F3MdyRA64s"
                }
            );
            album_1.Singles.Add(
                new Model.Single()
                {
                    ID = 7,
                    Name = "Yume wo Miteiru Aida (Iz One ver.)",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1196MRW9kQeZoVBYUnD2y0E2U20Ro1r7I"
                }
            );
            //Album HEART*IZ
            Model.Album album_2 = new Model.Album()
            {
                ID = 2,
                Name = "HEART*IZ",
                ReleaseDate = new DateTime(2019, 4, 1),
                ImageUri = "https://drive.google.com/uc?export=download&id=1SL5W3Arp5YDQHrs94WvIJ0f1ut2cyGrE"
            };
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 1,
                    Name = "Sunflower",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1WYu7DnT846CzYTu3_OXLIVSzVHoApO06"
                }
            );
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 2,
                    Name = "Violeta",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1Tl_28ex7QUTglmgErl-8WWYUAi3T6Luj"
                }
            );
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 3,
                    Name = "Highlight",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1cStpgMwfrXyHppD_wwA5QmAlKqi4yGbR"
                }
            );
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 4,
                    Name = "Really Like You",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=12CyoPdRCLktnGNs9Nr90GtrCZZvxCci-"
                }
            );
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 5,
                    Name = "Airplane",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1vPXNXKqg8eSoMjnU28kyPw8kGWN-V7Ru"
                }
            );
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 6,
                    Name = "Above the Sky",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1BDfjDgZsot0te2M3G8OxIPwYlV49ofyl"
                }
            );
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 7,
                    Name = "Neko ni Naritai (Korean version)",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1DFy_zbsmniYCW_Q81FMPENMBcr3oPyT0"
                }
            );
            album_2.Singles.Add(
                new Model.Single()
                {
                    ID = 8,
                    Name = "Gokigen Sayonara (Korean version)",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=18oCQN_SDhCDxYbvInejCu990ngxoN-ZU"
                }
            );
            //Album BLOOM*IZ
            Model.Album album_3 = new Model.Album()
            {
                ID = 3,
                Name = "BLOOM*IZ",
                ReleaseDate = new DateTime(2020, 2, 17),
                ImageUri = "https://drive.google.com/uc?export=download&id=1s7OArexqMznBXu4YlAzhWDSCMW7dU3Cl"
            };
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 1,
                    Name = "Eyes",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1uE-8qdTnjJOZHKvu72kOf0ZADkBB6E7-"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 2,
                    Name = "FIESTA",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1dyu8U-xhLtVMZGnfyIqGPHS7N5M3NB7g"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 3,
                    Name = "Dreamlike",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1L4LD__qFrLAk1CK2jBOO9l9Qh55P8iKl"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 4,
                    Name = "Ayayaya",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=12u9jo60W0t0LLz65UXUwm2j3q5eZdfQw"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 5,
                    Name = "So Curious",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=18fx1WkS2a1AamgVTLRG5wLOenezp7Po8"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 6,
                    Name = "Spaceship",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1Fcc-XmIYvvIJbvGUiWcWS-5PaDrmnWAL"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 7,
                    Name = "Destiny",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=14o9N0mqI1qG9veMr_dQwOQtDnSwgaXG_"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 8,
                    Name = "YOU & I",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1twvo6J0bFa_A9NLVow7GWBR0732atHEG"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 9,
                    Name = "Daydream",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1b0NRqqxrTPKtKLCGE-NkpL_iB6LLhZx5"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 10,
                    Name = "Pink Blusher",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=16cUro-CBjxrreogtW0x1V8L6Sw_RbOtl"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 11,
                    Name = "Someday",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1xMXli2HeLPUbJnB0v3N84U1wYe4rbZIS"
                }
            );
            album_3.Singles.Add(
                new Model.Single()
                {
                    ID = 12,
                    Name = "Open Your Eyes",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=14u_JfuMghgtPuxUzpLOBMgvZxtl1fkLy"
                }
            );
            //Album Suki-To-Iwasetai
            Model.Album album_4 = new Model.Album()
            {
                ID = 4,
                Name = "Suki To Iwasetai",
                ReleaseDate = new DateTime(2019, 2, 6),
                ImageUri = "https://drive.google.com/uc?export=download&id=1xmm9jgeiWjOo_0HVmAvI0Dg3c180Q5w2"
            };
            album_4.Singles.Add(
                new Model.Single()
                {
                    ID = 1,
                    Name = "Suki To Iwasetai",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1zuQQ7Xq8MQ1BHglPM7zun7TDQImX8RvD"
                }
            );
            //Album Buenos-Aires
            Model.Album album_5 = new Model.Album()
            {
                ID = 5,
                Name = "Buenos Aires",
                ReleaseDate = new DateTime(2019, 6, 26),
                ImageUri = "https://drive.google.com/uc?export=download&id=1RoI4iQLg5ybQkB-hY11HZA50hZhbqsSB"
            };
            album_5.Singles.Add(
                new Model.Single()
                {
                    ID = 1,
                    Name = "Buenos Aires",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1zSGxzjMbx7AbRTDhqK8sv96DWBNe6UpD"
                }
            );
            //Album Vampire
            Model.Album album_6 = new Model.Album()
            {
                ID = 6,
                Name = "Vampire",
                ReleaseDate = new DateTime(2019, 9, 25),
                ImageUri = "https://drive.google.com/uc?export=download&id=1mvY8I9iDoGDO2gYVB3TrPdDzcWus7b0U"
            };
            album_6.Singles.Add(
                new Model.Single()
                {
                    ID = 1,
                    Name = "Vampire",
                    Mp3Uri = "https://drive.google.com/uc?export=download&id=1coD2biKyTLXOasOqLHpxQsFkSSLXI8nA"
                }
            );
            //
            Albums.Add(album_1);
            Albums.Add(album_2);
            Albums.Add(album_3);
            Albums.Add(album_4);
            Albums.Add(album_5);
            Albums.Add(album_6);
            Albums = new ObservableCollection<Model.Album>(Albums.OrderBy(x => x.ReleaseDate));
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

        public Command RefreshListAlbumCommand { get; }

        public void ExcuteRefreshListAlbumCommand()
        {
            Albums.Clear();
            CreateListAlbum();
            IsRefreshing = false;
        }

        private static readonly object padlock = new object();
        private static AlbumsManagerViewModel instance = null;

        public static AlbumsManagerViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AlbumsManagerViewModel();
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