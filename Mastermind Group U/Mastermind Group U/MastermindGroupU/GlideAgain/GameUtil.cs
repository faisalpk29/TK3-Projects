using System;
using Microsoft.SPOT;

namespace GlideAgain
{
    class GameUtil
    {

        #region changeColor
        public static void raceRadio_TapEvent_r1(MasterMind mm)
        {
            mm.setCounter(mm.getCounter() == 6 ? 0 : mm.getCounter()+1);


            switch (mm.getCounter())
            {
                case 0: mm.getRb1().SelectedColor = GHI.Glide.Colors.Red;
                        mm.getRb1().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: mm.getRb1().SelectedColor = GHI.Glide.Colors.Green;
                        mm.getRb1().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: mm.getRb1().SelectedColor = GHI.Glide.Colors.White;
                        mm.getRb1().Color = GHI.Glide.Colors.White;
                    break;
                case 3: mm.getRb1().SelectedColor = GHI.Glide.Colors.Blue;
                        mm.getRb1().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4: mm.getRb1().SelectedColor = GHI.Glide.Colors.Yellow;
                        mm.getRb1().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: mm.getRb1().SelectedColor = GHI.Glide.Colors.Orange;
                        mm.getRb1().Color = GHI.Glide.Colors.Orange;
                    break;

            }
            mm.getRb1().Invalidate();

        }
        public static void raceRadio_TapEvent_r2(MasterMind mm)
        {

            mm.setCounter(mm.getCounter() == 6 ? 0 : mm.getCounter() + 1);


            switch (mm.getCounter())
            {
                case 0: mm.getRb2().SelectedColor = GHI.Glide.Colors.Red;
                    mm.getRb2().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: mm.getRb2().SelectedColor = GHI.Glide.Colors.Green;
                    mm.getRb2().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: mm.getRb2().SelectedColor = GHI.Glide.Colors.White;
                    mm.getRb2().Color = GHI.Glide.Colors.White;
                    break;
                case 3: mm.getRb2().SelectedColor = GHI.Glide.Colors.Blue;
                    mm.getRb2().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4: mm.getRb2().SelectedColor = GHI.Glide.Colors.Yellow;
                    mm.getRb2().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: mm.getRb2().SelectedColor = GHI.Glide.Colors.Orange;
                    mm.getRb2().Color = GHI.Glide.Colors.Orange;
                    break;

            }
            mm.getRb2().Invalidate();

        }
        public static void raceRadio_TapEvent_r3(MasterMind mm)
        {

            mm.setCounter(mm.getCounter() == 6 ? 0 : mm.getCounter() + 1);


            switch (mm.getCounter())
            {
                case 0: mm.getRb3().SelectedColor = GHI.Glide.Colors.Red;
                    mm.getRb3().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: mm.getRb2().SelectedColor = GHI.Glide.Colors.Green;
                    mm.getRb3().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: mm.getRb3().SelectedColor = GHI.Glide.Colors.White;
                    mm.getRb3().Color = GHI.Glide.Colors.White;
                    break;
                case 3: mm.getRb3().SelectedColor = GHI.Glide.Colors.Blue;
                    mm.getRb3().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4: mm.getRb3().SelectedColor = GHI.Glide.Colors.Yellow;
                    mm.getRb3().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: mm.getRb3().SelectedColor = GHI.Glide.Colors.Orange;
                    mm.getRb3().Color = GHI.Glide.Colors.Orange;
                    break;

            }

            mm.getRb3().Invalidate();

        }
        public static void raceRadio_TapEvent_r4(MasterMind mm)
        {

            mm.setCounter(mm.getCounter() == 6 ? 0 : mm.getCounter() + 1);


            switch (mm.getCounter())
            {
                case 0: mm.getRb4().SelectedColor = GHI.Glide.Colors.Red;
                    mm.getRb4().Color = GHI.Glide.Colors.Red;
                    break;
                case 1: mm.getRb4().SelectedColor = GHI.Glide.Colors.Green;
                    mm.getRb4().Color = GHI.Glide.Colors.Green;
                    break;
                case 2: mm.getRb4().SelectedColor = GHI.Glide.Colors.White;
                    mm.getRb4().Color = GHI.Glide.Colors.White;
                    break;
                case 3: mm.getRb4().SelectedColor = GHI.Glide.Colors.Blue;
                    mm.getRb4().Color = GHI.Glide.Colors.Blue;
                    break;
                case 4: mm.getRb4().SelectedColor = GHI.Glide.Colors.Yellow;
                    mm.getRb4().Color = GHI.Glide.Colors.Yellow;
                    break;
                case 5: mm.getRb4().SelectedColor = GHI.Glide.Colors.Orange;
                    mm.getRb4().Color = GHI.Glide.Colors.Orange;
                    break;

            }
            mm.getRb4().Invalidate();

        }
        #endregion

        #region Left Right Movements
        // Handlers for left right events from the joystick
        public static void leftEventFired(MasterMind mm)
        {
            if (mm.getCurrentLeftRight() == 1) return;

            mm.setCurrentLeftRight(mm.getCurrentLeftRight() - 1);

            if (mm.getCurrentLeftRight() == 1)
            {
               mm.getRb2().OutlineColor = GHI.Glide.Colors.White;
                mm.getRb2().Invalidate();

                mm.getRb1().OutlineColor = GHI.Glide.Colors.Red;
               mm.getRb1().Invalidate();


            }
            if (mm.getCurrentLeftRight() == 2)
            {
              mm.getRb3().OutlineColor = GHI.Glide.Colors.White;
              mm.getRb3().Invalidate();

                mm.getRb2().OutlineColor = GHI.Glide.Colors.Red;
                mm.getRb2().Invalidate();

            }
            if (mm.getCurrentLeftRight() == 3)
            {

                mm.getRb4().OutlineColor = GHI.Glide.Colors.White;
                mm.getRb4().Invalidate();

                mm.getRb3().OutlineColor = GHI.Glide.Colors.Red;
                mm.getRb3().Invalidate();
            }


        }

        public static void rightEventFired(MasterMind mm)
        {
            if (mm.getCurrentLeftRight() == 4) return;
            mm.setCurrentLeftRight(mm.getCurrentLeftRight() + 1);
           

            if (mm.getCurrentLeftRight() == 2)
            {

                mm.getRb1().OutlineColor = GHI.Glide.Colors.White;
                mm.getRb1().Invalidate();

                mm.getRb2().OutlineColor = GHI.Glide.Colors.Red;
                mm.getRb2().Invalidate();


            }
            if (mm.getCurrentLeftRight() == 3)
            {

                mm.getRb2().OutlineColor = GHI.Glide.Colors.White;
                mm.getRb2().Invalidate();

                mm.getRb3().OutlineColor = GHI.Glide.Colors.Red;
                mm.getRb3().Invalidate();

            }
            if (mm.getCurrentLeftRight() == 4)
            {

                mm.getRb3().OutlineColor = GHI.Glide.Colors.White;
                mm.getRb3().Invalidate();

                mm.getRb4().OutlineColor = GHI.Glide.Colors.Red;
                mm.getRb4().Invalidate();

            }

        }
        #endregion
    }
}
