using Microsoft.Win32;
using System;
using System.Collections;
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
        Window openedWindow = null;


        SmartFile.ClientHandler client = null;
        ObservableCollection<String> directory = new ObservableCollection<string>();
        String currentPath = "";

        Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[] filesItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[19];
        Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[] accessItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[6];
        Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[] helpItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[0];
        Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[] aboutItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[0];


        Connect tempConnect = null;
        NewDirectory tempNewDirectory = null;
        RenameDirectory tempRenameDirectory = null;
        MoveDirectory tempMoveDirectory = null;
        AddUser tempAddUser = null;

        public MainWindow()
        {
            InitializeComponent();
            #region Initialize Popup-Windows
            tempConnect = new Connect(this);
            tempNewDirectory = new NewDirectory(this);
            tempRenameDirectory = new RenameDirectory(this);
            tempMoveDirectory = new MoveDirectory(this);
            tempAddUser = new Client.AddUser(this);
            #endregion
            #region Initialize Lists of ribbonButtons

            filesItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[17]
            {NewDirectory,Rename, Move,Delete,
            Upload, Download, _Rename,Copy,Paste,Details,_Delete,
            _AddUser,_EditUser,_RemoveUser,
            _AddGroup,_EditGroup,_RemoveGroup};

            accessItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[6]
            {AddUser,EditUser,RemoveUser,
            AddGroup,EditGroup,RemoveGroup};

            helpItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[0];

            aboutItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[0];

            #endregion

            directory.Add("Line 1");
            directory.Add("Line 2");
            dockPanel.DataContext = directory;

        }


        public void enableButtons()
        {
            setButtons(true);
        }
        public void disableButtons()
        {
            setButtons(false);
        }

        private void setButtons(Boolean b)
        {
            for (int i = 0; i < filesItems.Length; i++)
            {
                filesItems[i].IsEnabled = b;
            }

            for (int i = 0; i < accessItems.Length; i++)
            {
                accessItems[i].IsEnabled = b;
            }

        }


        public void setDialogOpen(Boolean b)
        {
            dialogOpen = b;
            openedWindow = null;
            enableButtons();
        }

        public void openWindow(Window w)
        {
            if (!dialogOpen)
            {
                dialogOpen = true;
                openedWindow = w;
                w.Show();
                disableButtons();
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
            copyDirectory();
        }


        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            pasteDirectory();
        }



        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            deleteDirectory();
        }


        private void Details_Click(object sender, RoutedEventArgs e)
        {
            details();
        }




        private void _AddUser_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempAddUser);
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
            //ArrayList s = client.getDirectory("/");
            //client.newFolder("NEW");
            //client.remove("/Test/NEW");
            //client.move("NEW", "JEFF");
            //client.rename("NEW", "JEFF");

            //client.tempLink("TEST/SmartFile.txt");

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

        internal void DownloadFile(string filename)
        {
            Console.WriteLine("Downloading [" + listBox.SelectedItem + "] to [" + filename + "]");
        }

        internal void copyDirectory()
        {
            Console.WriteLine("Copying Directory [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        internal void pasteDirectory()
        {
            Console.WriteLine("Pasting to Directory [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        private void details()
        {
            Console.WriteLine("Getting details on [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        internal void addUser(string user, bool? list, bool? read, bool? write, bool? delete)
        {
            Console.WriteLine("Add User :[" + user + "] with List?[" + list + "] Read?[" + read + "] Write?[" + write + "] Delete?[" + delete + "]");
        }

        #endregion




    }
}
