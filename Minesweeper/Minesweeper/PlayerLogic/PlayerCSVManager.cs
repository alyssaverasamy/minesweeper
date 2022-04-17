using System;
using System.Collections.Generic;
using System.Text;
using Minesweeper.GameService;
using System.IO;

namespace Minesweeper.PlayerLogic 
{
    internal class PlayerCSVManager : IPlayerManager
    {
        string _filePath;

        public PlayerCSVManager(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveAll(IEnumerable<Player> playerList)
        {
            List<string> playersAsStrings = new List<string>();
            foreach (Player player in playerList)
            {
                playersAsStrings.Add(player.ToString());
            }
            File.WriteAllLines(_filePath, playersAsStrings);
        }

        public List<Player> ReadAll()
        {
            List<Player> playerList = new List<Player>();
            string[] playersAsString = File.ReadAllLines(_filePath);
            foreach (string playerAsString in playersAsString)
            {
                Player player = Player.Parse(playerAsString);
                playerList.Add(player);
            }
            return playerList;
        }
    }
}
