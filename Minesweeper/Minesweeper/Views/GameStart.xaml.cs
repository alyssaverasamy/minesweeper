using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Minesweeper.Logic; using Minesweeper.Controls; 

namespace Minesweeper.Views
{
    public partial class GameStart : ContentPage
    {
        MineField mineGrid = new MineField(10, 10, 15);
        public GameStart()
        {
            InitializeComponent();

            for (int rows = 0; rows < mineGrid._nbrRows; rows++)
            {
                MineGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                MineGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                for (int cols = 0; cols < mineGrid._nbrCols; cols++)
                {

                    MineGrid.Children.Add(mineGrid._boxGrid[rows, cols], rows, cols);
                }

            }
        }
    }
}