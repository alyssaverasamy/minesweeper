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
       
        public int _rowPosition { get; set; }
        public int _columnPosition { get; set; }

        internal int _nearbyMines;

        public bool isMine;

        public bool isFlagged; 

        public MineButton(int colPos, int rowPos, int cellCondition)
        {
            _rowPosition = rowPos;
            _columnPosition = colPos;
            _nearbyMines = cellCondition; 
        }
      
    }
}

