using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Victors_Library
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LogsWindow : Window
    {
        public LogsWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            AddBookWindow.Editing = false;
            MainWindow.RunMusic = false;  // so when menu wont run music from start
            MainWindow.RunExplanation = false;  // so when user goes back to menu wont show explanation again

            BoughtBooks_Button.Background = Brushes.YellowGreen;
            AddedBooks_Button.Background = Brushes.YellowGreen;
            RemovedtBooks_Button.Background = Brushes.YellowGreen;
            Exceptions_Button.Background = Brushes.YellowGreen;

        }

        private void Bought_Button_Click(object sender, RoutedEventArgs e)
        {
            BookDataGrid.ItemsSource = BoughtBooksLogsDB.BoughtBooks;

            BoughtBooks_Button.Background = Brushes.Green;
            AddedBooks_Button.Background = Brushes.YellowGreen;
            RemovedtBooks_Button.Background = Brushes.YellowGreen;
            Exceptions_Button.Background = Brushes.YellowGreen;


        }
        private void Added_Button_Click(object sender, RoutedEventArgs e) //returns all library
        {
            BookDataGrid.ItemsSource = AddedBooksLogsDB.AddedBooks;

            BoughtBooks_Button.Background = Brushes.YellowGreen;
            AddedBooks_Button.Background = Brushes.Green;
            RemovedtBooks_Button.Background = Brushes.YellowGreen;
            Exceptions_Button.Background = Brushes.YellowGreen;

        }
        private void Removed_Button_Click(object sender, RoutedEventArgs e)
        {
            BookDataGrid.ItemsSource = RemovedBooksLogsDB.RemovedBooks;

            BoughtBooks_Button.Background = Brushes.YellowGreen;
            AddedBooks_Button.Background = Brushes.YellowGreen;
            RemovedtBooks_Button.Background = Brushes.Green;
            Exceptions_Button.Background = Brushes.YellowGreen;

        }
        private void Exceptions_Button_Click(object sender, RoutedEventArgs e)
        {
            BookDataGrid.ItemsSource = ExceptionLogsDB.Exceptions;

            BoughtBooks_Button.Background = Brushes.YellowGreen;
            AddedBooks_Button.Background = Brushes.YellowGreen;
            RemovedtBooks_Button.Background = Brushes.YellowGreen;
            Exceptions_Button.Background = Brushes.Green;

        }

        private void BookSearch_Button_Click(object sender, RoutedEventArgs e)
        {

            LibraryWindow LibraryWindow = new LibraryWindow();
            LibraryWindow.Show();
            this.Close();
        }
    }
}
