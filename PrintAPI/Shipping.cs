using System.Collections.Generic;

namespace Rowdy.API.PrintAPI.Shipping
{
    /// <summary>
    /// Shipping info for an item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The product ID
        /// </summary>
        public string productId { get; set; }

        /// <summary>
        /// The number of pages, if applicable
        /// </summary>
        public int pageCount { get; set; }

        /// <summary>
        /// The quantity of the item
        /// </summary>
        public int quantity { get; set; }
    }


    /// <summary>
    /// A request for an shipping quote
    /// </summary>
    public class ShippingQuoteRequest
    {
        /// <summary>
        /// ISO 3166-2:US state code
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// ISO 3166-1-alpha-2 country code
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// The item(s) you want to ship
        /// </summary>
        public List<Item> items { get; set; }
    }
        

    /// <summary>
    /// A response that will be received with a quote for shipping
    /// </summary>
    public class ShippingQuoteResponse
    {
        /// <summary>
        /// The shipping cost you will be charged, excluding tax
        /// </summary>
        public decimal shipping { get; set; }

        /// <summary>
        /// The handling cost you will be charged, excluding tax
        /// </summary>
        public decimal handling { get; set; }

        /// <summary>
        /// The amount charged on the payment screen, including tax
        /// </summary>
        public decimal payment { get; set; }

        /// <summary>
        /// The tax rate, either 0.06 or 0.21
        /// </summary>
        public decimal taxrate { get; set; }

        /// <summary>
        /// The shipping method most likely to be used
        /// </summary>
        public string method { get; set; }
    }
}
