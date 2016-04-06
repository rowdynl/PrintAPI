using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rowdy.API.OAuth
{
    class OAuthClient
    {
        private Token _token;
        private Uri _baseUri;
        private string _clientId;
        private string _clientSecret;
        private string _scope;


        public Boolean Authorize(Uri baseUri, string clientId, string clientSecret)
        {
            _baseUri = baseUri;
            _clientId = clientId;
            _clientSecret = clientSecret;

            RefreshToken();

            return true;
        }

        internal async void RefreshToken()
        {

            var client = HttpClientFactory.Create();
            var builder = new UriBuilder(new Uri(_baseUri, "oauth"));
            var credentials = GetCredentialsDictionary();
            try
            {
                var httpResponse = await client.PostAsync(builder.Uri, new FormUrlEncodedContent(credentials));

                //if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var response = await httpResponse.Content.ReadAsAsync<dynamic>();
                    _token = new Token
                    {
                        TokenString = response.access_token,
                        TokenType = response.token_type,
                        Expiration = DateTime.Now.Add(TimeSpan.FromSeconds((double)response.expires_in))
                    };
                    _scope = response.scope;
                }
                System.Diagnostics.Debug.WriteLine(httpResponse.StatusCode);
                System.Diagnostics.Debug.WriteLine(HttpStatusCode.OK);
                System.Diagnostics.Debug.WriteLine(_token.Expiration);
                System.Diagnostics.Debug.WriteLine(_token.TokenString);
                System.Diagnostics.Debug.WriteLine(_scope);
                //throw new Exception("HTTP error occured - " + httpResponse.StatusCode);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }

            

        }

        public string tokenstring()
        {
            return "";// _token.TokenString != null ? _token.TokenString : "";
        }

        internal IEnumerable<KeyValuePair<string, string>> GetCredentialsDictionary()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("client_id", _clientId);
            dict.Add("client_secret", _clientSecret);
            dict.Add("grant_type", "client_credentials");
            return dict;
        }
    }
    /// <summary>
    /// This holds token information for the OAuth client
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Expiration datetime
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Type of the token. This will mostly be 'bearer'
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// The token
        /// </summary>
        public string TokenString { get; set; }
    }
}
