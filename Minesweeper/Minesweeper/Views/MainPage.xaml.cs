using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//author: alyssa

namespace Minesweeper
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectDifficultyPage());
        }

        private async void RulesButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RulesPage());
        }

    }
}

