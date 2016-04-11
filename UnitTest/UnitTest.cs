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

        internal Client getClient()
        {
            var printAPIClient = new Client();
            printAPIClient.Authenticate(CLIENTID, SECRET, Client.Environment.TEST);

            return printAPIClient;

        }

        [TestMethod]        
        public void Authentication()
        {
            var printAPIClient = getClient();

            Assert.IsNotNull(printAPIClient);            
        }

        [TestMethod]
        public void PlaceOrder()
        {
            var printAPIClient = getClient();
            var items = new List<Rowdy.API.PrintAPI.Order.ItemIn>();
            items.Add(new Rowdy.API.PrintAPI.Order.ItemIn { id = "myitemid1", productId = Product.Aluminium40x30cm, pageCount = 0, quantity = 1, metadata = "Item metadata" });
            items.Add(new Rowdy.API.PrintAPI.Order.ItemIn { id = "myitemid2", productId = Product.HoutBerkenplex40x30cm, pageCount = 0, quantity = 1, metadata = "Item metadata" });
            var order = new Rowdy.API.PrintAPI.Order.OrderRequest
            {
                id = "fooBar",
                email = "fake@email.com",
                items = items,
                shippingAddress = new Address { company = "Rowdy.nl", name = "Rowdy Schwachofer", line1 = "Great Oceandrive 11", postCode = "1000AA", city = "Amsterdam", country = Country.Netherlands },
                metadata = "Order metadata"
            };

            var response = printAPIClient.PostOrder(order);
            Assert.IsNotNull(response);

        }

        [TestMethod]
        public void StatusUpdatesValid()
        {
            var printAPIClient = getClient();

            var response = printAPIClient.GetOrderStatusUpdates(DateTime.Now.AddDays(-2));

            Assert.IsNotNull(response.since);
            
        }

        [TestMethod]
        public void RequestShippingQuote()
        {
            var printAPIClient = getClient();

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
