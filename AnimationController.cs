using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _2dGame
{
    class AnimationController
    {
        List<string> idle = new List<string>

{
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle1.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle2.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle3.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle4.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle5.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle6.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle7.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle8.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle9.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle10.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle11.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Idle/idle12.png",
};


        List<string> run =  new List<string>
    {
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run1.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run2.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run3.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run4.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run5.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run6.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run7.png",
        "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Run/run8.png",
    };

        List<string> coinAnimation = new List<string>
        {     "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Coin/coin1.png",
              "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Coin/coin2.png",
              "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Coin/coin3.png",
              "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Coin/coin4.png",
              "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Coin/coin5.png",
              "pack://application:,,,/2dGame;component/Resource/Animation/Animation_Coin/coin6.png",
};

        int playerCounter = 0;
        int coinCounter = 0;

        public void PlayPlayerAnimation(Rectangle Player_Canvas, PlayerObject playerobj)
        {

            if (playerobj.X == 0)
            {
                if (playerCounter >= idle.Count)
                {
                    playerCounter = 0;
                }
                Player_Canvas.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(idle[playerCounter], UriKind.Absolute))
                };
                playerCounter++;
            }
            else
            {
                if (playerobj.X < 0)
                {
                    Player_Canvas.LayoutTransform = new ScaleTransform(1, 1, 0, 0);
                }
                else
                {
                    Player_Canvas.LayoutTransform = new ScaleTransform(-1, 1, 0, 0);
                }

                if (playerCounter >= run.Count)
                {
                    playerCounter = 0;
                }
                Player_Canvas.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(run[playerCounter], UriKind.Absolute))
                };
                playerCounter++;
            }

        }
        public void PlayCoinAnimation(Shape coin)
        {
            if (coinCounter >= coinAnimation.Count)
            {
                coinCounter = 0;
            }
            coin.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(coinAnimation[coinCounter], UriKind.Absolute))
            };
            coinCounter++;
        }
        public void PlayCoinAnimation(Canvas playground, PlayerObject playerobj, double visibleOffset)
        {

            if (coinCounter >= coinAnimation.Count)
            {
                coinCounter = 0;
            }
            foreach (Shape element in playground.Children)
            {
                if (Equals(element.GetType(), typeof(Ellipse)) && (Canvas.GetLeft(element) > playerobj.GetLeft - visibleOffset && Canvas.GetLeft(element) < playerobj.GetLeft + visibleOffset))
                {
                    element.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(coinAnimation[coinCounter], UriKind.Absolute))
                    };
                }

            }
            coinCounter++;

        }

    }
}
