using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace Izone.Control
{
    public class SearchAlbumHandler : SearchHandler
    {
        private ObservableCollection<Model.Album> albums;
        public ObservableCollection<Model.Album> Albums
        {
            get => albums;
            set => albums = value;
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
                ItemsSource = albums.Where(x => x.Name.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await Shell.Current.GoToAsync($"listsingle?id={((Model.Album)item).ID.ToString()}");
        }
    }
}