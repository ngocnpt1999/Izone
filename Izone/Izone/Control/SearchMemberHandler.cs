using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Izone.Control
{
    public class SearchMemberHandler : SearchHandler
    {
        public static readonly BindableProperty ListMemberProperty =
            BindableProperty.Create(nameof(ListMember), typeof(ObservableCollection<Model.Member>),
                typeof(SearchMemberHandler));

        public ObservableCollection<Model.Member> ListMember
        {
            get => (ObservableCollection<Model.Member>)GetValue(ListMemberProperty);
            set => SetValue(ListMemberProperty, value);
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);
            if (string.IsNullOrEmpty(newValue) || string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = ListMember.Where(x => x.NickName.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            string id = ((Model.Member)item).ID.ToString();
            await Shell.Current.GoToAsync($"memberinfo?idmember={id}");
        }
    }
}