using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Astronomy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class Test : ContentPage
    {
        
        private Random random = new Random();
        public Planet planet;
        private List<Planet> planets;
        private int numclick = 0;
        private int kolprav;
        private List<string> answers = new List<string>();
        private List<string> answerswr = new List<string>();
        public Test(List<Planet> plan, int prav)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            check.Clicked += Check_Clicked;
            Photo.Clicked += Photo_SizeChanged;
            planets = plan;
            kolprav = prav;
            Set();

        }
        private void Set() {
            if (planets.Count == 0)
            {
                check.Text = "Посмотреть результаты";
                check.Clicked += Pop;
                return;
            }
            ans1.IsEnabled = true;
            ans2.IsEnabled = true;
            ans3.IsEnabled = true;
            ans4.IsEnabled = true;
            ans1.IsChecked = false;
            ans2.IsChecked = false;
            ans3.IsChecked = false;
            ans4.IsChecked = false;
            anst1.TextColor = Color.FromHex("#FFFFFF");
            anst2.TextColor = Color.FromHex("#FFFFFF");
            anst3.TextColor = Color.FromHex("#FFFFFF");
            anst4.TextColor = Color.FromHex("#FFFFFF");
            check.Text = "Проверить";
            answerswr = new List<string>() { "Эрида", "Макемаке", "Хаумеа", "Плутон", "Церера" };
            answers = new List<string>();
            int index = random.Next(planets.Count);
            planet = planets[index];
            answers.Add(planet.Ansprav);
            Text.Text = planet.Text;
            Photo.Source = planet.Img;
            answerswr.Remove(planet.Ansprav);
            planets.Remove(planet);
            index = random.Next(answerswr.Count);
            answers.Add(answerswr[index]);
            answerswr.Remove(answerswr[index]);
            index = random.Next(answerswr.Count);
            answers.Add(answerswr[index]);
            answerswr.Remove(answerswr[index]);
            index = random.Next(answerswr.Count);
            answers.Add(answerswr[index]);
            answerswr.Remove(answerswr[index]);
            index = random.Next(4);
            string p = answers[0];
            answers[0] = answers[index];
            answers[index] = p;
            anst1.Text = answers[0];
            anst2.Text = answers[1];
            anst3.Text = answers[2];
            anst4.Text = answers[3];
        }

        private void Ans4_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            switch (ans4.IsChecked)
            {
                case true:
                    ans1.IsChecked = false;
                    ans2.IsChecked = false;
                    ans3.IsChecked = false;
                    break;
                case false:
                    break;
            }
        }

        private void Ans3_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            switch (ans3.IsChecked)
            {
                case true:
                    ans1.IsChecked = false;
                    ans2.IsChecked = false;
                    ans4.IsChecked = false;
                    break;
                case false:
                    break;
            }
        }

        private void Ans2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            switch (ans2.IsChecked)
            {
                case true:
                    ans1.IsChecked = false;
                    ans3.IsChecked = false;
                    ans4.IsChecked = false;
                    break;
                case false:
                    break;
            }
        }

        private void Ans1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            switch (ans1.IsChecked)
            {
                case true:
                    ans4.IsChecked = false;
                    ans2.IsChecked = false;
                    ans3.IsChecked = false;
                    break;
                case false:
                    break;
            }
        }

        private async void Photo_SizeChanged(object sender, EventArgs e)
        {
            var modalPage = new ContentPage();
            Grid stack = new Grid();
            ImageButton but = new ImageButton() { Source = planet.Img, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
            but.Clicked += But_Clicked;
            stack.Children.Add(but);
            modalPage.Content = stack;
            await Navigation.PushModalAsync(modalPage);
        }

        private async void But_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Pop(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rez(kolprav), true);
        }
        private void Check_Clicked(object sender, EventArgs e)
        {
            if (numclick == 0)
            {
                if (anst1.Text == planet.Ansprav)
                    anst1.TextColor = Color.FromHex("#1E8449");
                else if (anst2.Text == planet.Ansprav)
                    anst2.TextColor = Color.FromHex("#1E8449");
                else if (anst3.Text == planet.Ansprav)
                    anst3.TextColor = Color.FromHex("#1E8449");
                else if (anst4.Text == planet.Ansprav)
                    anst4.TextColor = Color.FromHex("#1E8449");
                if (ans1.IsChecked && anst1.Text != planet.Ansprav)
                    anst1.TextColor = Color.FromHex("FF5733");
                else if (ans2.IsChecked && anst2.Text != planet.Ansprav)
                    anst2.TextColor = Color.FromHex("FF5733");
                else if (ans3.IsChecked && anst3.Text != planet.Ansprav)
                    anst3.TextColor = Color.FromHex("FF5733");
                else if (ans4.IsChecked && anst4.Text != planet.Ansprav)
                    anst4.TextColor = Color.FromHex("FF5733");
                else if (ans1.IsChecked || ans2.IsChecked || ans3.IsChecked || ans4.IsChecked)
                    kolprav += 1;
                numclick += 1;
                ans1.IsEnabled = false;
                ans2.IsEnabled = false;
                ans3.IsEnabled = false;
                ans4.IsEnabled = false;
                check.Text = "Далее";
            }
            else
            {
                Set();
                numclick = 0;
            }
        }
    }
}