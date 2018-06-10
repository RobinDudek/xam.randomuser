using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using rdk.randomuser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rdk.randomuser.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Properties
        private INavigation Navigation;

        private List<User> allUsers;
        public List<User> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                OnPropertyChanged();
            }
        }

        private List<User> filteredUsers;
        public List<User> FilteredUsers
        {
            get { return filteredUsers; }
            set
            {
                filteredUsers = value;
                OnPropertyChanged();
            }
        }

        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value.ToLower();
                ExecuteSearchCommand();
            }
        }
        #endregion

        public MainPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Title = "Liste des Employés";

            GetJson();

            GoToDetailCommand = new Command(async (object o) => await ExecuteGoToDetailCommand(o));
        }

        protected async void GetJson()
        {
            string json = await Api.Helper.GetUsers();
            AllUsers = JsonConvert.DeserializeObject<List<User>>(json);
            AllUsers = AllUsers.OrderBy(x => x.ToString()).ToList();
            FilteredUsers = AllUsers;
        }

        public Command GoToDetailCommand { get; set; }
        private async Task ExecuteGoToDetailCommand(object param)
        {
            try
            {
                var sample = (User)param;
                SelectedUser = null;
                await Navigation.PushAsync(new Views.DetailPage(sample));
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }

        public Command SearchCommand { get; set; }
        private void ExecuteSearchCommand()
        {
            try
            {
                FilteredUsers = AllUsers.Where(
                          x => x.ToString().ToLower().Contains(SearchText)
                            || x.City.ToLower().Contains(SearchText))
                          .ToList();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }
    }
}
