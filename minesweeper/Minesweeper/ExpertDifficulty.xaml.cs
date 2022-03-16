using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minesweeper
{
    public partial class ExpertDifficulty : ContentPage
    {
        public ExpertDifficulty()
        {
            InitializeComponent();
            for (int rowI = 0; rowI < 12; rowI++)
            {
                mineGridExpert.RowDefinitions.Add(new RowDefinition());
                mineGridExpert.ColumnDefinitions.Add(new ColumnDefinition());
                for (int colI = 0; colI < 12; colI++)
                {
                    Button mineBox = new Button();
                    mineBox.BackgroundColor = Color.LightGray;
                    mineGridExpert.Children.Add(mineBox, rowI, colI);
                }
            }
        }
    }
}