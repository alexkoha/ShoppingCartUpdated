using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Interfaces;
using ShoppingCart.Managers;
using ShoppingCart.Models;

namespace ShoppingCart.WPF.Services
{
    public class ProductsRepository : IProductsRepository
    {

        private UserManager _appManager;

        public ProductsRepository(UserManager appManager)
        {
            _appManager = appManager;
        }

        public async Task<IEnumerable<ItemKey>> GetProductsAsync()
        {
            var list = await Task.Run(()=>_appManager.ListOfProducts);
            return list;
        }
    }

}
