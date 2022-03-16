using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minesweeper
{

    public partial class BegginerDifficulty : ContentPage
    {
        public BegginerDifficulty()
        {
            InitializeComponent();

            for(int rowI = 0; rowI < 8; rowI++)
            {
                mineGridBegginer.RowDefinitions.Add(new RowDefinition());
                mineGridBegginer.ColumnDefinitions.Add(new ColumnDefinition());
                for (int colI = 0; colI < 8; colI ++)
                {
                    Button mineBox = new Button();
                    mineBox.BackgroundColor = Color.LightGray;
                    mineGridBegginer.Children.Add(mineBox, rowI, colI); 
                }
            }
        }
    }
}