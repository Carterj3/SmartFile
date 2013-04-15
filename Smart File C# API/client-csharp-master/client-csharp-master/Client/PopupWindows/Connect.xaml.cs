using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
        MainWindow parent;
        public Connect(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            parent.setDialogOpen(false);
            e.Cancel = true;
            this.Hide();
        }

        private void _ConnectOk_Click(object sender, RoutedEventArgs e)
        {
            String key = _ConnectKey.GetLineText(0);
            String password = _ConnectPassword.GetLineText(0);
            parent.connect(key, password);
            this.Close();
        }

        private void _ConnectCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
