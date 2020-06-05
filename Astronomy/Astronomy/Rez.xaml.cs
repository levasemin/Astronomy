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
    public partial class Rez : ContentPage
    {
        private List<ImageSource> exes = new List<ImageSource>() { "ex1", "ex2", "ex3", "ex4", "ex5", "ex6"};
        private List<ImageSource> okes = new List<ImageSource>() { "ok1", "ok2", "ok3", "ok4" };
        private List<ImageSource> awes = new List<ImageSource>() { "aw1", "aw2", "aw3", "aw4", "aw5", "aw6", "aw7", "aw8" };
        private List<ImageSource> im = new List<ImageSource>();
        private int num = 0;
        public Rez(int prav)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Status.Clicked += Status_Clicked;
            Again.Clicked += Again_Clicked;
            if (prav > 11)
            {
                im = exes;
                Words.Text = "А ты тот ещё, астроном)";
            }
            else if (prav > 8)
            {
                im = okes;
                Words.Text = "А ты неплох, может, даже знаешь, что такое телескоп";
            }
            else
            {
                im = awes;
                Words.Text = "Твой мир- аквариум, вряд ли ты вообще знаешь, что такое космос";
            }
            Status.Source = im[0];
        }

        private void Again_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync(true);
        }

        private void Status_Clicked(object sender, EventArgs e)
        {
            num += 1;
            if (im.Count == num)
                num = 0;
            Status.Source = im[num];
        }
    }
}