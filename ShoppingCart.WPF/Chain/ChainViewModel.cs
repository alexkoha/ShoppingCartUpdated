using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.WPF.Chain
{
    public class ChainViewModel : ObservableObject
    {
        private string _imagePath;
        private string _chainName;
        private double _cartPrice;

        private IEnumerable<Product> _expensiveProducts;
        private IEnumerable<Product> _cheapestProducts;

        public ChainViewModel(string chainName , string imagePath)
        {
            _chainName = chainName;
            _imagePath = imagePath;
            _cartPrice = 0;
        }

        public string ImagePath => _imagePath;
        public string ChainName => _chainName;
        public double CartPrice
        {
            get { return _cartPrice; }
            set
            {
                if (Equals(value, _cartPrice)) return;
                _cartPrice = value;
                RaisePropertyChangedEvent("CartPrice");
            }
        }
        public IEnumerable<Product> ExpensiveProducts
        {
            get { return _expensiveProducts; }
            set
            {
                _expensiveProducts = value;
                RaisePropertyChangedEvent("ExpensiveProducts");
            }
        }

        public IEnumerable<Product> CheapestProducts
        {
            get { return _cheapestProducts; }
            set
            {
                _cheapestProducts = value;
                RaisePropertyChangedEvent("CheapestProducts");
            }
        }
    }
}
