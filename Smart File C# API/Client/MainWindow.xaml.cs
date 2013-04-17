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

        /*
        Client Token: u78PuhtLu9jbHYhG9GoLapEk0oztav
        Client Secret: 9jhF6Yp6J4Ox2SQj71ihIo9SjDbrCn
         */

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
        ViewPermissions tempViewPermissions = null;

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
            tempViewPermissions = new Client.ViewPermissions(this);
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

            Ribbon.IsEnabled = b;
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
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete"+listBox.SelectedItem+"?\nThis cannot be undone\n", "Delete Directory", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Do this
                deleteDirectory();
            }
            
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
            MessageBox.Show("It does not appear possible to change what users are in a group using the Smartfile 2.0 API");
        }

        private void _ViewGroup_Click(object sender, RoutedEventArgs e)
        {
            openWindow(tempViewGroup);
        }

        private void _TaskRefresh_Click(object sender, RoutedEventArgs e)
        {
            refreshTasks();
        }



        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            _AddUser_Click(sender, e);
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            _EditUser_Click(sender, e);
        }

        private void ViewUser_Click(object sender, RoutedEventArgs e)
        {
            _ViewUser_Click(sender, e);
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            _AddGroup_Click(sender, e);
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("It does not appear possible to user the api to change what users are in a group");
        }

        private void ViewGroup_Click(object sender, RoutedEventArgs e)
        {
            _ViewGroup_Click(sender, e);
        }

        private void _AccessViewPermissions_Click(object sender, RoutedEventArgs e)
        {

            tempViewPermissions.setPath(listBox.SelectedItem.ToString());
            openWindow(tempViewPermissions);
        }

        #region Help Connectivity
        private void _HelpFileNewDirectory_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The New Directory button will allow you to create a new Folder (Directory) of a specified name in whatever directory you have currently selected\n");
        }

        private void _HelpFileRename_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Rename [Directory] button will allow you to rename the currently selected item {Directory, File} to a new specified name\n");
        }

        private void _HelpFileMoveDirectory_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Move [Directory] button will allow you to move the currently selected directory to a new specified path\n");
        }

        private void _HelpFileDeleteDirectory_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Delete [Directory] button will allow you to delete the currently selected directory\n");
        }

        private void _HelpFileUploadFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Upload [File] button will allow you to select a file from your computer to upload to the currently selected directory\n");
        }

        private void _HelpFileDownloadFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Download [File] button will allow you to download the currently selected file to a location on your computer\n");
        }

        private void _HelpFileRenameFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Rename [File] button will allow you rename the currently selected file to a specified name\n");
        }

        private void _HelpFileCopyFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Copy [File] button will record the currently selected file\n");
        }

        private void _HelpFilePasteFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Paste [File] button will copy the file stored using the Copy [File] button to the given directory\n");
        }

        private void _HelpFileDetailsFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Details [File] button will display significantly more details about the currently selected file than currently displayed\n");
        }

        private void _HelpFileDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Delete [File] button will delete the currently selected file\n");
        }

        private void _HelpFileAddUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Add User button will allow you to add a User with specified attributes\n {Username} is a mandatory field and is what the user will login using\n {E-Mail} is a mandatory field and is how the server will notify the user of their new account as well how the server will communicate with them\n {Home} is a mandatory field and it is the {Directory, File} that you want to give the user access to\n {List} is defaultly false and it is the ability for the user to see other files within a directory\n {Read} is defaultly false and it is the ability to download and therefore read a file which they have access to\n{Write} is defaultly false and it is the ability for the user to upload files to the given {home} directory\n{Delete} is defaultly false and it is the ability for the user to delete files which they have access to\n{Password} is defaultly auto-generated by the server and emailed to the user but a custom one can be entered\n{Name} is defaultly the same as the username but a custom one can be entered\n{Role} is defaultly User but a different role can be chosen\n{Expiration} is defaultly never but a custom date (MM/DD/YYYY) can be choosen for that user\n{Group(s)} is defaultly none but a user can be a member of as many groups as you want\nUnderneath Edit User you can tailor a user's permissions much more specifically than through Add User\n");
        }

        private void _HelpFileEditUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Edit User button will allow you to set specific permissions for an specified user and {Directory, File}\n{List} is defaultly false and it is the ability for the user to see other files within a directory\n {Read} is defaultly false and it is the ability to download and therefore read a file which they have access to\n{Write} is defaultly false and it is the ability for the user to upload files to the given {home} directory\n{Delete} is defaultly false and it is the ability for the user to delete files which they have access to\n");
        }

        private void _HelpFileViewUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The View User button is similar to Edit User but will display what permissions the user has for a given directory and allow them to be modified");
        }

        private void _HelpFileAddGroup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Warning: Intelligent Client is not able to add Users to Groups once the group is created\n The Add Group button will allow you to create a group with a specific name and specified members\nPermissions for the group can be set using the View Group button");

        }

        private void _HelpFileEditGroup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("During development we were unable to find a way to add users to groups post-creation so the Edit Group button displays a message stating that it does nothing");
        }

        private void _HelpFileViewGroup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The View Group button will allow you to set specific permissions for a selected group and {Directory, File} as well as display what the current settings are\n{List} is defaultly false and it is the ability for the user to see other files within a directory\n {Read} is defaultly false and it is the ability to download and therefore read a file which they have access to\n{Write} is defaultly false and it is the ability for the user to upload files to the given {home} directory\n{Delete} is defaultly false and it is the ability for the user to delete files which they have access to\n");

        }

        private void _HelpTaskRefresh_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Refresh Task button refreshes the status of the displayed tasks\n");
        }

        #endregion


        private void _Authors_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The two programmers for this project are\nJeffrey Carter - UI & Scope\nKyle Dooley - Connectivity\nThe source code and License for this project can be found on github [https://github.com/Carterj3/SmartFile]");
        }

        private void _Version_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version 1.0\n A Changelog can be found on github [https://github.com/Carterj3/SmartFile]");
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
            MessageBox.Show("Uploading :[" + filename + "] to ["+listBox.SelectedItem+"]");
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

        private void refreshTasks()
        {
            MessageBox.Show("Refreshing tasks");
        }

        #endregion

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            directory.Clear();

            if (Ribbon.SelectedItem.Equals(FileTab))
            {
                directory.Add("File1");
                directory.Add("Folder Name");
                directory.Add("Folder Name\\File2");
                directory.Add("Folder Name\\File3");
                directory.Add("Emtpy Folder");
            }
            else if (Ribbon.SelectedItem.Equals(TaskTab))
            {
                directory.Add("[Move] [File2] From [\\] to [\\Folder Name] : 100%");
            }
            else if (Ribbon.SelectedItem.Equals(AccessTab))
            {
                directory.Add("File1");
                directory.Add("Folder Name");
                directory.Add("Folder Name\\File2");
                directory.Add("Folder Name\\File3");
                directory.Add("Emtpy Folder");
            }
            else
            {

            }
        }







    }
}
