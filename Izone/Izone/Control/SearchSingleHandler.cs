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
        private string albumName;
        private ObservableCollection<Model.Single> singles;

        public string AlbumName
        {
            get => albumName;
            set => albumName = value;
        }
        public ObservableCollection<Model.Single> Singles
        {
            get => singles;
            set => singles = value;
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
                ItemsSource = Singles.Where(x => x.Name.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            string index = Singles.IndexOf((Model.Single)item).ToString();
            await Shell.Current.GoToAsync($"media?albumName={albumName}&index={index}");
        }
    }
}