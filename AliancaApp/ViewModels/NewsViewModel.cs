using AliancaApp.Models;
using AliancaApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AliancaApp.ViewModels
{
    public class NewsViewModel : BaseViewModel<News>
    {
        private News _selectedNews;

        public ObservableCollection<News> NewsItems { get; }
        public Command LoadItemsCommand { get; }
        public Command<News> ItemTapped { get; }

        public NewsViewModel()
        {
            Title = "Activitats";
            NewsItems = new ObservableCollection<News>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<News>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                NewsItems.Clear();
                var activities = await DataStore.GetItemsAsync(true);
                foreach (var activity in activities)
                {
                    NewsItems.Add(activity);
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

        public News SelectedActivity
        {
            get => _selectedNews;
            set
            {
                SetProperty(ref _selectedNews, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(News item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(NewsDetailPage)}?{nameof(NewsDetailViewModel.ItemId)}={item.Id}");
        }
    }
}