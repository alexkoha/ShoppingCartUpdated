using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ShoppingCart.Models
{
    //Very good design
    [Serializable]
    public class User : IEquatable<User> 
    {
        public User()
        {
            ItemsInCart = new List<ItemKey>();
        }

        public string Name { get; internal set; }
        public string UserId { get; internal set; }
        public ICollection<ItemKey> ItemsInCart { get; internal set; }
    
        //Don't you think that user id would be much stronger as an identity?
        public bool Equals(User user)
        {
            return (Name == user.Name);
        }

    }
}