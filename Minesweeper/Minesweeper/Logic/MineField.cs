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

        public void PlaceMines() // randomly place mines in grid
        {
            int col;
            int row;

            for (int mine = 0; mine < _nbrMines; mine++)
            {
                do
                {
                    col = random.Next(0, _nbrCols);
                    row = random.Next(0, _nbrRows);
                }
                while (_boxGrid[col, row].isMine); // prevent overlap

                _boxGrid[col, row].isMine = true;
            }
        }

        public int CountMines(int cellRow, int cellCol) // count mines adjacent to cell                             
        {                                         
            int mines = 0;
            if (_boxGrid[cellRow, cellCol].isMine)
                return 0; // if mine, don't need to count adjacent mines

            for (int col = cellCol - 1; col < cellCol + 2; col++)
                for (int row = cellRow - 1; row < cellRow + 2; row++)// checks all adjacent cells
                    if(0 <= col && col < _nbrCols && 0 <= row && row < _nbrRows) // check valid coordinates                                                               // 
                        if (_boxGrid[row, col].isMine && (row, col) != (cellRow, cellCol)) // omits center cell
                            mines++;
            return mines;
        }


        public void CellCondition()  //Checks the condition of each cell in the array using the CountMines methods, and sets the MineCellCondition using the a switch function. 
        {
            foreach(MineButton cell in _boxGrid)
                cell._nearbyMines = CountMines(cell.Row, cell.Column);
        }
    }
}
