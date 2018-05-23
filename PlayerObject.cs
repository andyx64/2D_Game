using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _2dGame
{
    
    
    class PlayerObject : GameObject
    {
        

        private double x;
        private double y;

        private double runSpeedX = 3;
        private double runSpeedY = 6;

        private int coinCounter = 0;

        private bool gameover = false;
        private bool localplayer;

        public delegate void GameOverEventHandler(PlayerObject sender, int e);
        public event GameOverEventHandler GameOver;



        public PlayerObject(double height, double width, double getLeft, double getTop, bool _localplayer)
        {
            GetLeft = getLeft;
            GetTop = getTop;
            Height = height;
            Width = width;
            LocalPlayer = _localplayer;
        }

        public override double GetTop
        {
            get { return getTop; }
            set
            {
                if(value < 800)
                {
                    getTop = value; NotifyPropertyChanged();
                }
                else if(gameover == false)
                {        
                    OnGameOver();
                    gameover = true;
                }              
            }
        }


        public double X
        {
            get { return x; }
            set { x = value; NotifyPropertyChanged(); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; NotifyPropertyChanged(); }
        }
        public double RunSpeedX
        {
            get { return runSpeedX; }
            set { runSpeedX = value; }
        }
        public double RunSpeedY
        {
            get { return runSpeedY; }
            set { runSpeedY = value; }
        }
        public int CoinCounter
        {
            get { return coinCounter; }
            set { coinCounter = value; NotifyPropertyChanged(); }

        }
        public bool LocalPlayer
        {
            get { return localplayer; }
            set { localplayer = value; }
        }

    

        protected virtual void OnGameOver()
        {
            if(GameOver != null)
            {
                GameOver(this, CoinCounter);
            }
        }
    









}
}
