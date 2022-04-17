using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Minesweeper.PlayerLogic
{
    internal class Player : INotifyPropertyChanged
    {
        private int _playerID;
        private string _playerName;
        private int _playerWins;

        public event PropertyChangedEventHandler PropertyChanged;

        public int PlayerID
        {
            get { return _playerID; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Player ID cannot be 0 or less than 0");
                _playerID = value;
            }
        }

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name cannot be empty");
                _playerName = value;
            }
        }

        public int PlayerWins
        {
            get { return _playerWins; }
            set
            {
                _playerWins = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerWins)));
            }
        }




        public Player(int playerID, string playerName, int playerWins)
        {
            PlayerID = playerID;
            PlayerName = playerName;
            PlayerWins = playerWins;

        }


        public void UpdateWins()
        {
            PlayerWins++;


        }



        public override bool Equals(object obj)
        {
            Player objPlayer = obj as Player;
            if (objPlayer == null)
                return false;
            return objPlayer.PlayerID == PlayerID;
        }

        public override int GetHashCode()
        {
            return PlayerID.GetHashCode();
        }

        public static Player Parse(string playerAsString)
        {
            Player player = null;
            string[] parameters = playerAsString.Split(',');
            int playerID = int.Parse(parameters[0].Trim());
            string playerName = parameters[1].Trim();
            int playerWins = int.Parse(parameters[2].Trim());
            player = new Player(playerID, playerName, playerWins);
            return player;

        }
        public override string ToString()
        {
            return $"{PlayerID}, {PlayerName}, {PlayerWins}";
        }
    }
}
