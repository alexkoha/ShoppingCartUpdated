using System;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ShoppingCart.Interfaces;
using ShoppingCart.Managers;
using ShoppingCart.Models;
using ShoppingCart.WPF.Services;
using ShoppingCart.WPF.Users;

namespace ShoppingCart.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainExpander_OnMouseLeave(object sender, MouseEventArgs e)
        {
            MainExpander.IsExpanded = false;
        }
    }
}
