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
    [QueryProperty("ID", "id")]
    public partial class ShowMemberInfoPage : ContentPage
    {
        private string id;
        public string ID
        {
            get => id;
            set => id = Uri.UnescapeDataString(value);
        }

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
            if (this.id != null)
            {
                BindingContext = ViewModel.MembersManagerViewModel.Instance.Members.Where(x => x.ID == int.Parse(this.id)).FirstOrDefault();
            }
            int countImages = (BindingContext as Model.Member).ImagesUri.Length;
            Device.StartTimer(TimeSpan.FromSeconds(6), (Func<bool>)(() =>
            {
                carouselView.Position = (carouselView.Position + 1) % countImages;
                return true;
            }));
        }
    }
}