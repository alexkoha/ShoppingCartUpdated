using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ShoppingCart.Interfaces;
using ShoppingCart.Managers;
using ShoppingCart.WPF.Command;

namespace ShoppingCart.WPF.Users
{
    public class SignUpViewModel
    {
        private UserManager _appManager;
        public DelegateCommand<Window> SignUpCommand { get; private set; }

        public SignUpViewModel(UserManager manager)
        {
            _appManager = manager;

            SignUpCommand = new DelegateCommand<Window>(SignUpNewUser);
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("User name cannot be empty.");
                }
                if (value.Length > 20)
                {
                    throw new Exception("name can not be longer than 20 charectors");
                }
                if (!Equals(_username, value))
                {
                    _username = value;
                }

            }
        }

        public void SignUpNewUser(Window windows)
        {
            var isSignedUp = _appManager.SignUpNewUser(_username);
            if (isSignedUp)
                windows.Close();
            else
                MessageBox.Show("this user name already exist, choose other one.");
            
        }
    }
}
