using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Minesweeper.Logic; using Minesweeper.Controls; 

namespace Minesweeper.Views //this is sample page template page, will not be included in the end product of the project. 
{
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
    }
}