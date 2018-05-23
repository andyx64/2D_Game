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
using System.Media;
using System.Windows.Threading;

namespace _2dGame
{
    /// <summary>
    /// Interaktionslogik für TitleScreen.xaml
    /// </summary>
    public partial class TitleScreen : Page
    {
        int click_counter = 0;


        public TitleScreen()
        {
            InitializeComponent();
            
            GraphicalEffects.TitleScreenBackground(background1, background2, background3, background4, background5,background11,background21,background31,background41,background51, 1);
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (click_counter == 0)
            {
                GraphicalEffects.StartTransition<MainWindow>(titlescreen_canvas, Titlescreen_Page);
                //Titlescreen_Page.NavigationService.Navigate( new MainWindow());
                click_counter++;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GraphicalEffects.StartTransition<ServerPage>(titlescreen_canvas, Titlescreen_Page);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
    }

