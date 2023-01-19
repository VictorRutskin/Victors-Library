using System;
using System.Text;

using static Victors_Library.Library_Class;

namespace Victors_Library.Classes
{
    public static class Global_Mehtods //global methods can be used anywhere
    {
        public static string SplitString(string Mainstr, string splitstr, int numofword) //Deletes "," from strings
        {
            try //if chars ==0
            {
                string str = Mainstr; //getting the to string


                char[] chars = str.ToCharArray();
                string[] words = new string[10];

                StringBuilder sb = new StringBuilder();
                int wordcounter = 0;

                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i].ToString() != splitstr)
                    {
                        sb.Append(chars[i]);
                    }
                    else
                    {
                        words[wordcounter] = sb.ToString();
                        sb.Clear();
                        wordcounter++;
                    }
                }


                str = sb.ToString(); // getting the final string of book name

                return words[numofword];
            }
            catch (Exception ex)
            {
                ExceptionLogsDB exceptionLogsDB = new ExceptionLogsDB();
                exceptionLogsDB.AddException(ex);
                return "";
            }
        }

        public static void DeletePsik(ref string str) //Deletes "," from strings
        {
            var charsToRemove = new string[] { ",", " " };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, " ");
            }
        }

        public static bool[] ToBoolStringArray(string str) //returns a bool array value
        {
            DeletePsik(ref str); //deletes prisks to prefent == errors
            string[] SplittedStrings = str.Split(' ');
            bool[] FinalBoolArray = new bool[GenresAmount];
            int counter = 0; //checks which input to put in

            for (int i = 0; i < SplittedStrings.Length; i++) // amount of strings
            {
                for (int j = 0; j < GenresAmount; j++) //amount of genres
                {
                    var LocalEnum = (GenreEnum)j;

                    if (SplittedStrings[i] == LocalEnum.ToString() && counter <= 3)
                    {
                        FinalBoolArray[j] = true;
                        counter++;
                    }

                }
            }
            return FinalBoolArray;

        }

        public static string[] ToarrayStrings(string str) //returns a string array value
        {
            DeletePsik(ref str); //deletes prisks to prefent == errors
            string[] SplittedStrings = str.Split(' ');

            return SplittedStrings;

        }

      

            public static string SelectedItemToName(string str) // turns selected item to string i can work with
        {
            StringBuilder stringBuilder = new StringBuilder();
            char[] characters = str.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != ',')
                {
                    stringBuilder.Append(characters[i]);
                }
                else
                {
                    break;
                }
            }
            string FinalString = stringBuilder.ToString();

            return FinalString;


        }
    }
}
