using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2dGame
{
    /// <summary>
    /// Interaktionslogik für GameOverScreen.xaml
    /// </summary>
    public partial class GameOverScreen : Page
    {
        int coins = 0;
        string coinstring;


        public GameOverScreen(int _coins)
        {
            coins = _coins;
            DataContext = this;
            coinstring = "Your Score is " + System.Convert.ToString(coins);
            InitializeComponent();
        
        }

        public int Coins
        {
            get { return coins; }
            set { coins = value;}
        }

        public string CoinString
        {
            get { return coinstring; }
            set { coinstring = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TitleScreen());
        }
    }
}
