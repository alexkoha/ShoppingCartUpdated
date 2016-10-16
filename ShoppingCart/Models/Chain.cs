using System;

namespace ShoppingCart.Models
{
    public class Chain : IEquatable<Chain>
    {
        /*Way to go on making the chain object imutable, it is a good practice, but makes for nasty code
         * You can achieve the same by returning the class as an interface whose properties expose only getters.
        */
        public Chain(string id,string chainId, string chainName, string chainXmlFileName, string storeId, string subchainId)
        {
            Id = id;
            ChainId = chainId;
            ChainName = chainName;
            ChainXmlFileName = chainXmlFileName;
            StoreId = storeId;
            SubchainId = subchainId;
        }

        public string Id { get; }
        public string ChainId { get; }
        public string SubchainId { get; }
        public string ChainName { get; }

        /* Mixing storage (Xml File Name) with your model is rarely a good idea
         * Consider what happens when you change the manner in which data is persisted?
         * Your model must be completely decoupled from storage specifics
         * 
         * Consider : https://en.wikipedia.org/wiki/Data_access_layer
         */
        public string ChainXmlFileName { get; }

        /* "It is unclear to me why a model of type chain has a single store id
         * The relationship between chain and store is that one chain has many sub chains and each subchain may have a store.
         * Your model does not describe this relationship properly."
         * 
         * Is what I thought until I understood that When you say "Chain" you actually mean "Store in a subchain in a chain"
         * Consider the names of your types, it is crucial that they accurately describe the domain which your application models
         * 
         * Consider: https://en.wikipedia.org/wiki/Domain-driven_design
         */
        public string StoreId { get; }

        public bool Equals(Chain other)
        {
            //Null reference checking?
            /* I don't think that having a non-deterministic ( with more than one outcome) equality method is a good idea. 
             * This means that your model is insufficiently designed.
            */
            return (ChainId == other.ChainId || Id==other.Id);
        }
        public override bool Equals(object obj)
        {
            var other = obj as Chain;
            /**
             * This Duplicates the Equals method above.
             * Consider: https://en.wikipedia.org/wiki/Don%27t_repeat_yourself
             */
            return other != null && (ChainId == other.ChainId || Id == other.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}