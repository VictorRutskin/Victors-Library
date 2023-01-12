using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;


namespace Victors_Library 
{
    public class Gif_Class  //class that sets the gif into pictures
    {
        public async void BookBuy(string BookName,Image image, Button button1, Button button2, Button button3, TextBlock textBlock) //defining a gif file to a specific image from the xaml
        {
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();

            GifVisble(true, image);
            SettingUpAGif(1, image);
            await screenTextEffect_Class.ScreenSay(BookName, textBlock, button1, button2, button3, "Librarian");
            GifVisble(false, image);

        }

        public async void BookComment( Image image, TextBlock textBlock, ComboBox comboBox, Button button1, Button button2) //defining a gif file to a specific image from the xaml
        {
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();

            switch (comboBox.Text)
            {
                case "Manga":
                    SettingUpAGif(9, image);
                    await screenTextEffect_Class.ScreenSay("I see you're a person of culture as well, weeb.", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Comic":
                    SettingUpAGif(5, image);
                    await screenTextEffect_Class.ScreenSay("Great,i will add this Comic to our library! but i dont really like all these super hero stuff..", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Journal":
                    SettingUpAGif(16, image);
                    await screenTextEffect_Class.ScreenSay("Seems like an interesting Journal, might read it later..", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Fantasy":
                    SettingUpAGif(7, image);
                    await screenTextEffect_Class.ScreenSay("Wow this looks very interesting!", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Adventure":
                    SettingUpAGif(6, image);
                    await screenTextEffect_Class.ScreenSay("I want to go to an adventure too..", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Romance":
                    SettingUpAGif(2, image);
                    await screenTextEffect_Class.ScreenSay("Very romantic!", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Horror":
                    SettingUpAGif(11, image);
                    await screenTextEffect_Class.ScreenSay("Horror?! oh no..", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Thriller":
                    SettingUpAGif(7, image);
                    await screenTextEffect_Class.ScreenSay("I am ready to get Thrilled!", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Children":
                    SettingUpAGif(6, image);
                    await screenTextEffect_Class.ScreenSay("That's.. Boring", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Cooking":
                    SettingUpAGif(12, image);
                    await screenTextEffect_Class.ScreenSay("I am hungry just from looking at this..", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Crime":
                    SettingUpAGif(13, image);
                    await screenTextEffect_Class.ScreenSay("Is this based on... a real story??", textBlock, button1, button2, "Librarian");
                    break;

                case "Education":
                    SettingUpAGif(10, image);
                    await screenTextEffect_Class.ScreenSay("Noooo i am tired of studying about new things..", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Action":
                    SettingUpAGif(9, image);
                    await screenTextEffect_Class.ScreenSay("Pew pew pew boom bomm boom haiiiya!", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Comedy":
                    SettingUpAGif(9, image);
                    await screenTextEffect_Class.ScreenSay("Looks like a very funny book.", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "History":
                    SettingUpAGif(16, image);
                    await screenTextEffect_Class.ScreenSay("Hmmm... didnt know that happened..", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Biography":
                    SettingUpAGif(13, image);
                    await screenTextEffect_Class.ScreenSay("Meh.. never liked that person..", textBlock, button1, button2, "Librarian");
                    break;

                case "Science":
                    SettingUpAGif(1, image);
                    await screenTextEffect_Class.ScreenSay("To the moon!", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;

                case "Religion":
                    SettingUpAGif(3, image);
                    await screenTextEffect_Class.ScreenSay("Wait!!! take this i want to join this book's Religion!", textBlock, button1, button2, "Librarian");
                    SettingUpAGif(13, image); //reset 
                    break;
            }



        }

        public void SettingUpAGif(int num, Image image) //defining a gif file to a specific image from the xaml
        {
            var Librarian1 = new BitmapImage();
            Librarian1.BeginInit();
            Librarian1.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + GetGifString(num));
            Librarian1.EndInit();
            ImageBehavior.SetAnimatedSource(image, Librarian1);
        }
        public void GifVisble(bool flag, Image image) //setting the image to visble/invisble
        {
            if (flag == true)
            {
                image.Opacity = 100;
            }
            else
            {
                image.Opacity = 0;
            }
        }

        public string GetGifString(int num) //convert number to gif
        {
            string str1 = @"Media\LibrarianGifs\Librarian";
            string str2 = num.ToString();
            string str3 = @".gif";

            return str1+ str2+ str3;

        }
       

    }
}
