using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minesweeper
{
    public partial class IntermediateDifficulty : ContentPage
    {
        public IntermediateDifficulty()
        {
            InitializeComponent();
            for (int rowI = 0; rowI < 10; rowI++)
            {
                mineGridIntermediate.RowDefinitions.Add(new RowDefinition());
                mineGridIntermediate.ColumnDefinitions.Add(new ColumnDefinition());
                for (int colI = 0; colI < 10; colI++)
                {
                    Button mineBox = new Button();
                    mineBox.BackgroundColor = Color.LightGray;
                    mineGridIntermediate.Children.Add(mineBox, rowI, colI);
                }
            }

        }
    }
}