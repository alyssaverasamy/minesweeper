using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper.Logic
{
    internal enum MinesCellCondition 
    {
        CellEmpty, 
        CellNearOne, 
        CellNearTwo,
        CellNearThree,
        CellNearFour,
        CellNearFive,
        CellNearSix,
        CellNearSeven,
        CellNearEight,
        CellisMine,     // A cell in the mine grid can potentially have 8 surrounding mines, its very unlikely, but must 
                       // be accounted for. 
    }
}
