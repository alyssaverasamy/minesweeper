using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Mine.AppService;

namespace Mine.PlayerLogic
{
    internal class PlayerRepository
    {
        private ObservableCollection<Player> _players = new ObservableCollection<Player>();

        public ObservableCollection<Player> Players => _players;
        public void AddPlayer(Player newPlayer)
        {
            foreach (Player player in _players)
                if (player.PlayerID == newPlayer.PlayerID)
                    throw new Exception("Duplicate Player IDs, Please Re-enter");
            _players.Add(newPlayer);
        }

        public Player SearchPlayer(Player searchedPlayer)
        {
            List<Player> searchlist = new List<Player>(Players);
            Player foundPlayer = searchlist.Find(x => x.PlayerID == searchedPlayer.PlayerID);
            return foundPlayer;

        }

        public void SaveAllPlayers(IPlayerManager playerManager)
        {
            playerManager.SaveAll(Players);
        }
        public void ReadAllPlayers(IPlayerManager playerManager)
        {
            List<Player> savedList = playerManager.ReadAll();
            foreach (Player player in savedList)
            {
                _players.Add(player);
            }
        }


    }
}
