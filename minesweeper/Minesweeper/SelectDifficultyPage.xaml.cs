using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Minesweeper
{    
    public partial class SelectDifficultyPage : ContentPage
    {    
        public SelectDifficultyPage ()
        {
            InitializeComponent ();
        }

        private async void BeginnerButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGame(9, 9, 10));
        }

        private async void IntermediateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGame(16, 16, 40));
        }

        private async void ExpertButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGame(30, 16, 99));
        }
    }
}

