using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Victors_Library.Classes;

namespace Victors_Library
{
    public abstract class Library_Class //main class of all type of paper, abstract and then turns to book/comic or whatever
    {

        //Class Data
        private string _Name; //Name of book
        private string _Author; //Author of book
        private string _Genre; //Gnere of book, will be put in their desired shelf

        private int _Id; //Book ID, for identification
        private int _NumPages; // Amount of pages, will affect book size in GUI
        private double _Price; // Book price, will show in GUI
        protected double Discount = 0; // precentage of discount

        private string _DateOfAdding; //date when book was added

        private Brush _Color; // Color of book, will show in GUI

        private bool[] _GenresArray = new bool[GenresAmount]; // bool of what genres

        public const int GenresAmount = 18;

        Random Random = new Random();

        public enum GenreEnum //value in enum here is balue in genres array
        {
            Manga,
            Comic,
            Journal,
            Fantasy,
            Adventure,
            Romance,
            Horror,
            Thriller,
            Children,
            Cooking,
            Crime,
            Education,
            Action,
            Comedy,
            History,
            Biography,
            Science,
            Religion,
        }


        public Library_Class(string name, int numpages, double price, string Genres, Brush color = null, string author = "Unknown", bool AddedToday = true)
        {
            DefaultFalseArray(ref _GenresArray);//reseting all genres to false

            _Id = Random.Next(100000000,999999999);
            _GenresArray = Global_Mehtods.ToBoolStringArray(Genres);

            _Name = name;
            _Author = author;
            _NumPages = numpages;
            _Price = price;
            _Color = color;

            if (AddedToday == true)
            {
                _DateOfAdding = getDate(true);
            }
            else
            {
                _DateOfAdding = getDate(false);
            }

        }
        public override string ToString()
        {
            return Name;
        }

        //ints for discount setting
        public static int BookDiscount = 0;
        public static int ComicDiscount = 10;
        public static int MangaDiscount = 20;
        public static int JournalDiscount = 30;
        public static int UnknownDiscount = 40;
        public static int victorDiscount = 60;

        public int CalculateDiscount() //calculates author discount then finalizes the highest discount in the derieved class itself 
        {
            int LocalDiscount = 0;

            if(Author =="Victor Rutskin")
            {
                LocalDiscount =  60;
            }
            else if(Author == "Unknown")
            {
                LocalDiscount =  40;
            }

            return LocalDiscount;
        }
        private static void DefaultFalseArray(ref bool[] BoolArray)
        {
            for (int i = 0; i < BoolArray.Length; i++)
            {
                BoolArray[i] = false;
            }
        }
        private static void ChangingGenresInArray(ref bool[] BoolArray, string[] GenresArray) //resets, then changes to new value.
        {
            DefaultFalseArray(ref BoolArray);

            for (int i = 0; i < GenresArray.Length; i++)
            {
                for (int j = 0; j < BoolArray.Length; j++)
                {
                    if (((GenreEnum)j).ToString() == GenresArray[i])
                    {
                        BoolArray[j] = true;
                    }
                }
            }
        }

        private static string getDate(bool AddedToday) //returns date
        {
            if (AddedToday == true)
            {
                DateTime Now = DateTime.Now;
                return Now.ToString();
            }
            else
            {
                string DefaultTime = "16-Oct-22 13:55:05"; //default time (when i worked on this function :D
                return DefaultTime;
            }
        }
      

        public int ID
        {
            get { return _Id; } //can only get id but never set
            set
            {
                _Id = value;
            }
        }

        public string Genres
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < _GenresArray.Length; i++)
                {
                    if (_GenresArray[i] == true)
                    {
                        stringBuilder.Append(((GenreEnum)i).ToString() + ",");
                    }
                }
                return stringBuilder.ToString();
            }
            set { _Genre = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }

        public int NumPages
        {
            get { return _NumPages; }
            set { _NumPages = value; }
        }

        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string LastEditDate
        {
            get { return _DateOfAdding; }
            set { _DateOfAdding = value; }
        }
        public Brush Color
        {
            get { return _Color; }
            set { _Color = value; }
        }



    }

}
