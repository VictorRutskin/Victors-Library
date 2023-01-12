using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Victors_Library.Classes;

namespace Victors_Library
{
    public partial class BookList_Class    //class that controls the list of all paperwork books comics etc
    {
       public static List<Library_Class> library = DataBaseService.GetData(); //when booklist initialized automatically se library to get data

        public static List<Library_Class> LoadAllBooks()
        {

            return DataBaseService.GetData();
        }


        public List<Library_Class> BooksList
        {
            get { return library; }
            set { library = value; }
        }



        public void AddBook(string genres, string name, int numpages, int price, Brush color, bool Updatedb, string author = "Unknown", bool DateAdd = false) //adds a book to the list after checking type
        {
            bool[] LocalGenresArray = Global_Mehtods.ToBoolStringArray(genres);

            if (LocalGenresArray[0] == true)
            {
                library.Add(new Manga_Class(name, numpages, price, genres, color, author)
                {
                });
            }
            else if (LocalGenresArray[1] == true)
            {
                library.Add(new Comic_Class(name, numpages, price, genres, color, author)
                {
                });
            }
            else if (LocalGenresArray[2] == true)
            {
                library.Add(new Journal_Class(name, numpages, price, genres, color, author)
                {
                });
            }
            else
            {
                library.Add(new Book_Class(name, numpages, price, genres, color, author)
                {
                });
            }

            if (Updatedb == true)
            {
                DataBaseService dataBaseService = new DataBaseService();
                dataBaseService.SaveData(library);
            }


        }

        public static void RemoveBook(string str) //removes a book from the list
        {
            string FinalString = Global_Mehtods.SelectedItemToName(str);
            try
            {
                foreach (Library_Class book in library)
                {

                    if (book.Name == FinalString)
                    {
                        library.Remove(book);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogsDB exceptionLogsDB = new ExceptionLogsDB();
                exceptionLogsDB.AddException(ex);
            }
      

        }



        public static bool CheckIfPart(string input, string CheckWith) // checks if entered strings are same after uppering them both and ignoring big or small letters
        {
            string inputUPPER = input.ToUpper();
            string CheckWithUPPER = CheckWith.ToUpper();


            char[] InputIntoCharacters = inputUPPER.ToCharArray();
            char[] CheckWithCharacters = CheckWithUPPER.ToCharArray();


            for (int i = 0; i < InputIntoCharacters.Length; i++)
            {
                if (InputIntoCharacters[i] != CheckWithCharacters[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static List<Library_Class> LoadSearch(string Genre, string name, string author, string id, string price, string pagenum) //load the search into the datagrid
        {
            try
            {
                foreach (Library_Class book in library.ToList())
                {
                    bool flag = true; //if stays true passed test to join searched item

                    if (Genre != "Genre" && Genre != "Any" && Genre != "")
                    {
                        bool localflag = false; //for very specific check

                        string[] checkedArray = new string[3];
                        string[] CheckWITHArray = new string[3];


                        checkedArray = Global_Mehtods.ToarrayStrings(Genre);
                        CheckWITHArray = Global_Mehtods.ToarrayStrings(book.Genres);


                        for (int i = 0; i < CheckWITHArray.Length; i++)
                        {
                            for (int j = 0; j < checkedArray.Length; j++)
                            {
                                if (CheckWITHArray[i] == checkedArray[j])
                                {
                                    localflag = true;
                                }
                            }
                        }

                        if (localflag == false)
                        {
                            flag = false;
                        }

                    }
                    if (name != "Name" && name != "")
                    {
                        if (CheckIfPart(name, book.Name) == false)
                        {
                            flag = false;
                        }
                    }

                    if (author != "Author" && author != "")
                    {
                        if (CheckIfPart(author, book.Author) == false)
                        {
                            flag = false;
                        }
                    }
                    if (id != "ID" && id != "")
                    {
                        if (book.ID.ToString() != id)
                        {
                            flag = false;
                        }
                    }
                    if (price != "Price" && price != "")
                    {
                        if (book.Price.ToString() != price)
                        {
                            flag = false;
                        }
                    }
                    if (pagenum != "Pages Number" && pagenum != "")
                    {
                        if (book.NumPages.ToString() != pagenum)
                        {
                            flag = false;
                        }
                    }



                    if (flag == false)
                    {
                        library.Remove(book);

                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionLogsDB exceptionLogsDB = new ExceptionLogsDB();
                exceptionLogsDB.AddException(ex);
            }


            return library;
        }
        public void AddOneBookToDB(bool DBupdate, string genres, string name, int numpages, int price, Brush color, string author = "Unknown") // adds book to list and to DB aswell
        {
            try
            {
                AddBook(genres, name, numpages, price, color, true, author, true);
            }
            catch (Exception ex)
            {
                ExceptionLogsDB exceptionLogsDB = new ExceptionLogsDB();
                exceptionLogsDB.AddException(ex);
            }

            DataBaseService dataBaseService = new DataBaseService();
            dataBaseService.SaveData(library);
            //update UI

        }
        public void DefaultBooks(List<Library_Class> list, bool DBupdate) //sets default book imade to reset the database (only used once or when i want to remake DB)
        {
            AddBook("Religion", "Victor Is Literally A GOD.", 666, 666, Brushes.Black, false, "Probably Not Victor", false);
            AddBook("Biography Adventure", "The Successful Life Of Victor Rutskin", 1264, 99, Brushes.Gold, false, "Vic Swampmilk", false);
            AddBook("Fantasy", "The Mythical Shrigma", 153, 65, Brushes.MediumPurple, false, "Danny Shovevani", false);
            AddBook("Adventure Fantasy", "Adventure Time", 900, 42, Brushes.SkyBlue, false, "Finn The Human", false);
            AddBook("Romance", "When Will I Find Love?", 1, 10, Brushes.DarkRed, false, "Mr.Chau", false);
            AddBook("Romance Manga Adventure", "Icha Icha", 68, 70, Brushes.DarkRed, false, "Jiraya Sensei", false);
            AddBook("Horror", "Out Of Milk", 48, 15, Brushes.GreenYellow, false, "Guy Dan", false);
            AddBook("Thriller", "The chase", 425, 80, Brushes.Coral, false, "Yuval Weiss", false);
            AddBook("Children", "The Tale Of The Ferret", 62, 40, Brushes.DarkSlateBlue, false, "Elior Estrin", false);
            AddBook("Cooking", "Sushi Recepies", 56, 30, Brushes.Black, false, "Masashi Kishimoto", false);
            AddBook("Crime Fantasy", "Who Teleported The Cake?", 26, 12, Brushes.HotPink, false, "Kimberly Brown", false);
            AddBook("Education", "How To Use Async In C#", 160, 47, Brushes.CornflowerBlue, false, "Nadav Starhilevitz", false);
            AddBook("Comedy", "Best Dad Jokes 2022", 500, 79, Brushes.PaleVioletRed, false, "Yuval Davidowitz", false);
            AddBook("History Children", "History With Shmulik", 200, 60, Brushes.DarkGray, false, "Shmuel Cohen-Shani", false);
            AddBook("History", "Yuval Mendelson's History Songs Lyrics", 86, 29, Brushes.FloralWhite, false, "Yuval Mendelson", false);
            AddBook("Biography Crime", "The Kraizman Family", 2000, 360, Brushes.LightYellow, false, "Daniel Kraizman", false);
            AddBook("Biography Thriller", "The Real Story Behind Winehouse", 260, 75, Brushes.Red, false, "Unknown", false);
            AddBook("Adventure Manga Action", "Lashaker's Adventure", 260, 75, Brushes.Red, false, "Unknown", false);
            AddBook("Manga Thriller Action", "The Betrayel of Junto", 25, 40, Brushes.Crimson, false, "Junto Uchiha", false);
            AddBook("Manga Crime Biography", "Alther's Fall", 200, 70, Brushes.DarkViolet, false, "Wood Lee", false);
            AddBook("Cooking", "On The Fire With Dad", 30, 15, Brushes.DarkGoldenrod, false, "Dmitry Rutskin", false);
            AddBook("Children Comedy Crime", "Story Of The Swamp Child", 11, 78, Brushes.Goldenrod, false, "Makakariker", false);
            AddBook("Religion Manga Education", "Shrek Is Love, Shrek Is Life", 2666, 99, Brushes.DarkGreen, false, "Someone Healthy", false);
            AddBook("History Comedy", "Fall Of Doge, The Funny Dog", 4, 20, Brushes.Yellow, false, "Unknown", false);
            AddBook("Thriller", "Unfortunate Fate", 30, 15, Brushes.Cyan, false, "Doctor Weiss", false);
            AddBook("Children", "Frog Tale", 20, 10, Brushes.LightGreen, false, "Daniel Cohen", false);
            AddBook("Comedy", "Bruh Moment Sound Effect #2", 3, 170, Brushes.DarkGreen, false, "Unknown", false);
            AddBook("Education", "How To Make Money From Fools", 1, 9999, Brushes.Tan, false, "Unknown", false);
            AddBook("Journal Manga", "This week's fashion", 20, 40, Brushes.Ivory, false, "Zendaya Shrigmaya", false);
            AddBook("Comic", "Super Dude", 52, 70, Brushes.GhostWhite, false, "Db Universe", false);
            AddBook("Education Thriller Horror", "Nice Guy Isnt Actually Nice", 457, 90, Brushes.Aquamarine, false, "Fredrick Humaro", false);



            if (DBupdate == true)
            {
                DataBaseService dataBaseService = new DataBaseService();
                dataBaseService.SaveData(library);
            }


        }


        public List<Library_Class> GetLibrary
        {
            get { return library; }

        }

    }
}
