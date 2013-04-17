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
    /// Interaction logic for ViewUser.xaml
    /// </summary>
    public partial class ViewUser : Window
    {
        MainWindow parent;
        public ViewUser(MainWindow owner)
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

        private void _UsernameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update the directory Combo Box
        }

        private void _DirectoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update the read/list/write/delete values
        }

        private void _ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            // Username
            String username;
            try
            {
                username = (String)_UsernameComboBox.SelectedItem;
            }
            catch (Exception)
            {

                username = "null";
            }
            // Read
            Boolean read = (Boolean)_Read.IsChecked;
            // List
            Boolean list = (Boolean)_List.IsChecked;
            // Write
            Boolean write = (Boolean)_Write.IsChecked;
            // Delete
            Boolean delete = (Boolean)_Delete.IsChecked;
            // Directory
            String directory;
            try
            {
                directory = (String)_DirectoryComboBox.SelectedItem;
            }
            catch (Exception)
            {

                directory = "null";
            }

            parent.editUser(username, read, list, write, delete, directory);
            this.Close();
        }

        private void _Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
