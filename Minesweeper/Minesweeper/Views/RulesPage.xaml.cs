using System;
using System.Collections.Generic;

using Xamarin.Forms;
//author: alyssa

namespace Minesweeper
{    
    public partial class RulesPage : ContentPage
    {    
        public RulesPage ()
        {
            InitializeComponent ();
        }


        private async void BackButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}

