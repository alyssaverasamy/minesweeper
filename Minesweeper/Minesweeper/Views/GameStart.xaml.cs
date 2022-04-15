﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Minesweeper.Logic; using Minesweeper.Controls; 

namespace Minesweeper.Views //this is sample page template page, willbe included in the end product of the project but will not be 
{                           // used in any capacity.                                 
    public partial class GameStart : ContentPage
    {
        MineField mineGrid = new MineField(10, 8, 10);
        Random random = new Random();
        public GameStart()
        {
            InitializeComponent();

            for (int rows = 0; rows < mineGrid.NumRows; rows++)
            {
                MineGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                MineGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }); 
                ;
                for (int cols = 0; cols < mineGrid.NumCols; cols++)
                {
                    
                    MineGrid.Children.Add(mineGrid.BoxGrid[rows, cols], cols, rows);
                }

            }

            foreach(MineButton button in MineGrid.Children)
            {
                button.Clicked += StartGame;
            }

        } 
            
        private void StartGame(object sender, EventArgs e)
        { 
            foreach(MineButton button in MineGrid.Children)
            {
                button.Clicked -= StartGame;
                button.Clicked += PlayGame; 
            }

            mineGrid.PlaceMines();
            mineGrid.CellCondition();
        }

        private void SwitchtoDig(object sender, EventArgs e)
        {
            DigBtn.IsEnabled = false;
            FlagBtn.IsEnabled = true;
        }

        private void SwitchtoFlag(object sender, EventArgs e)
        {
            FlagBtn.IsEnabled = false;
            DigBtn.IsEnabled = true;
        }

        private void PlayGame(object sender, EventArgs e)
        {

            if (FlagBtn.IsEnabled)
                DigCell(sender as MineButton);

            if (DigBtn.IsEnabled)
                FlagCell(sender as MineButton);
        }

        private void DigCell(MineButton button)
        {
            if (button.isMine)
                GameOver();
            else
            {
                button.Text = button._nearbyMines.ToString();
            }
        }


        private void FlagCell(MineButton button)
        {
            button.isFlagged=true;
            button.Text="~";
        }
        private void GameOver()
        {
            foreach (MineButton button in MineGrid.Children)
            {
                if (button.isMine)
                {
                    button.Text="*";
                    button.TextColor = Color.Red;
                }
            }

            DisplayAlert("GameOver", "Sorry", "OK");
        }
    }
}