using System;
using System.Collections.Generic;
using System.Text;
using Minesweeper.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minesweeper.Controls
{
    internal class MineButton : Button
    {
       
        public int Row { get; set; }
        public int Column { get; set; }

        internal int _nearbyMines;

        public bool isMine;

        public bool isFlagged; 

        public MineButton(int row, int column, int cellCondition)
        {
            Row = row;
            Column = column;
            _nearbyMines = cellCondition; 
        }
      
    }
}

