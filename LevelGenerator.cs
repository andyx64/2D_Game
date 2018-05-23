using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2dGame
{
    static class LevelGenerator
    {
        public static void CreateLevelDynamic(Shape Player, Canvas Playground)
        {

            for (int i = 250; i <= 30000; i += 200)
            {
                Random rnd = new Random((int)DateTime.Now.Ticks);
                double rndPositionX = rnd.Next(i + 50, i + 200);
                double rndPositionY = rnd.Next(100, 500);
                double rndRectHeight = rnd.Next(20, 50);
                double rndRectWidth = rnd.Next(100, 500);
                int rndCoinTrue = rnd.Next(0, 2);

                Thread.Sleep(1);

                if (rndCoinTrue == 1)
                {
                    int rndWidthint = System.Convert.ToInt32(rndRectWidth);
                    double tmpX = rndPositionX;
                    int times = rndWidthint / 40;

                    for (int a = 0; a < times; a++)
                    {
                        new CoinObject(Playground, tmpX + (40 * a), rndPositionY - 40, 38, 38);
                    }



                }

                Rectangle rect = new Rectangle();
                //rect.Margin = new System.Windows.Thickness(rndPositionX,rndPositionY,0,0);
                rect.Height = rndRectHeight;
                rect.Width = rndRectWidth;
                rect.StrokeThickness = 1;
                rect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/2dGame;component/Resource/PNG/jungle1.png", UriKind.Absolute))
                };
                rect.Stretch = Stretch.Fill;
                rect.RadiusX = 15;
                rect.RadiusY = 15;
                Playground.Children.Add(rect);
                Canvas.SetLeft(rect, rndPositionX);
                Canvas.SetTop(rect, rndPositionY);
            }
        }
            
        public static void CreateLevelStatic(Canvas Playground, int seed)
        {

            for (int i = 0; i <= 30000; i += 200)
            {
                Random rnd = new Random(i*seed);
                double rndPositionX = rnd.Next(i + 50, i + 200);
                double rndPositionY = rnd.Next(100, 500);
                double rndRectHeight = rnd.Next(20, 50);
                double rndRectWidth = rnd.Next(100, 500);
                int rndCoinTrue = rnd.Next(0, 2);

                if (rndCoinTrue == 1)
                {
                    int rndWidthint = System.Convert.ToInt32(rndRectWidth);
                    double tmpX = rndPositionX;
                    int times = rndWidthint / 40;

                    for (int a = 0; a < times; a++)
                    {
                        new CoinObject(Playground, tmpX + (40 * a), rndPositionY - 40, 38, 38);
                    }
                }

                Rectangle rect = new Rectangle();
                //rect.Margin = new System.Windows.Thickness(rndPositionX,rndPositionY,0,0);
                rect.Height = rndRectHeight;
                rect.Width = rndRectWidth;
                rect.StrokeThickness = 1;
                rect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/2dGame;component/Resource/PNG/jungle1.png", UriKind.Absolute))
                };
                rect.Stretch = Stretch.Fill;
                rect.RadiusX = 15;
                rect.RadiusY = 15;
                Playground.Children.Add(rect);
                Canvas.SetLeft(rect, rndPositionX);
                Canvas.SetTop(rect, rndPositionY);
            }
        }


    }
}
