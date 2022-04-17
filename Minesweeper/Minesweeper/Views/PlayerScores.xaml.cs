using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.PlayerLogic;
using Minesweeper.GameService;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;



namespace Minesweeper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerScores : ContentPage
    {
        PlayerRepository playerRepository = new PlayerRepository();
        IPlayerManager _playerManager;

        string _filePath = Path.Combine(FileSystem.AppDataDirectory, "players.csv");

        public PlayerScores()
        {
            InitializeComponent();
            _playerManager = new PlayerCSVManager(_filePath);
            ReadPlayers();
            LstofPlayers.ItemsSource = playerRepository.Players;
        }

        private Player CapturePlayerInfo()
        {
            int id = int.Parse(EntID.Text);
            string name = EntName.Text;
            int firstWin = 1;

            Player newPlayer = new Player(id, name, firstWin);

            return newPlayer;
        }

        private void AddPLayer_Clicked(object sender, EventArgs e)
        {
            try
            {
                Player newPlayer = CapturePlayerInfo();
                playerRepository.AddPlayer(newPlayer);
            }
            catch (Exception ex)
            {
                DisplayAlert("Something Went Wrong:", ex.Message, "OK");
            }


        }

        private void UpdatePlayer_Clicked(object sender, EventArgs e)
        {
            Player lookUp = LstofPlayers.SelectedItem as Player;

            try
            {
                Player foundPlayer = playerRepository.SearchPlayer(lookUp);

                foundPlayer.PlayerWins++;
            }
            catch (Exception)
            {
                DisplayAlert("Could not find player", "Please re-try", "Re-Try");
            }


        }

        private void SaveAll(object sender, EventArgs e)
        {
            try
            {
                playerRepository.SaveAllPlayers(_playerManager);
            }
            catch (Exception)
            {
                DisplayAlert("Writing Error", "Error while writing players, data is not saved", "OK");
            }
        }

        private void ReadPlayers()
        {
            try
            {
                playerRepository.ReadAllPlayers(_playerManager);
            }
            catch (Exception)
            {
                DisplayAlert("Reading Error", "Cannot Read players", "OK");
            }
        }
    }
}
