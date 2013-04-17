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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        MainWindow parent;
        public AddUser(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
            // Need to get the roles

            // Need to get the groups
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.setDialogOpen(false);
            e.Cancel = true;
            this.Hide();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            // Username
            String username = _Username.GetLineText(0);
            // Email
            String email = _Email.GetLineText(0);
            // Home
            String home = _Home.GetLineText(0);
            // list? Read? Write? Delete?
            Boolean list = (Boolean)_List.IsChecked;
            Boolean read = (Boolean)_Read.IsChecked;
            Boolean write = (Boolean)_Write.IsChecked;
            Boolean delete = (Boolean)_Delete.IsChecked;
            // Password
            String password = _Password.GetLineText(0);
            // Name
            String name = _Name.GetLineText(0);
            // Role
            String role;

            try
            {
                role = _Role.SelectedValue.ToString();
            }
            catch (Exception)
            {
                role = "null";
            }
            // Expiration
            String expiration = _Expiration.GetLineText(0);
            // Groups
            String[] groups;

            try
            {
                groups = new String[_GroupRemove.Items.Count];
                int j = 0;
                foreach (ItemCollection i in _GroupRemove.Items)
                {
                    groups[j] = i.ToString();
                    j++;
                }
            }
            catch (Exception)
            {

                groups = null;
            }

            MessageBox.Show(String.Format("Username:{0}\nEmail:{1}\nHome:{2}\nList:{3}\nRead:{4}\nWrite:{5}\nDelete:{6}\nPassword:{7}\nName:{8}\nRole:{9}\nExpiration:{10}\nGroups:{11}\n", username, email, home, list, read, write
                , delete, password, name, role, expiration, groups.ToArray<String>().ToString()));
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            // store group

            // remove from add

            // add to remove
        }

        private void RemoveGroup_Click(object sender, RoutedEventArgs e)
        {
            // store group

            // remove from remove

            // add to add

        }


    }
}
