using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Victors_Library.Classes;
using Victors_Library.Classes.DB_classes___DB;
using static Victors_Library.Exceptions_Class;
using TextBox = System.Windows.Controls.TextBox;

namespace Victors_Library
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LibraryWindow : Window
    {
        public LibraryWindow()
        {
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            InitializeComponent();

            AddBookWindow.Editing = false;
            MainWindow.RunMusic = false;  // so when menu wont run music from start
            MainWindow.RunExplanation = false;  // so when user goes back to menu wont show explanation again

            BookDataGrid.ItemsSource = BookList_Class.library; // item source is the data from library after it was reseted to DB

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SpecificSearchList = library;
            BookList_Class.library = DataBaseService.GetData();
            BookDataGrid.ItemsSource = BookList_Class.LoadSearch(Genre_ComboBox.Text, Name_TextBox.Text, Author_TextBox.Text, ID_TextBox.Text, Price_TextBox.Text, Pages_TextBox.Text);

            PrintReport.Onhold = BookList_Class.library; //Sets current library on hold in report
            BookList_Class.library = DataBaseService.GetData(); //reset DB
        }


        private void IfTextEmpty(object sender, TextChangedEventArgs e)
        {
            // i could make an if clicked on textbox, save in a method what box is clicked and then
            //get the text from there and default text and make the if epty function 'more stable' but 
            //i have no time for that and other things are more important to work on it seems with the time i've been given.
            //so i will stay with each box has its own if empty.
        }
        private void IfEmptyResetName(object sender, TextChangedEventArgs e)
        {
            if (this.Name_TextBox.Text == "")
            {
                Name_TextBox.Text = "Name";
            }


        }
        private void IfEmptyResetAuthor(object sender, TextChangedEventArgs e)
        {
            if (Author_TextBox.Text == "")
            {
                Author_TextBox.Text = "Author";
            }
        }
        private void IfEmptyResetID(object sender, TextChangedEventArgs e)
        {
            if (ID_TextBox.Text == "")
            {
                ID_TextBox.Text = "ID";
            }
        }
        private void IfEmptyResetPages(object sender, TextChangedEventArgs e)
        {
            if (Pages_TextBox.Text == "")
            {
                Pages_TextBox.Text = "Pages Number";
            }
        }
        private void IfEmptyResetPrice(object sender, TextChangedEventArgs e)
        {
            if (Price_TextBox.Text == "")
            {
                Price_TextBox.Text = "Price";
            }
        }

        private async void Button_Remove_Click(object sender, RoutedEventArgs e) //removes item from list
        {
            Gif_Class gif_Class = new Gif_Class();
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();


            if (BookDataGrid.SelectedItem != null)
            {
         

                string str = "";

                if (BookDataGrid.SelectedItem != null)
                {
                    foreach (DataGridCellInfo cell in BookDataGrid.SelectedCells)
                    {
                        str = cell.Item.ToString(); //getting the to string

                        StringBuilder sb = new StringBuilder();

                        char[] chars = str.ToCharArray();

                        foreach (char c in chars)
                        {
                            if (c.ToString() != ",")
                            {
                                sb.Append(c);

                            }
                            else
                            {
                                break;
                            }
                        }
                        str = sb.ToString(); // getting the final string of book name

                    }


                }
                RemovedBooksLogsDB.AddBookRemovedDB(str, true);

                BookList_Class.RemoveBook(BookDataGrid.SelectedItem.ToString());

                DataBaseService dataBaseService = new DataBaseService();
                dataBaseService.SaveData(BookList_Class.library);


                BookDataGrid.ItemsSource = BookList_Class.LoadAllBooks();
                gif_Class.BookBuy("This Book have been removed!", Librarian_Image, Button_Buy, Button_Menu, Button_Remove, MainTextBlock);
            }
            else
            {
                try
                {
                    ExceptionLogsDB exceptionLogs = new ExceptionLogsDB();

                    NoBookSelectedException exception = new NoBookSelectedException();
                    exceptionLogs.AddException(exception);
                    throw exception;
                }
                catch
                {
                    gif_Class.GifVisble(true, Librarian_Image);
                    gif_Class.SettingUpAGif(15, Librarian_Image);
                    await screenTextEffect_Class.ScreenSay("Pick the book you want to Remove first dummy!!!", MainTextBlock, Button_Buy, Button_Remove, Button_Add, Button_Edit, Logs_Button,PrintReport_Button_Copy,"Librarian");
                    gif_Class.GifVisble(false, Librarian_Image);
                }
     
            }

        }



        private async void Button_Buy_Click(object sender, RoutedEventArgs e)
        {
            Gif_Class gif_Class = new Gif_Class();
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();

            if (BookDataGrid.SelectedItem != null)
            {
                StringBuilder stringBuilder = new StringBuilder();

                string SelectedBook = BookDataGrid.SelectedItem.ToString();


                gif_Class.BookBuy(SelectedBook, Librarian_Image, Button_Buy, Button_Menu, Button_Remove, MainTextBlock);

                string str = "";

                if (BookDataGrid.SelectedItem != null)
                {
                    foreach (DataGridCellInfo cell in BookDataGrid.SelectedCells)
                    {
                        str = cell.Item.ToString(); //getting the to string

                        StringBuilder sb = new StringBuilder();

                        char[] chars = str.ToCharArray();

                        foreach (char c in chars)
                        {
                            if (c.ToString() != ",")
                            {
                                sb.Append(c);

                            }
                            else
                            {
                                break;
                            }
                        }
                        str = sb.ToString(); // getting the final string of book name

                    }               


                }
                BoughtBooksLogsDB.AddBookBoughtDB(str, true);
            }
            else
            {
                try
                {
                    ExceptionLogsDB exceptionLogs = new ExceptionLogsDB();

                    NoBookSelectedException exception = new NoBookSelectedException();
                    exceptionLogs.AddException(exception);
                    throw exception;
                }
                catch
                {
                    gif_Class.GifVisble(true, Librarian_Image);
                    gif_Class.SettingUpAGif(15, Librarian_Image);
                    await screenTextEffect_Class.ScreenSay("Pick the book you want to buy first dummy!!!", MainTextBlock, Button_Buy, Button_Remove, Button_Add, Button_Edit, Logs_Button, PrintReport_Button_Copy, "Librarian");
                    gif_Class.GifVisble(false, Librarian_Image);
                }

 
            }

        }

        private void BookAdd_Button(object sender, RoutedEventArgs e)
        {
            AddBookWindow addbookwindow = new AddBookWindow();
            addbookwindow.Show();
            this.Close();
        }

        private void BookSearch_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Reports_Button_Click(object sender, RoutedEventArgs e)
        {
            LogsWindow logsWindow = new LogsWindow();
            logsWindow.Show();
            this.Close();
        }

        private async void PrintReport_Button_Click(object sender, RoutedEventArgs e)
        {
            PrintReport printReport = new PrintReport();

            printReport.PrintTextReport();

            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();
            await screenTextEffect_Class.ScreenSay("Your report has been printed into this path:" + PrintReport.FolderPath, MainTextBlock, Button_Buy, Button_Remove, Button_Add, Button_Edit, Logs_Button,PrintReport_Button_Copy ,"Librarian");

        }
            private async void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            Gif_Class gif_Class = new Gif_Class();
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();

            string str = "";

            if (BookDataGrid.SelectedItem != null)
            {
                foreach (DataGridCellInfo cell in BookDataGrid.SelectedCells) 
                {
                     str = cell.Item.ToString(); //getting the to string

                    StringBuilder sb = new StringBuilder();

                    char[] chars = str.ToCharArray();

                    foreach(char c in chars)
                    {
                        if(c.ToString() !=",")
                        {
                            sb.Append(c);

                        }
                        else
                        {
                            break;
                        }
                    }
                    str = sb.ToString(); // getting the final string of book name

                }

                AddBookWindow addbookwindow = new AddBookWindow();

                foreach (Library_Class book in BookList_Class.library)
                {
                    if(book.Name == str)
                    {
                        addbookwindow.Genre_ComboBox.Text = Global_Mehtods.SplitString(book.Genres.ToString(), ",", 0);
                        addbookwindow.Genre_ComboBox_Second.Text = Global_Mehtods.SplitString(book.Genres.ToString(), ",", 1);
                        addbookwindow.Genre_ComboBox_Third.Text = Global_Mehtods.SplitString(book.Genres.ToString(), ",", 2);
                        addbookwindow.Name_TextBox.Text = book.Name;
                        addbookwindow.Author_TextBox.Text = book.Author;
                        addbookwindow.Price_TextBox.Text = book.Price.ToString();
                        addbookwindow.Pages_TextBox.Text = book.NumPages.ToString();
                        addbookwindow.superCombo.SelectedColor = book.Color;

                        AddBookWindow.BookToRemove = book.Name;
                        AddBookWindow.Editing = true;
                        AddBookWindow.BookToRemoveID = book.ID;
                        break;
                    }
                }
                addbookwindow.Show();


                this.Close();


            }
            else
            {
                try
                {
                    ExceptionLogsDB exceptionLogs = new ExceptionLogsDB();

                    NoBookSelectedException exception = new NoBookSelectedException();
                    exceptionLogs.AddException(exception);
                    throw exception;
                }
                catch
                {
                    gif_Class.GifVisble(true, Librarian_Image);
                    gif_Class.SettingUpAGif(15, Librarian_Image);
                    await screenTextEffect_Class.ScreenSay("Pick the book you want to Edit first dummy!!!", MainTextBlock, Button_Buy, Button_Remove, Button_Add, Button_Edit, Logs_Button, PrintReport_Button_Copy, "Librarian");
                    gif_Class.GifVisble(false, Librarian_Image);
                }
          
            }


        }

        private void Genre_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
