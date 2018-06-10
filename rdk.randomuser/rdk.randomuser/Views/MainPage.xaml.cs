using rdk.randomuser.ViewModels;
using Xamarin.Forms;

namespace rdk.randomuser.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
        }
    }
}
