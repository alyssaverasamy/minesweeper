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

        // placeholder, need to update to change difficulty based on selection
        private async void DifficultyButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGame());
        }
    }
}

