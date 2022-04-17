using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
                MineGrid.RowDefinitions.Add(new RowDefinition { });
                MineGrid.ColumnDefinitions.Add(new ColumnDefinition { });
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
            if (button.IsEnabled)
            {
                button.IsEnabled = false;
                if (button.isMine)
                {
                    button.Source = "mineExplode.png";
                    GameOver();
                }
                else
                {
                    button.Source = $"num{button._nearbyMines}.png";

                    if (button._nearbyMines == 0)
                    {
                        for (int row = button.Row - 1; row < button.Row + 2; row++)
                            for (int col = button.Column - 1; col < button.Column + 2; col++)// checks all adjacent cells
                                if (0 <= col && col < mineGrid.NumCols && 0 <= row && row < mineGrid.NumRows) // check valid coordinates                                                               // 
                                    if ((row, col) != (button.Row, button.Column)) // omits center cell
                                        DigCell(mineGrid.BoxGrid[row, col]);
                    }
                }
            }
        }


        private void FlagCell(MineButton button)
        {
            button.isFlagged=true;
            //button.Text="~";
        }

        private void GameOver()
        {
            foreach (MineButton button in MineGrid.Children)
            {
                if (button.isMine)
                {
                    button.Source = "mineReveal.png";
                }
            }

            DisplayAlert("GameOver", "Sorry", "OK");
        }
    }
}