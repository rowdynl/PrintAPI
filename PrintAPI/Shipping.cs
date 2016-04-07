using System.Collections.Generic;

namespace Rowdy.API.PrintAPI.Shipping
{    
    public class Item : ItemBase
    {
        public string productId { get; set; }
        public int pageCount { get; set; }
        public int quantity { get; set; }
    }

    public class ShippingQuoteRequest : RequestBase
    {
        public string state { get; set; }
        public string country { get; set; }
        public List<Item> items { get; set; }
    }
        
    public class ShippingQuoteResponse : ResponseBase
    {
        public decimal shipping { get; set; }
        public decimal handling { get; set; }
        public decimal payment { get; set; }
        public decimal taxrate { get; set; }
        public string method { get; set; }
    }


}
