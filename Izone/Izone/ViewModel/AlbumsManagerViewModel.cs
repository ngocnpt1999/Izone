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

        private ObservableCollection<Model.Album> albums;

        public ObservableCollection<Model.Album> Albums
        {
            get => albums;
            set
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
            Albums = new ObservableCollection<Model.Album>()
            {
                new Model.Album()
                {
                    ID=1,
                    Name="COLOR*IZ",
                    ImageUri="https://drive.google.com/uc?export=download&id=1eJ7Tewku5XEEv3zUb1gjjtkQcttxXidX",
                    Singles=new ObservableCollection<Model.Single>()
                    {
                        new Model.Single()
                        {
                            ID=1,
                            Name="Colors",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1qmgru_zrNogwMHwYuyMZS58qoeJ269iC"
                        },
                        new Model.Single()
                        {
                            ID=2,
                            Name="O' My!",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=15EoEJxExvEJj-DE-Q-IFrjMSFIOEftWb"
                        },
                        new Model.Single()
                        {
                            ID=3,
                            Name="La Vie en Rose",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1NsJNox5OUcs0JYYjrV7NsGQga54Em2AQ"
                        },
                        new Model.Single()
                        {
                            ID=4,
                            Name="Memory",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1J99dGEK4gWJAMM-QsjHMuegAXpNCqEKl"
                        },
                        new Model.Single()
                        {
                            ID=5,
                            Name="We Together (Iz One ver.)",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1Qlbu77XDyZq2IIzivSjnTKEoYDMAl8Mx"
                        },
                        new Model.Single()
                        {
                            ID=6,
                            Name="Suki ni Nacchau Darō? (Iz One ver.)",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1VPBMSyk3fh7IIADArkuD31F3MdyRA64s"
                        },
                        new Model.Single()
                        {
                            ID=7,
                            Name="Yume wo Miteiru Aida (Iz One ver.)",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1196MRW9kQeZoVBYUnD2y0E2U20Ro1r7I"
                        }
                    }
                },
                new Model.Album()
                {
                    ID=2,
                    Name="HEART*IZ",
                    ImageUri="https://drive.google.com/uc?export=download&id=1SL5W3Arp5YDQHrs94WvIJ0f1ut2cyGrE",
                    Singles=new ObservableCollection<Model.Single>()
                    {
                        new Model.Single()
                        {
                            ID=1,
                            Name="Sunflower",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1WYu7DnT846CzYTu3_OXLIVSzVHoApO06"
                        },
                        new Model.Single()
                        {
                            ID=2,
                            Name="Violeta",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1Tl_28ex7QUTglmgErl-8WWYUAi3T6Luj"
                        },
                        new Model.Single()
                        {
                            ID=3,
                            Name="Highlight",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1cStpgMwfrXyHppD_wwA5QmAlKqi4yGbR"
                        },
                        new Model.Single()
                        {
                            ID=4,
                            Name="Really Like You",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=12CyoPdRCLktnGNs9Nr90GtrCZZvxCci-"
                        },
                        new Model.Single()
                        {
                            ID=5,
                            Name="Airplane",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1vPXNXKqg8eSoMjnU28kyPw8kGWN-V7Ru"
                        },
                        new Model.Single()
                        {
                            ID=6,
                            Name="Above the Sky",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1BDfjDgZsot0te2M3G8OxIPwYlV49ofyl"
                        },
                        new Model.Single()
                        {
                            ID=7,
                            Name="Neko ni Naritai (Korean version)",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1DFy_zbsmniYCW_Q81FMPENMBcr3oPyT0"
                        },
                        new Model.Single()
                        {
                            ID=8,
                            Name="Gokigen Sayonara (Korean version)",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=18oCQN_SDhCDxYbvInejCu990ngxoN-ZU"
                        }
                    }
                },
                new Model.Album()
                {
                    ID=3,
                    Name="BLOOM*IZ",
                    ImageUri="https://drive.google.com/uc?export=download&id=1s7OArexqMznBXu4YlAzhWDSCMW7dU3Cl",
                    Singles=new ObservableCollection<Model.Single>()
                    {
                        new Model.Single()
                        {
                            ID=1,
                            Name="Eyes",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1uE-8qdTnjJOZHKvu72kOf0ZADkBB6E7-"
                        },
                        new Model.Single()
                        {
                            ID=2,
                            Name="FIESTA",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1dyu8U-xhLtVMZGnfyIqGPHS7N5M3NB7g"
                        },
                        new Model.Single()
                        {
                            ID=3,
                            Name="Dreamlike",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1L4LD__qFrLAk1CK2jBOO9l9Qh55P8iKl"
                        },
                        new Model.Single()
                        {
                            ID=4,
                            Name="Ayayaya",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=12u9jo60W0t0LLz65UXUwm2j3q5eZdfQw"
                        },
                        new Model.Single()
                        {
                            ID=5,
                            Name="So Curious",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=18fx1WkS2a1AamgVTLRG5wLOenezp7Po8"
                        },
                        new Model.Single()
                        {
                            ID=6,
                            Name="Spaceship",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1Fcc-XmIYvvIJbvGUiWcWS-5PaDrmnWAL"
                        },
                        new Model.Single()
                        {
                            ID=7,
                            Name="Destiny",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=14o9N0mqI1qG9veMr_dQwOQtDnSwgaXG_"
                        },
                        new Model.Single()
                        {
                            ID=8,
                            Name="YOU & I",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1twvo6J0bFa_A9NLVow7GWBR0732atHEG"
                        },
                        new Model.Single()
                        {
                            ID=9,
                            Name="Daydream",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1b0NRqqxrTPKtKLCGE-NkpL_iB6LLhZx5"
                        },
                        new Model.Single()
                        {
                            ID=10,
                            Name="Pink Blusher",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=16cUro-CBjxrreogtW0x1V8L6Sw_RbOtl"
                        },
                        new Model.Single()
                        {
                            ID=11,
                            Name="Someday",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=1xMXli2HeLPUbJnB0v3N84U1wYe4rbZIS"
                        },
                        new Model.Single()
                        {
                            ID=12,
                            Name="Open Your Eyes",
                            Mp3Uri="https://drive.google.com/uc?export=download&id=14u_JfuMghgtPuxUzpLOBMgvZxtl1fkLy"
                        }
                    }
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