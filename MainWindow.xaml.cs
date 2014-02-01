using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using PolyMaker;
using EllipseMaker;

namespace ZytronicTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {

        string deviceType;

        #region Whole NEW TAPPING System Variables

        //randomness 3 reg
        int[] tappingArray3 = { 1, 2, 3 };
        Random rndTap = new Random(); //universal
        int[] tappingArray3Rnd;

        //randomness 2region
        int[] tappingArray2 = { 1, 2 };
        int[] tappingArray2Rnd;
        //use the same random number as 3 regions

        //random holds
        string[] tappingHold = { "B", "H", "C" };
        Random rndTapHold = new Random();
        string[] tappingHoldRnd;
        string tapHold;
        //
        int holdCountT;
        

        //
        Boolean booleanSwitchT3; //3 or 2 region.. applicable for both
        int i3; //incrementer 3 regions
        int i2; //incrementer 2 regions
       
        //new errors
        int errorCircle;
        int errorRect;
        int errorTriangle;

        //new point collection
        PointCollection collectPoints = new PointCollection();
        #endregion

        #region swipe image variables
        ImageBrush up = new ImageBrush();
        ImageBrush down = new ImageBrush();
        ImageBrush left = new ImageBrush();
        ImageBrush right = new ImageBrush();
        ImageBrush dUp = new ImageBrush();
        ImageBrush dDown = new ImageBrush();
        ImageBrush curveD = new ImageBrush();
        ImageBrush curveU = new ImageBrush();
        ImageBrush done = new ImageBrush();
        ImageBrush end = new ImageBrush();
        #endregion

        #region New Swipe Variables
        //swipe touch points
        Point SwipeTouchPoint;
        PointCollection swipeTouchPointCollector = new PointCollection();
        PointCollection swipePointCollectionLog = new PointCollection();

        //swipe time
        double timeToSwipe;
        Stopwatch swipeWatch = new Stopwatch();

        //swipeShapes
        Ellipse swipeCircle = new Ellipse() { Width = 100, Height = 100 };

        //swipeUp counter even/odd
        int swipeEvenOdd;

        //swipe random order
        //1set
        int[] swipeOrder = {0, 1, 2, 3, 4, 5, 6, 7};
        Random rnd = new Random(); //universal
        int[] swipeOrderRnd;
        //2set
        int[] swipeOrder2 = { 0, 1, 2, 3 };
        int[] swipeOrderRnd2;

        bool swipeSet;
        string whichSwipe;

        //holdregion Randmizer
        int[] swipeHold = { 0, 1, 2 };
        int[] swipeHoldRnd;
        int holdRegionSCount;
        bool booleanSwitch = false;
        string swipeHoldReg;
        string setOfSwipe;
        string handS;
        string swipeHoldRegion;

        
        //holdregion Rectangles for swipe
        Point bp1, bp2, hp1, hp2, cp1, cp2;
        Rect bRect, hRect, cRect;

        //touchpoint moving
        Point movingTouchPoint;
        
        /*
        int swipeArrIndx0;
        int swipeArrIndx1;
        int swipeArrIndx2;
        int swipeArrIndx3;
        int swipeArrIndx4;
        int swipeArrIndx5;
        int swipeArrIndx6;
        int swipeArrIndx7;
        */

        //swipe 5 times
        int swipeTimesCounter;

        #endregion

        #region 3 regions Variables
        //--bottom--center starts---

        //bottom-corner 1-1
        double b_One1_x;
        double b_One1_y;
        double b_One2_x;
        double b_One2_y;
        double b_One3_x;
        double b_One3_y;

        Point b_one1;
        Point b_one2;
        Point b_one3;

        //bottom-corner 1-2
        double b_two1_x;
        double b_two1_y;
        double b_two2_x;
        double b_two2_y;
        double b_two3_x;
        double b_two3_y;

        Point b_two1;
        Point b_two2;
        Point b_two3;

        //bottom-corner 1-3
        double b_three1_x;
        double b_three1_y;
        double b_three2_x;
        double b_three2_y;
        double b_three3_x;
        double b_three3_y;

        Point b_three1;
        Point b_three2;
        Point b_three3;

        //--bottom--center ends---

        //---horizontal-center --starts--

        //horizontal-center 1-1
        double h_One1_x;
        double h_One1_y;
        double h_One2_x;
        double h_One2_y;
        double h_One3_x;
        double h_One3_y;

        Point h_one1;
        Point h_one2;
        Point h_one3;

        //horizontal-center 1-2
        double h_two1_x;
        double h_two1_y;
        double h_two2_x;
        double h_two2_y;
        double h_two3_x;
        double h_two3_y;

        Point h_two1;
        Point h_two2;
        Point h_two3;

        //horizontal-center  1-3
        double h_three1_x;
        double h_three1_y;
        double h_three2_x;
        double h_three2_y;
        double h_three3_x;
        double h_three3_y;

        Point h_three1;
        Point h_three2;
        Point h_three3;

        //---horizontal-center --ends--

        //---bottom-center --starts--

        //bottom-center 1-1
        double bc_One1_x;
        double bc_One1_y;
        double bc_One2_x;
        double bc_One2_y;
        double bc_One3_x;
        double bc_One3_y;

        Point bc_one1;
        Point bc_one2;
        Point bc_one3;

        //bottom-center 1-2
        double bc_two1_x;
        double bc_two1_y;
        double bc_two2_x;
        double bc_two2_y;
        double bc_two3_x;
        double bc_two3_y;

        Point bc_two1;
        Point bc_two2;
        Point bc_two3;

        //bottom-center  1-3
        double bc_three1_x;
        double bc_three1_y;
        double bc_three2_x;
        double bc_three2_y;
        double bc_three3_x;
        double bc_three3_y;

        Point bc_three1;
        Point bc_three2;
        Point bc_three3;

        //---bottom-center --ends--
        #endregion//three regions ENDS-----------

        #region New Bottom Center Points [3 Regions]
        //New bottom-center 1-1
        double n_bc_one1_x;
        double n_bc_one1_y;
        double n_bc_one2_x;
        double n_bc_one2_y;

        Point rect_bc_1_p1;
        Point rect_bc_1_p2;

        Rect rect_bc_1;

        //New bottom-center 1-2
        double n_bc_two1_x;
        double n_bc_two1_y;
        double n_bc_two2_x;
        double n_bc_two2_y;

        Point rect_bc_2_p1;
        Point rect_bc_2_p2;

        Rect rect_bc_2;

        //New bottom-center 1-3
        double n_bc_three1_x;
        double n_bc_three1_y;
        double n_bc_three2_x;
        double n_bc_three2_y;

        Point rect_bc_3_p1;
        Point rect_bc_3_p2;

        Rect rect_bc_3;

        #endregion

        #region 2 regions Variables

        //bottom-corner (2 region) 1-1
        double t_b_One1_x;
        double t_b_One1_y;
        double t_b_One2_x;
        double t_b_One2_y;
        double t_b_One3_x;
        double t_b_One3_y;

        Point t_b_one1;
        Point t_b_one2;
        Point t_b_one3;

        //bottom-corner (2 region) 1-2
        double t_b_two1_x;
        double t_b_two1_y;
        double t_b_two2_x;
        double t_b_two2_y;
        double t_b_two3_x;
        double t_b_two3_y;

        Point t_b_two1;
        Point t_b_two2;
        Point t_b_two3;

        //horizontal-center(2 region) 1-1
        double t_h_one1_x;
        double t_h_one1_y;
        double t_h_one2_x;
        double t_h_one2_y;
        double t_h_one3_x;
        double t_h_one3_y;

        Point t_h_one1;
        Point t_h_one2;
        Point t_h_one3;

        //horizontal-center(2 region)  1-2
        double t_h_two1_x;
        double t_h_two1_y;
        double t_h_two2_x;
        double t_h_two2_y;
        double t_h_two3_x;
        double t_h_two3_y;

        Point t_h_two1;
        Point t_h_two2;
        Point t_h_two3;

        //bottom-center(2 region) 1-1
        double t_bc_one1_x;
        double t_bc_one1_y;
        double t_bc_one2_x;
        double t_bc_one2_y;
        double t_bc_one3_x;
        double t_bc_one3_y;

        Point t_bc_one1;
        Point t_bc_one2;
        Point t_bc_one3;

        //bottom-center(2 region)  1-2
        double t_bc_two1_x;
        double t_bc_two1_y;
        double t_bc_two2_x;
        double t_bc_two2_y;
        double t_bc_two3_x;
        double t_bc_two3_y;

        Point t_bc_two1;
        Point t_bc_two2;
        Point t_bc_two3;

        #endregion//two regions ENDS-----------

        #region New Bottom Center Points [2 Regions]
        //New bottom-center [2 Regions] 1-1
        double n_t_bc_one1_x;
        double n_t_bc_one1_y;
        double n_t_bc_one2_x;
        double n_t_bc_one2_y;

        Point t_rect_bc_1_p1;
        Point t_rect_bc_1_p2;

        Rect t_rect_bc_1;

        //New bottom-center [2 Regions] 1-2
        double n_t_bc_two1_x;
        double n_t_bc_two1_y;
        double n_t_bc_two2_x;
        double n_t_bc_two2_y;

        Point t_rect_bc_2_p1;
        Point t_rect_bc_2_p2;

        Rect t_rect_bc_2;

        #endregion

        #region check repetitive shapes
        int circleWidth = 100;
        int circleHeight = 100;
        int cirN =0, recN=0, triN=0;

        #endregion

        #region date and time for Participant ID + File Name
        string participantID = DateTime.Now.ToString("yyMMddHHmmss");
                
        #endregion

        #region hold, touchregion, hand, twoORthree region variable
        string holdRegion;
        int touchRegion;
        string hand;
        int twoORthree;
        string touchHoldRegion;
        string t_touchHoldRegion;
        #endregion

        #region Touch Hold Changer Variables
        int bh=0;
        int hh=0;
        int ch=0;

        string firstHold;
        string secondHold;
        string thirdHold;
        #endregion

        #region next shape variables
        string nextshape;
        string t_nextshape;
        int t_nxt;
        int nxt;
        #endregion

        #region contains shape booleans
        bool containsCirclePrimary;
        bool containsCircle;
        bool containsRectangle;
        bool containsTriangle;
        #endregion

        #region Sequence randomizer variables for 3 regions
        //sequence randomizer variables
        int a_, b_, c_, d_, e_, f_, g_, h_, i_, j_, k_, l_, m_, n_,
            a2_, b2_, c2_, d2_, e2_, f2_, g2_, h2_, i2_, j2_, k2_, l2_, m2_, n2_,
            a3_, b3_, c3_, d3_, e3_, f3_, g3_, h3_, i3_, j3_, k3_, l3_, m3_, n3_;

        //sequence buttons
        bool combo1;
        bool combo2;
        bool combo3;

        bool startingB;
        bool startingH;
        bool startingC;

        #endregion

        #region sequence randomizer variable for 2 regions
        int at_, bt_, ct_, dt_,
            at2_, bt2_, ct2_, dt2_, 
            at3_, bt3_, ct3_, dt3_;

        #endregion

        #region Diagnosis
        //errors
        int circleError;
        int rectangleError;
        int triangleError;

        //timers
        double timeToTap;
        Stopwatch tapWatch = new Stopwatch();

        #endregion

        #region Shape Sequence
        //3-region left and right hand
        int b_i;

        //2-region left and right hand
        int t_i;
        #endregion

        #region Elementary shape instances
        Ellipse newCirclePrimary;
        Rectangle newRectangle = new Rectangle();
        Polygon newTriangle = new Polygon();
        Ellipse newCircle = new Ellipse() { Width = 100, Height = 100 };
        Ellipse newCircle2 = new Ellipse() { Width = 100, Height = 100 };
        Ellipse newCircle3 = new Ellipse() { Width = 100, Height = 100 };
        Ellipse newCircle4 = new Ellipse() { Width = 100, Height = 100 };
        Ellipse newCircle5 = new Ellipse() { Width = 100, Height = 100 };

        //TextBlock txtTest = new TextBlock();

        #endregion

        //tap hold change image
        ImageBrush startTap = new ImageBrush();
        Boolean fourteen = false;
        Boolean tweentyEight = false;

        #region Touch Event Variables
        double xUP;
        double yUP;
        Point touchUp;

        double xTouchPoint;
        double yTouchPoint;

        double xPosition;
        double yPosition;
        Point tappingPoint;
        //all 'touch' get added to this collection until the right touch
        PointCollection allPoints = new PointCollection();

        double xDelta;
        double yDelta;
        double xVel;
        double yVel;

        double ScreenX = System.Windows.SystemParameters.PrimaryScreenWidth;
        double ScreenY = System.Windows.SystemParameters.PrimaryScreenHeight;



        //double ScreenX;
        //double ScreenY;

        double vectorLength;

        double LengthSqrd;
        #endregion

        #region Boolean Buttons
        bool three_regions = true;

        bool left_handed = true;

        bool tapping = true;

        #endregion

        #region X,Y Point Variables to define the rectangular Hold Region
        //*****XYpoints Variables

        //hold area

        //bottom-corner
        double bX1 = 0;
        double bX2 = 330;
        double bY1 = 540;
        double bY2 = 720;

        //horizontal-center
        double hX1 = 0;
        double hX2 = 330;
        double hY1 = 240;
        double hY2 = 410;

        //bottom-center
        double bcX1 = 411;
        double bcX2 = 741;
        double bcY1 = 540;
        double bcY2 = 720;

        #endregion 

        #region variables for swipe displacement for moving objects
        double canvas1LocX;
        double canvas1LocY;

        double canvas1H;
        double canvas1W;

        double parentCanvasLocX;
        double parentCanvasLocY;

        double parentCanvasH;
        double parentCanvasW;

        int dx = 44;
        int dy = 60;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            #region MainWindow Variables
            //this.Cursor = Cursors.None;
            //this.ResizeMode = ResizeMode.NoResize;
            //System.Diagnostics.Process.Start("StartUPDD.bat");
            //System.Diagnostics.Process.Start("ZyConfig.exe", "usb set_enabled 1");
            //System.Diagnostics.Process.Start("ZyConfig.exe", "usb set_device_mode multi");
            System.Diagnostics.Process.Start("ZyConfig.exe", "usb set_flex_position top");
            //System.Diagnostics.Process.Start("ZyConfig.exe", "usb SET_RESOLUTION 4096, 4096");
            //System.Diagnostics.Process.Start("ZyConfig.exe", "usb ping");
            //this.Cursor = Cursors.None;
            this.ResizeMode = ResizeMode.NoResize;
            this.Topmost = true;
            this.Activate();

            #endregion

        }

        #region Hold Region Rectangles for Swipe
        public void holdRegIdnSwipe()
        {
            if (left_handed == true)
            {
                //left hand reset
                bX1 = hX1 = 0;
                bX2 = hX2 = 330;
                bcX1 = 411;
                bcX2 = 741;
                
                //points
                bp1 = new Point(bX1 * ScreenX / 1152, bY2 * ScreenY / 720);
                bp2 = new Point(bX2 * ScreenX / 1152, bY1 * ScreenY / 720);
                hp1 = new Point(hX1 * ScreenX / 1152, hY2 * ScreenY / 720);
                hp2 = new Point(hX2 * ScreenX / 1152, hY1 * ScreenY / 720);
                cp1 = new Point(bcX1 * ScreenX / 1152, bcY2 * ScreenY / 720);
                cp2 = new Point(bcX2 * ScreenX / 1152, bcY1 * ScreenY / 720);

                //rectangles
                bRect = new Rect(bp1, bp2);
                hRect = new Rect(hp1, hp2);
                cRect = new Rect(cp1, cp2);

                
            }
            if (left_handed == false)
            {
                //left to right hand conversion
                bX1 = hX1 = 1152;
                bX2 = hX2 = 1152 - 330;
                bcX1 = 1152 - 352;
                bcX2 = 1152 - 762;
                
                //points
                bp1 = new Point(bX1 * ScreenX / 1152, bY2 * ScreenY / 720);
                bp2 = new Point(bX2 * ScreenX / 1152, bY1 * ScreenY / 720);
                hp1 = new Point(hX1 * ScreenX / 1152, hY2 * ScreenY / 720);
                hp2 = new Point(hX2 * ScreenX / 1152, hY1 * ScreenY / 720);
                cp1 = new Point(bcX1 * ScreenX / 1152, bcY2 * ScreenY / 720);
                cp2 = new Point(bcX2 * ScreenX / 1152, bcY1 * ScreenY / 720);

                //rectangles
                bRect = new Rect(bp1, bp2);
                hRect = new Rect(hp1, hp2);
                cRect = new Rect(cp1, cp2);
            }
        }


        #endregion

        #region Swipe Action
        public void SwipeAction()
        {

            if (vectorLength > 4)
            {
                if (swipeEvenOdd % 2 == 0)
                {
                    Canvas1.Children.Clear();
                    swipeCircle.Fill = Brushes.Red;
                    Canvas1.Children.Add(swipeCircle);
                }
                else if (swipeEvenOdd % 2 != 0)
                {
                    Canvas1.Children.Clear();
                    swipeCircle.Fill = Brushes.Green;
                    Canvas1.Children.Add(swipeCircle);
                }
            }

            else if (vectorLength > 4)
            {
                if (swipeEvenOdd % 2 == 0)
                {
                    Canvas1.Children.Clear();
                    swipeCircle.Fill = Brushes.Red;
                    Canvas1.Children.Add(swipeCircle);
                }
                else if (swipeEvenOdd % 2 != 0)
                {
                    Canvas1.Children.Clear();
                    swipeCircle.Fill = Brushes.Green;
                    Canvas1.Children.Add(swipeCircle);
                }
            }
        }
        #endregion

        #region Point in a Triangle Identifier
        //below two methods checks whether or not a point is inside a triangle
        double sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        bool PointInTriangle(Point pt, Point v1, Point v2, Point v3)
        {
            bool b1, b2, b3;

            b1 = sign(pt, v1, v2) < 0.0f;
            b2 = sign(pt, v2, v3) < 0.0f;
            b3 = sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }
        #endregion

        #region Timer
        public void timerWatch()
        {
            //timer
            tapWatch.Stop();
            timeToTap = Math.Round(tapWatch.Elapsed.TotalMilliseconds, 0);
            Console.WriteLine("Timer: " + timeToTap);
            tapWatch.Restart();
        }
        #endregion

        #region swipe array printer [temp func]
        public void swipeArrayPrinter()
        { 
        //prints order of array
        Console.WriteLine("SwipeArrayOrder: " + swipeOrderRnd[0] + " ; " + swipeOrderRnd[1] + " ; " + swipeOrderRnd[2] + " ; " +
             swipeOrderRnd[3] + " ; " +  swipeOrderRnd[4] + " ; " +  swipeOrderRnd[5] + " ; " + 
              swipeOrderRnd[6] + " ; " +  swipeOrderRnd[7]);
        /*/prints index in order of element 0 to 7
        Console.WriteLine("SwipeArrayIndex: " + swipeArrIndx0 + " ; " + swipeArrIndx1 + " ; " + swipeArrIndx2 +
             " ; " + swipeArrIndx3 + " ; " + swipeArrIndx4 + " ; " + swipeArrIndx5 + " ; " +
             swipeArrIndx6 + " ; " + swipeArrIndx7);*/
        }
        #endregion

        #region Swipe Insturctions
        public void swipeInstruction()
        {
            if (holdRegionSCount < 3)
            {
                if (swipeSet == false)
                {
                    //swipe order visualization
                    if (swipeEvenOdd == 0)
                    {
                        swipeArt(swipeOrderRnd[0]);
                    }
                    else if (swipeEvenOdd == 1)
                    {
                        swipeArt(swipeOrderRnd[1]);
                    }
                    else if (swipeEvenOdd == 2)
                    {
                        swipeArt(swipeOrderRnd[2]);
                    }
                    else if (swipeEvenOdd == 3)
                    {
                        swipeArt(swipeOrderRnd[3]);
                    }
                    else if (swipeEvenOdd == 4)
                    {
                        swipeArt(swipeOrderRnd[4]);
                    }
                    else if (swipeEvenOdd == 5)
                    {
                        swipeArt(swipeOrderRnd[5]);
                    }
                    else if (swipeEvenOdd == 6)
                    {
                        swipeArt(swipeOrderRnd[6]);
                    }
                    else if (swipeEvenOdd == 7)
                    {
                        swipeArt(swipeOrderRnd[7]);
                    }
                    else if (swipeEvenOdd == 8)
                    {
                        swipeTimesCounter++;
                        if (swipeTimesCounter == 1 || swipeTimesCounter == 2 || swipeTimesCounter == 3 || swipeTimesCounter == 4)
                        {
                            
                            swipeEvenOdd = 0;
                            tappingPoint.X = 0;
                            tappingPoint.Y = 0;
                            rnd = new Random();
                            swipeOrderRnd = swipeOrder.OrderBy(x => rnd.Next()).ToArray();
                            swipeArt(swipeOrderRnd[0]);
                        }
                        else if (swipeTimesCounter == 5)
                        {
                            swipeTimesCounter = 0;
                            swipeArt(8);
                            holdRegionSCount++;
                            if (holdRegionSCount == 1)
                            {
                                holdAlertSwipe(swipeHoldRnd[1]);
                                swipeEvenOdd = 0;
                                tappingPoint.X = 0;
                                tappingPoint.Y = 0;
                                Console.WriteLine("8th taps: " + tappingPoint);
                            }
                            else if (holdRegionSCount == 2)
                            {
                                holdAlertSwipe(swipeHoldRnd[2]);
                                swipeEvenOdd = 0;
                                tappingPoint.X = 0;
                                tappingPoint.Y = 0;
                                Console.WriteLine("8th taps: " + tappingPoint);
                            }
                            else if (holdRegionSCount > 2)
                            {
                                HoldAlert.Text = "The task is complete!";
                                swipeFeedFwd.Background = end;
                            }
                        }
                    }
                }

                if (swipeSet == true)
                {
                    if (swipeEvenOdd == 1)
                    {
                        swipeArt2(swipeOrderRnd2[0]);
                    }
                    if (swipeEvenOdd == 2)
                    {
                        swipeArt2(swipeOrderRnd2[1]);
                    }
                    if (swipeEvenOdd == 3)
                    {
                        swipeArt2(swipeOrderRnd2[1]);
                    }
                    if (swipeEvenOdd == 4)
                    {
                        swipeArt2(swipeOrderRnd2[2]);
                    }
                    if (swipeEvenOdd == 5)
                    {
                        swipeArt2(swipeOrderRnd2[2]);
                    }
                    if (swipeEvenOdd == 6)
                    {
                        swipeArt2(swipeOrderRnd2[3]);
                    }
                    if (swipeEvenOdd == 7)
                    {
                        swipeArt2(swipeOrderRnd2[3]);
                    }
                    if (swipeEvenOdd == 8)
                    {
                        swipeArt2(8);
                        holdRegionSCount++;
                        if (holdRegionSCount == 1)
                        {
                            holdAlertSwipe(swipeHoldRnd[1]);
                            swipeEvenOdd = 0;
                            tappingPoint.X = 0;
                            tappingPoint.Y = 0;
                            Console.WriteLine("8th taps: " + tappingPoint);
                        }
                        else if (holdRegionSCount == 2)
                        {
                            holdAlertSwipe(swipeHoldRnd[2]);
                            swipeEvenOdd = 0;
                            tappingPoint.X = 0;
                            tappingPoint.Y = 0;
                            Console.WriteLine("8th taps: " + tappingPoint);
                        }
                        else if (holdRegionSCount > 2)
                        {
                            HoldAlert.Text = "The task is complete!";
                            swipeFeedFwd.Background = end;
                        }
                    }

                }
            }

        }
        #endregion

        #region swipe artist 1set
        public void swipeArt(int whatSwipe)
        {
            if (holdRegionSCount < 3)
            {
                if (swipeSet == false)
                {
                    switch (whatSwipe)
                    {
                        case 0:
                            swipeFeedFwd.Background = up;
                            
                            
                            break;
                        case 1:
                            swipeFeedFwd.Background = down;
                            
                            
                            break;
                        case 2:
                            swipeFeedFwd.Background = right;
                            
                            
                            break;
                        case 3:
                            swipeFeedFwd.Background = left;
                            
                            
                            break;
                        case 4:
                            swipeFeedFwd.Background = dDown;
                            
                            
                            break;
                        case 5:
                            swipeFeedFwd.Background = dUp;
                            
                            
                            break;
                        case 6:
                            swipeFeedFwd.Background = curveD;
                            
                            
                            break;
                        case 7:
                            swipeFeedFwd.Background = curveU;
                            
                            
                            break;
                        case 8:
                            swipeFeedFwd.Background = done;
                            break;
                    }
                }
            }
            else if (holdRegionSCount > 2)
            {
                swipeFeedFwd.Background = end;
            }
        }
        #endregion

        #region swipe artist 2set
        public void swipeArt2(int whatSwipe2)
        {
            if (holdRegionSCount < 3)
            {
                if (swipeSet == true)
                {
                    switch (whatSwipe2)
                    {
                        case 0:
                            if (booleanSwitch == false)
                            {
                                swipeFeedFwd.Background = up;
                                
                            }
                            else if (booleanSwitch == true)
                            {
                                swipeFeedFwd.Background = down;
                                
                            }
                            break;
                        case 1:
                            if (booleanSwitch == false)
                            {
                                swipeFeedFwd.Background = right;
                                
                            }
                            else if (booleanSwitch == true)
                            {
                                swipeFeedFwd.Background = left;
                                
                            }
                            break;
                        case 2:
                            if (booleanSwitch == false)
                            {
                                swipeFeedFwd.Background = dUp;
                                
                            }
                            else if (booleanSwitch == true)
                            {
                                swipeFeedFwd.Background = dDown;
                                
                            }
                            break;
                        case 3:
                            if (booleanSwitch == false)
                            {
                                swipeFeedFwd.Background = curveD;
                                
                            }
                            else if (booleanSwitch == true)
                            {
                                swipeFeedFwd.Background = curveU;
                                
                            }
                            break;
                        case 8:
                            swipeFeedFwd.Background = done;
                            break;
                    }
                }
            }
            else if (holdRegionSCount > 2)
            {
                swipeFeedFwd.Background = end;
            }
        }
        #endregion

        #region SwipeDetector
        public void swipeDetector()
        {
            if (left_handed == true)
            {
                if (swipeFeedFwd.Background == up)
                {
                    whichSwipe = "up";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == down)
                {
                    whichSwipe = "down";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == right)
                {
                    whichSwipe = "right";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == left)
                {
                    whichSwipe = "left";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == dDown)
                {
                    whichSwipe = "dDown";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == dUp)
                {
                    whichSwipe = "dUp";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == curveD)
                {
                    whichSwipe = "curveD";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == curveU)
                {
                    whichSwipe = "curveU";
                    Console.WriteLine(whichSwipe);
                }
            }
            else if (left_handed == false) //for right hand only dUp, dDown, curveU, curveD are interchanged
            {
                if (swipeFeedFwd.Background == up)
                {
                    whichSwipe = "up";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == down)
                {
                    whichSwipe = "down";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == right)
                {
                    whichSwipe = "right";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == left)
                {
                    whichSwipe = "left";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == dDown)
                {
                    whichSwipe = "curveD";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == dUp)
                {
                    whichSwipe = "curveU";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == curveD)
                {
                    whichSwipe = "dDown";
                    Console.WriteLine(whichSwipe);
                }
                else if (swipeFeedFwd.Background == curveU)
                {
                    whichSwipe = "dUp";
                    Console.WriteLine(whichSwipe);
                }
            }
        }
        #endregion

        #region SwipeHoldDetector
        public void swipeHoldDetector()
        {
            if (swipeHoldReg == "B")
            {
                swipeHoldRegion = "B";
            }
            else if (swipeHoldReg == "H")
            {
                swipeHoldRegion = "H";
            }
            else if (swipeHoldReg == "C")
            {
                swipeHoldRegion = "c";
            }

        }
        #endregion

        #region Swipe Logger
        public void swipeLogger()
        {
            //if (holdRegionSCount < 3)
            //{
                //log - participantID, time, points for a swipe, which swipe
                using (StreamWriter writer = new StreamWriter(participantID + "-S.txt", true))
                {
                    writer.Write(Environment.NewLine + participantID + ";" + deviceType +";" + handS + ";" + swipeHoldRegion + ";" +
                        whichSwipe + ";" + timeToSwipe + ";" + swipePointCollectionLog);
                }
           // }
        }
        #endregion

        #region New Tap instructions
        public void tapInsturction()
        {
            if (three_regions == true)
            {
                if (i3 == 1 || i3 == 4 || i3 == 7 || i3 == 10 || i3 == 13)
                {
                    tappingDraw(tappingArray3Rnd[1]);
                    Console.WriteLine("Hallelujah!!!");
                    Console.WriteLine(tappingArray3Rnd[0] + ";" + tappingArray3Rnd[1] + ";" + tappingArray3Rnd[2]);
                }
                else if (i3 == 2 || i3 == 5 || i3 == 8 || i3 == 11 || i3 == 14)
                {
                    tappingDraw(tappingArray3Rnd[2]);
                    Console.WriteLine("No!!! Hallelujah!!!");
                    Console.WriteLine(tappingArray3Rnd[0] + ";" + tappingArray3Rnd[1] + ";" + tappingArray3Rnd[2]);
                }
                else if (i3 == 3 || i3 == 6 || i3 == 9 || i3 == 12 || i3 == 15)
                {
                    tappingDraw(tappingArray3Rnd[0]);
                }
            }
            else if (three_regions == false)
            {
                if (i2 == 1 || i2 == 3 || i2 == 5 || i2 == 7 || i2 == 9)
                {
                    tappingDraw(tappingArray2Rnd[1]);
                }
                else if (i2 == 2 || i2 == 4 || i2 == 6 || i2 == 8 || i2 == 10)
                {
                    tappingDraw(tappingArray2Rnd[0]);
                }
            }
        }
        #endregion

        #region New Tapping Draw
        public void tappingDraw(int getTapRegion)
        {
            if (left_handed == true)
            {
                if (three_regions == true)
                {
                    if (i3 >= 1 && i3 < 15)
                    {
                        Canvas1.Background = null;
                        if (getTapRegion == 1)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("....." + cirN);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.YellowGreen;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("-----" + cirN);
                            }
                        }
                        else if (getTapRegion == 2)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newRectangle);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Violet;
                                Canvas1.Children.Add(newRectangle);
                            }
                        }
                        else if (getTapRegion == 3)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Green;
                                Canvas1.Children.Add(newTriangle);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Black;
                                Canvas1.Children.Add(newTriangle);
                            }


                        }
                    }
                    else if (i3 == 15)
                    {
                        Canvas1.Children.Clear();
                        Canvas1.Background = done;
                        Console.WriteLine("i3 == 15");
                        holdCountT++;
                        holdTapchanger();
                        HoldAlertBox();
                    }
                }
                else if (three_regions == false)
                {
                    if (i2 >= 0 && i2 < 10)
                    {
                        Canvas1.Background = null;
                        if (getTapRegion == 1)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("....." + cirN);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.YellowGreen;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("-----" + cirN);
                            }
                        }
                        else if (getTapRegion == 2)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newRectangle);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Violet;
                                Canvas1.Children.Add(newRectangle);
                            }
                        }
                    }
                    else if (i2 == 10)
                    {
                        Canvas1.Children.Clear();
                        Canvas1.Background = done;
                        Console.WriteLine("i2 == 10");
                        holdCountT++;
                        holdTapchanger();
                        HoldAlertBox();
                    }
                }
            }
            else if (left_handed == false)
            {
                if (three_regions == true)
                {
                    if (i3 >= 1 && i3 < 15)
                    {
                        Canvas1.Background = null;
                        if (getTapRegion == 1)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Green;
                                Canvas1.Children.Add(newTriangle);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Black;
                                Canvas1.Children.Add(newTriangle);
                            }
                            
                            
                        }
                        else if (getTapRegion == 2)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newRectangle);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Violet;
                                Canvas1.Children.Add(newRectangle);
                            }
                        }
                        else if (getTapRegion == 3)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("....." + cirN);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.YellowGreen;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("-----" + cirN);
                            } 


                        }
                    }
                    else if (i3 == 15)
                    {
                        Canvas1.Children.Clear();
                        Canvas1.Background = done;
                        Console.WriteLine("i3 == 15");
                        holdCountT++;
                        holdTapchanger();
                        HoldAlertBox();
                    }
                }
                else if (three_regions == false)
                {
                    if (i2 >= 0 && i2 < 10)
                    {
                        Canvas1.Background = null;
                        if (getTapRegion == 2)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("....." + cirN);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.YellowGreen;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("-----" + cirN);
                            }
                        }
                        else if (getTapRegion == 1)
                        {
                            if (booleanSwitchT3 == true)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newRectangle);
                            }
                            else if (booleanSwitchT3 == false)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Violet;
                                Canvas1.Children.Add(newRectangle);
                            }
                        }
                    }
                    else if (i2 == 10)
                    {
                        Canvas1.Children.Clear();
                        Canvas1.Background = done;
                        Console.WriteLine("i2 == 10");
                        holdCountT++;
                        holdTapchanger();
                        HoldAlertBox();
                    }
                }
            }
        }
        #endregion

        #region Hold change draw
        public void holdChangeDraw()
        {
            if (three_regions == true)
            {
                if (i3 == 16 || i3 == 0)
                {
                    Canvas1.Background = null;
                    rndTap = new Random();
                    tappingArray3Rnd = tappingArray3.OrderBy(x => rndTap.Next()).ToArray();
                    i3 = 1;
                    collectPoints.Clear();
                    tappingDraw(tappingArray3Rnd[0]);
                    Console.WriteLine("i3 == 16");

                }
            }
            else if (three_regions == false)
            {
                if (i2 == 11 || i2 == 0)
                {
                    Canvas1.Background = null;
                    rndTap = new Random();
                    tappingArray2Rnd = tappingArray2.OrderBy(x => rndTap.Next()).ToArray();
                    i2 = 1;
                    collectPoints.Clear();
                    tappingDraw(tappingArray2Rnd[0]);
                    Console.WriteLine("i3 == 10");

                }
            
            }
        }
        #endregion

        #region Hold Region Changer New
        public void holdTapchanger()
        {
            if (holdCountT == 0)
            {
                tappingHoldIdentifier(tappingHoldRnd[0]);

            }
            else if (holdCountT == 1)
            {
                tappingHoldIdentifier(tappingHoldRnd[1]);

            }
            else if (holdCountT == 2)
            {
                tappingHoldIdentifier(tappingHoldRnd[2]);
            }
        }
       #endregion

        #region Hold Region Identify New
        public void tappingHoldIdentifier(string tapholds)
        {
            switch (tapholds)
            { 
                case "B":
                        tapHold = "B";

                        break;
                case "H":
                        tapHold = "H";

                        break;
                case "C":
                        tapHold = "C";

                        break;

            }
        }
        #endregion

        #region Tapping Logger
        public void tappingLogger()
        {
            if (left_handed == true)
            {
                if (Canvas1.Background != end && Canvas1.Background != done)
                {
                    if (containsCircle)
                    {
                        using (StreamWriter writer = new StreamWriter(participantID + "-T.txt", true))
                        {
                            writer.Write(Environment.NewLine + participantID + ";" + deviceType + ";" + hand + ";" + twoORthree + ";" + tapHold + ";" + touchRegion
                                + ";" + timeToTap + ";" + (errorCircle - 1) + ";" + collectPoints + ";");
                        }
                    }
                    else if (containsRectangle)
                    {
                        using (StreamWriter writer = new StreamWriter(participantID + "-T.txt", true))
                        {
                            writer.Write(Environment.NewLine + participantID + ";" + deviceType + ";" + hand + ";" + twoORthree + ";" + tapHold + ";" + touchRegion
                                + ";" + timeToTap + ";" + (errorRect - 1) + ";" + collectPoints + ";");
                        }
                    }
                    else if (containsTriangle)
                    {
                        using (StreamWriter writer = new StreamWriter(participantID + "-T.txt", true))
                        {
                            writer.Write(Environment.NewLine + participantID + ";" + deviceType + ";" + hand + ";" + twoORthree + ";" + tapHold + ";" + touchRegion
                                + ";" + timeToTap + ";" + (errorTriangle - 1) + ";" + collectPoints + ";");
                        }
                    }
                }
            }
            else if (left_handed == false)
            {
                if (Canvas1.Background != end && Canvas1.Background != done)
                {
                    if (containsCircle)
                    {
                        using (StreamWriter writer = new StreamWriter(participantID + "-T.txt", true))
                        {
                            writer.Write(Environment.NewLine + participantID + ";" + deviceType + ";" + hand + ";" + twoORthree + ";" + tapHold + ";" + touchRegion
                                + ";" + timeToTap + ";" + (errorCircle-1) + ";" + collectPoints + ";");
                        }
                    }
                    else if (containsRectangle)
                    {
                        using (StreamWriter writer = new StreamWriter(participantID + "-T.txt", true))
                        {
                            writer.Write(Environment.NewLine + participantID + ";" + deviceType + ";" + hand + ";" + twoORthree + ";" + tapHold + ";" + touchRegion
                                + ";" + timeToTap + ";" + (errorRect-1) + ";" + collectPoints + ";");
                        }
                    }
                    else if (containsTriangle)
                    {
                        using (StreamWriter writer = new StreamWriter(participantID + "-T.txt", true))
                        {
                            writer.Write(Environment.NewLine + participantID + ";" + deviceType + ";" + hand + ";" + twoORthree + ";" + tapHold + ";" + touchRegion
                                + ";" + timeToTap + ";" + (errorTriangle-1) + ";" + collectPoints + ";");
                        }
                    }
                }
            }
        
        }
        #endregion

        #region Condition Buttons
        private void threeRegion(object sender, RoutedEventArgs e)
        {
            three_regions = true;
        }

        private void twoRegion(object sender, RoutedEventArgs e)
        {
            three_regions = false;
        }

        private void leftHand(object sender, RoutedEventArgs e)
        {
            left_handed = true;
        }

        private void rightHand(object sender, RoutedEventArgs e)
        {
            left_handed = false;
        }

        public void tappingButton(object sender, RoutedEventArgs e)
        {
            //monitor res pixel to point
            //ScreenX = ScreenXPixel * 72 / 96;
            //ScreenY = ScreenYPixel * 72 / 96;


            #region old tapping resets [cannot be deleted!!]
            tapping = true;
            swipeFeedFwd.Background = new SolidColorBrush(Colors.White);
            CanvasDone.Background = null;

            cirN = 0; recN = 0; triN = 0;
            

            allPoints.Clear();
            //errors reset
            circleError = 0;
            rectangleError = 0;
            triangleError = 0;

            #region Shape Sequence Reset
            //3-region
            b_i = 0;

            //2-region
            t_i = 1;
            #endregion

            SignalBox.Text = "Tap the Shape";

            /*
            ParentCanvas.Background = null;
            Canvas1.Width = 250;
            Canvas1.Height = 250;
            Canvas.SetLeft(Canvas1, 70);
            Canvas.SetTop(Canvas1, -300);
            MoveObjects.X = 0;
            MoveObjects.Y = 0;
            */

            Canvas1.Width = 100;
            Canvas1.Height = 100;

            #region Shape Factory
            //primary shape [circle] -- adds to Canvas1
            
            newCirclePrimary = new Ellipse() { Width = 100, Height = 100 };
            newCirclePrimary.Fill = Brushes.Blue;
            

            //rectangle
            newRectangle.Fill = Brushes.Red;
            newRectangle.Width = 100;
            newRectangle.Height = 100;

            //polygon [triangle]
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(new Point(0, 0));
            myPointCollection.Add(new Point(0, 1));
            myPointCollection.Add(new Point(1, 1));
            newTriangle.Points = myPointCollection;
            newTriangle.Fill = Brushes.Green;
            newTriangle.Width = 100;
            newTriangle.Height = 100;
            newTriangle.Stretch = Stretch.Fill;
            newTriangle.VerticalAlignment = VerticalAlignment.Center;
            newTriangle.HorizontalAlignment = HorizontalAlignment.Center;

            //ellipse [circle]
            //1
            newCircle = new Ellipse() { Width = 100, Height = 100 };
            newCircle.Fill = Brushes.Blue;


            

            /*/initial shape
            if (three_regions == true)
            {
                if (combo1)
                {
                    Canvas1.Children.Clear();
                    Canvas1.Children.Add(newRectangle);
                    //timer
                    tapWatch.Stop();
                    
                    Console.WriteLine(timeToTap);
                    tapWatch.Restart();
                    
                }
                if (combo2)
                {
                    Canvas1.Children.Clear();
                    Canvas1.Children.Add(newCircle);
                    //timer
                    tapWatch.Stop();
                    
                    Console.WriteLine(timeToTap);
                    tapWatch.Restart();
                    
                }
                if (combo3)
                {
                    Canvas1.Children.Clear();
                    Canvas1.Children.Add(newTriangle);

                    //timer
                    tapWatch.Stop();
                    
                    Console.WriteLine(timeToTap);
                    tapWatch.Restart();
                    
                }
            }
            else if (three_regions == false)
            {
                if (combo1)
                {
                    Canvas1.Children.Clear();
                    Canvas1.Children.Add(newCircle);

                    //timer
                    tapWatch.Stop();
                    
                    Console.WriteLine(timeToTap);
                    tapWatch.Restart();
                }
                if (combo2)
                {
                    Canvas1.Children.Clear();
                    Canvas1.Children.Add(newRectangle);

                    //timer
                    tapWatch.Stop();
                    
                    Console.WriteLine(timeToTap);
                    tapWatch.Restart();
                }
                
            }

            */
            
            
            #endregion
            #endregion
            Canvas1.Opacity = 100;
            collectPoints.Clear();

            //start image
            done.ImageSource = new BitmapImage(new Uri("done.png", UriKind.Relative));
            //end image
            end.ImageSource = new BitmapImage(new Uri("end.png", UriKind.Relative));
            
            //New Tappings
            tappingArray3Rnd = tappingArray3.OrderBy(x => rndTap.Next()).ToArray();
            tappingArray2Rnd = tappingArray2.OrderBy(x => rndTap.Next()).ToArray();
            Canvas1.Children.Clear();
            Canvas1.Background = done;
            
            //tap5times = 0;
            i3 = 0;
            i2 = 0;
            
            //holdRegion randomizer
            tappingHoldRnd = tappingHold.OrderBy(x => rndTapHold.Next()).ToArray();
            holdCountT = 0;
            tappingHoldIdentifier(tappingHoldRnd[0]);
            HoldAlertBox();

            //error reset
            errorCircle = 0;
            errorRect = 0;
            errorTriangle = 0;
            
            //Canvas1.Background = null;
        }

        public void swipeButton(object sender, RoutedEventArgs e)
        {
            //monitor res pixel to point
            //ScreenX = ScreenXPixel * 72 / 96;
            //ScreenY = ScreenYPixel * 72 / 96;

            swipeSet = false;
            
            tapping = false;
            swipeEvenOdd = 0;
            Canvas1.Children.Clear();
            swipeCircle.Fill = Brushes.Blue;
            Canvas1.Children.Add(swipeCircle);
            Canvas1.Opacity = 0;
            //
            bh = 0;
            hh = 0;
            ch = 0;

            //swipe-order randomizer
            //1set
            swipeOrderRnd = swipeOrder.OrderBy(x => rnd.Next()).ToArray();
            swipeArt(8);
            //2set
            swipeOrderRnd2 = swipeOrder2.OrderBy(x => rnd.Next()).ToArray();
            swipeArt2(8);

            //holdRegion randomizer
            swipeHoldRnd = swipeHold.OrderBy(x => rnd.Next()).ToArray();
            holdRegionSCount = 0;
            holdAlertSwipe(swipeHoldRnd[0]);
            
            
            /*
            swipeArrIndx0 = Array.IndexOf(swipeOrderRnd, 0);
            swipeArrIndx1 = Array.IndexOf(swipeOrderRnd, 1);
            swipeArrIndx2 = Array.IndexOf(swipeOrderRnd, 2);
            swipeArrIndx3 = Array.IndexOf(swipeOrderRnd, 3);
            swipeArrIndx4 = Array.IndexOf(swipeOrderRnd, 4);
            swipeArrIndx5 = Array.IndexOf(swipeOrderRnd, 5);
            swipeArrIndx6 = Array.IndexOf(swipeOrderRnd, 6);
            swipeArrIndx7 = Array.IndexOf(swipeOrderRnd, 7);
            */

            

            MoveObjects.X = 0;
            MoveObjects.Y = 0;

            #region swipe images
            //load swipe direction feedforward images
            
            up.ImageSource = new BitmapImage(new Uri("up.png", UriKind.Relative));
            down.ImageSource = new BitmapImage(new Uri("down.png", UriKind.Relative));
            left.ImageSource = new BitmapImage(new Uri("left.png", UriKind.Relative));
            right.ImageSource = new BitmapImage(new Uri("right.png", UriKind.Relative));  
            dUp.ImageSource = new BitmapImage(new Uri("dUp.png", UriKind.Relative));         
            dDown.ImageSource = new BitmapImage(new Uri("dDown.png", UriKind.Relative));
            curveD.ImageSource = new BitmapImage(new Uri("curveD.png", UriKind.Relative));
            curveU.ImageSource = new BitmapImage(new Uri("curveU.png", UriKind.Relative));
            done.ImageSource = new BitmapImage(new Uri("done.png", UriKind.Relative));
            end.ImageSource = new BitmapImage(new Uri("end.png", UriKind.Relative));

            //mycanvas.Background = ib;
            #endregion

        }

        public void flex(object sender, RoutedEventArgs e)
        {
            deviceType = "Flex";
        }

        public void rigid(object sender, RoutedEventArgs e)
        {
            deviceType = "Rigid";
        }
        #endregion

        #region Sequence Buttons
        private void comb1 (object sender, RoutedEventArgs e)
        {
            combo1 = true;
            combo2 = false;
            combo3 = false;
        }
        private void comb2(object sender, RoutedEventArgs e)
        {
            combo1 = false;
            combo2 = true;
            combo3 = false;
        }
        private void comb3(object sender, RoutedEventArgs e)
        {
            combo1 = false;
            combo2 = false;
            combo3 = true;
        }
        private void startB(object sender, RoutedEventArgs e)
        {
            startingB = true;
            startingH = false;
            startingC = false;
        }
        private void startH(object sender, RoutedEventArgs e)
        {
            startingB = false;
            startingH = true;
            startingC = false;
        }
        private void startC(object sender, RoutedEventArgs e)
        {
            startingB = false;
            startingH = false;
            startingC = true;
        }

        private void swipe2(object sender, RoutedEventArgs e)
        {
            swipeSet = true;
            setOfSwipe = "PAIR";
        }
        private void swipe1(object sender, RoutedEventArgs e)
        {
            swipeSet = false;
            setOfSwipe = "NO-PAIR";
        }
        #endregion


        #region Hold Change Manager [old]
        public void HoldChangeManager()
        {
            if (b_i  == 13)
            {
                if (secondHold == "B")
                {
                    if (bh == 0)
                    {
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        //Canvas1.Children.Clear();
                        HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                        Console.WriteLine("Hold Region: BOTTOM CORNER");
                        Console.WriteLine("It's in there!");
                        Console.WriteLine("b_i:::AFTER:: " + b_i);
                        bh++;
                        fourteen = true;
                    }

                    else if (bh == 1)
                    {
                        
                        if (bRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                            b_i++;
                            fourteen = false;
                            bh = 0;
                        }
                        else
                        {
                            //b_i = b_i - 1;
                            Console.WriteLine("Go go go BBBb b_i : " + b_i);
                        }

                    }
                    
                    
                }

                else if (secondHold == "H")
                {
                    
                    if (hh == 0)
                    {
                        //b_i = b_i - 1;
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        //Canvas1.Children.Clear();
                        HoldAlert.Text = "Hold Region: HORIZONTAL CENTER";
                        Console.WriteLine("Hold Region: HORIZONTAL CENTER");
                        Console.WriteLine("It's in there!");
                        Console.WriteLine("b_i:::AFTER:: " + b_i);
                        hh++;
                        fourteen = true;
                    }

                    else if (hh == 1)
                    {
                        if (hRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                            b_i++;
                            fourteen = false;
                            hh = 0;
                        }
                        else
                        {
                            //b_i = b_i - 1;
                            Console.WriteLine("Go go go hhh b_i : " + b_i);
                            
                        }

                    }
                }

                else if (secondHold == "C")
                {
                    ch++;
                    if (ch == 0)
                    {
                        //b_i = b_i - 1;
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        //Canvas1.Children.Clear();
                        HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                        Console.WriteLine("Hold Region: BOTTOM CENTER");
                        Console.WriteLine("It's in there!");
                        Console.WriteLine("b_i:::AFTER:: " + b_i);
                        ch++;
                        fourteen = true;
                        
                    }

                    else if (ch == 1)
                    {
                        if (cRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                            b_i++;
                            fourteen = false;
                            ch = 0;
                            
                        }
                        else
                        {
                            //b_i = b_i - 1;
                            Console.WriteLine("Go go go cccc b_i : " + b_i);
                            
                        }

                    }
                }
            }

            if (b_i == 28)
            {
                if (thirdHold == "B")
                {
                    if (bh == 0)
                    {
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                        Console.WriteLine("Hold Region: BOTTOM CORNER");
                        Console.WriteLine("It's in there!");
                        Console.WriteLine("b_i:::AFTER:: " + b_i);
                        bh++;
                        tweentyEight = true;
                    }

                    else if (bh == 1)
                    {

                        if (bRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                            b_i++;
                        }
                        else
                        {
                            //b_i = b_i - 1;
                            Console.WriteLine("Go go go BBBb b_i : " + b_i);
                        }

                    }


                }

                else if (thirdHold == "H")
                {

                    if (hh == 0)
                    {
                        //b_i = b_i - 1;
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        HoldAlert.Text = "Hold Region: HORIZONTAL CENTER";
                        Console.WriteLine("Hold Region: HORIZONTAL CENTER");
                        Console.WriteLine("It's in there!");
                        Console.WriteLine("b_i:::AFTER:: " + b_i);
                        hh++;
                        tweentyEight = true;
                    }

                    else if (hh == 1)
                    {
                        if (hRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                            b_i++;
                        }
                        else
                        {
                            //b_i = b_i - 1;
                            Console.WriteLine("Go go go hhh b_i : " + b_i);

                        }

                    }
                }

                else if (thirdHold == "C")
                {
                    ch++;
                    if (ch == 0)
                    {
                        //b_i = b_i - 1;
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                        Console.WriteLine("Hold Region: BOTTOM CENTER");
                        Console.WriteLine("It's in there!");
                        Console.WriteLine("b_i:::AFTER:: " + b_i);
                        ch++;
                        tweentyEight = true;
                    }

                    else if (ch == 1)
                    {
                        if (cRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                            b_i++;

                        }
                        else
                        {
                            //b_i = b_i - 1;
                            Console.WriteLine("Go go go cccc b_i : " + b_i);

                        }

                    }
                }
            }
        }
        #endregion//old

        #region Hold the Hold change for one more Event[old]

        public void HoldHoldChange()
        {
            if (three_regions == true)
            {

                if ((b_i + 1 == a_ || b_i + 1 == d_ || b_i + 1 == g_)
                                     && (b_i + 1 == 14 || b_i + 1 == 28))
                {
                    Console.WriteLine("b_i:::Before:: " + b_i);
                    bh++;
                    if (bh == 1)
                    {
                        b_i = b_i - 1;
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                        Console.WriteLine("Hold Region: BOTTOM CORNER");
                        Console.WriteLine("It's in there!");
                        Console.WriteLine("b_i:::AFTER:: " + b_i);
                    }

                    if (bh > 1)
                    {
                        if (bRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                        }
                        else
                        {
                            b_i = b_i - 1;
                            Console.WriteLine("Go go go BBBb b_i : " + b_i);
                        }

                    }
                }
                if ((b_i + 1 == a2_ || b_i + 1 == d2_ || b_i + 1 == g2_)
                && (b_i + 1 == 14 || b_i + 1 == 28))
                {

                    Console.WriteLine("b_i:::Before:: " + b_i);
                    hh++;
                    if (hh == 1)
                    {
                        b_i = b_i - 1;
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        HoldAlert.Text = "Hold Region: HORIZONTAL CENTER";
                        Console.WriteLine("Hold Region: HORIZONTAL CENTER");
                        Console.WriteLine("It's in thereHH");
                        Console.WriteLine("b_i:::AFTERHH:: " + b_i);
                    }

                    if (hh > 1)
                    {
                        if (hRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                        }
                        else
                        {
                            b_i = b_i - 1;
                            Console.WriteLine("Go go go HHHH b_i : " + b_i);
                        }

                    }

                }
                if ((b_i + 1 == a3_ || b_i + 1 == d3_ || b_i + 1 == g3_)
                && (b_i + 1 == 14 || b_i + 1 == 28))
                {

                    Console.WriteLine("b_i:::BeforeCC:: " + b_i);
                    ch++;
                    if (ch == 1)
                    {
                        b_i = b_i - 1;
                        CanvasDone.Opacity = 100;
                        startTap.ImageSource = new BitmapImage(new Uri("startTap.png", UriKind.Relative));
                        CanvasDone.Background = startTap;
                        HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                        Console.WriteLine("Hold Region: BOTTOM CENTER");
                        Console.WriteLine("It's in thereCC");
                        Console.WriteLine("b_i:::AFTERCC:: " + b_i);
                    }

                    if (ch > 1)
                    {
                        if (cRect.Contains(tappingPoint))
                        {
                            CanvasDone.Opacity = 0;
                            Console.WriteLine("It's in there too!!!");
                            Console.WriteLine("b_i:::FINALLY:: " + b_i);
                        }
                        else
                        {
                            b_i = b_i - 1;
                            Console.WriteLine("Go go go CCCC b_i : " + b_i);
                        }

                    }

                }
            }

            else if (three_regions == false)
            {
                if (startingB)
                {
                    if (t_i == 3)
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                        Console.WriteLine("Hold Region: BOTTOM CENTER");
                    }
                    if (t_i == 6)
                    {
                        HoldAlert.Text = "Hold Region: HORIZONTAL CENTER";
                        Console.WriteLine("Hold Region: HORIZONTAL CENTER");
                    }
                }

                if (startingH)
                {
                    if (t_i == 6)
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                        Console.WriteLine("Hold Region: BOTTOM CENTER");
                    }
                    if (t_i == 3)
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                        Console.WriteLine("Hold Region: BOTTOM CORNER");
                    }

                }

                if (startingC)
                {
                    if (t_i == 6)
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                        Console.WriteLine("Hold Region: BOTTOM CORNER");
                    }
                    if (t_i == 3)
                    {
                        HoldAlert.Text = "Hold Region: HORIZONTAL CENTER";
                        Console.WriteLine("Hold Region: HORIZONTAL CENTER");
                    }
                }
            }
            if (b_i + 1 >= 42)
            {
                HoldAlert.Text = "The Task is Complete";
            }
            if (t_i >= 9)
            {
                HoldAlert.Text = "The Task is Complete";
            }
        }
        #endregion
        

        #region Hold Alert Text Box TAP
        public void HoldAlertBox()
        {
            if (tapping == true)
            {
                if (three_regions == true)
                {

                    if (tapHold == "B")
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                        Console.WriteLine("Hold Region: BOTTOM CORNER");


                    }
                    else if (tapHold == "H")
                    {
                        HoldAlert.Text = "Hold Region: SIDE CENTER";
                        Console.WriteLine("Hold Region: SIDE CENTER");


                    }
                    else if (tapHold == "C")
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                        Console.WriteLine("Hold Region: BOTTOM CENTER");
                    }

                    if (holdCountT > 2)
                    {
                        HoldAlert.Text = "The task is complete!";
                        Console.WriteLine("The task is complete!");
                        Canvas1.Background = end;
                    }
                }

                else if (three_regions == false)
                {

                    if (tapHold == "B")
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                        Console.WriteLine("Hold Region: BOTTOM CORNER");


                    }
                    else if (tapHold == "H")
                    {
                        HoldAlert.Text = "Hold Region: SIDE CENTER";
                        Console.WriteLine("Hold Region: SIDE CENTER");


                    }
                    else if (tapHold == "C")
                    {
                        HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                        Console.WriteLine("Hold Region: BOTTOM CENTER");
                    }

                    if (holdCountT > 2)
                    {
                        HoldAlert.Text = "The task is complete!";
                        Console.WriteLine("The task is complete!");
                        Canvas1.Background = end;
                    }
                }
            }
        }
        #endregion

        #region hold alert for swipe
        public void holdAlertSwipe(int whichHoldS)
        {
            if (tapping == false)
            {
                if (whichHoldS == 0)
                {
                    HoldAlert.Text = "Hold Region: BOTTOM CORNER";
                    Console.WriteLine("Hold Region: BOTTOM CORNER");
                    swipeHoldReg = "B";
                }
                else if (whichHoldS == 1)
                {
                    HoldAlert.Text = "Hold Region: SIDE CENTER";
                    Console.WriteLine("Hold Region: SIDE CENTER");
                    swipeHoldReg = "H";
                }
                else if (whichHoldS == 2)
                {
                    HoldAlert.Text = "Hold Region: BOTTOM CENTER";
                    Console.WriteLine("Hold Region: BOTTOM CENTER");
                    swipeHoldReg = "C";
                }
            }
        }
        #endregion

        #region Error Counter [old]
        public void errorCounter()
        {
            #region Error Counter and 'Wrong' Feedback and TouchPoints Collector
            if ((containsCirclePrimary) || (containsCircle))
            {
                switch (twoORthree)
                {
                    case 3:
                        if (!((PointInTriangle(tappingPoint, b_one1, b_one2, b_one3)
                                && (b_i == a_ || b_i == c_ || b_i == h_ || b_i == j_ || b_i == n_))) 
                            && !((rect_bc_1.Contains(tappingPoint)
                                && (b_i == a3_ || b_i == c3_ || b_i == h3_ || b_i == j3_ || b_i == n3_)))
                            && !((PointInTriangle(tappingPoint, h_one1, h_one2, h_one3)
                                && (b_i == a2_ || b_i == c2_ || b_i == h2_ || b_i == j2_ || b_i == n2_))))
                        {
                            circleError += 1;

                            allPoints.Add(tappingPoint);

                            //feedback
                            SignalBox.Text = "WRONG...";
                        }
                        break;

                    case 2:
                        if (!((PointInTriangle(tappingPoint, t_b_one1, t_b_one2, t_b_one3)
                                && (t_touchHoldRegion == "b"))) 
                            && !((t_rect_bc_1.Contains(tappingPoint)
                                && (t_touchHoldRegion == "c")))
                            && !((PointInTriangle(tappingPoint, t_h_one1, t_h_one2, t_h_one3)
                                && (t_touchHoldRegion == "h"))))
                        {
                            circleError += 1;

                            allPoints.Add(tappingPoint);

                            //feedback
                            SignalBox.Text = "WRONG...";
                        }
                        break;
                }
            }
            if (containsRectangle)
            {
                switch (twoORthree)
                {
                    case 3:

                        if (!((PointInTriangle(tappingPoint, b_two1, b_two2, b_two3)
                                && (b_i == b_ || b_i == d_ || b_i == f_ || b_i == k_ || b_i == m_))) 
                            && !((rect_bc_2.Contains(tappingPoint)
                                 && (b_i == b3_ || b_i == d3_ || b_i == f3_ || b_i == k3_ || b_i == m3_)))
                            && !((PointInTriangle(tappingPoint, h_two1, h_two2, h_two3)
                                 && (b_i == b2_ || b_i == d2_ || b_i == f2_ || b_i == k2_ || b_i == m2_))))
                        {
                            rectangleError += 1;

                            allPoints.Add(tappingPoint);
                            //feedback
                            SignalBox.Text = "WRONG...";
                        }
                        break;

                    case 2:

                        if (!((PointInTriangle(tappingPoint, t_b_two1, t_b_two2, t_b_two3)
                                 && (t_touchHoldRegion == "b"))) 
                            && !((t_rect_bc_2.Contains(tappingPoint)
                                 && (t_touchHoldRegion == "c")))
                            && !((PointInTriangle(tappingPoint, t_h_two1, t_h_two2, t_h_two3)
                                 && (t_touchHoldRegion == "h"))))
                        {
                            rectangleError += 1;

                            allPoints.Add(tappingPoint);
                            //feedback
                            SignalBox.Text = "WRONG...";
                        }

                        break;
                }
            }
            if (containsTriangle)
            {

                if (!((PointInTriangle(tappingPoint, b_three1, b_three2, b_three3)
                         && (b_i == e_ || b_i == g_ || b_i == i_ || b_i == l_))) 
                    && !((rect_bc_3.Contains(tappingPoint)
                         && (b_i == e3_ || b_i == g3_ || b_i == i3_ || b_i == l3_)))
                    && !((PointInTriangle(tappingPoint, h_three1, h_three2, h_three3)
                         && (b_i == e2_ || b_i == g2_ || b_i == i2_ || b_i == l2_))))
                {
                    triangleError += 1;

                    allPoints.Add(tappingPoint);
                    //feedback
                    SignalBox.Text = "WRONG...";
                }
            }

            #endregion

            #region 'Correct' Feedback,TouchPoints Printer and Cleaner
            if ((containsCirclePrimary) || (containsCircle))
            {
                switch (twoORthree)
                {
                    case 3:

                        if (((PointInTriangle(tappingPoint, b_one1, b_one2, b_one3)) && ((b_i == a_ || b_i == c_ || b_i == h_ || b_i == j_ || b_i == n_)))
                            || ((rect_bc_1.Contains(tappingPoint)) && (b_i == a3_ || b_i == c3_ || b_i == h3_ || b_i == j3_ || b_i == n3_))
                            || ((PointInTriangle(tappingPoint, h_one1, h_one2, h_one3)) && (b_i == a2_ || b_i == c2_ || b_i == h2_ || b_i == j2_ || b_i == n2_)))
                        {

                            allPoints.Add(tappingPoint);
                            Console.WriteLine(allPoints);
                            timerWatch();
                            //log
                            using (StreamWriter writer = new StreamWriter(participantID + ".txt", true))
                            {
                                writer.Write(hand + ";" + twoORthree + ";" + holdRegion + ";" + touchRegion + ";" + allPoints + ";" + timeToTap + ";" + circleError + ";");
                            }

                            allPoints.Clear();
                            
                            //feedback
                            SignalBox.Text = "CORRECT!!!";
                            HoldAlertBox();
                           
                        }
                        break;

                    case 2:
                        if (((PointInTriangle(tappingPoint, t_b_one1, t_b_one2, t_b_one3)) && (t_touchHoldRegion == "b"))
                            || ((t_rect_bc_1.Contains(tappingPoint)) && (t_touchHoldRegion == "c"))
                            || ((PointInTriangle(tappingPoint, t_h_one1, t_h_one2, t_h_one3)) && (t_touchHoldRegion == "h")))
                            {
            
                            allPoints.Add(tappingPoint);
                            Console.WriteLine(allPoints);
                            timerWatch();
                            //log
                            using (StreamWriter writer = new StreamWriter(participantID + ".txt", true))
                            {
                                writer.Write(hand + ";" + twoORthree + ";" + holdRegion + ";" + touchRegion + ";" + allPoints + ";" + timeToTap + ";" + circleError + ";");
                            }

                            allPoints.Clear();
                            
                            //feedback
                            SignalBox.Text = "CORRECT!!!";
                            HoldAlertBox();
                            
                        }

                        break;

                }
            }
            if (containsRectangle)
            {
                switch (twoORthree)
                {
                    case 3:
                        if (((PointInTriangle(tappingPoint, b_two1, b_two2, b_two3)) && (b_i == b_ || b_i == d_ || b_i == f_ || b_i == k_ || b_i == m_))
                            || ((rect_bc_2.Contains(tappingPoint)) && (b_i == b3_ || b_i == d3_ || b_i == f3_ || b_i == k3_ || b_i == m3_))
                            || ((PointInTriangle(tappingPoint, h_two1, h_two2, h_two3)) && (b_i == b2_ || b_i == d2_ || b_i == f2_ || b_i == k2_ || b_i == m2_)))
                        {
                            

                            allPoints.Add(tappingPoint);
                            Console.WriteLine(allPoints);
                            timerWatch();
                            //log
                            using (StreamWriter writer = new StreamWriter(participantID + ".txt", true))
                            {
                                writer.Write(hand + ";" + twoORthree + ";" + holdRegion + ";" + touchRegion + ";" + allPoints + ";" + timeToTap + ";" + rectangleError + ";");
                            }
                            allPoints.Clear();
                            
                            //feedback
                            SignalBox.Text = "CORRECT!!!";
                            HoldAlertBox();
                        }
                        break;

                    case 2:
                        if (((PointInTriangle(tappingPoint, t_b_two1, t_b_two2, t_b_two3)) && (t_touchHoldRegion == "b"))
                            || ((t_rect_bc_2.Contains(tappingPoint)) && (t_touchHoldRegion == "c"))
                            || ((PointInTriangle(tappingPoint, t_h_two1, t_h_two2, t_h_two3)) && (t_touchHoldRegion == "h")))
                        {

                            allPoints.Add(tappingPoint);
                            Console.WriteLine(allPoints);
                            timerWatch();
                            //log
                            using (StreamWriter writer = new StreamWriter(participantID + ".txt", true))
                            {
                                writer.Write(hand + ";" + twoORthree + ";" + holdRegion + ";" + touchRegion + ";" + allPoints + ";" + timeToTap + ";" + rectangleError + ";");
                            }
                            allPoints.Clear();
                            
                            //feedback
                            SignalBox.Text = "CORRECT!!!";
                            HoldAlertBox();

                            
                        }
                        break;

                }
            }
            if (containsTriangle)
            {
                if (((PointInTriangle(tappingPoint, b_three1, b_three2, b_three3)) && (b_i == e_ || b_i == g_ || b_i == i_ || b_i == l_))
                    || ((rect_bc_3.Contains(tappingPoint)) && (b_i == e3_ || b_i == g3_ || b_i == i3_ || b_i == l3_))
                    || ((PointInTriangle(tappingPoint, h_three1, h_three2, h_three3)) && (b_i == e2_ || b_i == g2_ || b_i == i2_ || b_i == l2_)))
                {

                    allPoints.Add(tappingPoint);
                    timerWatch();
                    //log
                    using (StreamWriter writer = new StreamWriter(participantID + ".txt", true))
                    {
                        writer.Write(hand + ";" + twoORthree + ";" + holdRegion + ";" + touchRegion + ";" + allPoints + ";" + timeToTap + ";" + triangleError + ";");
                    }
                    Console.WriteLine(allPoints);
                    allPoints.Clear();
                    
                    //feedback
                    SignalBox.Text = "CORRECT!!!";
                    HoldAlertBox();
                }
            }

            #endregion
        }


        #endregion

        

        #region draw and count  [old]
        public void drawAndCount(string nextShapeIn)
        {
            if (fourteen == false || tweentyEight == false)
            {
                if (b_i < 42)
                {
                    if (three_regions == true)
                    {
                        if (nextShapeIn == "b-circle")
                        {
                            if (cirN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("....." + cirN);
                            }
                            if (cirN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.YellowGreen;
                                //circleHeight += 50;
                                //circleWidth += 50;
                                Canvas1.Children.Add(newCircle);
                                Console.WriteLine("-----" + cirN);
                            }
                            cirN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "b-rectangle")
                        {
                            if (recN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newRectangle);
                            }
                            if (recN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Violet;
                                Canvas1.Children.Add(newRectangle);
                            }
                            recN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "b-triangle")
                        {
                            if (triN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Green;
                                Canvas1.Children.Add(newTriangle);
                            }
                            if (triN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Black;
                                Canvas1.Children.Add(newTriangle);
                            }
                            triN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "h-circle")
                        {
                            if (cirN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newCircle);
                            }
                            if (cirN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.YellowGreen;
                                //circleHeight += 50;
                                //circleWidth += 50;
                                Canvas1.Children.Add(newCircle);
                            }
                            cirN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "h-rectangle")
                        {
                            if (recN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newRectangle);
                            }
                            if (recN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Violet;
                                Canvas1.Children.Add(newRectangle);
                            }
                            recN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "h-triangle")
                        {
                            if (triN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Green;
                                Canvas1.Children.Add(newTriangle);
                            }
                            if (triN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Black;
                                Canvas1.Children.Add(newTriangle);
                            }
                            triN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "c-circle")
                        {
                            if (cirN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newCircle);
                            }
                            if (cirN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newCircle.Fill = Brushes.YellowGreen;
                                //circleHeight += 50;
                                //circleWidth += 50;
                                Canvas1.Children.Add(newCircle);
                            }
                            cirN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "c-rectangle")
                        {
                            if (recN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Red;
                                Canvas1.Children.Add(newRectangle);
                            }
                            if (recN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newRectangle.Fill = Brushes.Violet;
                                Canvas1.Children.Add(newRectangle);
                            }
                            recN += 1;
                            b_i += 1;

                        }

                        if (nextShapeIn == "c-triangle")
                        {
                            if (triN % 2 == 0)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Green;
                                Canvas1.Children.Add(newTriangle);
                            }
                            if (triN % 2 != 0)
                            {
                                Canvas1.Children.Clear();
                                newTriangle.Fill = Brushes.Black;
                                Canvas1.Children.Add(newTriangle);
                            }
                            triN += 1;
                            b_i += 1;

                        }

                        Console.WriteLine("b_i : " + b_i);
                        Console.WriteLine("nxt_T: " + nextshape);
                        Console.WriteLine("nxtVal: " + nxt);

                        using (StreamWriter writer = new StreamWriter("logger.txt", true))
                        {
                            writer.WriteLine("t_i : " + b_i + "nxt_T: " + nextshape + "nxtVal: " + nxt);
                        }
                    }
                }
            }

            if (t_i < 10)
            {
                if (three_regions == false)
                {
                    if (t_nextshape == "b-circle")
                    {
                        if (cirN % 2 == 0)
                        {
                            Canvas1.Children.Clear();
                            newCircle.Fill = Brushes.Violet;
                            Canvas1.Children.Add(newCircle);
                        }
                        if (cirN % 2 != 0)
                        {
                            Canvas1.Children.Clear();
                            newCircle.Fill = Brushes.YellowGreen;
                            //circleHeight += 50;
                            //circleWidth += 50;
                            Canvas1.Children.Add(newCircle);
                        }
                        cirN += 1;
                        t_i += 1;
                        
                    }

                    if (t_nextshape == "b-rectangle")
                    {
                        if (recN % 2 == 0)
                        {
                            Canvas1.Children.Clear();
                            newRectangle.Fill = Brushes.Red;
                            Canvas1.Children.Add(newRectangle);
                        }
                        if (recN % 2 != 0)
                        {
                            Canvas1.Children.Clear();
                            newRectangle.Fill = Brushes.Violet;
                            Canvas1.Children.Add(newRectangle);
                        }
                        recN += 1;
                        t_i += 1;
                        
                    }

                    Console.WriteLine("t_i : " + t_i);
                    Console.WriteLine("nxt_T: " + t_nextshape);
                    Console.WriteLine("nxtVal: " + t_nxt);

                    using (StreamWriter writer = new StreamWriter("logger.txt", true))
                    {
                        writer.WriteLine("t_i : " + t_i + "nxt_T: " + t_nextshape + "nxtVal: " + t_nxt);
                    }

                }
            }
        }
        #endregion

        #region TouchEvents
        private void Window_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            //touch down
            #region TouchPoint Variables
            xPosition = Math.Round(e.ManipulationOrigin.X, 0);
            yPosition = Math.Round(e.ManipulationOrigin.Y, 0);

            //TappingPoint
            tappingPoint = new Point(xPosition + 1, yPosition);
            #endregion
            
            holdRegIdnSwipe(); //For StartButton                      

            #region incrementer randomness
            //booleanSwitch 
            //3regions
            if (three_regions == true)
            {
                if (i3 % 2 == 0)
                {
                    booleanSwitchT3 = true;
                }
                else if (i3 % 2 != 0)
                {
                    booleanSwitchT3 = false;
                }
            }
                //2regions
            else if (three_regions == false)
            {
                if (i2 % 2 == 0)
                {
                    booleanSwitchT3 = true;
                }
                else if (i2 % 2 != 0)
                {
                    booleanSwitchT3 = false;
                }
            }

            //i3
            switch (i3)
            { 
                case 3:
                    //rndTap = new Random();
                    tappingArray3Rnd = tappingArray3.OrderBy(x => rndTap.Next()).ToArray();
                    Console.WriteLine("ARRAY:::" + tappingArray3Rnd);
                    break;
                case 6:
                    //rndTap = new Random();
                    tappingArray3Rnd = tappingArray3.OrderBy(x => rndTap.Next()).ToArray();
                    Console.WriteLine("ARRAY:::" + tappingArray3Rnd);
                    break;
                case 9:
                    //rndTap = new Random();
                    tappingArray3Rnd = tappingArray3.OrderBy(x => rndTap.Next()).ToArray();
                    Console.WriteLine("ARRAY:::" + tappingArray3Rnd);
                    break;
                case 12:
                    //rndTap = new Random();
                    tappingArray3Rnd = tappingArray3.OrderBy(x => rndTap.Next()).ToArray();
                    Console.WriteLine("ARRAY:::" + tappingArray3Rnd);
                    break;
                case 15:
                    //rndTap = new Random();
                    tappingArray3Rnd = tappingArray3.OrderBy(x => rndTap.Next()).ToArray();
                    Console.WriteLine("ARRAY:::" + tappingArray3Rnd);
                    break;
            }
            //2 regions
            switch (i2)
            { 
                case 2:
                    tappingArray2Rnd = tappingArray2.OrderBy(x => rndTap.Next()).ToArray();
                    break;
                case 4:
                    tappingArray2Rnd = tappingArray2.OrderBy(x => rndTap.Next()).ToArray();
                    break;
                case 6:
                    tappingArray2Rnd = tappingArray2.OrderBy(x => rndTap.Next()).ToArray();
                    break;
                case 8:
                    tappingArray2Rnd = tappingArray2.OrderBy(x => rndTap.Next()).ToArray();
                    break;
                case 10:
                    tappingArray2Rnd = tappingArray2.OrderBy(x => rndTap.Next()).ToArray();
                    break;
            }

            #endregion
            //Console.WriteLine("ARRAY:::" + tappingArray3Rnd[0] + ";" + tappingArray3Rnd[1] + ";" + tappingArray3Rnd[2]);
           
            HoldAlertBox();
            
            #region Done and Change hold automatically
            if ((Canvas1.Background == done) && (tapHold == "B"))
            {
                if (bRect.Contains(tappingPoint))
                {
                    holdChangeDraw();
                    timerWatch();
                }
            }
            else if ((Canvas1.Background == done) && (tapHold == "H"))
            {
                if (hRect.Contains(tappingPoint))
                {
                    holdChangeDraw();
                    timerWatch();
                }
            }
            else if ((Canvas1.Background == done) && (tapHold == "C"))
            {
                if (cRect.Contains(tappingPoint))
                {
                    holdChangeDraw();
                    timerWatch();
                }
            }
            #endregion

            
            
            Console.WriteLine("down EVENT ENTERED");
            Console.WriteLine(tappingPoint.X + ";" + tappingPoint.Y);
            //Console.WriteLine("Pixel: " + ScreenXPixel + ";" + ScreenYPixel);
            Console.WriteLine("Point: " + ScreenX + ";" + ScreenY);
            
            
            //SPECIAL FUNCTIONS: swipe timer // NOT FOR TAPPING - START
            swipeWatch.Stop();
            swipeWatch.Restart();
            //SPECIAL FUNCTIONS: swipe timer // NOT FOR TAPPING - END
            
            
            
            if (tapping == true)
            {
                /*
            //log
            using (StreamWriter writer = new StreamWriter("T-" + participantID + ".txt", true))
            {
                writer.Write(Environment.NewLine + participantID + ";");
            }

            */

            //HoldHoldChange();
            //HoldChangeManager();

            Console.WriteLine("participant id::::" + participantID);


            #region WhichHold identifer for touch input 3 regions
            if (b_i == a_ || b_i == b_ || b_i == c_ || b_i == d_ || b_i == e_ || b_i == f_ || b_i == g_
                 || b_i == h_ || b_i == i_ || b_i == j_ || b_i == k_ || b_i == l_ || b_i == m_ || b_i == n_)
            {
                touchHoldRegion = "b";
            }
            else if (b_i == a2_ || b_i == b2_ || b_i == c2_ || b_i == d2_ || b_i == e2_ || b_i == f2_ || b_i == g2_
                 || b_i == h2_ || b_i == i2_ || b_i == j2_ || b_i == k2_ || b_i == l2_ || b_i == m2_ || b_i == n2_)
            {
                touchHoldRegion = "h";
            }
            else if (b_i == a3_ || b_i == b3_ || b_i == c3_ || b_i == d3_ || b_i == e3_ || b_i == f3_ || b_i == g3_
                 || b_i == h3_ || b_i == i3_ || b_i == j3_ || b_i == k3_ || b_i == l3_ || b_i == m3_ || b_i == n3_)
            {
                touchHoldRegion = "c";
            }


            #endregion

            #region Whichhold identifier for touchHoldRegion 2 regions
            if (((startingB == true) && (t_i >= 1 && t_i <= 3))
                || ((startingH == true) && (t_i >= 4 && t_i <= 6))
                || ((startingC == true) && (t_i >= 7 && t_i <= 9)))
            {
                t_touchHoldRegion = "b";
            }
            else if (((startingB == true) && (t_i >= 7 && t_i <= 9))
                || ((startingH == true) && (t_i >= 1 && t_i <= 3))
                || ((startingC == true) && (t_i >= 4 && t_i <= 6)))
            {
                t_touchHoldRegion = "h";
            }
            else if (((startingB == true) && (t_i >= 4 && t_i <= 6))
                || ((startingH == true) && (t_i >= 7 && t_i <= 9))
                || ((startingC == true) && (t_i >= 1 && t_i <= 3)))
            {
                t_touchHoldRegion = "c";
            }
            #endregion

            #region Time Variables for tapping
            string tapDate = DateTime.Now.ToLongDateString();
            string tapTime = DateTime.Now.ToLongTimeString();

            #endregion

            #region LEFT RIGHT CONVERSION
            if (left_handed == true)
            {
                //reset left hand
                bX1 = hX1 = 0;
                bX2 = hX2 = 330;

                bcX1 = 411;
                bcX2 = 741;

                hand = "L";
            }
            if (left_handed == false)
            {
                //left-hand to right hand transformation
                bX1 = hX1 = 1152;
                bX2 = hX2 = 1152 - 330 ;

                bcX1 = 1152 - 352;
                bcX2 = 1152 - 762;

                hand = "R";

                //Console
                Console.WriteLine("B1-1: " + b_one1.X + ";" + b_one1.Y);
                Console.WriteLine("B1-1: " + b_one2.X + ";" + b_one2.Y);
                Console.WriteLine("B1-1: " + b_one3.X + ";" + b_one3.Y);
            }
            #endregion

            #region 3 regions Variables
            //--bottom--center starts---

            //bottom-corner 1-1
            b_One1_x = bX1 * (ScreenX / 1152);
            b_One1_y = bY2 * (ScreenY / 720);
            b_One2_x = (((bX2 - bX1) * 2 / 5) + bX1) * (ScreenX / 1152);
            b_One2_y = bY1 * (ScreenY / 720);
            b_One3_x = bX1 * (ScreenX / 1152);
            b_One3_y = bY1 * (ScreenY / 720);

             b_one1 = new Point(b_One1_x, b_One1_y);
             b_one2 = new Point(b_One2_x, b_One2_y);
             b_one3 = new Point(b_One3_x, b_One3_y);

            //bottom-corner 1-2
             b_two1_x = bX1 * (ScreenX / 1152);
             b_two1_y = bY2 * (ScreenY / 720);
             b_two2_x = (((bX2 - bX1) * 2 / 5) + bX1) * (ScreenX / 1152);
             b_two2_y = bY1 * (ScreenY / 720);
             b_two3_x = bX2 * (ScreenX / 1152);
             b_two3_y = (bY1 + (bY2 - bY1) / 3) * (ScreenY / 720);

             b_two1 = new Point(b_two1_x, b_two1_y);
             b_two2 = new Point(b_two2_x, b_two2_y);
             b_two3 = new Point(b_two3_x, b_two3_y);

            //bottom-corner 1-3
             b_three1_x = bX2 * (ScreenX / 1152);
             b_three1_y = (bY1 + (bY2 - bY1) / 3) * (ScreenY / 720);
             b_three2_x = bX1 * (ScreenX / 1152);
             b_three2_y = bY2 * (ScreenY / 720);
             b_three3_x = bX2 * (ScreenX / 1152);
             b_three3_y = bY2 * (ScreenY / 720);

             b_three1 = new Point(b_three1_x, b_three1_y);
             b_three2 = new Point(b_three2_x, b_three2_y);
             b_three3 = new Point(b_three3_x, b_three3_y);

            //--bottom--center ends---

            //---horizontal-center --starts--

            //horizontal-center 1-1
             h_One1_x = hX1 * (ScreenX / 1152);
             h_One1_y = hY2 * (ScreenY / 720);
             h_One2_x = (((hX2 - hX1) * 2 / 5) + hX1) * (ScreenX / 1152);
             h_One2_y = hY1 * (ScreenY / 720);
             h_One3_x = hX1 * (ScreenX / 1152);
             h_One3_y = hY1 * (ScreenY / 720);

             h_one1 = new Point(h_One1_x, h_One1_y);
             h_one2 = new Point(h_One2_x, h_One2_y);
             h_one3 = new Point(h_One3_x, h_One3_y);

            //horizontal-center 1-2
             h_two1_x = hX1 * (ScreenX / 1152);
             h_two1_y = hY2 * (ScreenY / 720);
             h_two2_x = (((hX2 - hX1) * 2 / 5) + hX1) * (ScreenX / 1152);
             h_two2_y = hY1 * (ScreenY / 720);
             h_two3_x = hX2 * (ScreenX / 1152);
             h_two3_y = (hY1 + (hY2 - hY1) / 3) * (ScreenY / 720);

             h_two1 = new Point(h_two1_x, h_two1_y);
             h_two2 = new Point(h_two2_x, h_two2_y);
             h_two3 = new Point(h_two3_x, h_two3_y);

            //horizontal-center  1-3
             h_three1_x = hX2 * (ScreenX / 1152);
             h_three1_y = (hY1 + (hY2 - hY1) / 3) * (ScreenY / 720);
             h_three2_x = hX1 * (ScreenX / 1152);
             h_three2_y = hY2 * (ScreenY / 720);
             h_three3_x = hX2 * (ScreenX / 1152);
             h_three3_y = hY2 * (ScreenY / 720);

             h_three1 = new Point(h_three1_x, h_three1_y);
             h_three2 = new Point(h_three2_x, h_three2_y);
             h_three3 = new Point(h_three3_x, h_three3_y);

            //---horizontal-center --ends--

            //---bottom-center --starts--

            //bottom-center 1-1
             bc_One1_x = bcX1 * (ScreenX / 1152);
             bc_One1_y = bcY2 * (ScreenY / 720);
             bc_One2_x = (((bcX2 - bcX1) * 2 / 5) + bcX1) * (ScreenX / 1152);
             bc_One2_y = bcY1 * (ScreenY / 720);
             bc_One3_x = bcX1 * (ScreenX / 1152);
             bc_One3_y = bcY1 * (ScreenY / 720);

             bc_one1 = new Point(bc_One1_x, bc_One1_y);
             bc_one2 = new Point(bc_One2_x, bc_One2_y);
             bc_one3 = new Point(bc_One3_x, bc_One3_y);

            //bottom-center 1-2
             bc_two1_x = bcX1 * (ScreenX / 1152);
             bc_two1_y = bcY2 * (ScreenY / 720);
             bc_two2_x = (((bcX2 - bcX1) * 2 / 5) + bcX1) * (ScreenX / 1152);
             bc_two2_y = bcY1 * (ScreenY / 720);
             bc_two3_x = bcX2 * (ScreenX / 1152);
             bc_two3_y = (bcY1 + (bcY2 - bcY1) / 3) * (ScreenY / 720);

             bc_two1 = new Point(bc_two1_x, bc_two1_y);
             bc_two2 = new Point(bc_two2_x, bc_two2_y);
             bc_two3 = new Point(bc_two3_x, bc_two3_y);

            //bottom-center  1-3
             bc_three1_x = bcX2 * (ScreenX / 1152);
             bc_three1_y = (bcY1 + (bcY2 - bcY1) / 3) * (ScreenY / 720);
             bc_three2_x = bcX1 * (ScreenX / 1152);
             bc_three2_y = bcY2 * (ScreenY / 720);
             bc_three3_x = bcX2 * (ScreenX / 1152);
             bc_three3_y = bcY2 * (ScreenY / 720);

             bc_three1 = new Point(bc_three1_x, bc_three1_y);
             bc_three2 = new Point(bc_three2_x, bc_three2_y);
             bc_three3 = new Point(bc_three3_x, bc_three3_y);

            //---bottom-center --ends--
            #endregion//three regions ENDS-----------

            #region New Bottom Center Points [3 Regions]
            //New bottom-center 1-1
             n_bc_one1_x = bcX1 * (ScreenX / 1152);
             n_bc_one1_y = bcY2 * (ScreenY / 720);
             n_bc_one2_x = (bcX1 + (bcX2 - bcX1) / 3) * (ScreenX / 1152);
             n_bc_one2_y = bcY1 * (ScreenY / 720);

             rect_bc_1_p1 = new Point(n_bc_one1_x, n_bc_one1_y);
             rect_bc_1_p2 = new Point(n_bc_one2_x, n_bc_one2_y);

             rect_bc_1 = new Rect(rect_bc_1_p1, rect_bc_1_p2);

            //New bottom-center 1-2
             n_bc_two1_x = (bcX1 + (bcX2 - bcX1) / 3) * (ScreenX / 1152);
             n_bc_two1_y = bcY2 * (ScreenY / 720);
             n_bc_two2_x = ((bcX1 + (bcX2 - bcX1) / 3) + (bcX2 - bcX1) / 3) * (ScreenX / 1152);
             n_bc_two2_y = bcY1 * (ScreenY / 720);

             rect_bc_2_p1 = new Point(n_bc_two1_x, n_bc_two1_y);
             rect_bc_2_p2 = new Point(n_bc_two2_x, n_bc_two2_y);

             rect_bc_2 = new Rect(rect_bc_2_p1, rect_bc_2_p2);

            //New bottom-center 1-3
             n_bc_three1_x = ((bcX1 + (bcX2 - bcX1) / 3) + (bcX2 - bcX1) / 3) * (ScreenX / 1152);
             n_bc_three1_y = bcY2 * (ScreenY / 720);
             n_bc_three2_x = bcX2 * (ScreenX / 1152);
             n_bc_three2_y = bcY1 * (ScreenY / 720);

             rect_bc_3_p1 = new Point(n_bc_three1_x, n_bc_three1_y);
             rect_bc_3_p2 = new Point(n_bc_three2_x, n_bc_three2_y);

             rect_bc_3 = new Rect(rect_bc_3_p1, rect_bc_3_p2);

            #endregion

            #region 2 regions Variables

            //bottom-corner (2 region) 1-1
             t_b_One1_x = bX1 * (ScreenX / 1152);
             t_b_One1_y = bY2 * (ScreenY / 720);
             t_b_One2_x = bX2 * (ScreenX / 1152);
             t_b_One2_y = bY1 * (ScreenY / 720);
             t_b_One3_x = bX1 * (ScreenX / 1152);
             t_b_One3_y = bY1 * (ScreenY / 720);

             t_b_one1 = new Point(t_b_One1_x, t_b_One1_y);
             t_b_one2 = new Point(t_b_One2_x, t_b_One2_y);
             t_b_one3 = new Point(t_b_One3_x, t_b_One3_y);

            //bottom-corner (2 region) 1-2
             t_b_two1_x = bX1 * (ScreenX / 1152);
             t_b_two1_y = bY2 * (ScreenY / 720);
             t_b_two2_x = bX2 * (ScreenX / 1152);
             t_b_two2_y = bY1 * (ScreenY / 720);
             t_b_two3_x = bX2 * (ScreenX / 1152);
             t_b_two3_y = bY2 * (ScreenY / 720);

             t_b_two1 = new Point(t_b_two1_x, t_b_two1_y);
             t_b_two2 = new Point(t_b_two2_x, t_b_two2_y);
             t_b_two3 = new Point(t_b_two3_x, t_b_two3_y);

            //horizontal-center(2 region) 1-1
             t_h_one1_x = hX1 * (ScreenX / 1152);
             t_h_one1_y = hY2 * (ScreenY / 720);
             t_h_one2_x = hX2 * (ScreenX / 1152);
             t_h_one2_y = hY1 * (ScreenY / 720);
             t_h_one3_x = hX1 * (ScreenX / 1152);
             t_h_one3_y = hY1 * (ScreenY / 720);

             t_h_one1 = new Point(t_h_one1_x, t_h_one1_y);
             t_h_one2 = new Point(t_h_one2_x, t_h_one2_y);
             t_h_one3 = new Point(t_h_one3_x, t_h_one3_y);

            //horizontal-center(2 region)  1-2
             t_h_two1_x = hX1 * (ScreenX / 1152);
             t_h_two1_y = hY2 * (ScreenY / 720);
             t_h_two2_x = hX2 * (ScreenX / 1152);
             t_h_two2_y = hY1 * (ScreenY / 720);
             t_h_two3_x = hX2 * (ScreenX / 1152);
             t_h_two3_y = hY2 * (ScreenY / 720);

             t_h_two1 = new Point(t_h_two1_x, t_h_two1_y);
             t_h_two2 = new Point(t_h_two2_x, t_h_two2_y);
             t_h_two3 = new Point(t_h_two3_x, t_h_two3_y);

            //bottom-center(2 region) 1-1
             t_bc_one1_x = bcX1 * (ScreenX / 1152);
             t_bc_one1_y = bcY2 * (ScreenY / 720);
             t_bc_one2_x = bcX2 * (ScreenX / 1152);
             t_bc_one2_y = bcY1 * (ScreenY / 720);
             t_bc_one3_x = bcX1 * (ScreenX / 1152);
             t_bc_one3_y = bcY1 * (ScreenY / 720);

             t_bc_one1 = new Point(t_bc_one1_x, t_bc_one1_y);
             t_bc_one2 = new Point(t_bc_one2_x, t_bc_one2_y);
             t_bc_one3 = new Point(t_bc_one3_x, t_bc_one3_y);

            //bottom-center(2 region)  1-2
             t_bc_two1_x = bcX1 * (ScreenX / 1152);
             t_bc_two1_y = bcY2 * (ScreenY / 720);
             t_bc_two2_x = bcX2 * (ScreenX / 1152);
             t_bc_two2_y = bcY1 * (ScreenY / 720);
             t_bc_two3_x = bcX2 * (ScreenX / 1152);
             t_bc_two3_y = bcY2 * (ScreenY / 720);

             t_bc_two1 = new Point(t_bc_two1_x, t_bc_two1_y);
             t_bc_two2 = new Point(t_bc_two2_x, t_bc_two2_y);
             t_bc_two3 = new Point(t_bc_two3_x, t_bc_two3_y);

            #endregion//two regions ENDS-----------

            #region New Bottom Center Points [2 Regions]
            //New bottom-center [2 Regions] 1-1
             n_t_bc_one1_x = bcX1 * (ScreenX / 1152);
             n_t_bc_one1_y = bcY2 * (ScreenY / 720);
             n_t_bc_one2_x = (bcX1 + (bcX2 - bcX1) / 2) * (ScreenX / 1152);
             n_t_bc_one2_y = bcY1 * (ScreenY / 720);

             t_rect_bc_1_p1 = new Point(n_t_bc_one1_x, n_t_bc_one1_y);
             t_rect_bc_1_p2 = new Point(n_t_bc_one2_x, n_t_bc_one2_y);

             t_rect_bc_1 = new Rect(t_rect_bc_1_p1, t_rect_bc_1_p2);

            //New bottom-center [2 Regions] 1-2
             n_t_bc_two1_x = (bcX1 + (bcX2 - bcX1) / 2) * (ScreenX / 1152);
             n_t_bc_two1_y = bcY2 * (ScreenY / 720);
             n_t_bc_two2_x = bcX2 * (ScreenX / 1152);
             n_t_bc_two2_y = bcY1 * (ScreenY / 720);

             t_rect_bc_2_p1 = new Point(n_t_bc_two1_x, n_t_bc_two1_y);
             t_rect_bc_2_p2 = new Point(n_t_bc_two2_x, n_t_bc_two2_y);

             t_rect_bc_2 = new Rect(t_rect_bc_2_p1, t_rect_bc_2_p2);

            #endregion

            #region Shape Checker Booleans
            containsCirclePrimary = (Canvas1.Children.Contains(newCirclePrimary));
            containsCircle = (Canvas1.Children.Contains(newCircle));
            containsRectangle = (Canvas1.Children.Contains(newRectangle));
            containsTriangle = (Canvas1.Children.Contains(newTriangle));
            #endregion

            #region two OR three region
            if (three_regions == true)
            {
                twoORthree = 3;
            }
            if (three_regions == false)
            {
                twoORthree = 2;
            }
            #endregion

            #region touch region identifer

            //touch region
            switch (twoORthree)
            {
                case 3:
                    if ((PointInTriangle(tappingPoint, b_one1, b_one2, b_one3)) || (rect_bc_1.Contains(tappingPoint))
                        || (PointInTriangle(tappingPoint, h_one1, h_one2, h_one3)))
                    {
                        touchRegion = 1;
                    }
                    if ((PointInTriangle(tappingPoint, b_two1, b_two2, b_two3)) || (rect_bc_2.Contains(tappingPoint))
                        || (PointInTriangle(tappingPoint, h_two1, h_two2, h_two3)))
                    {
                        touchRegion = 2;
                    }
                    if ((PointInTriangle(tappingPoint, b_three1, b_three2, b_three3)) || (rect_bc_3.Contains(tappingPoint))
                        || (PointInTriangle(tappingPoint, h_three1, h_three2, h_three3)))
                    {
                        touchRegion = 3;
                    }
                    Console.WriteLine("TR: " + touchRegion);
                    break;

                case 2:
                    if ((PointInTriangle(tappingPoint, t_b_one1, t_b_one2, t_b_one3)) || (t_rect_bc_1.Contains(tappingPoint))
                        || (PointInTriangle(tappingPoint, t_h_one1, t_h_one2, t_h_one3)))
                    {
                        touchRegion = 1;
                    }
                    if ((PointInTriangle(tappingPoint, t_b_two1, t_b_two2, t_b_two3)) || (t_rect_bc_2.Contains(tappingPoint))
                        || (PointInTriangle(tappingPoint, t_h_two1, t_h_two2, t_h_two3)))
                    {
                        touchRegion = 2;
                    }
                    Console.WriteLine("TR: " + touchRegion);
                    break;


            }
            #endregion

            #region hold region identifer 
            //2 region falls into 3 regions, so no need to identify hold region for 2-touch regions
            //B = bottom corner, H = Horizontal Center, C = Bottom Center
            if ((PointInTriangle(tappingPoint, b_one1, b_one2, b_one3)) || (PointInTriangle(tappingPoint, b_two1, b_two2, b_two3))
                || (PointInTriangle(tappingPoint, b_three1, b_three2, b_three3)))
            {
                holdRegion = "B";
            }
            if ((PointInTriangle(tappingPoint, h_one1, h_one2, h_one3)) || (PointInTriangle(tappingPoint, h_two1, h_two2, h_two3))
                || (PointInTriangle(tappingPoint, h_three1, h_three2, h_three3)))
            {
                holdRegion = "H";
            }
            if ((rect_bc_1.Contains(tappingPoint)) || (rect_bc_2.Contains(tappingPoint)) || (rect_bc_3.Contains(tappingPoint)))
            {
                holdRegion = "C";
            }

            #endregion

            

            #region error counter NEW
            if (left_handed == true)
            {

                if (three_regions == true)
                {
                    if (Canvas1.Background != done)
                    {
                        if (containsCircle)
                        {
                            if (!((PointInTriangle(tappingPoint, b_one1, b_one2, b_one3)) && (tapHold == "B"))
                                || !((PointInTriangle(tappingPoint, h_one1, h_one2, h_one3)) && (tapHold == "H"))
                                    || !((rect_bc_1.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorCircle++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::cirlce::::::" + errorCircle);
                            }

                        }
                        else if (containsRectangle)
                        {
                            if (!((PointInTriangle(tappingPoint, b_two1, b_two2, b_two3)) && (tapHold == "B"))
                                || !((!PointInTriangle(tappingPoint, h_two1, h_two2, h_two3)) && (tapHold == "H"))
                                    || !((rect_bc_2.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorRect++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::rect::::::" + errorRect);
                            }

                        }
                        else if (containsTriangle)
                        {
                            if (!((PointInTriangle(tappingPoint, b_three1, b_three2, b_three3)) && (tapHold == "B"))
                                || !((!PointInTriangle(tappingPoint, h_three1, h_three2, h_three3)) && (tapHold == "H"))
                                    || !((rect_bc_3.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorTriangle++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::triangle::::::" + errorTriangle);

                            }

                        }
                    }
                }
                //2 regions
                else if (three_regions == false)
                {
                    if (Canvas1.Background != done)
                    {
                        if (containsCircle)
                        {
                            if (!((PointInTriangle(tappingPoint, t_b_one1, t_b_one2, t_b_one3)) && (tapHold == "B"))
                                || !((PointInTriangle(tappingPoint, t_h_one1, t_h_one2, t_h_one3)) && (tapHold == "H"))
                                    || !((t_rect_bc_1.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorCircle++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::cirlce2regions::::::" + errorCircle);
                            }

                        }
                        else if (containsRectangle)
                        {
                            if (!((PointInTriangle(tappingPoint, t_b_two1, t_b_two2, t_b_two3)) && (tapHold == "B"))
                                || !((!PointInTriangle(tappingPoint, t_h_two1, t_h_two2, t_h_two3)) && (tapHold == "H"))
                                    || !((t_rect_bc_2.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorRect++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::rect2region::::::" + errorRect);
                            }

                        }

                    }
                }
            }
                //right hand error collection

            if (left_handed == false)
            {

                if (three_regions == true)
                {
                    if (Canvas1.Background != done)
                    {
                        if (containsTriangle)
                        {
                            if (!((PointInTriangle(tappingPoint, b_one1, b_one2, b_one3)) && (tapHold == "B"))
                                || !((PointInTriangle(tappingPoint, h_one1, h_one2, h_one3)) && (tapHold == "H"))
                                    || !((rect_bc_1.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorTriangle++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::cirlce::::::" + errorCircle);
                            }

                        }
                        else if (containsRectangle)
                        {
                            if (!((PointInTriangle(tappingPoint, b_two1, b_two2, b_two3)) && (tapHold == "B"))
                                || !((!PointInTriangle(tappingPoint, h_two1, h_two2, h_two3)) && (tapHold == "H"))
                                    || !((rect_bc_2.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorRect++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::rect::::::" + errorRect);
                            }

                        }
                        else if (containsCircle)
                        {
                            if (!((PointInTriangle(tappingPoint, b_three1, b_three2, b_three3)) && (tapHold == "B"))
                                || !((!PointInTriangle(tappingPoint, h_three1, h_three2, h_three3)) && (tapHold == "H"))
                                    || !((rect_bc_3.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorCircle++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::triangle::::::" + errorTriangle);

                            }

                        }
                    }
                }
                //2 regions
                else if (three_regions == false)
                {
                    if (Canvas1.Background != done)
                    {
                        if (containsRectangle)
                        {
                            if (!((PointInTriangle(tappingPoint, t_b_one1, t_b_one2, t_b_one3)) && (tapHold == "B"))
                                || !((PointInTriangle(tappingPoint, t_h_one1, t_h_one2, t_h_one3)) && (tapHold == "H"))
                                    || !((t_rect_bc_1.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorRect++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::cirlce2regions::::::" + errorCircle);
                            }

                        }
                        else if (containsCircle)
                        {
                            if (!((PointInTriangle(tappingPoint, t_b_two1, t_b_two2, t_b_two3)) && (tapHold == "B"))
                                || !((!PointInTriangle(tappingPoint, t_h_two1, t_h_two2, t_h_two3)) && (tapHold == "H"))
                                    || !((t_rect_bc_2.Contains(tappingPoint)) && (tapHold == "C")))
                            {
                                errorCircle++;
                                collectPoints.Add(tappingPoint);
                                Console.WriteLine(":::::rect2region::::::" + errorRect);
                            }

                        }

                    }
                }
            }

            #endregion

            Console.WriteLine("i2:::" + i2);
            Console.WriteLine("i3:::" + i3);

            //Console.WriteLine(ScreenX + "  :  " + ScreenY);

            if (tapping == true)
            {
                MoveObjects.X = 0;
                MoveObjects.Y = 0;

                if (Canvas1.Background != end && Canvas1.Background != done)
                {
                    //Console.WriteLine(three_regions + " : " + left_handed);
                    #region Left Hand Tapping
                    //###########*****************************LEFT HAND TAPPING*******STARTS********************
                    if (hand == "L")
                    {

                        #region Left Hand 3 Regions
                        //****-----------3 region starts-----------
                        if (three_regions == true)
                        {
                            if (tapHold == "B")
                            {
                                if (PointInTriangle(tappingPoint, b_one1, b_one2, b_one3))
                                {
                                    Console.WriteLine("bottom-corner 1-1");

                                    if ((containsCirclePrimary) || (containsCircle))
                                    {


                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorCircle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorCircle = 0;
                                        i3++;

                                    }

                                }

                                //bottom-corner 1-2
                                else if (PointInTriangle(tappingPoint, b_two1, b_two2, b_two3))
                                {
                                    Console.WriteLine("bottom-corner 1-2");

                                    if (containsRectangle)
                                    {



                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorRect);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();

                                        collectPoints.Clear();
                                        errorRect = 0;
                                        i3++;

                                    }

                                }
                                //bottom-corner 1-3
                                else if (PointInTriangle(tappingPoint, b_three1, b_three2, b_three3))
                                {
                                    Console.WriteLine("bottom-corner 1-3");

                                    if (containsTriangle)
                                    {
                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorTriangle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorTriangle = 0;
                                        i3++;

                                    }
                                }
                            }
                            //--------------------bottom---corner----hold---ends-----

                            //--------------------horizontal-center----hold---starts--
                            //horizontal-center-- 1-1
                            else if (tapHold == "H")
                            {
                                if (PointInTriangle(tappingPoint, h_one1, h_one2, h_one3))
                                {
                                    Console.WriteLine("horizontal-center--1-1");

                                    if ((containsCirclePrimary) || (containsCircle))
                                    {

                                        timerWatch();

                                        tappingLogger();
                                        Console.WriteLine(errorCircle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorCircle = 0;
                                        i3++;
                                    }
                                }
                                //horizontal-center-- 1-2
                                else if (PointInTriangle(tappingPoint, h_two1, h_two2, h_two3))
                                {
                                    Console.WriteLine("horizontal-center--1-2");

                                    if (containsRectangle)
                                    {
                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorRect);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorRect = 0;
                                        i3++;
                                    }
                                }
                                //horizontal-center-- 1-3
                                else if (PointInTriangle(tappingPoint, h_three1, h_three2, h_three3))
                                {
                                    Console.WriteLine("horizontal-center--1-3");

                                    if (containsTriangle)
                                    {
                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorTriangle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorTriangle = 0;
                                        i3++;
                                    }
                                }
                            }
                            //-----------------horizontal-center------hold---ends-----

                            //--------------------bottom-center----hold---starts--
                            //bottom-center-- 1-1
                            if (tapHold == "C")
                            {
                                if (rect_bc_1.Contains(tappingPoint))
                                {
                                    Console.WriteLine("bottom-center--1-1");

                                    if ((containsCirclePrimary) || (containsCircle))
                                    {
                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorCircle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorCircle = 0;
                                        i3++;
                                    }
                                }
                                //bottom-center-- 1-2
                                else if (rect_bc_2.Contains(tappingPoint))
                                {
                                    Console.WriteLine("bottom-center--1-2");

                                    if (containsRectangle)
                                    {
                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorRect);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorRect = 0;
                                        i3++;
                                    }
                                }
                                //bottom-center-- 1-3
                                else if (rect_bc_3.Contains(tappingPoint))
                                {
                                    Console.WriteLine("bottom-center--1-3");

                                    if (containsTriangle)
                                    {
                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorTriangle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorTriangle = 0;
                                        i3++;
                                    }
                                }
                            }
                            //-----------------bottom-center------hold---ends-----
                        }
                        //****---- 3 regions --------------- ends
                        #endregion

                        #region Left Hand 2 Regions
                        if (Canvas1.Background != done)
                        {
                            //****---- 2 regions --------------- starts
                            if (three_regions == false)
                            {
                                if (tapHold == "B")
                                {
                                    //bottom-corner-- 2 regions
                                    if (PointInTriangle(tappingPoint, t_b_one1, t_b_one2, t_b_one3))
                                    {
                                        Console.WriteLine("bottom-corner(2 region)--1-1");

                                        if ((containsCirclePrimary) || (containsCircle))
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorCircle);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorCircle = 0;
                                            i2++;
                                        }
                                    }
                                    else if (PointInTriangle(tappingPoint, t_b_two1, t_b_two2, t_b_two3))
                                    {
                                        Console.WriteLine("bottom-corner--(2 region)  1-2");

                                        if (containsRectangle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorRect);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorRect = 0;
                                            i2++;
                                        }
                                    }
                                }
                                //horizontal-corner-- 2 regions
                                if (tapHold == "H")
                                {
                                    if (PointInTriangle(tappingPoint, t_h_one1, t_h_one2, t_h_one3))
                                    {
                                        Console.WriteLine("horiz-center (2 region)--1-1");

                                        if ((containsCirclePrimary) || (containsCircle))
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorCircle);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorCircle = 0;
                                            i2++;
                                        }
                                    }
                                    else if (PointInTriangle(tappingPoint, t_h_two1, t_h_two2, t_h_two3))
                                    {
                                        Console.WriteLine("horzi-center--(2 region)  1-2");

                                        if (containsRectangle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorRect);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorRect = 0;
                                            i2++;
                                        }
                                    }
                                }

                                //bottom-center-- 2 regions
                                if (tapHold == "C")
                                {
                                    if (t_rect_bc_1.Contains(tappingPoint))
                                    {
                                        Console.WriteLine("bottom-center (2 region)--1-1");

                                        if ((containsCirclePrimary) || (containsCircle))
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorCircle);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorCircle = 0;
                                            i2++;
                                        }
                                    }
                                    else if (t_rect_bc_2.Contains(tappingPoint))
                                    {
                                        Console.WriteLine("bottom-center--(2 region)  1-2");

                                        if (containsRectangle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorRect);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorRect = 0;
                                            i2++;
                                        }
                                    }
                                }
                            }
                        }

                        ////****---- 2 regions --------------- ends
                    }
                        #endregion
                    //###########*****************************LEFT HAND TAPPING*******ENDS********************
                    #endregion

                    #region Right Hand Tapping
                    //###########*****************************  <<RIGHT HAND>> TAPPING*******STARTS********************
                    if (hand == "R")
                    {

                        #region Right Hand 3 Regions
                        if (three_regions == true)
                        {
                            if (tapHold == "B")
                            {
                                //--------------------bottom---corner----hold---starts-- <<RIGHT HAND>> ---
                                //bottom-corner  <<RIGHT HAND>> 1-1
                                if (PointInTriangle(tappingPoint, b_one1, b_one2, b_one3))
                                {
                                    Console.WriteLine("bottom-corner  <<RIGHT HAND>> 1-1");

                                    if (containsTriangle)
                                    {

                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorCircle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorCircle = 0;
                                        i3++;
                                    }
                                }
                                //bottom-corner <<RIGHT HAND>>  1-2
                                else if (PointInTriangle(tappingPoint, b_two1, b_two2, b_two3))
                                {
                                    Console.WriteLine("bottom-corner <<RIGHT HAND>>  1-2");

                                    if (containsRectangle)
                                    {

                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorRect);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorRect = 0;
                                        i3++;
                                    }
                                }
                                //bottom-corner  <<RIGHT HAND>> 1-3
                                else if (PointInTriangle(tappingPoint, b_three1, b_three2, b_three3))
                                {
                                    Console.WriteLine("bottom-corner  <<RIGHT HAND>> 1-3");

                                    if (containsCircle)
                                    {

                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorTriangle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorTriangle = 0;
                                        i3++;
                                    }
                                }
                            }
                            //--------------------bottom---corner----hold---ends-- <<RIGHT HAND>> ---

                            //--------------------horizontal-center----hold---starts- <<RIGHT HAND>> -
                            //horizontal-center- <<RIGHT HAND>> - 1-1
                            else if (tapHold == "H")
                            {
                                if (PointInTriangle(tappingPoint, h_one1, h_one2, h_one3))
                                {
                                    Console.WriteLine("horizontal-center- <<RIGHT HAND>> -1-1");

                                    if (containsTriangle)
                                    {

                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorCircle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorCircle = 0;
                                        i3++;
                                    }
                                }
                                //horizontal-center- <<RIGHT HAND>> - 1-2
                                else if (PointInTriangle(tappingPoint, h_two1, h_two2, h_two3))
                                {
                                    Console.WriteLine("horizontal-center- <<RIGHT HAND>> -1-2");

                                    if (containsRectangle)
                                    {

                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorRect);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorRect = 0;
                                        i3++;
                                    }
                                }
                                //horizontal-center- <<RIGHT HAND>> - 1-3
                                else if (PointInTriangle(tappingPoint, h_three1, h_three2, h_three3))
                                {
                                    Console.WriteLine("horizontal-center- <<RIGHT HAND>> -1-3");
                                    using (StreamWriter writer = new StreamWriter("tappingRightHand.txt", true))

                                        if (containsCircle)
                                        {

                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorTriangle);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorTriangle = 0;
                                            i3++;

                                        }
                                }
                            }
                            //-----------------horizontal-center------hold---ends-- <<RIGHT HAND>> ---

                            //--------------------bottom-center----hold---starts- <<RIGHT HAND>> -
                            //bottom-center- <<RIGHT HAND>> - 1-1
                            else if (tapHold == "C")
                            {
                                if (rect_bc_1.Contains(tappingPoint))
                                {
                                    Console.WriteLine("bottom-center- <<RIGHT HAND>> -1-1");

                                    if (containsTriangle)
                                    {

                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorCircle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorCircle = 0;
                                        i3++;
                                    }
                                }
                                //bottom-center- <<RIGHT HAND>> - 1-2
                                else if (rect_bc_2.Contains(tappingPoint))
                                {
                                    Console.WriteLine("bottom-center- <<RIGHT HAND>> -1-2");
                                    using (StreamWriter writer = new StreamWriter("tappingRightHand.txt", true))

                                        if (containsRectangle)
                                        {

                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorRect);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorRect = 0;
                                            i3++;
                                        }
                                }
                                //bottom-center- <<RIGHT HAND>> - 1-3
                                else if (rect_bc_3.Contains(tappingPoint))
                                {
                                    Console.WriteLine("bottom-center- <<RIGHT HAND>> -1-3");

                                    if (containsCircle)
                                    {

                                        timerWatch();
                                        tappingLogger();
                                        Console.WriteLine(errorTriangle);
                                        Console.WriteLine("collected point::" + collectPoints);
                                        tapInsturction();
                                        collectPoints.Clear();
                                        errorTriangle = 0;
                                        i3++;
                                    }
                                }
                                //-----------------bottom-center------hold---ends-- <<RIGHT HAND>> ---
                            }
                        }
                        //****---- 3 regions ----------- <<RIGHT HAND>> ---- ends
                        #endregion

                        #region Right Hand 2 Regions
                        //****---- 2 regions ------------ <<RIGHT HAND>> --- starts

                        if (three_regions == false)
                        {
                            if (Canvas1.Background != done)
                            {

                                if (tapHold == "B")
                                {

                                    //bottom-corner- <<RIGHT HAND>> - 2 regions
                                    if (PointInTriangle(tappingPoint, t_b_one1, t_b_one2, t_b_one3))
                                    {
                                        Console.WriteLine("bottom-corner(2 region)- <<RIGHT HAND>> -1-1");

                                        if (containsRectangle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorCircle);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorCircle = 0;
                                            i2++;
                                        }
                                    }

                                    else if (PointInTriangle(tappingPoint, t_b_two1, t_b_two2, t_b_two3))
                                    {
                                        Console.WriteLine("bottom-corner--(2 region)  <<RIGHT HAND>>  1-2");

                                        if (containsCircle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorRect);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorRect = 0;
                                            i2++;
                                        }
                                    }
                                }
                                //horizontal-corner- <<RIGHT HAND>> - 2 regions
                                if (tapHold == "H")
                                {

                                    if (PointInTriangle(tappingPoint, t_h_one1, t_h_one2, t_h_one3))
                                    {
                                        Console.WriteLine("horiz-center (2 region)- <<RIGHT HAND>> -1-1");

                                        if (containsRectangle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorCircle);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorCircle = 0;
                                            i2++;
                                        }
                                    }
                                    else if (PointInTriangle(tappingPoint, t_h_two1, t_h_two2, t_h_two3))
                                    {
                                        Console.WriteLine("horzi-center--(2 region)  <<RIGHT HAND>>  1-2");

                                        if (containsCircle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorRect);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorRect = 0;
                                            i2++;
                                        }
                                    }
                                }
                                //bottom-center- <<RIGHT HAND>> - 2 regions
                                if (tapHold == "C")
                                {

                                    if (t_rect_bc_1.Contains(tappingPoint))
                                    {
                                        Console.WriteLine("bottom-center (2 region)- <<RIGHT HAND>> -1-1");

                                        if (containsRectangle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorCircle);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorCircle = 0;
                                            i2++;
                                        }
                                    }
                                    else if (t_rect_bc_2.Contains(tappingPoint))
                                    {
                                        Console.WriteLine("bottom-center--(2 region)  <<RIGHT HAND>>  1-2");

                                        if (containsCircle)
                                        {
                                            timerWatch();
                                            tappingLogger();
                                            Console.WriteLine(errorRect);
                                            Console.WriteLine("collected point::" + collectPoints);
                                            tapInsturction();
                                            collectPoints.Clear();
                                            errorRect = 0;
                                            i2++;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                    }

                    //###########*****************************RIGHT HAND TAPPING*****ENDS********************
                    #endregion


                    Console.WriteLine("Touch Down - X: " + xPosition + ", Y: " + yPosition);
                }
            }

        } 
        }


        private void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            Console.WriteLine("delta EVENT ENTERED"); 
            
            if (tapping == false)
            {
            
            
            #region Time Variables for tapping
            string swipeDate = DateTime.Now.ToLongDateString();
            string swipeTime = DateTime.Now.ToLongTimeString();
            #endregion

            #region Swipe Variables
            Point canvas1Loc = Canvas1.PointToScreen(new Point());
            Point parentCanvasLoc = ParentCanvas.PointToScreen(new Point());

            canvas1LocX = canvas1Loc.X;
            canvas1LocY = canvas1Loc.Y;

            canvas1H = Canvas1.ActualHeight;
            canvas1W = Canvas1.ActualWidth;

            parentCanvasLocX = parentCanvasLoc.X;
            parentCanvasLocY = parentCanvasLoc.Y;

            parentCanvasH = ParentCanvas.ActualHeight;
            parentCanvasW = ParentCanvas.ActualWidth;

            //direction-limit variables
            bool canvas1XaxisL = false;
            bool canvas1XaxisR = false;
            bool canvas1YaxisD = false;
            bool canvas1YaxisU = false;

            
            
           
            #endregion

            #region Swipe Movement Filter
            if (canvas1LocY < (parentCanvasLocY + parentCanvasH - canvas1H / 3))
            {
                canvas1YaxisD = true;
            }
            if (canvas1LocX > (parentCanvasLocX + canvas1W / 3))
            {
                canvas1XaxisL = true;
            }
            if (canvas1LocY > parentCanvasLocY)
            {
                canvas1YaxisU = true;
            }
            if (canvas1LocX < (parentCanvasLocX + parentCanvasW - canvas1W / 3))
            {
                canvas1XaxisR = true;
            }
            #endregion

            #region swipe identifiers [left hand]
            /*if (left_handed == true)
            {
                if ((yDelta > 8) && (xDelta > -5 && xDelta < 5) && (yVel > 0.20) && (canvas1YaxisD == true))
                {
                    swipeDirection = "down";
                }
                if ((yDelta < -8) && (xDelta > -5 && xDelta < 5) && (yVel < -0.20) && (canvas1YaxisU == true))
                {
                    swipeDirection = "up";
                }
                if ((xDelta > 12) && (yDelta < 2 && yDelta > -2) && (xVel > 0.45) && (canvas1XaxisR == true))
                {
                    swipeDirection = "right";
                }
                if ((xDelta < -12) && (yDelta < 2 && yDelta > -2) && (xVel < -0.45) && (canvas1XaxisL == true))
                {
                    swipeDirection = "left";
                }
                if ((xDelta > 20) && (yDelta < -10) && ((xVel > 0.35) && (yVel < -0.20)) && (canvas1XaxisR == true && canvas1YaxisU == true))
                {
                    swipeDirection = "diagonalUp";
                }
                if ((xDelta < -20) && (yDelta > 10) && ((xVel < -0.35) && (yVel > 0.20)) && (canvas1XaxisL == true && canvas1YaxisD == true))
                {
                    swipeDirection = "diagonalDown";
                }
                if ((xDelta > 20) && (yDelta > 8) && ((xVel > 0.35) && (yVel > 0.20)) && (canvas1XaxisR == true && canvas1YaxisD == true))
                {
                    swipeDirection = "curvedDown";
                }
                if ((xDelta < -25) && (yDelta < -8) && ((xVel < -0.45) && (yVel < -0.20)) && (canvas1XaxisL == true && canvas1YaxisU == true))
                {
                    swipeDirection = "curvedUp";
                }
            }
             * */
            #endregion

            #region Swipe identifiers [right hand]
            /*
                if (left_handed == false)
            {
                if ((yDelta > 8) && (xDelta > -5 && xDelta < 5) && (yVel > 0.20) && (canvas1YaxisD == true))
                {
                    swipeDirection = "downR";
                }
                if ((yDelta < -8) && (xDelta > -5 && xDelta < 5) && (yVel < -0.20) && (canvas1YaxisU == true))
                {
                    swipeDirection = "upR";
                }
                if ((xDelta < -12) && (yDelta < 2 && yDelta > -2) && (xVel < -0.45) && (canvas1XaxisL == true))
                {
                    swipeDirection = "leftR";
                }
                if ((xDelta > 12) && (yDelta < 2 && yDelta > -2) && (xVel > 0.45) && (canvas1XaxisR == true))
                {
                    swipeDirection = "rightR";
                }
                if ((xDelta < -20) && (yDelta < -10) && ((xVel < -0.35) && (yVel < -0.20)) && (canvas1XaxisL == true && canvas1YaxisU == true))
                {
                    swipeDirection = "diagonalUpR";
                }
                if ((xDelta > 20) && (yDelta > 10) && ((xVel > 0.35) && (yVel > 0.20)) && (canvas1XaxisR == true && canvas1YaxisD == true))
                {
                    swipeDirection = "diagonalDownR";
                }
                if ((xDelta < -20) && (yDelta > 8) && ((xVel < -0.35) && (yVel > 0.20)) && (canvas1XaxisL == true && canvas1YaxisD == true))
                {
                    swipeDirection = "curvedDownR";
                }
                if ((xDelta > 20) && (yDelta < -8) && ((xVel > 0.45) && (yVel < -0.20)) && (canvas1XaxisR == true && canvas1YaxisU == true))
                {
                    swipeDirection = "curvedUpR";
                }
            }
             * */
            #endregion

            #region DeltaEvent Variables
            xDelta = e.DeltaManipulation.Translation.X;
            yDelta = e.DeltaManipulation.Translation.Y;

            xTouchPoint = Math.Round(e.ManipulationOrigin.X, 0);
            yTouchPoint = Math.Round(e.ManipulationOrigin.Y, 0);
            movingTouchPoint = new Point(xTouchPoint + 1, yTouchPoint);


            xVel = e.Velocities.LinearVelocity.X;

            yVel = e.Velocities.LinearVelocity.Y;

            vectorLength = e.CumulativeManipulation.Translation.Length;

            LengthSqrd = e.CumulativeManipulation.Translation.LengthSquared;
            #endregion

            #region new Delta variables
            SwipeTouchPoint = new Point(xTouchPoint + 1, yTouchPoint);
            swipeTouchPointCollector.Add(SwipeTouchPoint);
            #endregion

            #region consoles
            using (StreamWriter writer = new StreamWriter("hello.txt", true))
            {
                writer.WriteLine("Moving Touch Point X: " + xTouchPoint + " Y: " + yTouchPoint);
            }

            //Console.WriteLine(LengthSqrd);

            //Console.WriteLine(ScreenX + "  :  " + ScreenY);

            Console.WriteLine("Length: " + vectorLength);

            Console.WriteLine("Velocity - X: " + xVel + "  Y: " + yVel);

            //Console.WriteLine("Touch Up - X: " + xUP + ", Y: " + yUP);

            //textBox1.Text = xDelta.ToString();

            Console.WriteLine("Moving Touch Point X: " + xTouchPoint + " Y: " + yTouchPoint);
            Console.WriteLine("Touch Down - X: " + xPosition + ", Y: " + yPosition);
            Console.WriteLine("Touch Moved -  X: " + xDelta + ", Y: " + yDelta);
            Console.WriteLine("Touch Up - X: " + xUP + ", Y: " + yUP);

            //Console.WriteLine("diffX: " + diffX + ", diffY: " + diffY);


            #endregion



            }
        }


        private void Window_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Console.WriteLine("Up EVENT ENTERED");

            if (tapping == false)
            {
                Console.WriteLine(swipeOrderRnd[0] + ";" + swipeOrderRnd[1] + ";" + swipeOrderRnd[2] + ";" + swipeOrderRnd[3] + ";" +
                    swipeOrderRnd[4] + ";" + swipeOrderRnd[5] + ";" + swipeOrderRnd[6] + ";" + swipeOrderRnd[7] + ";");
            }

            holdRegIdnSwipe();

            #region boolean switch for odd even events
            switch (booleanSwitch) //for 2set 
            { 
                case false:
                    booleanSwitch = true;
                    break;
                case true:
                    booleanSwitch = false;
                    break;
            }
            #endregion

            #region handCheck
            //handcheck
            if (left_handed == true)
            {
                handS = "L";
            }
            else if (left_handed == false)
            {
                handS = "R";
            }
            #endregion

            if (tapping == false)
            {
                //swipeArrayPrinter();

                xUP = e.ManipulationOrigin.X;
                yUP = e.ManipulationOrigin.Y;

                touchUp = new Point(xUP, yUP);

                  //Console.WriteLine("REAL:: Touch Up - X: " + xUP + ", Y: " + yUP);
                    #region Done Action To change hold region automatically
                    if ((swipeFeedFwd.Background == done) && swipeHoldReg == "B")
                    {
                        if ((bRect.Contains(tappingPoint)) || (bRect.Contains(touchUp)))
                        {
                            swipeEvenOdd = 1;
                            //swipe-order randomizer
                            //1set
                            swipeOrderRnd = swipeOrder.OrderBy(x => rnd.Next()).ToArray();
                            swipeArt(swipeOrderRnd[0]);
                            //2set
                            swipeOrderRnd2 = swipeOrder2.OrderBy(x => rnd.Next()).ToArray();
                            swipeArt2(swipeOrderRnd2[0]);
                        }
                        Console.WriteLine("done n B");
                    }
                    else if ((swipeFeedFwd.Background == done) && swipeHoldReg == "H")
                    {
                        if ((hRect.Contains(tappingPoint)) || (hRect.Contains(touchUp)))
                        {
                            swipeEvenOdd = 1;
                            //swipe-order randomizer
                            //1set
                            swipeOrderRnd = swipeOrder.OrderBy(x => rnd.Next()).ToArray();
                            swipeArt(swipeOrderRnd[0]);
                            //2set
                            swipeOrderRnd2 = swipeOrder2.OrderBy(x => rnd.Next()).ToArray();
                            swipeArt2(swipeOrderRnd2[0]);
                        }
                        Console.WriteLine("done n H");
                    }
                    else if ((swipeFeedFwd.Background == done) && swipeHoldReg == "C")
                    {
                        if ((cRect.Contains(tappingPoint)) || (cRect.Contains(touchUp)))
                        {
                            swipeEvenOdd = 1;
                            //swipe-order randomizer
                            //1set
                            swipeOrderRnd = swipeOrder.OrderBy(x => rnd.Next()).ToArray();
                            swipeArt(swipeOrderRnd[0]);
                            //2set
                            swipeOrderRnd2 = swipeOrder2.OrderBy(x => rnd.Next()).ToArray();
                            swipeArt2(swipeOrderRnd2[0]);
                        }
                        Console.WriteLine("done n C");
                    }
                    #endregion
                    
                
                if (vectorLength > 4) //to make sure delta event occured
                    {
                  
                    #region new swipe actions
                    /*
                Console.WriteLine("deltas in UP: " + vectorLength + " ; " + xVel + " ; " + yVel +
                    " ; " + xDelta + " ; " + yDelta);
                Console.WriteLine("deltas in UPde: " + xDelta + " ; " + yDelta);
                Console.WriteLine("nnnnn   " + tappingPoint);
                */

                    //B
                        if (swipeFeedFwd.Background != done && swipeFeedFwd.Background != end)
                        {
                            if ((bRect.Contains(movingTouchPoint)) && swipeHoldReg == "B")
                            {
                                swipeDetector();
                                swipeHoldDetector();
                                swipeInstruction();
                                SwipeAction();

                                Console.WriteLine("Bottom Swipe");
                                swipeEvenOdd++;
                                swipePointCollectionLog = swipeTouchPointCollector;
                                Console.WriteLine("All points: " + swipeTouchPointCollector + " ||| SwipePoints: " + swipePointCollectionLog);

                                //swipe timer
                                swipeWatch.Stop();
                                timeToSwipe = Math.Round(swipeWatch.Elapsed.TotalMilliseconds, 0);
                                Console.WriteLine("timeToSwipe: " + timeToSwipe);

                                swipeLogger();

                            }

                            //H
                            else if ((hRect.Contains(movingTouchPoint)) && swipeHoldReg == "H")
                            {
                                swipeDetector();
                                swipeHoldDetector();
                                swipeInstruction();
                                SwipeAction();

                                Console.WriteLine("Horiz Swipe");
                                swipeEvenOdd++;
                                swipePointCollectionLog = swipeTouchPointCollector;
                                Console.WriteLine("All points: " + swipeTouchPointCollector + " ||| SwipePoints: " + swipePointCollectionLog);

                                //swipe timer
                                swipeWatch.Stop();
                                timeToSwipe = Math.Round(swipeWatch.Elapsed.TotalMilliseconds, 0);
                                Console.WriteLine("timeToSwipe: " + timeToSwipe);

                                swipeLogger();


                            }

                            //C
                            else if ((cRect.Contains(movingTouchPoint)) && swipeHoldReg == "C")
                            {
                                swipeDetector();
                                swipeHoldDetector();
                                swipeInstruction();
                                SwipeAction();

                                Console.WriteLine("Center Swipe");
                                swipeEvenOdd++;
                                swipePointCollectionLog = swipeTouchPointCollector;
                                Console.WriteLine("All points: " + swipeTouchPointCollector + " ||| SwipePoints: " + swipePointCollectionLog);

                                //swipe timer
                                swipeWatch.Stop();
                                timeToSwipe = Math.Round(swipeWatch.Elapsed.TotalMilliseconds, 0);
                                Console.WriteLine("timeToSwipe: " + timeToSwipe);

                                swipeLogger();

                            }
                        }

                    #endregion


                    

                    //swipe point collection clear
                    //Console.WriteLine("SwipePointCollector: " + swipeTouchPointCollector);
                    swipeTouchPointCollector.Clear();
                    swipePointCollectionLog.Clear();
                    vectorLength = 0;
                }
            }
        #endregion
        }
    }
}
