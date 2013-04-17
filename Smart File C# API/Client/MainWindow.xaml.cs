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
        EditUser tempEditUser = null;
        ViewUser tempViewUser = null;
        AddGroup tempAddGroup = null;
        ViewGroup tempViewGroup = null;

        public MainWindow()
        {
            InitializeComponent();
            #region Initialize Popup-Windows
            tempConnect = new Connect(this);
            tempNewDirectory = new NewDirectory(this);
            tempRenameDirectory = new RenameDirectory(this);
            tempMoveDirectory = new MoveDirectory(this);
            tempAddUser = new Client.AddUser(this);
            tempEditUser = new Client.EditUser(this);
            tempViewUser = new Client.ViewUser(this);
            tempAddGroup = new Client.AddGroup(this);
            tempViewGroup = new Client.ViewGroup(this);
            #endregion
            #region Initialize Lists of ribbonButtons

            filesItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[17]
            {NewDirectory,Rename, Move,Delete,
            Upload, Download, _Rename,Copy,Paste,Details,_Delete,
            _AddUser,_EditUser,_ViewUser,
            _AddGroup,_EditGroup,_ViewGroup};

            accessItems = new Microsoft.Windows.Controls.Ribbon.RibbonMenuItem[6]
            {AddUser,EditUser,ViewUser,
            AddGroup,EditGroup,ViewGroup};

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
            openWindow(tempEditUser);
        }

        private void _ViewUser_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempViewUser);
        }

        private void _AddGroup_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempAddGroup);
        }

        private void _EditGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _ViewGroup_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempViewGroup);
        }


        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewGroup_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region PopUp Window Connectivity
        internal void connect(string key, string password)
        {

            try
            {
                client = null;
                client = new SmartFile.ClientHandler(key, password);
            }
            catch (Exception e)
            {

                MessageBox.Show(String.Format("An Error Occured but has been caught\nLocation:0000\n{0}", e.Message));
            }

        }

        internal void createDirectory(string name)
        {
            MessageBox.Show("Create Directory [" + currentPath + "] / [" + name + "]");
        }

        internal void renameDirectory(string name)
        {

            MessageBox.Show("Renaming Directory [" + listBox.SelectedItem + "] to [" + name + "]");
        }

        internal void MoveDirectory(string name)
        {
            MessageBox.Show("Moved Directory [" + currentPath + "] / [" + listBox.SelectedItem + "] to [" + name + "]");
        }

        internal void deleteDirectory()
        {
            MessageBox.Show("Deleting Directory [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        internal void UploadFile(string filename)
        {
            MessageBox.Show("Uploading :[" + filename + "]");
        }

        internal void DownloadFile(string filename)
        {
            MessageBox.Show("Downloading [" + listBox.SelectedItem + "] to [" + filename + "]");
        }

        internal void copyDirectory()
        {
            MessageBox.Show("Copying Directory [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        internal void pasteDirectory()
        {
            MessageBox.Show("Pasting to Directory [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        private void details()
        {
            MessageBox.Show("Getting details on [" + currentPath + "] / [" + listBox.SelectedItem + "]");
        }

        internal void addUser(string user, bool? list, bool? read, bool? write, bool? delete)
        {
            MessageBox.Show("Add User :[" + user + "] with List?[" + list + "] Read?[" + read + "] Write?[" + write + "] Delete?[" + delete + "]");
        }

        internal void editUser(string username, bool read, bool list, bool write, bool delete, string directory)
        {
            MessageBox.Show(String.Format("Username:{0}\nRead?:{1}\nList?:{2}\nWrite:{3}\nDelete:{4}\nDirectory:{5}\n Edit User", username, read, list, write, delete, directory));
        }

        internal void addGroup(string groupName, string[] groupMembers)
        {
            String tempList = "";
            foreach (String s in groupMembers)
            {
                tempList += s + "\n";
            }
            MessageBox.Show(String.Format("GroupName:{0}\nMembers:{1}", groupName, tempList));
        }

        internal void editGroup(string groupName, string directory, bool read, bool list, bool write, bool delete)
        {
            MessageBox.Show(String.Format("Group:{0}\nDirectory:{1}\nRead:{2}\nList:{3}\nWrite:{4}\nDelete:{5}", groupName, directory, read, list, write, delete));
        }

        #endregion


    }
}
