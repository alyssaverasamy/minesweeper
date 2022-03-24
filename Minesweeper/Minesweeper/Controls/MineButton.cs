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

        internal MinesCellCondition _condition; 

        public bool cellisMine;

        public bool cellisFlagged; 

        public MineButton(int colPos, int rowPos, MinesCellCondition cellCondition)
        {
            this._rowPosition = rowPos;
            this._columnPosition = colPos;
            this._condition = cellCondition; 
        }
      
    }
}

