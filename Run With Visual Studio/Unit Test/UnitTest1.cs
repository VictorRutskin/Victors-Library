using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Media;
using Victors_Library;
namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefaultBoolAtStartValuesTest() //checks if all default main menu stats are right
        {
            bool Checker = true;

            if (MainWindow.RunMusic == false)
            {
                Checker = false;
            }
            if (MainWindow.RunExplanation == false)
            {
                Checker = false;
            }
            if (Checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "One of default values in mainmenu is set to false.");
            }

        }

        [TestMethod]
        public void BookAddTest() //adding a sample book, if checker = false, the added book doesnt exist in list
        {


            BookList_Class.library.Add(new Book_Class("BookName", 666, 100, "Horror", Brushes.Black, "fella"));


            bool Checker = false;

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                if (library_Class.NumPages == 666 && library_Class.Price == 100 && library_Class.Name == "BookName" && library_Class.Author == "fella")
                {
                    Checker = true;
                    break;
                }
            }

            if (Checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "Book was not added,error.");
            }

        }

        [TestMethod]
        public void BookRemoveTest() //adding a sample book,and deleting it, if checker = false, the added wasent deleted
        {
            BookList_Class.library.Add(new Book_Class("BookName", 666, 100, "Horror", Brushes.Black, "fella"));

            BookList_Class.RemoveBook("BookName");

            bool Checker = true;

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                if (library_Class.NumPages == 666 && library_Class.Price == 100 && library_Class.Name == "BookName" && library_Class.Author == "fella")
                {
                    Checker = false;
                    break;
                }
            }

            if (Checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "Book was not deleted,error.");
            }
        }

        [TestMethod]
        public void DataBaseTest() //checking if all the db's arent null
        {
            bool checker = true; //all database arent null

            if(DataBaseService.GetData()==null)
            {
                checker = false;
            }
            if (RemovedBooksLogsDB.GetData() == null)
            {
                checker = false;
            }
            if (BoughtBooksLogsDB.GetData() == null)
            {
                checker = false;
            }
            if (AddedBooksLogsDB.GetData() == null)
            {
                checker = false;
            }
            if (ExceptionLogsDB.GetData() == null)
            {
                checker = false;
            }

            if (checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "One of the DB's is null.");
            }
        }

        [TestMethod]
        public void DiscountLegitimacyCheck() //checking if discounts are more or equal than 0% and less or equal to 100%
        {
            int[] DiscountsArray = new int[10];

            DiscountsArray[0] = Library_Class.BookDiscount;
            DiscountsArray[1] = Library_Class.ComicDiscount;
            DiscountsArray[2] = Library_Class.JournalDiscount;
            DiscountsArray[3] = Library_Class.MangaDiscount;
            DiscountsArray[4] = Library_Class.victorDiscount;
            DiscountsArray[5] = Library_Class.UnknownDiscount;

            for(int i = 0; i < DiscountsArray.Length; i++)
            {
                if (DiscountsArray[i] < 0 || DiscountsArray[i] > 100)
                {
                    Assert.ThrowsException<System.Exception>(() => DiscountsArray[i] + " has an iligitimate discount");
                }
            }           
     
        }

        [TestMethod]
        public void LibraryBooksLegitPriceNoBigOrSmallNumbers() //checking if all books have a legitimate price and we didnt break the price cap
        {
            bool checker = true;

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                if (library_Class.Price <= 0 || library_Class.Price > 999999)
                {
                    checker = false;
                    break;
                }
            }

            if (checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "One of the books in the library has an unlegit price.");
            }
        }

        [TestMethod]
        public void LibraryBooksLegitPriceNoWords() //checking if all books have a legitimate pagenum and we didnt break the pagenum cap
        {
            bool checker = true;

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                int result = 0;
                if (int.TryParse(library_Class.Price.ToString(), out result) == false)
                {
                    checker = false;
                    break;
                }
            }

            if (checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "One of the books in the library has a text value of numpage.");
            }
        }
        [TestMethod]
        public void LibraryBooksLegitPagesNoBigOrSmallNumbers() //checking if all books have a legitimate pagenum and we didnt break the pagenum cap
        {
            bool checker = true;

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                if (library_Class.NumPages <= 0 || library_Class.NumPages > 999999)
                {
                    checker = false;
                    break;
                }
            }

            if (checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "One of the books in the library has an unlegit amount of pages.");
            }
        }

        [TestMethod]
        public void LibraryBooksLegitPageNoWords() //checking if all books have a legitimate pagenum and we didnt break the pagenum cap
        {
            bool checker = true;

            foreach (Library_Class library_Class in BookList_Class.library)
            {
                int result = 0;
                if (int.TryParse(library_Class.NumPages.ToString(), out  result)==false)
                {
                    checker = false;
                    break;
                }
            }

            if (checker == false)
            {
                Assert.ThrowsException<System.Exception>(() => "One of the books in the library has a text value of numpage.");
            }
        }

       
    }

}
