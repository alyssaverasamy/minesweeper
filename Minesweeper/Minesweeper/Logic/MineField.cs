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
        private int _numRows;
        private int _numCols;
        private int _numMines;

        public int NumRows
        {
            get => _numRows;
            set
            {
                if (value <= 0)
                    throw new Exception("number of rows must be greater than zero.");
                _numRows = value;
            }
        }

        public int NumCols
        {
            get => _numCols;
            set
            {
                if (value <= 0)
                    throw new Exception("number of columns must be greater than zero.");
                _numCols = value;
            }
        }

        public int NumMines
        {
            get => _numMines;
            set
            {
                if (value >= _numRows * _numCols)
                    throw new Exception("grid must have at least one non-mine cell.");
                _numMines = value;
            }
        }

        public MineButton[,] BoxGrid;

        public MineField(int numRows, int numCols, int numMines)
        {
            NumRows = numRows;
            NumCols = numCols;
            NumMines = numMines;

            BoxGrid = new MineButton[NumRows, NumCols];
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < NumCols; col++)
                {
                    MineButton button = new MineButton(row,col,0);
                    button.BackgroundColor = Color.LightGray;
                    BoxGrid[row, col] = button;
                }
            }
        }

        public void PlaceMines() // randomly place mines in grid
        {
            int col;
            int row;

            for (int mine = 0; mine < NumMines; mine++)
            {
                do
                {
                    col = random.Next(0, NumCols);
                    row = random.Next(0, NumRows);
                }
                while (BoxGrid[row, col].isMine); // prevent overlap

                BoxGrid[row, col].isMine = true;
            }
        }

        public int CountMines(int cellRow, int cellCol) // count mines adjacent to cell                             
        {                                         
            int mines = 0;
            if (BoxGrid[cellRow, cellCol].isMine)
                return 0; // if mine, don't need to count adjacent mines

            for (int row = cellRow - 1; row < cellRow + 2; row++)
                for (int col = cellCol - 1; col < cellCol + 2; col++)// checks all adjacent cells
                    if(0 <= col && col < NumCols && 0 <= row && row < NumRows) // check valid coordinates                                                               // 
                        if (BoxGrid[row, col].isMine && (row, col) != (cellRow, cellCol)) // omits center cell
                            mines++;
            return mines;
        }


        public void CellCondition()  //Checks the condition of each cell in the array using the CountMines methods, and sets the MineCellCondition using the a switch function. 
        {
            foreach(MineButton cell in BoxGrid)
                cell._nearbyMines = CountMines(cell.Row, cell.Column);
        }
    }
}
