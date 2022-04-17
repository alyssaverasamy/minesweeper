using System;
using System.Collections.Generic;
using System.Text;
using Minesweeper.PlayerLogic;

namespace Minesweeper.GameService
{
    internal interface IPlayerManager
    {
        void SaveAll(IEnumerable<Player> player);

        List<Player> ReadAll();
    }
}
