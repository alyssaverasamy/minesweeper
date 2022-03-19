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

            _boxGrid = new MineButton[_nbrRows, _nbrCols];
            for (var rowCount = 0; rowCount < _nbrRows; rowCount++)
            {
                for (var colCount = 0; colCount < _nbrCols; colCount++)
                {
                    MineButton button = new MineButton();
                    button.BackgroundColor = Color.LightGray;
                    _boxGrid[rowCount, colCount] = button;
                    button.rowPosition = rowCount;
                    button.columnPosition = colCount;

                }
            }
        }
    }
}
