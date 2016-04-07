using System;
using System.Collections.Generic;

namespace Rowdy.API.PrintAPI.Order
{
    /// <summary>
    /// The order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The order ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The current order status
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// The tracking URL provided by our shipping partner, if any
        /// </summary>
        public string trackingUrl { get; set; }

        /// <summary>
        /// The date/time the order was created
        /// </summary>
        public DateTime dateTime { get; set; }

        /// <summary>
        /// The e-mail address you supplied with the order
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// The Print API checkout info
        /// </summary>
        public CheckoutInfo checkout { get; set; }

        /// <summary>
        /// The items in the order
        /// </summary>
        public List<Item> items { get; set; }

        /// <summary>
        /// The address to which the order will be shipped
        /// </summary>
        public Address shippingAddress { get; set; }

        /// <summary>
        /// The metadata stored with the order
        /// </summary>
        public string metadata { get; set; }
    }


    /// <summary>
    /// Checkout info for an order
    /// </summary>
    public class CheckoutInfo
    {
        /// <summary>
        /// The checkout amount
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// The current payment status
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// The URL of the payment screen
        /// </summary>
        public string paymentUrl { get; set; }

        /// <summary>
        /// The URL of the checkout setup
        /// </summary>
        public string setupUrl { get; set; }
    }


    /// <summary>
    /// Details of a single item of an order
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The item ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The product ID
        /// </summary>
        public string productId { get; set; }

        /// <summary>
        /// The number of pages in files
        /// </summary>
        public int pageCount { get; set; }

        /// <summary>
        /// The quantity of the item
        /// </summary>
        public int quantity { get; set; }        

        /// <summary>
        /// The metadata stored with the order item
        /// </summary>
        public string metadata { get; set; }
    }

    public class ItemIn : Item
    {
        /// <summary>
        /// The files associated with the item
        /// </summary>
        public Files files { get; set; }

        /// <summary>
        /// Product options for the item
        /// </summary>
        public List<OptionOut> options { get; set; }
    }

    public class ItemOut : Item
    {
        /// <summary>
        /// The files associated with the item
        /// </summary>
        public FileIn files { get; set; }

        /// <summary>
        /// Product options for the item
        /// </summary>
        public List<Option> options { get; set; }
    }


    /// <summary>
    /// An option for an item
    /// </summary>
    public class Option
    {
        /// <summary>
        /// The ID of the option
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The value of the option
        /// </summary>
        public string value { get; set; }
    }

    public class OptionOut : Option
    {
        /// <summary>
        /// The user-friendly name of the option
        /// </summary>
        public string name { get; set; }
    }


    /// <summary>
    /// A list of files associated with an item
    /// </summary>
    public class Files
    {
        /// <summary>
        /// The content file
        /// </summary>
        public FileOut content { get; set; }

        /// <summary>
        /// The cover file, if the product requires one
        /// </summary>
        public FileOut cover { get; set; }
    }


    /// <summary>
    /// A list of files that Print API should auto-download. These files must be publicly available on your webserver. Print API also offers an upload endpoint, in case that's not an option. You can find out which files a product requires from the products list.
    /// </summary>
    public class FileIn
    {
        /// <summary>
        /// The URL of the content file
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// The URL of the cover file
        /// </summary>
        public string cover { get; set; }
    }


    /// <summary>
    /// Details of a single file of an item (Out, response from server)
    /// </summary>
    public class FileOut
    {
        /// <summary>
        /// The current status of the file
        /// </summary>
        public FileStatus status { get; set; }

        /// <summary>
        /// The URL from which the file will be downloaded, if the file is scheduled for auto-download
        /// </summary>
        public string downloadUrl { get; set; }

        /// <summary>
        /// The URL to which to upload the file, if the file is not scheduled for auto-download
        /// </summary>
        public string uploadUrl { get; set; }
    }


    /// <summary>
    /// The status of a file on an order
    /// </summary>
    public class FileStatus
    {
        /// <summary>
        /// The file will be downloaded soon
        /// </summary>
        public const string DownloadPending = "DownloadPending";

        /// <summary>
        /// The file is being downloaded
        /// </summary>
        public const string DownloadInProgress = "DownloadInProgress";

        /// <summary>
        /// The file download failed, but will be retried
        /// </summary>
        public const string DownloadRetryPending = "DownloadRetryPending";

        /// <summary>
        /// The file download failed. You'll be e-mailed details
        /// </summary>
        public const string DownloadFailed = "DownloadFailed";

        /// <summary>
        /// The API is awaiting a valid file upload
        /// </summary>
        public const string AwaitingUpload = "AwaitingUpload";

        /// <summary>
        /// The file is being uploaded
        /// </summary>
        public const string UploadInProgress = "UploadInProgress";

        /// <summary>
        /// The file download or upload succeeded
        /// </summary>
        public const string Accepted = "Accepted";

        /// <summary>
        /// The file download or upload was cancelled
        /// </summary>
        public const string Cancelled = "Cancelled";

    }
    

    /// <summary>
    /// The status of an order
    /// </summary>
    public class OrderStatus
    {
        /// <summary>
        /// The order is awaiting files and/or payment
        /// </summary>
        public const string Created = "Created";
        /// <summary>
        /// The order is being processed
        /// </summary>
        public const string Processing = "Processing";
        /// <summary>
        /// The order has been shipped
        /// </summary>
        public const string Shipped = "Shipped";
        /// <summary>
        /// The order has been cancelled
        /// </summary>
        public const string Cancelled = "Cancelled";
    }

    /// <summary>
    /// The status of a Print API checkout payment
    /// </summary>
    public class PaymentStatus
    {
        /// <summary>
        /// The payment is open
        /// </summary>
        public const string Open = "Open";
        /// <summary>
        /// The payment failed
        /// </summary>
        public const string Failed = "Failed";
        /// <summary>
        /// The payment succeeded
        /// </summary>
        public const string Successful = "Successful";
        /// <summary>
        /// The payment was cancelled
        /// </summary>
        public const string Cancelled = "Cancelled";
    }
}
