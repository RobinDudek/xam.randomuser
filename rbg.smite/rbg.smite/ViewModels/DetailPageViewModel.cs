using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
using rdk.randomuser.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rdk.randomuser.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        #region Properties
        private INavigation Navigation;

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        #endregion

        public DetailPageViewModel(INavigation navigation, User user)
        {
            Navigation = navigation;
            
            User = user;

            Title = User.ToString();

            TextToSpeechCommand = new Command(async () => await CrossTextToSpeech.Current.Speak(
                User.GetFullAddress(),
                new CrossLocale { Language = "fr", Country = "fr" }));
            ShareCommand = new Command(async () => await ExecuteShareCommand());
            
            Analytics.TrackEvent("User detail entered", new Dictionary<string, string> {
                { "User", User.ToString() }, { "Gender", User.Gender }
            });
        }

        public Command TextToSpeechCommand { get; set; }

        public Command ShareCommand { get; set; }
        private async Task ExecuteShareCommand()
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    if (!CrossShare.IsSupported)
                        return;

                    CrossShare.Current.Share(new ShareMessage
                    {
                        Title = "Voici un de mes employés!",
                        Text = "Je vous partage les statistiques de: " + User.ToString(),
                        Url = User.UserIcon_URL
                    });
                });
            }
            catch(Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }
    }
}
