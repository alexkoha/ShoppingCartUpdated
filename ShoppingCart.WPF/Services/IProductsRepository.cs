using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Models;

namespace ShoppingCart.WPF.Services
{

    public interface IProductsRepository
    {
        Task<IEnumerable<ItemKey>> GetProductsAsync();
    }
}
