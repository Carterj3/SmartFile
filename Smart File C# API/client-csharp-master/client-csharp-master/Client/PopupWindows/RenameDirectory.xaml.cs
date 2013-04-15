﻿using System;
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
    /// Interaction logic for RenameDirectory.xaml
    /// </summary>
    public partial class RenameDirectory : Window
    {
        MainWindow parent = null;
        public RenameDirectory(MainWindow owner)
        {
            parent = owner;
            InitializeComponent();
        }

        private void Rename_Click(object sender, RoutedEventArgs e)
        {
            String name = DirectoryName.GetLineText(0);
            parent.renameDirectory(name);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
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
