using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Izone.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListMemberPage : ContentPage
    {
        private ViewModel.ListMemberViewModel viewModel;

        public ListMemberPage()
        {
            InitializeComponent();
            viewModel = new ViewModel.ListMemberViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.IsRefreshing = true;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var member = ((CollectionView)sender).SelectedItem as Model.Member;
            if (member != null)
            {
                await Navigation.PushAsync(new View.ShowMemberInfoPage(member));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}