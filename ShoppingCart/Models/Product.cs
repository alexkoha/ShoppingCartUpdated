namespace ShoppingCart.Models
{
    public class Product
    {
        public string ProductName { get; internal set; }
        public string UnitQty { get; internal set; }
        public string Quantity { get; internal set; }

        /*
         "Each item can potentially have a different price in every store, this is dictated by the XML Schema of the files.
         This means that this model does not sufficiently depict the schema, since it associated the price of an item with a chain"

            Is what I thought initially, until I understood that when you say "Chain" you mean your "Chain" model.
            Which actually describes a store in a sub chain in a chain.

            Do you see the chaos that bad naming can cause?
             */
        public double ItemPrice { get; internal set; }

        //ChainId?
        public string CaindId { get; internal set; }
        public string ItemCode { get; internal set; }

    }
}
