﻿using System;
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
        public ListMemberPage()
        {
            InitializeComponent();
            BindingContext = ViewModel.MembersManagerViewModel.Instance;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var member = ((CollectionView)sender).SelectedItem as Model.Member;
            if (member != null)
            {
                await Navigation.PushAsync(new View.ShowMemberInfoPage(member.ID));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}