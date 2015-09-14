using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;
using GHI.Glide;
using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

using GHI.Glide.Display;
using GHI.Glide.UI;

namespace GlideAgain
{

    public partial class Program
    {

        // Screen 1
        private static GHI.Glide.Display.Window mainWindow;
        private GHI.Glide.UI.Button btn1Player;
        private GHI.Glide.UI.Button btn2Player;

        // Screen 2
        //private static GHI.Glide.Display.Window masterMind;
        private MasterMind winMasterMind;
        private Player2Window winPlayer2;
        private int displayHeight;
        private Font f;
        private int fontHeight;

        //joystick
        private Joystick.Position lastJoystickPosition = new Joystick.Position();

        // main color combination to match
        private int[] solution = new int[4];

        //list of color codes and their numbers
        private int[] listColors = new int[6];

        // flags to navigate between screens
        private bool isPlayer1Selected = false;
        private bool isGameScreen = false;
        private bool isGameOver = false;
        private bool isPlayer2Win = false;


        void ProgramStarted()
        {

            Glide.FitToScreen = true;

            //load screen from xml
            mainWindow = GlideLoader.LoadWindow(Resources.GetString(Resources.StringResources.MainWindow));
            winMasterMind = new MasterMind();

            // reference for buttons from first screen
            btn1Player = (GHI.Glide.UI.Button)mainWindow.GetChildByName("btn1Player");
            btn2Player = (GHI.Glide.UI.Button)mainWindow.GetChildByName("btn2Player");

            btn1Player.TintColor = GHI.Glide.Colors.Red;


            //listeners from button clicked
            btn1Player.TapEvent += btn1Player_ButtonPressed;
            btn2Player.TapEvent += btn2Player_ButtonPressed;

            f = Resources.GetFont(Resources.FontResources.NinaB);
            fontHeight = f.Height;
            displayHeight = displayTE35.Height;

            // position for joystick
            double xPos = joystick.GetPosition().X;
            double yPos = joystick.GetPosition().Y;
            GT.Timer jt = new GT.Timer(275);

            jt.Tick += jt_Tick;

            joystick.JoystickPressed += joystick_JoystickPressed;
            jt.Start();

            button.ButtonPressed += button_ButtonPressed;

            Glide.MainWindow = mainWindow;
            GlideTouch.Initialize();



        }

        //Navigate to start screen after button component is pressed after finishing the game
        void button_ButtonPressed(GTM.GHIElectronics.Button sender, GTM.GHIElectronics.Button.ButtonState state)
        {
            if (isGameOver)
            {
                Glide.MainWindow = mainWindow;
                isGameOver = false;
                isGameScreen = false;

                winMasterMind.getGameWindow().Dispose();

            }
        }

        //Events to handle center clicks on the joystick
        void joystick_JoystickPressed(Joystick sender, Joystick.ButtonState state)
        {
            //when the user is on the game screen
            if (isGameScreen)
            {
                isGameOver = winMasterMind.submitResult();

                //user win or lose the game
                if (isGameOver && winMasterMind.getFullyCorrect() == 4)
                {
                    multicolorLED.TurnGreen();
                }
                else
                    multicolorLED.TurnRed();

            }
            // When the user is on the 2 Players screen
            else if (isPlayer2Win)
            {
                //get colors from user 1
                solution = winPlayer2.submitResult();

                isPlayer2Win = false;
                winPlayer2.getPlayer2Win().Dispose();

                //start game for user 1
                startGame(solution);

            }
            else
            {
                if (isPlayer1Selected) btn1Player_ButtonPressed(new Object());
                else btn2Player_ButtonPressed(new Object());
            }



        }

        //Starts a new Game
        private void startGame(int[] newSolution)
        {
            isGameScreen = true;
            isPlayer2Win = false;

            if (newSolution != null) winMasterMind = new MasterMind(newSolution);
            else
                winMasterMind = new MasterMind();

            Glide.MainWindow = winMasterMind.getGameWindow();
            isGameScreen = true;
            winMasterMind.startNewRow();

        }


        //Code Region for Movements of the Joystick
        #region UpDownLeftRight
        private void leftEventFired()
        {
            if (isGameScreen)
            {
                winMasterMind.leftEventFired();
            }
            else if (isPlayer2Win)
            {
                winPlayer2.leftEventFired();
            }

        }

        private void rightEventFired()
        {
            if (isGameScreen)
            {
                winMasterMind.rightEventFired();
            }
            else if (isPlayer2Win)
            {
                winPlayer2.rightEventFired();
            }


        }

        private void downEventFired()
        {
            if (isGameScreen) winMasterMind.changeColor();
            else if (isPlayer2Win) winPlayer2.changeColor();
            else selectPlayer2();
        }

        private void upEventFired()
        {
            if (isGameScreen) winMasterMind.changeColor();
            else if (isPlayer2Win) winPlayer2.changeColor();
            else selectPlayer1();
        }

        #endregion


        //Select Player Mode from the Start Screen
        #region Start Screen

        void btn2Player_ButtonPressed(Object sender)
        {
            winPlayer2 = new Player2Window();
            Glide.MainWindow = winPlayer2.getPlayer2Win();
            isPlayer2Win = true;
            isGameScreen = false;
            multicolorLED.TurnRed();
        }

        void btn1Player_ButtonPressed(Object sender)
        {
            startGame(null);
        }
        private void selectPlayer1()
        {
            btn2Player.TintColor = GHI.Glide.Colors.White;
            btn2Player.TintAmount = 0;
            btn2Player.Invalidate();

            btn1Player.TintColor = GHI.Glide.Colors.Red;
            btn1Player.TintAmount = 50;
            btn1Player.Invalidate();

            isPlayer1Selected = true;
        }

        private void selectPlayer2()
        {
            btn1Player.TintColor = GHI.Glide.Colors.White;
            btn1Player.TintAmount = 0;
            btn1Player.Invalidate();

            btn2Player.TintColor = GHI.Glide.Colors.Red;
            btn2Player.TintAmount = 50;
            btn2Player.Invalidate();

            isPlayer1Selected = false;
        }
        #endregion


        //Code to handle joystick movements
        #region JoyStickHelpers
        private bool didJoystickMove(Joystick.Position position)
        {
            double realX = 0, realY = 0;
            Joystick.Position newJoystickPosition = position;
            double newX = newJoystickPosition.X - lastJoystickPosition.X;
            double newY = newJoystickPosition.Y - lastJoystickPosition.Y;

            // did we actually move...
            if (System.Math.Abs(newX) >= 0.5) { realX = newX; }
            if (System.Math.Abs(newY) >= 0.5) { realY = newY; }
            if (realX == 0.0 && realY == 0.5) return false;
            Debug.Print("Real x  :: " + realX + "  Real Y :: " + realY);
            return true;
        }

        void jt_Tick(GT.Timer timer)
        {
            Joystick.Position position = joystick.GetPosition();

            if (didJoystickMove(position))
            {
                if (position.Y > .9)
                {
                    upEventFired();
                }
                else if (position.Y < -.9)
                {
                    downEventFired();
                }
                else if (position.X > .9)
                {
                    rightEventFired();
                }
                else if (position.X < -.9)
                {
                    leftEventFired();
                }

                lastJoystickPosition = position;
            }
        }
        #endregion
    }



}
