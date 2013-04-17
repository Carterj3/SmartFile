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
    /// Interaction logic for AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        MainWindow parent;

        public AddGroup(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
        }

        private void _Remove_Click(object sender, RoutedEventArgs e)
        {
            // Store selected item

            // Remove it from remove

            // Add it to add
        }

        private void _Add_Click(object sender, RoutedEventArgs e)
        {
            // Store selected item

            // Remove it from add

            // Add it to remove
        }

        private void _CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            // Group name
            String groupName = _GroupName.GetLineText(0);

            // Users
            String[] groupMembers;

            try
            {
                ItemCollection temp = _RemoveUser.Items;
                groupMembers = new String[temp.Count];
                for (int i = 0; i < temp.Count; i++)
                {
                    groupMembers[i] = (String)temp.GetItemAt(i);
                }
            }
            catch (Exception)
            {

                groupMembers = null;
            }

            parent.addGroup(groupName, groupMembers);

        }

        private void _Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.setDialogOpen(false);
            e.Cancel = true;
            this.Hide();
        }
    }
}
