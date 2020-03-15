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
        private ObservableCollection<Model.Member> members;
        public ObservableCollection<Model.Member> Members
        {
            get => members;
            set => members = value;
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
                ItemsSource = members.Where(x => x.NickName.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await Shell.Current.GoToAsync($"memberprofile?id={((Model.Member)item).ID.ToString()}");
        }
    }
}