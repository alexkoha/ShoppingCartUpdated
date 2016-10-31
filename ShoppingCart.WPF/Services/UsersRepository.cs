using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Managers;
using ShoppingCart.Models;

namespace ShoppingCart.WPF.Services
{
    public class UsersRepository : IUsersRepository
    {
        private UserManager _appManager;

        public UsersRepository(UserManager appManager)
        {
            _appManager = appManager;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            return await Task.Run(() => _appManager.CurrentUser);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await Task.Run(() => _appManager.Users);
        }
    }
}
