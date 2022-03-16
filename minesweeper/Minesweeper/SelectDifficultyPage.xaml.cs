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
        private async void BegginerButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BeginnerDifficulty());
        }

        private async void IntermediateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IntermediateDifficulty());
        }

        private async void ExpertButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpertDifficulty());
        }
    }
}

