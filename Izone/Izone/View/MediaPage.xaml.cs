using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPage : ContentPage
    {
        public MediaPage(string uri)
        {
            InitializeComponent();
            mediaView.Source = MediaSource.FromUri(new Uri(uri));
        }
    }
}