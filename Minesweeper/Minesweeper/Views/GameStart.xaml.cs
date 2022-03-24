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
                button.Clicked += StartGame;
            }

        } 
            
        private void StartGame(object sender, EventArgs e)
        { 
            List<string> MineLocations = new List<string>();
            string a; 
            foreach(MineButton button in MineGrid.Children)
            {
                button.Clicked -= StartGame; 
            }

            mineGrid.PlaceMines(); 
            
           foreach(MineButton button in MineGrid.Children)
            {
                if (button.cellisMine == true)
                    button.Text = "*"; 
            }
   

        }
        
    }
}