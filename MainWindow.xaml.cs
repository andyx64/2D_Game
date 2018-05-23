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
using System.Threading;

namespace _2dGame
{
    partial class MainWindow : Page
    {

        PlayerObject playerobj = new PlayerObject(74,42,10,10,true);

        AnimationController anim = new AnimationController();
        SoundController sound = new SoundController();
        DebugWindow debug = new DebugWindow();
     

        Task task1;
        Task task2;
        Task task3;


        public MainWindow()
        {
          

            DataContext = playerobj;
            


            debug.DataContext = playerobj;

            
            InitializeComponent();
            playerobj.GameOver += OnGameOver;


            debug.Show();
       
            LevelGenerator.CreateLevelStatic(Background_Canvas, 2);

            GraphicalEffects.EndTransiton(Background_Canvas, MainWindows_Page);
            var PhysicsTimer = new DispatcherTimer();
            PhysicsTimer.Tick += PhysicsTimerTick;
            PhysicsTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            task1 = new Task(PhysicsTimer.Start);


            var AnimationTimer = new DispatcherTimer();
            AnimationTimer.Tick += AnimationTimerTick;
            AnimationTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            task2 = new Task(AnimationTimer.Start);

            var CoinTimer = new DispatcherTimer();
            CoinTimer.Tick += CoinTimerTick;
            CoinTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            task3 = new Task(CoinTimer.Start);

        

            task1.Start();
            task2.Start();
            task3.Start();
        }

        private void PhysicsTimerTick(object sender, EventArgs e)
        {
            PlayerMovement.PlayerMove(Background_Canvas, playerobj,true);
            Physics.Gravity(Background_Canvas, playerobj);
            CameraMovement.CameraFollow(playerobj, Scroller, 250);
            GraphicalEffects.IngameScreenBackground_5(background1, background2, background3, background4, background5, background11, background21, background31, background41, background51, 1, playerobj.X, MainWindows_Page.ActualWidth, Collision.CollisonDetectLeft(Background_Canvas, playerobj,false), Collision.CollisionDetectRight(Background_Canvas, playerobj,false));
        }
        private void AnimationTimerTick(object sender, EventArgs e)
        {
            anim.PlayPlayerAnimation(Player_Canvas, playerobj);
            
        }

        public void CoinTimerTick(object sender, EventArgs e)
        {
            anim.PlayCoinAnimation(Background_Canvas,playerobj,600);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            playerobj.X = PlayerMovement.PlayerDirectionX(sender, e, playerobj.X, playerobj.RunSpeedX);
            playerobj.Y = PlayerMovement.PlayerDirectionY(sender, e, playerobj.Y, playerobj.RunSpeedY, Collision.CollisionDetectTop(Background_Canvas, playerobj,false));

            if(e.Key == Key.Escape)
            {
                this.NavigationService.Navigate(new TitleScreen());
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            playerobj.X = PlayerMovement.KeyResetX(sender, e, playerobj.X);
            playerobj.Y = PlayerMovement.KeyResetY(sender, e, playerobj.Y);
        }

        private void OnGameOver(PlayerObject sender, int e)
        {
                NavigationService.Navigate(new GameOverScreen(e));
        }

    }
}




