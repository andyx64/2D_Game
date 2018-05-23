using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2dGame
{
    class SoundController
    {
        MediaPlayer mplayer = new MediaPlayer();

        public void PlaySound(Rectangle Player_Canvas, double x, double y)
        {

            mplayer.Open(new Uri("pack://application:,,,/2dGame;component/Resource/Sounds/Effects/footstep1.mp3", UriKind.Absolute));

            mplayer.Play();
        }
    }
}
