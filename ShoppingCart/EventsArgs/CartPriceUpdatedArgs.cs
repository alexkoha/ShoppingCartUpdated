using System;
using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.EventsArgs
{
    /*
     * Product already has the chain id, so why limit your property names to specific chains?
    Why limit yourself to three when you can just have a collection of cart objects?
    Seems to me that this is what your model is missing.
    */
    public class CartPriceUpdatedArgs : EventArgs
    {
        public IEnumerable<Product> MahsaneyHashookExpensiveProducts { get; set; }
        public IEnumerable<Product> MahsaneyHashookChipestProducts { get; set; }
        public IEnumerable<Product> ShookHaairExpensiveProducts { get; set; }
        public IEnumerable<Product> ShookHaairChipestProducts { get; set; }
        public IEnumerable<Product> ViktoryExpensiveProducts { get; set; }
        public IEnumerable<Product> ViktoryChipestProducts { get; set; }
        public double ViktoryCartPrice { get; set; }
        public double ShookHaairCartPrice { get; set; }
        public double MahsaneyHashookCartPrice { get; set; }
    }
}