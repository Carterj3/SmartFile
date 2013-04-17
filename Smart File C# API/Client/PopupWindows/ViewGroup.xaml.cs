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
    /// Interaction logic for ViewGroup.xaml
    /// </summary>
    public partial class ViewGroup : Window
    {
        MainWindow parent;
        public ViewGroup(MainWindow owner)
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

        private void _GroupName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get group name

            // Reset directory
            // Grab new permissions
        }

        private void _Directory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Store directory

            // if .. go up a level

            //  else Get children

            // List directory + children + .. [unless / ]
        }

        private void _EditGroup_Click(object sender, RoutedEventArgs e)
        {
            String groupName;
            try
            {
                groupName = (String)_GroupName.SelectedItem;
            }
            catch (Exception)
            {

                groupName = "";
            }
            String directory;
            try
            {
                directory = (String)_Directory.SelectedItem;
            }
            catch (Exception)
            {

                directory = "";
            }
            // Read
            Boolean read = (Boolean)_Read.IsChecked;
            // List
            Boolean list = (Boolean)_List.IsChecked;
            // Write
            Boolean write = (Boolean)_Write.IsChecked;
            // Delete
            Boolean delete = (Boolean)_Delete.IsChecked;

            parent.editGroup(groupName, directory, read, list, write, delete);
            this.Close();
        }

        private void _Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
