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
    public partial class GroupPage : ContentPage
    {
        private ViewModel.GroupViewModel viewModel;

        private bool token;

        public GroupPage()
        {
            InitializeComponent();
            viewModel = new ViewModel.GroupViewModel();
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
                int countImages = viewModel.Image.Length;
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

        private async void SeeAllMember_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ListMemberPage());
        }

        private async void SeeAllAlbum_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ListAlbumPage());
        }

        private async void collectionMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var member = ((Model.Member)collectionMember.SelectedItem);
            if (member == null)
            {
                return;
            }

            if (member == viewModel.ListMember[viewModel.ListMember.Count - 1])
            {
                await Navigation.PushAsync(new View.ListMemberPage());
            }
            else
            {
                await Navigation.PushAsync(new View.MemberInfoPage(member.ID));
            }
            collectionMember.SelectedItem = null;
        }

        private async void collectionAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var album = ((Model.Album)collectionAlbum.SelectedItem);
            if (album == null)
            {
                return;
            }

            if (album == viewModel.ListAlbum[viewModel.ListAlbum.Count - 1])
            {
                await Navigation.PushAsync(new View.ListAlbumPage());
            }
            else
            {
                await Navigation.PushAsync(new View.ListSingleInAlbumPage(album.Name));
            }
            collectionAlbum.SelectedItem = null;
        }
    }
}