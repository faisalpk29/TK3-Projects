using System;
using Microsoft.SPOT;
using GHI.Glide;
namespace GlideAgain
{
    class MasterMind
    {
        //UI Components
        GHI.Glide.Display.Window masterMind;
        private GHI.Glide.UI.RadioButton r1;
        private GHI.Glide.UI.RadioButton r2;
        private GHI.Glide.UI.RadioButton r3;
        private GHI.Glide.UI.RadioButton r4;
        private GHI.Glide.UI.TextBlock txtResult;

        //Instance Variables
        private int round = 0;
        private int currentLeftRight = 1;
        private int currentGroup = 1;
        private int yPostition = 45;
        private int counter = 0;

        //Arrays for color codes.
        //solution is the main combination against which the game is being played.
        private int[] solution = new int[4];
        private int[] listColors = new int[6];

        //Determine the completeness of the solution
        int fullyCorrect = 0, halfCorrect = 0;


        //Constructor for 1 Player Game
        public MasterMind()
        {

            Glide.FitToScreen = true;
            masterMind = GlideLoader.LoadWindow(Resources.GetString(Resources.StringResources.MasterMind));
            currentGroup = 1;

            // Generate Random Sequence for colors
            for (int i = 0; i < solution.Length; i++)
            {
                solution[i] = new Random().Next(6);
                Debug.Print("\n Solution  :: " + solution[i]);
            }

            //Add color codes
            listColors[0] = 255;
            listColors[1] = 32768;
            listColors[2] = 16777215;
            listColors[3] = 16711680;
            listColors[4] = 65535;
            listColors[5] = 42495;

            masterMind.Render();
        }

        //Constructor for 2 Players Game
        public MasterMind(int[] newSolution)
        {

            Glide.FitToScreen = true;
            masterMind = GlideLoader.LoadWindow(Resources.GetString(Resources.StringResources.MasterMind));
            currentGroup = 1;

            //Replace the solution with the input given by the user from 2 Player
            solution = newSolution;

            //Add color codes
            listColors[0] = 255;
            listColors[1] = 32768;
            listColors[2] = 16777215;
            listColors[3] = 16711680;
            listColors[4] = 65535;
            listColors[5] = 42495;

            masterMind.Render();
        }


        public GHI.Glide.Display.Window getGameWindow()
        {
            return masterMind;
        }


        //Starts a new Row
        public void startNewRow()
        {
            r1 = (GHI.Glide.UI.RadioButton)masterMind.GetChildByName("r1-" + currentGroup);
            r2 = (GHI.Glide.UI.RadioButton)masterMind.GetChildByName("r2-" + currentGroup);
            r3 = (GHI.Glide.UI.RadioButton)masterMind.GetChildByName("r3-" + currentGroup);
            r4 = (GHI.Glide.UI.RadioButton)masterMind.GetChildByName("r4-" + currentGroup);

            r1.OutlineColor = GHI.Glide.Colors.Red;
            r1.Invalidate();
        }

        //Submit the result for the row
        public bool submitResult()
        {
            int pinLocation = 0;
            ++round;

            fullyCorrect = 0;
            halfCorrect = 0;

            int[] places = new int[4] { -1, -1, -1, -1 };
            int[] places2 = new int[4] { -1, -1, -1, -1 };


            //Current selection of the color codes
            int[] currentSelection = new int[4];
            currentSelection[0] = (int)r1.Color;
            currentSelection[1] = (int)r2.Color;
            currentSelection[2] = (int)r3.Color;
            currentSelection[3] = (int)r4.Color;

            ////Check At exact same position
            for (int i = 0; i < solution.Length; i++)
            {
                if (currentSelection[i] == listColors[solution[i]])
                {
                    fullyCorrect++;
                    places[i] = 1;
                    places2[i] = 1;
                    //TheScore.AddBlackPeg(CurrentRow, pinLocation);
                    pinLocation++;
                }
            }



            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // make sure the positions aren't the same and the pegs in the different positions
                    // both in the solution and the player row haven't already been determined
                    if ((i != j) && (places[i] != 1) && (places2[j] != 1))
                    {
                        // if the GuessedRow color matches the Grid Color at a different position
                        // We have a white peg
                        if (currentSelection[i] == listColors[solution[j]])
                        {
                            //TheScore.AddWhitePeg(CurrentRow, pinLocation);
                            pinLocation++;
                            places[i] = 1;
                            places2[j] = 1;
                            halfCorrect++;
                            break;
                        }
                    }
                }
            }

            bool result = populateVisualResult(fullyCorrect, halfCorrect);

            yPostition += 20;

            masterMind.Render();
            masterMind.Invalidate();
            resetOutline();


            //change later
            if (currentGroup < 10) currentGroup++;
            else currentGroup = 0;

            if (!result)
            {
                startNewRow();
            }


            return result;

        }
        
        //Reset the check boxes upon changing the row
        public void resetOutline()
        {
            r1.OutlineColor = GHI.Glide.Colors.White;
            r1.Invalidate();
            r2.OutlineColor = GHI.Glide.Colors.White;
            r2.Invalidate();
            r3.OutlineColor = GHI.Glide.Colors.White;
            r3.Invalidate();
            r4.OutlineColor = GHI.Glide.Colors.White;
            r4.Invalidate();

            currentLeftRight = 1;
        }

        //getter for the varibale fully correct
        public int getFullyCorrect()
        {
            return fullyCorrect;
        }

        #region Show Result
        // Show result for each row in the rectangles
        private bool populateVisualResult(int fc, int hc)
        {
            bool result = false;
            int fullWrong = 4 - (fc + hc);
            GHI.Glide.UI.Canvas canvas = new GHI.Glide.UI.Canvas();
            int xPosition = 100;
            masterMind.AddChild(canvas);
            for (int i = 0; i < fc; i++)
            {
                xPosition += 20;
                canvas.DrawRectangle(GHI.Glide.Colors.Green, 1, xPosition, yPostition, 10, 10, 0, 0, GHI.Glide.Colors.Green, 0, 0, GHI.Glide.Colors.Green, 0, 0, 100);

            }

            for (int i = 0; i < hc; i++)
            {
                xPosition += 20;
                canvas.DrawRectangle(GHI.Glide.Colors.Gray, 1, xPosition, yPostition, 10, 10, 0, 0, GHI.Glide.Colors.Gray, 0, 0, GHI.Glide.Colors.Gray, 0, 0, 100);

            }

            for (int i = 0; i < fullWrong; i++)
            {
                xPosition += 20;
                canvas.DrawRectangle(GHI.Glide.Colors.Red, 1, xPosition, yPostition, 10, 10, 0, 0, GHI.Glide.Colors.Red, 0, 0, GHI.Glide.Colors.Red, 0, 0, 100);
            }


            if (fc == 4 | round == 10)
            {
                showResultCode(canvas);
                txtResult = (GHI.Glide.UI.TextBlock)masterMind.GetChildByName("txtResult");
                if (fc == 4)
                {
                    txtResult.Text = "You Win!  ";
                    txtResult.FontColor = GHI.Glide.Colors.Green;
                }
                else
                {
                    txtResult.Text = "You Lost ! Code is :  ";
                    txtResult.FontColor = GHI.Glide.Colors.Red;
                }
                result = true;
            }

            return result;

        }

        // Show final result at the top
        private void showResultCode(GHI.Glide.UI.Canvas canvas)
        {
            int xPos = 180;
            for (int i = 0; i < 4; i++)
            {

                if (listColors[solution[i]] == 255) canvas.DrawRectangle(GHI.Glide.Colors.Red, 1, xPos, 10, 15, 15, 0, 0, GHI.Glide.Colors.Red, 0, 0, GHI.Glide.Colors.Red, 0, 0, 100);
                else if (listColors[solution[i]] == 32768) canvas.DrawRectangle(GHI.Glide.Colors.Green, 1, xPos, 10, 15, 15, 0, 0, GHI.Glide.Colors.Green, 0, 0, GHI.Glide.Colors.Green, 0, 0, 100);
                else if (listColors[solution[i]] == 16777215) canvas.DrawRectangle(GHI.Glide.Colors.White, 1, xPos, 10, 15, 15, 0, 0, GHI.Glide.Colors.White, 0, 0, GHI.Glide.Colors.White, 0, 0, 100);
                else if (listColors[solution[i]] == 16711680) canvas.DrawRectangle(GHI.Glide.Colors.Blue, 1, xPos, 10, 15, 15, 0, 0, GHI.Glide.Colors.Blue, 0, 0, GHI.Glide.Colors.Blue, 0, 0, 100);
                else if (listColors[solution[i]] == 65535) canvas.DrawRectangle(GHI.Glide.Colors.Yellow, 1, xPos, 10, 15, 15, 0, 0, GHI.Glide.Colors.Yellow, 0, 0, GHI.Glide.Colors.Yellow, 0, 0, 100);
                else if (listColors[solution[i]] == 42495) canvas.DrawRectangle(GHI.Glide.Colors.Orange, 1, xPos, 10, 15, 15, 0, 0, GHI.Glide.Colors.Orange, 0, 0, GHI.Glide.Colors.Orange, 0, 0, 100);
                xPos += 20;


            }

        }
        #endregion

        #region UpDownLeftRight
        public void leftEventFired()
        {
            GameUtil.leftEventFired(this);

        }

        public void rightEventFired()
        {
            GameUtil.rightEventFired(this);

        }


        public void changeColor()
        {
            if (currentLeftRight == 1) GameUtil.raceRadio_TapEvent_r1(this);
            if (currentLeftRight == 2) GameUtil.raceRadio_TapEvent_r2(this);
            if (currentLeftRight == 3) GameUtil.raceRadio_TapEvent_r3(this);
            if (currentLeftRight == 4) GameUtil.raceRadio_TapEvent_r4(this);
        }
        #endregion

        #region gettersAndSetters
        public GHI.Glide.UI.RadioButton getRb1()
        {
            return this.r1;
        }

        public GHI.Glide.UI.RadioButton getRb2()
        {
            return this.r2;
        }

        public GHI.Glide.UI.RadioButton getRb3()
        {
            return this.r3;
        }

        public GHI.Glide.UI.RadioButton getRb4()
        {
            return this.r4;
        }

        public int getCurrentLeftRight()
        {
            return this.currentLeftRight;
        }

        public void setCurrentLeftRight(int clr)
        {
            this.currentLeftRight = clr;
        }

        public int getCounter()
        {
            return this.counter;
        }

        public void setCounter(int c)
        {
            this.counter = c;
        }

        #endregion

    }




}
