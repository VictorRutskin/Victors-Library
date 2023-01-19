using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
using Victors_Library;

namespace Victors_Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool RunMusic = true; // if first run = run music, else do not (when change to other page it changes to false)
        public static bool RunExplanation = true; // if first run = run Explanation, else do not (when change to other page it changes to false)

        public MainWindow()
        {
            SettingDefaultsAtStart settingDefaultsAtStart = new SettingDefaultsAtStart();

            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            InitializeComponent();

            AddBookWindow.Editing = false;
            MainTextBlock.IsEnabled = false;


            if (RunMusic==true) // only happens in first run, when move to other page it resets
            {
                SoundPlayer sound = new SoundPlayer("Naruto Shippuden OST-Peaceful Theme 1 (Unreleased)-EXTENDED.Wav");
                sound.PlayLooping();
            }
            if (RunExplanation == true) // only happens in first run, when move to other page it resets
            {
                settingDefaultsAtStart.DefaultSettingsMain(MainTextBlock, Librarian_Image, BookSearch_Button,true); 

            }
            else
            {
                settingDefaultsAtStart.DefaultSettingsMain(MainTextBlock, Librarian_Image, BookSearch_Button,false); 
            }
        }


        private void MainTextBlock_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BookRemoving_Button_Click(object sender, RoutedEventArgs e)
        {

            AddBookWindow addbookwindow = new AddBookWindow();
            addbookwindow.Show();
            this.Close();
        }
        private void BookAdding_Button_Click(object sender, RoutedEventArgs e)
        {

            AddBookWindow addbookwindow = new AddBookWindow();
            addbookwindow.Show();
            this.Close();

        }
        private void BookSearch_Button_Click(object sender, RoutedEventArgs e)
        {

            LibraryWindow LibraryWindow = new LibraryWindow();
            LibraryWindow.Show();
            this.Close();
        }
        private void ExitLibrary(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        
    }
}
