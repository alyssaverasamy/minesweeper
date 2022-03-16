using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minesweeper
{

    public partial class BeginnerDifficulty : ContentPage
    {
        public BeginnerDifficulty()
        {
            InitializeComponent();

            for (int rowI = 0; rowI < 8; rowI++)
            {
                mineGridBeginner.RowDefinitions.Add(new RowDefinition());
                mineGridBeginner.ColumnDefinitions.Add(new ColumnDefinition());
                for (int colI = 0; colI < 8; colI ++)
                {
                    Button mineBox = new Button();
                    mineBox.BackgroundColor = Color.LightGray;
                    mineGridBeginner.Children.Add(mineBox, rowI, colI); 
                }
            }
        }

        private async void PauseButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PauseMenu());
        }
    }
}