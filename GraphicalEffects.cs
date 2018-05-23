using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace _2dGame
{
    static class GraphicalEffects
    {
        public static void StartTransition<T>(Canvas transitionCanvas, Page page)
        {
            int counter = 0;
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {

                if (counter != 100)
                {
                    transitionCanvas.Opacity = transitionCanvas.Opacity -= 0.05;
                }
                else if (counter == 100)
                {
                    transitionCanvas.Opacity = 100;
                    page.NavigationService.Navigate( (T)Activator.CreateInstance(typeof(T)));
                }
                counter += 1;
            }
        }
        public static void EndTransiton(Canvas transitionCanvas, Page page)
        {
            transitionCanvas.Opacity = 0;
            int counter = 0;
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {

                if (counter != 100)
                {
                    transitionCanvas.Opacity = transitionCanvas.Opacity += 0.05;
                }
                else if (counter == 100)
                {
                    transitionCanvas.Opacity = 100;
                }
                counter += 1;
            }
        }
        public static void TitleScreenBackground(Image a, Image b, Image c, Image d, Image f, Image a1, Image b1, Image c1, Image d1, Image f1, double speed)
        {

            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {

                Canvas.SetLeft(a, Canvas.GetLeft(a) - speed / 16);
                Canvas.SetLeft(b, Canvas.GetLeft(b) - speed / 8);
                Canvas.SetLeft(c, Canvas.GetLeft(c) - speed / 4);
                Canvas.SetLeft(d, Canvas.GetLeft(d) - speed / 2);
                Canvas.SetLeft(f, Canvas.GetLeft(f) - speed);
                Canvas.SetLeft(a1, Canvas.GetLeft(a1) - speed / 16);
                Canvas.SetLeft(b1, Canvas.GetLeft(b1) - speed / 8);
                Canvas.SetLeft(c1, Canvas.GetLeft(c1) - speed / 4);
                Canvas.SetLeft(d1, Canvas.GetLeft(d1) - speed / 2);
                Canvas.SetLeft(f1, Canvas.GetLeft(f1) - speed);

                if (Canvas.GetLeft(a) < -a.ActualWidth)
                {
                    Canvas.SetLeft(a, Canvas.GetLeft(a1) + a1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(b) < -b.ActualWidth)
                {
                    Canvas.SetLeft(b, Canvas.GetLeft(b1) + b1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(c) < -c.ActualWidth)
                {
                    Canvas.SetLeft(c, Canvas.GetLeft(c1) + c1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(d) < -d.ActualWidth)
                {
                    Canvas.SetLeft(d, Canvas.GetLeft(d1) + d1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(f) < -f.ActualWidth)
                {
                    Canvas.SetLeft(f, Canvas.GetLeft(f1) + f1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(a1) < -a1.ActualWidth)
                {
                    Canvas.SetLeft(a1, Canvas.GetLeft(a) + a.ActualWidth - 2);
                }
                if (Canvas.GetLeft(b1) < -b1.ActualWidth)
                {
                    Canvas.SetLeft(b1, Canvas.GetLeft(b) + b.ActualWidth - 2);
                }
                if (Canvas.GetLeft(c1) < -c1.ActualWidth)
                {
                    Canvas.SetLeft(c1, Canvas.GetLeft(c) + c.ActualWidth - 2);
                }
                if (Canvas.GetLeft(d1) < -d1.ActualWidth)
                {
                    Canvas.SetLeft(d1, Canvas.GetLeft(d) + d.ActualWidth - 2);
                }
                if (Canvas.GetLeft(f1) < -f1.ActualWidth)
                {
                    Canvas.SetLeft(f1, Canvas.GetLeft(f) + f.ActualWidth - 2);
                }
            }

        }


        public static void IngameScreenBackground_1(Image a, Image a1, double speed, double x, double windowWidth, bool leftCollison, bool rightCollison)
        {
            if (rightCollison == false && leftCollison == false)
            {
                Canvas.SetLeft(a, Canvas.GetLeft(a) - speed * x);
                Canvas.SetLeft(a1, Canvas.GetLeft(a1) - speed * x);
            }


            if (x > 0)
            {
                if (Canvas.GetLeft(a) < -a.ActualWidth)
                {
                    Canvas.SetLeft(a, Canvas.GetLeft(a1) + a1.ActualWidth - 2);
                }
                if (Canvas.GetLeft(a1) < -a1.ActualWidth)
                {
                    Canvas.SetLeft(a1, Canvas.GetLeft(a) + a.ActualWidth - 2);
                }
            }
            if (x < 0)
            {
                if (Canvas.GetLeft(a) > a.ActualWidth)
                {
                    Canvas.SetLeft(a, Canvas.GetLeft(a1) - a1.ActualWidth + 2);
                }
                if (Canvas.GetLeft(a1) > a1.ActualWidth)
                {
                    Canvas.SetLeft(a1, Canvas.GetLeft(a) - a.ActualWidth + 2);
                }
            }

        }


        public static void IngameScreenBackground_5(Image a, Image b, Image c, Image d, Image f, Image a1, Image b1, Image c1, Image d1, Image f1, double speed, double x, double windowWidth, bool leftCollison, bool rightCollison)
        {
            GraphicalEffects.IngameScreenBackground_1(a, a1, speed / 16, x, windowWidth, leftCollison, rightCollison);
            GraphicalEffects.IngameScreenBackground_1(b, b1, speed / 8, x, windowWidth, leftCollison, rightCollison);
            GraphicalEffects.IngameScreenBackground_1(c, c1, speed / 4, x, windowWidth, leftCollison, rightCollison);
            GraphicalEffects.IngameScreenBackground_1(d, d1, speed / 2, x, windowWidth, leftCollison, rightCollison);
            GraphicalEffects.IngameScreenBackground_1(f, f1, speed, x/1.3, windowWidth, leftCollison, rightCollison);
        }




        /* public static void IngameScreenBackground(Canvas ParralaxCanvas, double x)
         {
             string[] parralax = new string[]
             {
                 "pack://application:,,,/2dGame;component/Resource/PNG/Parallax_background/plx-1.png",
                 "pack://application:,,,/2dGame;component/Resource/PNG/Parallax_background/plx-2.png",
                 "pack://application:,,,/2dGame;component/Resource/PNG/Parallax_background/plx-3.png",
                 "pack://application:,,,/2dGame;component/Resource/PNG/Parallax_background/plx-4.png",
                 "pack://application:,,,/2dGame;component/Resource/PNG/Parallax_background/plx-5.png",
             };
             foreach(string element in parralax)
             {
                 Image image = new Image();
                 image.Source = new BitmapImage(new Uri(element, UriKind.Absolute));

                 Canvas.SetLeft(image, 1);
                 Canvas.SetTop(image, 1);
                 ParralaxCanvas.Children.Add(image);
             }
         }*/
    }

}
