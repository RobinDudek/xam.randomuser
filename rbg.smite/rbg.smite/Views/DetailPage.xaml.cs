using rdk.randomuser.Models;
using rdk.randomuser.ViewModels;
using Xamarin.Forms;

namespace rdk.randomuser.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(User User)
        {
            InitializeComponent();
            BindingContext = new DetailPageViewModel(Navigation, User);
        }
    }
}