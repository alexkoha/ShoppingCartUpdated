using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShoppingCart.Managers;
using ShoppingCart.Models;
using ShoppingCart.WPF.Command;

namespace ShoppingCart.WPF.Users
{
    public class RemoveViewModel
    {
        private UserManager _appManager;
        private User _selectedUser;
        
        public IEnumerable<User> Users { get; private set; }
        public DelegateCommand<Window> RemoveUserCommand { get; private set; }

        public RemoveViewModel(UserManager userManager)
        {
            _appManager = userManager;

            Users = _appManager.Users;
            RemoveUserCommand = new DelegateCommand<Window>(RemoveUser);
        }


        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (!Equals(_selectedUser, value))
                    _selectedUser = value;
            }
        }

        private void RemoveUser(Window window)
        {
            var isDeleted = _appManager.RemoveUser(SelectedUser);

            if (isDeleted)
                window.Close();
            else
                MessageBox.Show("Somthing gone wrong.Try again.");
        }
    }
}
