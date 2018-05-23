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

namespace _2dGame
{
    static class CameraMovement
    {
        public static void CameraFollow(PlayerObject playerobj, ScrollViewer scroller, double offset)
        {
            scroller.ScrollToHorizontalOffset(playerobj.GetLeft - offset);
            scroller.ScrollToVerticalOffset(playerobj.GetTop - offset);
        }

    }
}
