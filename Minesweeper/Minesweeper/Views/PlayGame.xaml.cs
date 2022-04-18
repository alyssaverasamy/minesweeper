using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Minesweeper.Controls;
using Minesweeper.Logic;
using Minesweeper.Views;
using Minesweeper.PlayerLogic;

// author: alyssa
// some code in this file is collaborative work from the test file GameStart.xaml.cs

namespace Minesweeper
{    
    public partial class PlayGame : ContentPage
    {
        MineField mineField;
        int flagCount = 0;

        public PlayGame (int numRows, int numCols, int numMines)
        {
            InitializeComponent ();

            mineField = new MineField(numRows, numCols, numMines);
            minesLeft.Text = numMines.ToString();

            for (int row = 0; row < numRows; row++)
            {
                mineGridLayout.RowDefinitions.Add(new RowDefinition());
                mineGridLayout.ColumnDefinitions.Add(new ColumnDefinition());

                for (int col = 0; col < numCols; col++)
                {
                    MineButton cell = mineField.BoxGrid[row, col];
                    cell.Source = "hiddenCell.png";
                    cell.Aspect = Aspect.AspectFill;
                    cell.Clicked += FirstCellClicked;
                    mineGridLayout.Children.Add(cell, col, row);
                }
            }
        }

        private async void PauseButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PauseMenu());
        }

        private void FirstCellClicked(object sender, EventArgs e)
        {
            foreach (MineButton cell in mineGridLayout.Children)
            {
                cell.Clicked -= FirstCellClicked;
                cell.Clicked += CellClicked;
            }

            MineButton startCell = (MineButton)sender;

            mineField.PlaceMines(startCell.Row, startCell.Column);
            mineField.CellCondition();
        }

        private void CellClicked(object sender, EventArgs e)
        {
            if (ToggleFlag.IsToggled) // switch on -> flag
                FlagCell(sender as MineButton);
            else // switch off -> dig
                DigCell(sender as MineButton);
        }

        private void DigCell(MineButton cell)
        {
            if (cell.IsEnabled && !cell.isFlagged)
            {
                cell.IsEnabled = false;
                if (cell.isMine)
                    LoseGame(cell.Row, cell.Column);
                else 
                {
                    cell.Source = $"num{cell._nearbyMines}.png";
                    mineField.numRevealed++;

                    if (mineField.numRevealed == (mineField.NumRows * mineField.NumCols) - mineField.NumMines)
                        WinGame();

                    if (cell._nearbyMines == 0)
                    {
                        for (int row = cell.Row - 1; row < cell.Row + 2; row++)
                            for (int col = cell.Column - 1; col < cell.Column + 2; col++)// checks all adjacent cells
                                if (0 <= col && col < mineField.NumCols && 0 <= row && row < mineField.NumRows) // check valid coordinates                                                               // 
                                    if ((row, col) != (cell.Row, cell.Column)) // omits center cell
                                        DigCell(mineField.BoxGrid[row, col]);
                    }
                }
            }
        }


        private void FlagCell(MineButton cell)
        {
            if (cell.isFlagged)
            {
                cell.Source = "hiddenCell.png";
                cell.isFlagged = false;
                flagCount--;
            }
            else
            {
                cell.Source = "flagCell.png";
                cell.isFlagged = true;
                flagCount++;
            }
            minesLeft.Text = (mineField.NumMines - flagCount).ToString();
        }

        private async void WinGame()
        {
            foreach (MineButton cell in mineGridLayout.Children)
            {
                cell.IsEnabled = false;
                if (cell.isMine)
                    cell.Source = "flagCell.png";
            }


            await DisplayAlert("you win!", "nice", "ok");

            await Navigation.PushAsync(new PlayerScores());
        }

        private void LoseGame(int bombRow, int bombCol)
        {
            foreach (MineButton cell in mineGridLayout.Children)
            {
                cell.IsEnabled = false;
                if (cell.isMine)
                {
                    if ((cell.Row, cell.Column) == (bombRow, bombCol))
                        cell.Source = "mineExplode.png";
                    else
                        cell.Source = "mineReveal.png";
                }
            }


            DisplayAlert("game over", "sorry", "ok");
        }
    }
}


