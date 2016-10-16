namespace ShoppingCart.Models
{
    /*Naming a class is very important since it helps you understand your code better and prevent bugs: a better name for this class
     * A better name for this class would be ChainItem.
     */
    public class Item
    {
        public string ChainId { get; internal set; }
        public string ItemCode { get; internal set; }
        public string ProductName { get; internal set; }
    }
}