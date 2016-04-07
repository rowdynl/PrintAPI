using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace Rowdy.API.PrintAPI
{
    /// <summary>
    /// A simple Print API REST client.
    /// 
    /// This small utility simplifies using the REST API from C#. Print API offers a flexible and
    /// secure REST API that lets you print and ship your PDF or image files as a wide range of
    /// products, like hardcover books, softcover books, wood or aluminium prints and much more.
    /// 
    /// Read more at: https://www.printapi.nl/services/rest-api
    /// 
    /// @package Print API
    /// @version 0.0.1
    /// @Author Rowdy Schwachöfer
    /// @copyright 2016 - http://rowdy.nl
    /// </summary>
     public class Client
    {
        const string LIVE_BASE_URI = @"https://live.printapi.nl/v1/";
        const string TEST_BASE_URI = @"https://test.printapi.nl/v1/";
        const string USER_AGENT    = @"Rowdy.nl Print API C# Client v0.0.1";

        public enum Environment {TEST, LIVE};
        private OAuth.OAuthClient client;



        /// <summary>
        /// Call this to obtain an authenticated Print API client
        /// The client ID and secret can be obtained by creating a free Print API account at: https://portal.printapi.nl/test/account/register
        /// </summary>
        /// <param name="clientId">The client ID assigned to your application</param>
        /// <param name="secret">The secret assigned to your application</param>
        /// <param name="environment">The environment you would like to authenticate for: Test (default) or Live</param>
        /// <returns>An authenticated Print API client</returns>
        public void Authenticate(string clientId, string secret, Environment environment = Environment.TEST)
        {
           
            var serverUri = new Uri(environment == Environment.LIVE ? LIVE_BASE_URI : TEST_BASE_URI);

            client = new OAuth.OAuthClient(serverUri);
            client.Authenticate(clientId, secret);
            
                        
        }        

        #region Orders
        public void PostOrder()
        {

        }

        public void GetOrder(string orderId)
        {

        }

        public void GetOrderStatus(string orderId)
        {

        }

        public void GetOrders(int limit, int offset)
        {

        }

        public void GetOrderStatusUpdates(DateTime since)
        {

        }
        #endregion
        #region Checkout
        public void PostCheckout(string orderId)
        {

        }

        public void GetCheckoutStatus(string orderId)
        {

        }
        #endregion
        #region Shipping
        public Shipping.ShippingQuoteResponse RequestShippingQuote(Shipping.ShippingQuoteRequest request)
        {
            var t = client.Post("shipping/quote", JsonConvert.SerializeObject(request));
            t.Wait();            

            return JsonConvert.DeserializeObject<Shipping.ShippingQuoteResponse>(Convert.ToString(t.Result));
        }
        #endregion
        #region Uploads
        public void UploadFile()
        {

        }
        #endregion
        #region Helpers
        //private dynamic 
        #endregion
    }
    
}






    /**
     * Returns formatted parameters for the OAuth token endpoint.
     *
     * @param string $clientId    The client ID credential.
     * @param string $secret      The client secret credential.
     *
     * @return string Formatted parameters for the Print API OAuth token endpoint.
     
    static private function _formatOAuthParameters($clientId, $secret)
    {
        return 'grant_type=client_credentials'
            . '&client_id='.urlencode($clientId)
            . '&client_secret='.urlencode($secret);
    }
    /**
     * Sets common cURL options.
     *
     * @param resource $ch The cURL handle.
     *//*
    static private function _setDefaultCurlOpts($ch)
    {
        curl_setopt($ch, CURLOPT_USERAGENT, self::USER_AGENT);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
        curl_setopt($ch, CURLOPT_FRESH_CONNECT, true);
        curl_setopt($ch, CURLOPT_FOLLOWLOCATION, false);
        curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 15);
        curl_setopt($ch, CURLOPT_TIMEOUT, 60); // note: _request(...) overrides this
    }
    **
     * Throws an exception if the specified cURL request failed.
     *
     * @param resource $ch     The cURL handle.
     * @param mixed    $result The result of curl_exec().
     *
     * @throws PrintApiException         If the cURL request failed.
     * @throws PrintApiResponseException If the API returned an error report.
     *
    static private function _throwExceptionForFailure($ch, $result)
    {
        // Check for cURL errors:
        $errno = curl_errno($ch);
        $error = curl_error($ch);
        if ($errno) {
            throw new PrintApiException('cURL error: '. $error, $errno);
        }
        // Check for API responses indicating failure:
        $statusCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
        if ($statusCode < 200 || $statusCode >= 300) {
            throw new PrintApiResponseException($result, $statusCode);
        }
    }
    // ================
    // Instance members
    // ================
    /** @var string 
    private $baseUri;
    /** @var string  private $token;
    /** @var int  private $timeout = 90;
    /**
     * Private constructor, call {@link authenticate()} to obtain an instance of this class.
     *
     * @param string $baseUri The base URI of the Print API environment.
     * @param string $token   An OAuth access token.
     
    private function __construct($baseUri, $token)
    {
        $this->baseUri = $baseUri;
        $this->token = $token;
    }
    /**
     * Sends an HTTP POST request to Print API.
     *
     * @param string $uri        The destination URI. Can be absolute or relative.
     * @param array  $content    The request body as an associative array.
     * @param array  $parameters The query parameters as an associative array.
     *
     * @return object The decoded API response.
     *
     * @throws PrintApiException         If the HTTP request fails altogether.
     * @throws PrintApiResponseException If the API response indicates an error.
     
    public function post($uri, $content, $parameters = array())
    {
        $uri = $this->_constructApiUri($uri, $parameters);
        $content = $content !== null ? json_encode($content) : null;
        return $this->_request('POST', $uri, $content, 'application/json');
    }
    /**
     * Sends an HTTP GET request to Print API.
     *
     * @param string $uri        The destination URI. Can be absolute or relative.
     * @param array  $parameters The query parameters as an associative array.
     *
     * @return object The decoded API response.
     *
     * @throws PrintApiException         If the HTTP request fails altogether.
     * @throws PrintApiResponseException If the API response indicates an error.
     
    public function get($uri, $parameters = array())
    {
        $uri = $this->_constructApiUri($uri, $parameters);
        return $this->_request('GET', $uri);
    }
    /**
     * Uploads a file to Print API.
     *
     * @param string $uri       The destination URI. Can be absolute or relative.
     * @param string $fileName  The name of the file to upload.
     * @param string $mediaType One of "application/pdf", "image/jpeg" or "image/png".
     *
     * @return object The decoded API response.
     *
     * @throws PrintApiException         If the HTTP request fails altogether.
     * @throws PrintApiResponseException If the API response indicates an error.
     
    public function upload($uri, $fileName, $mediaType)
    {
        $uri = $this->_constructApiUri($uri);
        $content = file_get_contents($fileName);
        return $this->_request('POST', $uri, $content, $mediaType);
    }
    /**
     * Gets the request timeout in seconds. 0 if timeout is disabled.
     *
     * @return int The request timeout in seconds.
     
    public function getTimeout()
    {
        return $this->timeout;
    }
    /**
     * Sets the request timeout in seconds. Specify 0 to disable timeout.
     *
     * @param int $timeout The request timeout in seconds.
     *
     * @throws PrintApiException If the specified timeout is not an integer.
     
    public function setTimeout($timeout)
    {
        if (!is_integer($timeout))
        {
            throw new PrintApiException('Argument $timeout must be an integer.');
        }
        $this->timeout = $timeout;
    }
    // ===============
    // Private helpers
    // ===============
    /**
     * Generates a fully qualified URI for the API.
     *
     * @param string $uri        The destination URI. Can be absolute or relative.
     * @param array  $parameters The query parameters as an associative array.
     *
     * @return string A fully qualified API URI.
     
    private function _constructApiUri($uri, $parameters = array())
    {
        $uri = trim($uri, '/');
        if (strpos($uri, $this->baseUri) === false)
        {
            $uri = $this->baseUri. $uri;
        }
        if (!empty($parameters))
        {
            $uri.= '?'.http_build_query($parameters);
        }
        return $uri;
    }
    /**
     * Sends a custom HTTP request to the API.
     *
     * @param string      $method      The HTTP verb to use for the request.
     * @param string      $uri         The destination URI (absolute).
     * @param mixed       $content     The request body, e.g. a JSON string.
     * @param null|string $contentType The Content-Type HTTP header value.
     *
     * @return object The decoded API response.
     *
     * @throws PrintApiException         If the HTTP request fails altogether.
     * @throws PrintApiResponseException If the API response indicates an error.
     
    private function _request($method, $uri, $content = null, $contentType = null)
    {
        // Create cURL handle:
        $ch = curl_init($uri);
        self::_setDefaultCurlOpts($ch);
        curl_setopt($ch, CURLOPT_CUSTOMREQUEST, $method);
        curl_setopt($ch, CURLOPT_TIMEOUT, $this->timeout);
        // Set HTTP headers:
        $headers = array();
        $headers[] = 'Accept: application/json';
        $headers[] = 'Authorization: Bearer '. $this->token;
        if ($contentType !== null) {
            $headers[] = 'Content-Type: '. $contentType;
        }
        curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
        // Set request body:
        if ($content !== null) {
            curl_setopt($ch, CURLOPT_POSTFIELDS, $content);
        }
        // Execute request:
        $result = curl_exec($ch);
        self::_throwExceptionForFailure($ch, $result);
        curl_close($ch);
        return json_decode($result);
    }
}
*/
