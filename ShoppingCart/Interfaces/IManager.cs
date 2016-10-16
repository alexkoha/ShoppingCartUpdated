using System;
using ShoppingCart.EventsArgs;
using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    /*Manager of what, exactly? naming is crucial to the understanding of others (and yourself) of your code.
     * how about ICartManager?
     */
    public interface IManager
    {
        event EventHandler<ProductCartListUpdatedArgs> ProductCartListUpdated;
        event EventHandler<CurrentUserEventArgs> CurrentUserUpdated;
        event EventHandler<UsersListUpdatedArgs> UsersListUpdated;
        event EventHandler<CartPriceUpdatedArgs> CartPriceUpdated;

        void AddItemToCart(ItemKey itemKey, int quantity);
        bool RemoveItemFromCart(ItemKey itemKey);

        /*Events are a good practice, but don't you think that a method which is called calculate is expected to return some value?
         * I would Expect a Task<double> as a return type here
        */
        void CalculateCart();

        /*Decouple storage from business logic
         * Consider: https://en.wikipedia.org/wiki/Data_access_layer
         */
        void SaveShoppingCart(string file);

        /*Decouple storage from business logic
         * Consider: https://en.wikipedia.org/wiki/Data_access_layer
        */
        void LoadShoppingCart(string file);

        /*
         * I would place this method in a different interface which receives some Cart model and outputs it to the file
         * Consider:
         * a) https://en.wikipedia.org/wiki/Single_responsibility_principle
         * b) https://en.wikipedia.org/wiki/Interface_segregation_principle
         */

        void CreatExcelFileShoppingCart(string fileName); //<=======


        /*
            Doesn't this belong to the User engine?
            Consider:
         * a) https://en.wikipedia.org/wiki/Single_responsibility_principle
         * b) https://en.wikipedia.org/wiki/Interface_segregation_principle
         */
        bool SignUpNewUser(string name);
        void ChooseCurrentUser(User user);
        bool RemoveUser(User user);
    }
}