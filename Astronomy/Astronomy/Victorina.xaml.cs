using Android.App;
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
    public class Planet
    {
        public Planet(ImageSource img, string text, string ansprav)
        {
            this.Img = img;
            this.Text = text;
            this.Ansprav = ansprav;
        }
        public ImageSource Img { private set; get; }
        public string Text { private set; get; }
        public string Ansprav { private set; get; }
    };
    public partial class Victorina : ContentPage
    {
        
        public Victorina()
        {
            InitializeComponent();
            High.Clicked += High_Clicked;
            Low.Clicked += Low_Clicked;
            Middle.Clicked += Middle_Clicked;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Middle_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Эй", "Только хардкор!", "Ок");
        }

        private async void High_Clicked(object sender, EventArgs e)
        {
            List<Planet> plans = new List<Planet>() {new Planet("Cerera.jpg", "Ближайшая к Солнцу карликовая планета", "Церера"), new Planet("Erida.jpg", "Наиболее далёкая от Солнца и массивная карликовая планета", "Эрида"),
        new Planet("Pluton.jpg", "Эта карликовая планета имеет спутник Харон, который лишь в 2 раза меньше самой планеты", "Плутон"), new Planet("Makemake.jpg", "Карликовая планета, обнаруженная 31 марта 2005 года", "Макемаке"),
        new Planet("Orc.jpg", "Карликовая планета, прозванная \"Анти - Плутон\"", "Орк"), new Planet("Sedna.jpg", "Получила имя в честь эскимосской богини морских звезд", "Седна"), new Planet("Pluton.jpg", "Считался планетой до 2006", "Плутон"),
        new Planet("Cerera.jpg", "Названа в честь древнеримской богини плодородия", "Церера"), new Planet("Cerera.jpg", "Является крупнейшим объектом в главном поясе астероидов, расположенном между орбитами Марса и Юпитера", "Церера"),
        new Planet("Orc.jpg", "Эта карликовая планета получила название в честь этрусского бога подземного мира ", "Орк"), new Planet("Pluton.jpg", "Самая крупная карликовая планета Солнечной системы", "Плутон"), new Planet("Cerera.jpg", "У какой карликовой планеты нет спутников?", "Церера")};

            await Navigation.PushAsync(new Test(plans, 0));
        }
        private async void Low_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Эй", "Только хардкор!", "Ок");
        }
    }
}