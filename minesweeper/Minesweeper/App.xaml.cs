using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Minesweeper.Views;

namespace Minesweeper
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new GameStart(); 
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

