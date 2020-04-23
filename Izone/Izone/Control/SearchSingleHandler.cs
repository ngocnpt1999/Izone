using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Izone.Control
{
    public class SearchSingleHandler : SearchHandler
    {
        public static readonly BindableProperty ListSingleProperty =
            BindableProperty.Create(nameof(ListSingle), typeof(ObservableCollection<Model.Single>), typeof(SearchSingleHandler));

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
            int index = ListSingle.IndexOf((Model.Single)item);
            await Task.Delay(500);
            await Shell.Current.Navigation.PushAsync(new View.MediaPage(ListSingle.ToList(), index));
        }
    }
}