using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static Victors_Library.Exceptions_Class;

namespace Victors_Library
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public static string BookToRemove = "";
        public static int BookToRemoveID = 0;
        public static bool Editing = false;

        public AddBookWindow()
        {
            SettingDefaultsAtStart settingDefaultsAtStart = new SettingDefaultsAtStart();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            InitializeComponent();

            MainWindow.RunMusic = false;  // so when menu wont run music from start
            MainWindow.RunExplanation = false;  // so when user goes back to menu wont show explanation again

            settingDefaultsAtStart.DefaultSettingsAddBook(MainTextBlock, Librarian_Image);


        }

        private async void Add_Button_Click(object sender, RoutedEventArgs e)
        {

            bool ContidionsToAdd = true;
            int Sampleint;
            string LibrarianFinalString;

            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class(); // to use librarian
            StringBuilder LibrarianFinalStringStringBuilder = new StringBuilder(); // to use stringbuilder
            LibrarianFinalStringStringBuilder.Append("Silly! you ");


            if (Genre_ComboBox.Text == "Main Genre")
            {
                ContidionsToAdd = false;
                LibrarianFinalStringStringBuilder.Append("need to pick a Main Genre, ");
            }
            if (Name_TextBox.Text == "Name")
            {
                ContidionsToAdd = false;
                LibrarianFinalStringStringBuilder.Append("need to pick a book Name, ");
            }
            if (int.TryParse(Price_TextBox.Text, out Sampleint) == false)
            {
                ContidionsToAdd = false;
                LibrarianFinalStringStringBuilder.Append("the Price cannot contain letters or symbols, ");
            }
            if (int.TryParse(Pages_TextBox.Text, out Sampleint) == false)
            {
                ContidionsToAdd = false;
                LibrarianFinalStringStringBuilder.Append("the Text cannot contain letters or symbols, ");
            }


            if (Author_TextBox.Text == "" || Author_TextBox.Text == "Author" || Author_TextBox.Text == "Unknown")
            {
                Author_TextBox.Text = "Unknown";
            }

            if (ContidionsToAdd == true) //succesfull
            {
                Gif_Class gif = new Gif_Class();

                if (Editing == true) // if editing remove the book to remove and reenter its details
                {

                    BookList_Class.RemoveBook(BookToRemove);

                    gif.SettingUpAGif(9, Librarian_Image);
                    await screenTextEffect_Class.ScreenSay("We will edit this book details!", MainTextBlock, Add_Button, Button_Menu, Button_Menu, "Librarian");
                    gif.SettingUpAGif(13, Librarian_Image);


                }
                else if (Editing == false)
                {
                    foreach (Library_Class book in BookList_Class.library.ToList()) //checks if there is already a book with same name, if there is librarian event + do not add book
                    {

                        if (book.Name == Name_TextBox.Text) //if duplicate change its details
                        {
                            try
                            {
                                ExceptionLogsDB exceptionLogs = new ExceptionLogsDB();

                                DuplicateBookAddingException exception = new DuplicateBookAddingException(Name_TextBox.Text + " already exists in the library.");
                                exceptionLogs.AddException(exception);
                                throw exception;                             
                            }
                            catch
                            {
                                gif.SettingUpAGif(9, Librarian_Image);
                                await screenTextEffect_Class.ScreenSay("This book already exists in the library!", MainTextBlock, Add_Button, Button_Menu, Button_Menu, "Librarian");
                                gif.SettingUpAGif(13, Librarian_Image);
                            }


                            break;
                        }
                    }
                }

                //probably needs fixing and make an event that adds this to database and when this happens refresh all database in all parts.

                BookList_Class bookList_Class = new BookList_Class();

                StringBuilder stringBuilderGenres = new StringBuilder();

                stringBuilderGenres.Append(Genre_ComboBox.Text);
                if (Genre_ComboBox_Second.Text != "Genre 2")
                {
                    stringBuilderGenres.Append(" " + Genre_ComboBox_Second.Text);
                }
                if (Genre_ComboBox_Second.Text != "Genre 3")
                {
                    stringBuilderGenres.Append(" " + Genre_ComboBox_Third.Text);
                }
                string FinalGenresString = stringBuilderGenres.ToString();

                bookList_Class.AddOneBookToDB(true, FinalGenresString, Name_TextBox.Text, int.Parse(Pages_TextBox.Text), int.Parse(Price_TextBox.Text), superCombo.SelectedColor, Author_TextBox.Text);
                AddedBooksLogsDB.AddBookAddedDB(Name_TextBox.Text, true);

                Gif_Class gif_Class = new Gif_Class();

                if (Editing == true) //if editing = true, set id to the id from the edited book.
                {
                    foreach (Library_Class book in BookList_Class.library.ToList()) //checks if there is already a book with same name, if there is librarian event + do not add book
                    {

                        if (book.Name == Name_TextBox.Text) //if duplicate change its details
                        {
                            book.ID = BookToRemoveID;

                            break;
                        }
                    }
                }
                if (Editing == false)
                {
                    gif_Class.BookComment(Librarian_Image, MainTextBlock, Genre_ComboBox, Add_Button, Button_Menu);
                }
            }
            else //failed
            {
                LibrarianFinalString = LibrarianFinalStringStringBuilder.ToString();

                try
                {
                    ExceptionLogsDB exceptionLogs = new ExceptionLogsDB();

                    IlegalBookAddingException exception = new IlegalBookAddingException(LibrarianFinalString);
                    exceptionLogs.AddException(exception);
                    throw exception;
                }
                catch
                {
                    Gif_Class gif_Class = new Gif_Class();
                    gif_Class.SettingUpAGif(8, Librarian_Image);

                    await screenTextEffect_Class.ScreenSay(LibrarianFinalString, MainTextBlock, Add_Button, Button_Menu, Button_Menu, "Librarian");
                    gif_Class.SettingUpAGif(13, Librarian_Image);

                }

            }

        }

        private void Button_GoToMenu(object sender, RoutedEventArgs e)
        {
            LibraryWindow LibraryWindow = new LibraryWindow();
            LibraryWindow.Show();
            this.Close();
        }

        private async void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Task.Delay(1);
            if (Name_TextBox.Text.Length <= 36)
            {
                NameBlock.Text = Name_TextBox.Text;

            }
        }

        private async void Author_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Task.Delay(1);
            if (Author_TextBox.Text.Length <= 28)
            {
                AuthorBlock.Text = "Author: " + Author_TextBox.Text;

            }
        }

        private async void Price_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Task.Delay(1);

            if (int.TryParse(Price_TextBox.Text, out int value))
            {
                int LocalPrice = int.Parse(Price_TextBox.Text);
                if (LocalPrice <= 9999) //max value for price is 99999
                {

                    var isNumeric = int.TryParse(Price_TextBox.Text, out int n);

                    if (isNumeric == true)
                    {
                        PriceTextBlock.Text = Price_TextBox.Text + "$";
                    }
                    else
                    {
                        PriceTextBlock.Text = "Price" + "$";
                        //librarian event that says you cannot enter non int
                    }
                }


            }

        }

        private async void Pages_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Task.Delay(1);

            if (int.TryParse(Pages_TextBox.Text, out int value))
            {
                int LocalPages = int.Parse(Pages_TextBox.Text);
                if (LocalPages < 99999)//max value for pages is 999999
                {

                    var isNumeric = int.TryParse(Pages_TextBox.Text, out int n);

                    if (isNumeric == true)
                    {
                        PagesBlock.Text = "Pages: " + Pages_TextBox.Text;
                    }
                    else
                    {
                        PagesBlock.Text = "Pages: ";
                        //librarian event that says you cannot enter non int 
                    }
                }
            }
        }

        private async void Genre_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //if same genre picked reset
        {
            await Task.Delay(1);

            if (Genre_ComboBox_Second.Text == Genre_ComboBox.Text || Genre_ComboBox_Third.Text == Genre_ComboBox.Text)
            {
                Genre_ComboBox.Text = "Main Genre";
            }
        }

        private async void Genre_ComboBox_Second_SelectionChanged(object sender, SelectionChangedEventArgs e) //if same genre picked reset
        {
            await Task.Delay(1);

            if (Genre_ComboBox.Text == Genre_ComboBox_Second.Text || Genre_ComboBox_Third.Text == Genre_ComboBox_Second.Text)
            {
                Genre_ComboBox_Second.Text = "Genre 2";
            }
        }

        private async void Genre_ComboBox_Third_SelectionChanged(object sender, SelectionChangedEventArgs e) //if same genre picked reset
        {
            await Task.Delay(1);

            if (Genre_ComboBox.Text == Genre_ComboBox_Third.Text || Genre_ComboBox_Second.Text == Genre_ComboBox_Third.Text)
            {
                Genre_ComboBox_Third.Text = "Genre 3";
            }
        }
    }
}
