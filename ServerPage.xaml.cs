using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaktionslogik für ServerPage.xaml
    /// </summary>
    public partial class ServerPage : INotifyPropertyChanged
    {
        string localip;
        public event PropertyChangedEventHandler PropertyChanged;

        public ServerPage()
        {
            DataContext = this;
            InitializeComponent();
            LocalIP = ServerClient.GetLocalIp();
            GraphicalEffects.TitleScreenBackground(background1, background2, background3, background4, background5, background11, background21, background31, background41, background51, 1);
        }

        public string LocalIP
        {
            get { return localip; }
            set { localip = value; NotifyPropertyChanged(); }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindows_Multiplayer main;
            try
            {              
                main = new MainWindows_Multiplayer(localIP_page.Text, localPORT_page.Text, remoteIP_page.Text, remotePORT_page.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Ungültige IP!" + ex);
                return;
            }
            
           
            serverpage.NavigationService.Navigate(main);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            serverpage.NavigationService.Navigate(new TitleScreen());
        }
    }
}
