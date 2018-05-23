using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2dGame
{
    /// <summary>
    /// Interaktionslogik für StartWindow.xaml
    /// </summary>
    /// 
   

    public partial class StartWindow : Window
    {
       
        MediaPlayer mplayer = new MediaPlayer();
    

        public StartWindow()
        {
            mplayer.Open(new Uri("pack://application:,,,/2dGame;component/Resource/Sounds/Music/TitleMusic.mp3"));


            InitializeComponent();

            mplayer.Play();
           
            frame.NavigationService.Navigate(new TitleScreen());


            




        }


        /* private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
         {
             MessageBox.Show(System.Convert.ToString(VisualTreeHelper.GetChildrenCount(this)));
             var child = VisualTreeHelper.GetChild(this,1);
         }*/
    }
}
