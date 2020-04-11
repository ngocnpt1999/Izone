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
    [QueryProperty("IdMember", "idmember")]
    public partial class ShowMemberInfoPage : ContentPage
    {
        private string idmember;
        public string IdMember
        {
            get => idmember;
            set => idmember = Uri.UnescapeDataString(value);
        }

        private ViewModel.MemberInfoViewModel viewModel;
        private bool token = true;

        public ShowMemberInfoPage()
        {
            InitializeComponent();
        }

        public ShowMemberInfoPage(Model.Member member)
        {
            InitializeComponent();
            BindingContext = member;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.idmember != null)
            {
                viewModel = new ViewModel.MemberInfoViewModel(int.Parse(this.idmember));
                BindingContext = viewModel.Member;
            }
            int countImages = (BindingContext as Model.Member).ImagesUri.Length;
            Device.StartTimer(TimeSpan.FromSeconds(6), (Func<bool>)(() =>
            {
                carouselView.Position = (carouselView.Position + 1) % countImages;
                return token;
            }));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            token = false;
        }
    }
}