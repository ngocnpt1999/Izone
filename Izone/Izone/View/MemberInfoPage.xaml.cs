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
    public partial class MemberInfoPage : ContentPage
    {
        private bool token;

        private ViewModel.MemberInfoViewModel viewModel;

        public MemberInfoPage()
        {
            InitializeComponent();
        }

        public MemberInfoPage(int idMember)
        {
            InitializeComponent();
            viewModel = new ViewModel.MemberInfoViewModel(idMember);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            token = true;
            Device.StartTimer(TimeSpan.FromSeconds(6), (Func<bool>)(() =>
            {
                if (viewModel.IsRefreshing)
                {
                    return true;
                }
                int countImages = viewModel.Member.ImagesUri.Length;
                carouselView.Position = (carouselView.Position + 1) % countImages;
                return token;
            }));
            viewModel.IsRefreshing = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            token = false;
        }
    }
}