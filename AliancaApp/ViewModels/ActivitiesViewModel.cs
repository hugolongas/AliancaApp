using AliancaApp.Models;
using AliancaApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AliancaApp.ViewModels
{
    public class ActivitiesViewModel : BaseViewModel<Activity>
    {
        private Activity _selectedActivity;

        public ObservableCollection<Activity> Activities { get; }
        public Command LoadItemsCommand { get; }
        public Command<Activity> ItemTapped { get; }

        public ActivitiesViewModel()
        {
            Title = "Activitats";
            Activities = new ObservableCollection<Activity>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Activity>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Activities.Clear();
                var activities = await DataStore.GetItemsAsync(true);
                foreach (var activity in activities)
                {
                    Activities.Add(activity);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedActivity = null;
        }

        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                SetProperty(ref _selectedActivity, value);
                OnItemSelected(value);
            }
        }


        async void OnItemSelected(Activity item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ActivityDetailPage)}?{nameof(ActivityDetailViewModel.ItemId)}={item.Id}");
        }
    }
}