using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Astronomy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            Yes.Clicked += Yes_Clicked;
            No.Clicked += No_Clicked;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Yes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Victorina());
        }

        private async void No_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Эх", "Подумай ещё раз, вдруг повезет", "Ок");
        }
    }
}