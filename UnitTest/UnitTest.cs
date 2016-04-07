using System;
using Rowdy.API.PrintAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        const string CLIENTID = "test_XuB25k5ClAMh3qu8jc67neSrWHDQpS1hcZsqxtKZl4oMqdxVudpeA6XRJje";
        const string SECRET = "test_wNmnzIFed6eIXygTrYfbRjPwmDWNfbINnook8PWeR7uYqBzMukE3Ehum7Xa";

        [TestMethod]        
        public void Authentication()
        {
            var printAPIClient = new Client();
            printAPIClient.Authenticate(CLIENTID, SECRET, Client.Environment.TEST);

            Assert.IsNotNull(printAPIClient);            
        }

        [TestMethod]
        public void RequestShippingQuote()
        {
            var printAPIClient = new Client();
            printAPIClient.Authenticate(CLIENTID, SECRET, Client.Environment.TEST);

            var items = new List<Rowdy.API.PrintAPI.Shipping.Item>();
            items.Add(new Rowdy.API.PrintAPI.Shipping.Item { productId = Product.Aluminium30x20cm, quantity = 22 });
            
            var request = new Rowdy.API.PrintAPI.Shipping.ShippingQuoteRequest
            {
                country = Country.Netherlands,
                items = items
            };

            var resp = printAPIClient.RequestShippingQuote(request);

            Assert.IsTrue(resp.payment != 0);            
        }
    }
}
