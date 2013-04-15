using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        Boolean dialogOpen = false;
        SmartFile.ClientHandler client = null;
        ObservableCollection<String> directory = new ObservableCollection<string>();
        String currentPath = "";

        Connect tempConnect = null;
        NewDirectory tempNewDirectory = null;
        RenameDirectory tempRenameDirectory = null;
        MoveDirectory tempMoveDirectory = null;

        public MainWindow()
        {
            InitializeComponent();
            #region Initialize Popup-Windows
            tempConnect = new Connect(this);
            tempNewDirectory = new NewDirectory(this);
            tempRenameDirectory = new RenameDirectory(this);
            tempMoveDirectory = new MoveDirectory(this);
            #endregion



            directory.Add("Line 1");
            directory.Add("Line 2");
            dockPanel.DataContext = directory;
        }

        public void setDialogOpen(Boolean b)
        {
            dialogOpen = b;
        }

        public void openWindow(Window w)
        {
            if (!dialogOpen)
            {
                dialogOpen = true;
                w.Show();
            }
        }

        #region onCLick

        private void _Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void _Connect_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempConnect);
        }

        private void _Disconnect_Click(object sender, RoutedEventArgs e)
        {
            client = null;
        }


        private void NewDirectory_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempNewDirectory);
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempRenameDirectory);
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempMoveDirectory);
        }

        // http://msdn.microsoft.com/en-us/library/aa969773.aspx#Common_Dialogs
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".*"; // Default file extension
            dlg.Filter = "Any File (*.*)|*.*"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                UploadFile(filename);
            }
        }


        // Literally just typed Microsoft.Win32.<Control Space> and made the best guess
        private void Download_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new SaveFileDialog();
            //
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".*"; // Default file extension
            dlg.Filter = "Any File (*.*)|*.*"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                DownloadFile(filename);
            }
        }

        

        private void Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            deleteDirectory();
        }


        private void Details_Click(object sender, RoutedEventArgs e)
        {

        }


        private void _AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _EditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _RemoveUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _AddGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _EditGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _RemoveGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveGroup_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region PopUp Window Connectivity
        internal void connect(string key, string password)
        {
            client = null;
            client = new SmartFile.ClientHandler(key, password);

        }

        internal void createDirectory(string name)
        {
            Console.WriteLine("Create Directory [" + currentPath + "] / [" + name + "]");
        }

        internal void renameDirectory(string name)
        {

            Console.WriteLine("Renaming Directory [" + listBox.SelectedItem + "] to [" + name + "]");
        }

        internal void MoveDirectory(string name)
        {
            Console.WriteLine("Moved Directory [" + currentPath + "] / [" + listBox.SelectedItem + "] to [" + name + "]");
        }

        internal void deleteDirectory()
        {
            Console.WriteLine("Deleting Directory [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        internal void UploadFile(string filename)
        {
            Console.WriteLine("Uploading :[" + filename + "]");
        }

        private void DownloadFile(string filename)
        {
            Console.WriteLine("Downloading ["+listBox.SelectedItem+"] to [" + filename + "]");
        }

        #endregion


    }
}
