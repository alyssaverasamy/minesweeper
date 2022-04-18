using System;
using System.Collections.Generic;
using System.Text;
using Minesweeper.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//author: tejas, code cleanup: alyssa

namespace Minesweeper.Controls
{
    internal class MineButton : ImageButton
    {

        public int Row => _row;
        public int Column => _column; 

        internal int _nearbyMines;

        public bool isMine;

        public bool isFlagged;


        private int _row;    
        private int _column; 

        public MineButton(int row, int column, int cellCondition)
        {
            _row = row;
            _column = column;
            _nearbyMines = cellCondition; 
        }
      
    }
}

