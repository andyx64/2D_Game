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

namespace _2dGame
{
    static class PlayerMovement
    {


        public static double PlayerDirectionX(object sender, KeyEventArgs e, double x, double speedX)
        {
            if (e.Key == Key.A)
            {
                x = -speedX;
            }
            if (e.Key == Key.D)
            {
                x = speedX;
            }
            return x;
        }
        public static double PlayerDirectionY(object sender, KeyEventArgs e, double y, double speedY, bool top)
        {
            if (e.Key == Key.W && top == true)
            {
                y = -speedY;
            }
            if (e.Key == Key.S)
            {
                y = speedY / 2;
            }
            return y;
        }
        public static double KeyResetY(object sender, KeyEventArgs e, double y)
        {
            /* if (e.Key == Key.W)
             {
                 y = -0;
             }*/
            if (e.Key == Key.S)
            {
                y = 0;
            }
            return y;
        }
        public static double KeyResetX(object sender, KeyEventArgs e, double x)
        {
            if (e.Key == Key.A)
            {
                x = 0;
            }
            if (e.Key == Key.D)
            {
                x = 0;
            }
            return x;
        }
        public static void PlayerMove(Canvas playerground, PlayerObject playerobj,bool coindetect)
        {

            if (Collision.CollisionDetectTop(playerground, playerobj, coindetect) == false && Collision.CollisonDetectBottom(playerground, playerobj,coindetect) == false)
            {
                playerobj.GetTop += playerobj.Y;
            }
            else
            {
                if (playerobj.Y < 0 && Collision.CollisionDetectTop(playerground, playerobj, coindetect) == true)
                {
                    playerobj.GetTop += playerobj.Y;

                }
                if (playerobj.Y > 0 && Collision.CollisonDetectBottom(playerground, playerobj, coindetect) == true)
                {
                    playerobj.GetTop += playerobj.Y;
                }
            }
            if (Collision.CollisionDetectRight(playerground, playerobj, coindetect) == false && Collision.CollisonDetectLeft(playerground, playerobj, coindetect) == false)
            {
                playerobj.GetLeft += playerobj.X;
            }
            else
            {
                if (playerobj.X < 0 && Collision.CollisonDetectLeft(playerground, playerobj, coindetect) == true)
                {
                    playerobj.GetLeft += playerobj.X;
                }
                if (playerobj.X > 0 && Collision.CollisionDetectRight(playerground, playerobj, coindetect) == true)
                {
                    playerobj.GetLeft += playerobj.X;
                }
            }
        }
    }
}
