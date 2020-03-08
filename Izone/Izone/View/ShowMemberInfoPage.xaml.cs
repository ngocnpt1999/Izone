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
    public partial class ShowMemberInfoPage : ContentPage
    {
        public ShowMemberInfoPage(Model.Member member)
        {
            InitializeComponent();
            BindingContext = member;
            int countImages = (BindingContext as Model.Member).ImagesUri.Count;
            Device.StartTimer(TimeSpan.FromSeconds(6), (Func<bool>)(() =>
            {
                carouselView.Position = (carouselView.Position + 1) % countImages;
                return true;
            }));
        }
    }
}