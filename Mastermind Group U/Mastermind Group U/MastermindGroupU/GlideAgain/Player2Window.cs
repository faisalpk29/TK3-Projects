using System;
using Microsoft.SPOT;
using GHI.Glide;
namespace GlideAgain
{
    class Player2Window
    {
        //UI Componenets
        GHI.Glide.Display.Window winPlayer2;
        private GHI.Glide.UI.RadioButton r1;
        private GHI.Glide.UI.RadioButton r2;
        private GHI.Glide.UI.RadioButton r3;
        private GHI.Glide.UI.RadioButton r4;


        //Current Position
        private int currentGroup = 1;
        private int currentLeftRight = 1;
        private int counter = 1;

      
       //Get input from the user
        public Player2Window()
        {

            Glide.FitToScreen = true;
            winPlayer2 = GlideLoader.LoadWindow(Resources.GetString(Resources.StringResources.Player2));
            currentGroup = 1;
            winPlayer2.Render();

            startNewRow();
        }

        public GHI.Glide.Display.Window getPlayer2Win()
        {
            return winPlayer2;
        }

        //Starts a new row from the user
        public void startNewRow()
        {

            r1 = (GHI.Glide.UI.RadioButton)winPlayer2.GetChildByName("r1-" + currentGroup);
            r2 = (GHI.Glide.UI.RadioButton)winPlayer2.GetChildByName("r2-" + currentGroup);
            r3 = (GHI.Glide.UI.RadioButton)winPlayer2.GetChildByName("r3-" + currentGroup);
            r4 = (GHI.Glide.UI.RadioButton)winPlayer2.GetChildByName("r4-" + currentGroup);
            r1.OutlineColor = GHI.Glide.Colors.Red;
            r1.Invalidate();

        }

        //Submit the selected code and forward the request to the 1 Player screen with the selected code
        public int[] submitResult()
        {


            int[] currentSelection = new int[4];
            int currentColor = (int)r1.Color;

            switch (currentColor)
            {
                case 255:
                    currentSelection[0] = 0;
                    break;
                case 32768:
                    currentSelection[0] = 1;
                    break;
                case 16777215:
                    currentSelection[0] = 2;
                    break;
                case 16711680:
                    currentSelection[0] = 3;
                    break;
                case 65535:
                    currentSelection[0] = 4;
                    break;
                case 42495:
                    currentSelection[0] = 5;
                    break;
            }

            currentColor = (int)r2.Color;

            switch (currentColor)
            {
                case 255:
                    currentSelection[1] = 0;
                    break;
                case 32768:
                    currentSelection[1] = 1;
                    break;
                case 16777215:
                    currentSelection[1] = 2;
                    break;
                case 16711680:
                    currentSelection[1] = 3;
                    break;
                case 65535:
                    currentSelection[1] = 4;
                    break;
                case 42495:
                    currentSelection[1] = 5;
                    break;
            }


            currentColor = (int)r3.Color;

            switch (currentColor)
            {
                case 255:
                    currentSelection[2] = 0;
                    break;
                case 32768:
                    currentSelection[2] = 1;
                    break;
                case 16777215:
                    currentSelection[2] = 2;
                    break;
                case 16711680:
                    currentSelection[2] = 3;
                    break;
                case 65535:
                    currentSelection[2] = 4;
                    break;
                case 42495:
                    currentSelection[2] = 5;
                    break;
            }


            currentColor = (int)r4.Color;

            switch (currentColor)
            {
                case 255:
                    currentSelection[3] = 0;
                    break;
                case 32768:
                    currentSelection[3] = 1;
                    break;
                case 16777215:
                    currentSelection[3] = 2;
                    break;
                case 16711680:
                    currentSelection[3] = 3;
                    break;
                case 65535:
                    currentSelection[3] = 4;
                    break;
                case 42495:
                    currentSelection[3] = 5;
                    break;
            }

            //listColors[0] = GHI.Glide.Colors.Red;
            //listColors[1] = GHI.Glide.Colors.Green;
            //listColors[2] = GHI.Glide.Colors.White;
            //listColors[3] = GHI.Glide.Colors.Blue;
            //listColors[4] = GHI.Glide.Colors.Yellow;
            //listColors[5] = GHI.Glide.Colors.Orange;


            //int[] currentSelection = new int[4];
            //currentSelection[0] = (int)r1.Color;
            //currentSelection[1] = (int)r2.Color;
            //currentSelection[2] = (int)r3.Color;
            //currentSelection[3] = (int)r4.Color;
            return currentSelection;

        }
     
        #region changeColor
        public  void raceRadio_TapEvent_r1()
        {
            setCounter(getCounter() == 6 ? 0 : getCounter() + 1);


            switch (getCounter())
            {
                case 0: getRb1().SelectedColor = GHI.Glide.Colors.Red;
                    getRb1().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: getRb1().SelectedColor = GHI.Glide.Colors.Green;
                    getRb1().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: getRb1().SelectedColor = GHI.Glide.Colors.White;
                    getRb1().Color = GHI.Glide.Colors.White;
                    break;
                case 3: getRb1().SelectedColor = GHI.Glide.Colors.Blue;
                    getRb1().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4: getRb1().SelectedColor = GHI.Glide.Colors.Yellow;
                    getRb1().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: getRb1().SelectedColor = GHI.Glide.Colors.Orange;
                    getRb1().Color = GHI.Glide.Colors.Orange;
                    break;

            }
            getRb1().Invalidate();

        }
        public  void raceRadio_TapEvent_r2()
        {

            setCounter(getCounter() == 6 ? 0 : getCounter() + 1);


            switch (getCounter())
            {
                case 0: getRb2().SelectedColor = GHI.Glide.Colors.Red;
                    getRb2().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: getRb2().SelectedColor = GHI.Glide.Colors.Green;
                    getRb2().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: getRb2().SelectedColor = GHI.Glide.Colors.White;
                    getRb2().Color = GHI.Glide.Colors.White;
                    break;
                case 3: getRb2().SelectedColor = GHI.Glide.Colors.Blue;
                    getRb2().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4: getRb2().SelectedColor = GHI.Glide.Colors.Yellow;
                    getRb2().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: getRb2().SelectedColor = GHI.Glide.Colors.Orange;
                    getRb2().Color = GHI.Glide.Colors.Orange;
                    break;

            }
            getRb2().Invalidate();

        }
        public void raceRadio_TapEvent_r3()
        {

            setCounter(getCounter() == 6 ? 0 : getCounter() + 1);


            switch (getCounter())
            {
                case 0: getRb3().SelectedColor = GHI.Glide.Colors.Red;
                        getRb3().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: getRb2().SelectedColor = GHI.Glide.Colors.Green;
                        getRb3().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: getRb3().SelectedColor = GHI.Glide.Colors.White;
                         getRb3().Color = GHI.Glide.Colors.White;
                    break;
                case 3: getRb3().SelectedColor = GHI.Glide.Colors.Blue;
                         getRb3().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4: getRb3().SelectedColor = GHI.Glide.Colors.Yellow;
                         getRb3().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: getRb3().SelectedColor = GHI.Glide.Colors.Orange;
                        getRb3().Color = GHI.Glide.Colors.Orange;
                    break;

            }

            getRb3().Invalidate();

        }
        public  void raceRadio_TapEvent_r4()
        {

            setCounter(getCounter() == 6 ? 0 : getCounter() + 1);


            switch (getCounter())
            {
                case 0: getRb4().SelectedColor = GHI.Glide.Colors.Red;
                    getRb4().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: getRb4().SelectedColor = GHI.Glide.Colors.Green;
                    getRb4().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: getRb4().SelectedColor = GHI.Glide.Colors.White;
                    getRb4().Color = GHI.Glide.Colors.White;
                    break;
                case 3: getRb4().SelectedColor = GHI.Glide.Colors.Blue;
                    getRb4().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4:getRb4().SelectedColor = GHI.Glide.Colors.Yellow;
                    getRb4().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: getRb4().SelectedColor = GHI.Glide.Colors.Orange;
                    getRb4().Color = GHI.Glide.Colors.Orange;
                    break;

            }
            getRb4().Invalidate();

        }

        public void changeColor()
        {
            if (currentLeftRight == 1) raceRadio_TapEvent_r1();
            if (currentLeftRight == 2) raceRadio_TapEvent_r2();
            if (currentLeftRight == 3) raceRadio_TapEvent_r3();
            if (currentLeftRight == 4) raceRadio_TapEvent_r4();
        }
        
        #endregion

        #region left right events
        public  void leftEventFired()
        {
            if (getCurrentLeftRight() == 1) return;

            setCurrentLeftRight(getCurrentLeftRight() - 1);

            if (getCurrentLeftRight() == 1)
            {
                getRb2().OutlineColor = GHI.Glide.Colors.White;
                getRb2().Invalidate();

                getRb1().OutlineColor = GHI.Glide.Colors.Red;
                getRb1().Invalidate();


            }
            if (getCurrentLeftRight() == 2)
            {
                getRb3().OutlineColor = GHI.Glide.Colors.White;
                getRb3().Invalidate();

                getRb2().OutlineColor = GHI.Glide.Colors.Red;
                getRb2().Invalidate();

            }
            if (getCurrentLeftRight() == 3)
            {

                getRb4().OutlineColor = GHI.Glide.Colors.White;
                getRb4().Invalidate();

                getRb3().OutlineColor = GHI.Glide.Colors.Red;
                getRb3().Invalidate();
            }


        }

        public  void rightEventFired()
        {
            if (getCurrentLeftRight() == 4) return;
            setCurrentLeftRight(getCurrentLeftRight() + 1);


            if (getCurrentLeftRight() == 2)
            {

                getRb1().OutlineColor = GHI.Glide.Colors.White;
                getRb1().Invalidate();

                getRb2().OutlineColor = GHI.Glide.Colors.Red;
                getRb2().Invalidate();


            }
            if (getCurrentLeftRight() == 3)
            {

                getRb2().OutlineColor = GHI.Glide.Colors.White;
                getRb2().Invalidate();

                getRb3().OutlineColor = GHI.Glide.Colors.Red;
                getRb3().Invalidate();

            }
            if (getCurrentLeftRight() == 4)
            {

                getRb3().OutlineColor = GHI.Glide.Colors.White;
                getRb3().Invalidate();

                getRb4().OutlineColor = GHI.Glide.Colors.Red;
                getRb4().Invalidate();

            }

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
