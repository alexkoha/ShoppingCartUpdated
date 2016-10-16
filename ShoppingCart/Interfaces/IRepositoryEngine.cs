using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    public interface IRepositoryEngine
    {
        /*Having an async method which does not return a task is a bad idea
         * It terminates almost immediately and does not allow the client of this class to know when the operation is done
         * Return a task from such methods.
         */
        void UpdateXmlFilesAsync();
        string GetChainName(string chainId);
        string GetCahinXmlFileName(string chainId);

        IDictionary<Chain, double> GetCartPrice(ICollection<ItemKey> selectedProducts);
        //I would not use Tuples so much in API code - you know which is the cheapest and which is the most expensive, do others?
        IDictionary<Chain, Tuple<IEnumerable<Product>, IEnumerable<Product>>> GetChipestExpentivestProductsByChains();
        IDictionary<ItemKey, IEnumerable<Product>> GetPrudcutsCart(ICollection<ItemKey> selectedProducts);
        IEnumerable<ItemKey> GetItemsList();

        Chain GetChainById(string id);

        /**
         * Seems that this interface persists and obtains data from the file system
         * But I would not make it its job to handle excel as well
         * 
         * Consider:
         * a) https://en.wikipedia.org/wiki/Single_responsibility_principle
         * b) https://en.wikipedia.org/wiki/Interface_segregation_principle
         */
        Task CeateAndSaveExcelFileProductCartAsync(string fileName,IDictionary<ItemKey, IEnumerable<Product>> cartProductsByItemKey);
    }
}