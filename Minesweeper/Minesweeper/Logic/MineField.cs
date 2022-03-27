using System;
using System.Collections.Generic;
using System.Text;
using Minesweeper.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minesweeper.Logic
{
    internal class MineField
    {
        Random random = new Random();
        public int _nbrRows;
        public int _nbrCols;

        public MineButton[,] _boxGrid;
        public int _nbrMines;

        public MineField(int nbrRows, int nbrCols, int nbrMines)
        {
            _nbrRows = nbrRows;
            _nbrCols = nbrCols;
            _nbrMines = nbrMines;

            _boxGrid = new MineButton[_nbrCols, _nbrRows];
            for (int colPosition = 0; colPosition < _nbrCols; colPosition++)
            {
                for (int rowPosition = 0; rowPosition < _nbrRows; rowPosition++)
                {
                    MineButton button = new MineButton(colPosition,rowPosition,0);
                    button.BackgroundColor = Color.LightGray;
                    _boxGrid[colPosition, rowPosition] = button;
                    

                }
            }
        }

        public void PlaceMines() //Randomly places mines in the created array 
        {
            for (int mine = 0; mine < _nbrMines; mine++)
            {
                int x = random.Next(0,_nbrCols);
                int y = random.Next(0,_nbrRows);

                _boxGrid[x,y].cellisMine = true;    
            }
        }

        public int CountMines(int xPos, int yPos) // Method is used to check the nearby surroudings of cell. User enters the cell                                             
        {                                         // position (column# = xPos -- row# = yPos) 
            int mines = 0;

            for(int x = xPos - 1; x < xPos + 2; x++) //iteration starts in the position next to cell we are checking 
            {                                        //continues until it reaches the position to the right of cell. 
                if(x < 0 || x >= _nbrCols)
                {
                    continue;                   //If the column does not exist inside the grid, skip to next code block 
                }
                for(int y = yPos - 1; y < yPos + 2; y++) //Starts 1 position above cell and ends 1 position below cell 
                {
                    if((y < 0 || y >= _nbrRows) || (x == xPos && y == yPos)) //If the row does not exist within grid or the current                                                                           
                    {                                                        //Column and Row is the same as the cell we are checking
                        continue;                                            // skip to next iteration                    
                    }
                    if (_boxGrid[x, y].cellisMine == true)                   //using the currently value of iteration we check if the 
                        mines++;                                             //cell in that position is a mine, if so mine ++ 
                    
                }
            }
            return mines;                                                    // the function returns the overall count of mines nearby
        }

        public void CellCondition()  //Checks the condition of each cell in the array using the CountMines methods, and sets the MineCellCondition using the a switch function. 
        {
            foreach(MineButton cell in _boxGrid)
                cell._nearbyMines = CountMines(cell._rowPosition, cell._columnPosition);
        }
    }
}
