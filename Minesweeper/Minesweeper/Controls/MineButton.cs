using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minesweeper.Controls
{
    internal class MineButton : Button
    {
       
        public int rowPosition { get; set; }
        public int columnPosition { get; set; }

      
    }
}

