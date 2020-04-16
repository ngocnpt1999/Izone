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
        public static readonly BindableProperty AlbumNameProperty =
            BindableProperty.Create("AlbumName", typeof(string), typeof(SearchSingleHandler), "");

        public static readonly BindableProperty ListSingleProperty =
            BindableProperty.Create("ListSingle", typeof(ObservableCollection<Model.Single>), typeof(SearchSingleHandler));

        public string AlbumName
        {
            get => (string)GetValue(AlbumNameProperty);
            set => SetValue(AlbumNameProperty, value);
        }

        public ObservableCollection<Model.Single> ListSingle
        {
            get => (ObservableCollection<Model.Single>)GetValue(ListSingleProperty);
            set => SetValue(ListSingleProperty, value);
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
                ItemsSource = ListSingle.Where(x => x.Name.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            string index = ListSingle.IndexOf((Model.Single)item).ToString();
            await Shell.Current.GoToAsync($"media?albumName={AlbumName}&index={index}");
        }
    }
}