using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Izone.Control
{
    public class SearchSingleHandler : SearchHandler
    {
        private Model.Album album;
        public Model.Album Album
        {
            get => album;
            set => album = value;
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
                ItemsSource = album.Singles.Where(x => x.Name.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            string index = album.Singles.IndexOf((Model.Single)item).ToString();
            await Shell.Current.GoToAsync($"media?albumid={album.ID.ToString()}&index={index}");
        }
    }
}