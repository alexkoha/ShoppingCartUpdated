using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    public interface IUserEngine
    {
        User GetGeustUser();
        bool AddUser(string name);
        bool RemoveUser(User user);
        bool IsContainsUser(User user);

        void AddItemToCart(User currentUser, ItemKey itemKey, int quantity);

        /**
         * If this is a user engine, what does it have to do with a cart>
         * Consider:
         * a) https://en.wikipedia.org/wiki/Single_responsibility_principle
         * b) https://en.wikipedia.org/wiki/Interface_segregation_principle
         */
        bool RemoveItemFromCart(User currentUser, ItemKey itemKey);
        void LoadShoppingCart(User currentUser, string fileLocation);
        void SaveShoppingCart(User currentUser, string fileLocation);
    }
}