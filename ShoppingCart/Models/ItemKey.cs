using System;

namespace ShoppingCart.Models
{
    /*
     * The name of this class does not help clear up what its purpose is- consider giving types clear and precise names.
     * This will help you create a better, more scalable code base.
    */
    [Serializable]
    public class ItemKey : IEquatable<ItemKey>
    {
        public int Quantity { get; internal set; }
        public string ProductName { get; internal set; }
        public int ItemId { get; internal set; }

        /*Back in the 80's - storage space was limited so developers used shorthand for property names
          It is considered as a bad practice today since it hinders readability.
             */
        public string UnitQty { get; internal set; }

        /* Mixing storage (File Name) with your model is rarely a good idea
         * Consider what happens when you change the manner in which data is persisted?
         * Your model must be completely decoupled from storage specifics
         *   
         * Consider : https://en.wikipedia.org/wiki/Data_access_layer
         */
        public string ImageFilePath { get; internal set; }

        public override bool Equals(object obj)
        {
            var myItem = obj as ItemKey;
            return !ReferenceEquals(myItem, null) && (ItemId== myItem.ItemId); 
        }
        public override int GetHashCode()
        {
            //Only use immutable properties in the GetHashCode method, otherwise your code may exhibit inconsistent behavior when caching such a type in a dictionary.
            var id = ItemId;
            return id.GetHashCode();
        }
        public bool Equals(ItemKey myItem)
        {
            //Check whether myItem is null or not first. Tracking NullReference Exceptions can be hard in complex methods.
            //It is also not always reproducable - so you better prevent these in advance.
            return string.Equals(ItemId, myItem.ItemId);
        }
    }
}