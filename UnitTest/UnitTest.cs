using System;
using Rowdy.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAuthentication()
        {
            var printAPIClient = new PrintAPI();
                printAPIClient.Authenticate("test_XuB25k5ClAMh3qu8jc67neSrWHDQpS1hcZsqxtKZl4oMqdxVudpeA6XRJje", 
                                                       "test_wNmnzIFed6eIXygTrYfbRjPwmDWNfbINnook8PWeR7uYqBzMukE3Ehum7Xa", 
                                                       PrintAPI.Environment.TEST);

            Assert.IsNotNull(printAPIClient);
            Assert.IsNotNull(printAPIClient.tokenString());
        }
    }
}
