using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Minesweeper
{    
    public partial class PlayGame : ContentPage
    {
        int _height;
        int _width;
        int _mines;

        public PlayGame (int height, int width, int mines)
        {
            InitializeComponent ();
            _height = height;
            _width = width;
            _mines = mines;

            for (int rowI = 0; rowI < _height; rowI++)
            {
                mineGrid.RowDefinitions.Add(new RowDefinition());
                mineGrid.ColumnDefinitions.Add(new ColumnDefinition());
                for (int colI = 0; colI < _width; colI++)
                {
                    Button mineBox = new Button();
                    mineBox.BackgroundColor = Color.LightGray;
                    mineGrid.Children.Add(mineBox, rowI, colI);
                }
            }

            minesLeft.Text = _mines.ToString();
        }

        private async void PauseButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PauseMenu());
        }
    }
}

