using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rowdy.API.PrintAPI.Checkout
{
    /// <summary>
    /// Information for the Print API checkout service
    /// </summary>
    public class CheckoutRequest
    {
        /// <summary>
        /// The URL to which your user should be returned
        /// </summary>
        private string _returnUrl;
        public string returnUrl
        {
            get { return _returnUrl; }
            set { _returnUrl = value.TrimMaxLength(512); }
        }

        /// <summary>
        /// The billing address
        /// </summary>
        public Address billingAddress { get; set; }
    }

    /// <summary>
    /// The Print API checkout setup
    /// </summary>
    public class CheckoutResponse
    {
        /// <summary>
        /// The payment status
        /// </summary>
        public PaymentStatus status { get; set; }

        /// <summary>
        /// The total payment due
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// The URL of the payment screen
        /// </summary>
        public string paymentUrl { get; set; }

        /// <summary>
        /// The URL to which your user will be returned
        /// </summary>
        public string returnUrl { get; set; }

        /// <summary>
        /// The billing address
        /// </summary>
        public Address billingAddress { get; set; }

    }
}
