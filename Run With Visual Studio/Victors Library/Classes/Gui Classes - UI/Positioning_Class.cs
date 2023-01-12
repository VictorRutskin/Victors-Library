using System.Windows.Controls;
using System.Windows;

namespace Victors_Library
{
    public partial class Positioning_Class // LocationPlacement_Class
    {
        static double ScreenHeight = SystemParameters.VirtualScreenHeight; //Gets user screen Height
        static double ScreenWidth = SystemParameters.VirtualScreenWidth; //Gets user screen Width
        double Resolution = ScreenHeight * ScreenWidth; //Calculates screen resolution

        double CalculationWidth = ScreenWidth / 1920; //width scaling
        double CalculationHeight = ScreenHeight / 1080; // height scaling

        public void SetUpSize(System.Windows.Controls.Image image, double Width, double Height) //setting up size of specific object, comparing to screen
        {
            image.Width = Width * CalculationWidth;
            image.Height = Height * CalculationHeight;
        }

        public void SetUpLocation(System.Windows.Controls.Image image, double LocationX, double LocationY) //setting up location of specific object, comparing to screen
        {
            Canvas.SetLeft(image, LocationX * CalculationWidth);
            Canvas.SetTop(image, LocationY * CalculationHeight);
        }

        public void SetUpAllSizes(System.Windows.Controls.Image image) //setting up locations of all visual objects comparing to user's screen  
        {
            SetUpSize(image, 600, 600);
        }
        public void SetUpAllLocations(System.Windows.Controls.Image image) //setting up sizes of all visual objects comparing to user's screen
        {
            SetUpLocation(image, 100, 850);
        }
        public void SetUpAllMiddleImage(System.Windows.Controls.Image image) //setting up sizes of all visual objects comparing to user's screen
        {
            Canvas.SetLeft(image, ScreenWidth / 3 - 100);
            Canvas.SetTop(image, ScreenHeight/2 - 50);
        }
        public void SetUpAllRightImage(System.Windows.Controls.Image image) //setting up sizes of all visual objects comparing to user's screen
        {
            Canvas.SetLeft(image, ScreenWidth);
            Canvas.SetTop(image, ScreenHeight);
        }

        public void SetUpAllMiddleTextblock(System.Windows.Controls.TextBlock textBlock) //setting up sizes of all visual objects comparing to user's screen
        {
            Canvas.SetLeft(textBlock, 15);
            Canvas.SetTop(textBlock, ScreenHeight-150);
        }
    }
}
