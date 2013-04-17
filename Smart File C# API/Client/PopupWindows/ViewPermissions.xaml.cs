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
    /// Interaction logic for ViewPermissions.xaml
    /// </summary>
    public partial class ViewPermissions : Window
    {
        MainWindow parent;
        public ViewPermissions(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();

        }

        public void setPath(String path)
        {
            _DirectoryLabel.Content = path;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.setDialogOpen(false);
            e.Cancel = true;
            this.Hide();
        }

        private void _UsernameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Update the Permission
        }

        private void _Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
