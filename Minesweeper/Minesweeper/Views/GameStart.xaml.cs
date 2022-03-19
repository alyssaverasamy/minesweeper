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
        MineField mineGrid = new MineField(10, 10, 10);
        Random random = new Random();
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

            foreach(MineButton button in MineGrid.Children)
            {
                button.Clicked += PlaceMines;
            }

        } 
            
        private void PlaceMines(object sender, EventArgs e)
        { 
            List<string> MineLocations = new List<string>();
            string a; 
            foreach(MineButton button in MineGrid.Children)
            {
                button.Clicked -= PlaceMines; 
            }

            for(int counter = 0; counter < mineGrid._nbrMines; counter++)
            {
                int r_I = random.Next(0,mineGrid._nbrMines);
                int c_I = random.Next(0, mineGrid._nbrMines);
                MineButton mine = new MineButton();
                mine.Text = "*";
                mine.TextColor = Color.Black;
                mine.isMine = true; 
                mine.FontSize = 15;
                mine.BackgroundColor = Color.White;
                mine.rowPosition = r_I; mine.columnPosition = c_I; 
                //mine.Clicked += MineClicked;
                MineLocations.Add($"{mine.rowPosition} , {mine.columnPosition}");
                MineGrid.Children.Add(mine, c_I, r_I);

                
            }
            Sample.ItemsSource = MineLocations; 

        }
        
    }
}