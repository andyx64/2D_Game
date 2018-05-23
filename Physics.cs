using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _2dGame
{
    static class Physics
    {
        public static void Gravity(Canvas playground, PlayerObject playerobj)
        {
            if (Collision.CollisionDetectTop(playground, playerobj,false) == false)
            {
                playerobj.Y += 0.1;
            }
            else
            {
                playerobj.Y = 0;
            }  
        }

    }
}
