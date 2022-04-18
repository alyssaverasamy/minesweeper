using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Minesweeper
{    
    public partial class PauseMenu : ContentPage
    {    
        public PauseMenu ()
        {
            InitializeComponent ();
        }

        private async void ResumeButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void QuitButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void RulesButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RulesPage());
        }
    }
}

