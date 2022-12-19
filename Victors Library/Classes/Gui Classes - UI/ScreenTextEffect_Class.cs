using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Victors_Library
{
    public partial class ScreenTextEffect_Class
    {
        private static int counter = 0; //so text will wait before changing again, cant change 2 times at same time.

        private static bool CanChange = true; //so text will wait before changing again, cant change 2 times at same time.

        private const int TextSplitByNumber = 50;

        public int leftovercalc(int stringlength, int currentcount, int leftover)
        {
            if (stringlength - (currentcount * TextSplitByNumber) < TextSplitByNumber)
            {
                return (TextSplitByNumber * (currentcount)) + leftover;
            }
            return TextSplitByNumber * (currentcount+1);
        }
        public async Task ScreenSay(string text, TextBlock textblock, Button Buttom1, Button Buttom2, Button Buttom3, Button Buttom4, Button Buttom5, Button Buttom6, string WhoTalks = "NoOne") // fills text in the window and says a specific text
        {

            Buttom1.IsEnabled = false;
            Buttom2.IsEnabled = false;
            Buttom3.IsEnabled = false;
            Buttom4.IsEnabled = false;
            Buttom5.IsEnabled = false;
            Buttom6.IsEnabled = false;

            //when happens disable add book
            textblock.Text = "";
            textblock.Background = Brushes.White;

            CanChange = false;

            char[] characters = text.ToCharArray(); // converts all text to characters

            if (characters.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (WhoTalks == "NoOne")
                {
                    textblock.Foreground = Brushes.Azure;

                }
                else if (WhoTalks == "Librarian")
                {
                    //      stringBuilder.Append("Librarian: ");
                    textblock.Foreground = Brushes.MediumPurple;

                }

                //calculating string lenghts to know how many text events needed
                int CutStringToIntPieces = characters.Length / TextSplitByNumber;

                int LeftOver = characters.Length % TextSplitByNumber;

                for (int i = 0; i < CutStringToIntPieces + 1; i++)
                {
                    int counter = 0;
                    for (int j = i * TextSplitByNumber; j < leftovercalc(characters.Length, i, LeftOver); j++)
                    {
                        stringBuilder.Append(characters[j]);
                        textblock.Text = stringBuilder.ToString();
                        await Task.Delay(100);
                        counter++;
                    }
                    await Task.Delay(500);
                    stringBuilder.Remove(0, counter);

                }


                textblock.Text = "";
                textblock.Background = null;
                await Task.Delay(1000);



                counter++;
                CanChange = true;
                Buttom1.IsEnabled = true;
                Buttom2.IsEnabled = true;
                Buttom3.IsEnabled = true;
                Buttom4.IsEnabled = true;
                Buttom5.IsEnabled = true;
                Buttom6.IsEnabled = true;


            }


        }
        public async Task ScreenSay(string text, TextBlock textblock,Button Buttom1, Button Buttom2, Button Buttom3, string WhoTalks = "NoOne") // fills text in the window and says a specific text
        {

            Buttom1.IsEnabled = false;
            Buttom2.IsEnabled = false;
            Buttom3.IsEnabled = false;

            //when happens disable add book
            textblock.Text = "";
            textblock.Background = Brushes.White;

            CanChange = false;

            char[] characters = text.ToCharArray(); // converts all text to characters

            if (characters.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (WhoTalks == "NoOne")
                {
                    textblock.Foreground = Brushes.Azure;

                }
                else if (WhoTalks == "Librarian")
                {
              //      stringBuilder.Append("Librarian: ");
                    textblock.Foreground = Brushes.MediumPurple;

                }

                //calculating string lenghts to know how many text events needed
                int CutStringToIntPieces = characters.Length / TextSplitByNumber;

                int LeftOver = characters.Length % TextSplitByNumber;

                for (int i = 0; i < CutStringToIntPieces + 1; i++)
                {
                    int counter = 0;
                    for (int j = i * TextSplitByNumber; j < leftovercalc(characters.Length, i, LeftOver); j++) 
                    {
                        stringBuilder.Append(characters[j]);
                        textblock.Text = stringBuilder.ToString();
                        await Task.Delay(100);
                        counter++;
                    }
                    await Task.Delay(500);
                    stringBuilder.Remove(0,counter);                    

                }
      

                textblock.Text = "";
                textblock.Background = null;
                await Task.Delay(1000);



                counter++;
                CanChange = true;
                Buttom1.IsEnabled = true;
                Buttom2.IsEnabled = true;
                Buttom3.IsEnabled = true;
            }


        }
        public async Task ScreenSay(string text, TextBlock textblock, Button Buttom1, Button Buttom2,  string WhoTalks = "NoOne") // fills text in the window and says a specific text
        {

            Buttom1.IsEnabled = false;
            Buttom2.IsEnabled = false;

            //when happens disable add book
            textblock.Text = "";
            textblock.Background = Brushes.White;

            CanChange = false;

            char[] characters = text.ToCharArray(); // converts all text to characters

            if (characters.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (WhoTalks == "NoOne")
                {
                    textblock.Foreground = Brushes.Azure;

                }
                else if (WhoTalks == "Librarian")
                {
                    //      stringBuilder.Append("Librarian: ");
                    textblock.Foreground = Brushes.MediumPurple;

                }

                //calculating string lenghts to know how many text events needed
                int CutStringToIntPieces = characters.Length / TextSplitByNumber;

                int LeftOver = characters.Length % TextSplitByNumber;

                for (int i = 0; i < CutStringToIntPieces + 1; i++)
                {
                    int counter = 0;
                    for (int j = i * TextSplitByNumber; j < leftovercalc(characters.Length, i, LeftOver); j++)
                    {
                        stringBuilder.Append(characters[j]);
                        textblock.Text = stringBuilder.ToString();
                        await Task.Delay(100);
                        counter++;
                    }
                    await Task.Delay(500);
                    stringBuilder.Remove(0, counter);

                }


                textblock.Text = "";
                textblock.Background = null;
                await Task.Delay(1000);



                counter++;
                CanChange = true;
                Buttom1.IsEnabled = true;
                Buttom2.IsEnabled = true;
            }


        }

        public async Task ScreenSay(string text, TextBlock textblock, string WhoTalks = "NoOne") // fills text in the window and says a specific text
        {
            //when happens disable add book
            textblock.Text = "";
            textblock.Background = Brushes.White;
            CanChange = false;

            char[] characters = text.ToCharArray(); // converts all text to characters

            if (characters.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (WhoTalks == "NoOne")
                {
                    textblock.Foreground = Brushes.Black;

                }
                else if (WhoTalks == "Librarian")
                {
                    //      stringBuilder.Append("Librarian: ");
                    textblock.Foreground = Brushes.MediumPurple;

                }

                //calculating string lenghts to know how many text events needed
                int CutStringToIntPieces = characters.Length / TextSplitByNumber;

                int LeftOver = characters.Length % TextSplitByNumber;

                for (int i = 0; i < CutStringToIntPieces + 1; i++)
                {
                    int counter = 0;
                    for (int j = i * TextSplitByNumber; j < leftovercalc(characters.Length, i, LeftOver); j++)
                    {
                        stringBuilder.Append(characters[j]);
                        textblock.Text = stringBuilder.ToString();
                        await Task.Delay(100);
                        counter++;
                    }
                    await Task.Delay(500);
                    stringBuilder.Remove(0, counter);

                }
             
                textblock.Text = "";
                textblock.Background = null;
                await Task.Delay(1000);


            

                counter++;
                CanChange = true;

            }


        }

        public async void ScreenSayAtRun(TextBlock textblock, Image image, Button button) // fills text in the window and says a specific text
        {
            Gif_Class gif_Class = new Gif_Class();

            gif_Class.GifVisble(false, image);
            await ScreenSay("Hello and welcome to victor's library!", textblock, button, button, button);

            gif_Class.GifVisble(true, image);
            await ScreenSay("Hey there, My name is Victoria and I am this library librarian!", textblock, button, button, button, "Librarian");

            gif_Class.GifVisble(true, image);
            await ScreenSay("How can i help you?", textblock, button, button, button, "Librarian");


        }

        public async void ScreenSayAtRun(TextBlock textblock, Image image,bool start) // fills text in the window and says a specific text
        {
            Gif_Class gif_Class = new Gif_Class();

            if (start == true)
            {
                gif_Class.GifVisble(false, image);
                await ScreenSay("Hello and welcome to victor's library!", textblock);

                gif_Class.GifVisble(true, image);
                await ScreenSay("Hey there, My name is Victoria and I am this library librarian!", textblock, "Librarian");

                await ScreenSay("The sales we have now are:", textblock, "Librarian");

                await ScreenSay("The Author that goes by the name Victor Rutskin has a %"+ Library_Class.victorDiscount + " Discount on his books ", textblock, "Librarian");
                await ScreenSay("Authors that their names are unknown have a %" + Library_Class.UnknownDiscount + " Discount on their books ", textblock, "Librarian");

                await ScreenSay("Regular books have a %"+ Library_Class.BookDiscount+" Discount", textblock, "Librarian");
                await ScreenSay("Comics have a %" + Library_Class.ComicDiscount + " Discount", textblock, "Librarian");
                await ScreenSay("Mangas have a %" + Library_Class.MangaDiscount + " Discount", textblock, "Librarian");
                await ScreenSay("Journals have a %" + Library_Class.JournalDiscount + " Discount", textblock, "Librarian");
                await ScreenSay("No double discounts!", textblock, "Librarian");



                await ScreenSay("So how can i help you?", textblock, "Librarian");
            }
            else
            {
                gif_Class.GifVisble(true, image);
                await ScreenSay("", textblock, "Librarian");
            }
        }
        public static bool ChangeStatus
        {
            get { return CanChange; }
            set { CanChange = value; }
        }


    }
}
