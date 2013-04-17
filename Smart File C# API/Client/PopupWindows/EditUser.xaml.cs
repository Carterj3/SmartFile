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

namespace Client
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        MainWindow parent;
        public EditUser(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.setDialogOpen(false);
            e.Cancel = true;
            this.Hide();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            // Username
            String username = _Username.GetLineText(0);
            // Read
            Boolean read = (Boolean)_Read.IsChecked;
            // List
            Boolean list = (Boolean)_List.IsChecked;
            // Write
            Boolean write = (Boolean)_Write.IsChecked;
            // Delete
            Boolean delete = (Boolean)_Delete.IsChecked;
            // Directory
            String directory = _Home.GetLineText(0);

            parent.editUser(username, read, list, write, delete, directory);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
