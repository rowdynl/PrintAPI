using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rowdy.API.OAuth
{
    /// <summary>
    /// 
    /// </summary>
    class OAuthClient
    {
        private Token token;
        private Uri baseUri;
        private string clientId;
        private string clientSecret;
        private string scope;
        private bool authenticationInProgess;

        /// <summary>
        /// Initialize the OAuthClient
        /// </summary>
        /// <param name="uri">The base Uri to wich we communicate</param>
        public OAuthClient(Uri uri)
        {
            baseUri = uri;
        }

        /// <summary>
        /// Authenticate against the server
        /// </summary>
        /// <param name="id">The client id</param>
        /// <param name="secret">The secret key</param>
        /// <returns></returns>
        public Boolean Authenticate(string id, string secret)
        {
            clientId = id;
            clientSecret = secret;

            RefreshToken();

            return (token != null && !String.IsNullOrEmpty(token.TokenString) && token.Expiration > DateTime.Now);
        }

        /// <summary>
        /// Runs an authenticated POST command to the server
        /// </summary>
        /// <param name="path">The path wich we must post to</param>
        /// <param name="content">The content we should post</param>
        /// <param name="contentType">A specific content type. Defaults to JSON</param>
        /// <returns>A dynamic object (mostly JSON) with the results</returns>
        public async Task<dynamic> Post(string path, string content, string contentType = "application/json")
        {
            RefreshToken();

            var client = HttpClientFactory.Create();            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.TokenString);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpContent = new StringContent(content, System.Text.Encoding.UTF8, contentType);
            var httpResponse = await client.PostAsync(new Uri(baseUri, path), httpContent);

            return await httpResponse.Content.ReadAsAsync<dynamic>();
        }

        /// <summary>
        /// Runs a authenticated GET command to the server
        /// </summary>
        /// <param name="path">The path wich we must request</param>
        /// <returns>A dynamic object (mostly JSON) with the results</returns>
        public async Task<dynamic> Get(string path)
        {
            RefreshToken();

            var client = HttpClientFactory.Create();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.TokenString);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpResponse = await client.GetAsync(new Uri(baseUri, path));

            return await httpResponse.Content.ReadAsAsync<dynamic>();
        }

        /// <summary>
        /// Refreshes the authentication token, if necessary (ie token expired, token not set)
        /// </summary>
        internal async void RefreshToken()
        {
            while (authenticationInProgess)
            {
                // HACK Fix this in to something nicer
                // Do something to wait
                System.Diagnostics.Debug.WriteLine("Waiting for Authentication to complete..");
            }

            if (token == null || String.IsNullOrEmpty(token.TokenString) || token.Expiration < DateTime.Now)
            {                
                try
                {
                    // Token needs to be refreshed
                    authenticationInProgess = true;
                    var client = HttpClientFactory.Create();
                    var builder = new UriBuilder(new Uri(baseUri, "oauth"));
                    var credentials = GetCredentialsDictionary();

                    var httpResponse = await client.PostAsync(builder.Uri, new FormUrlEncodedContent(credentials));
                    var response = await httpResponse.Content.ReadAsAsync<dynamic>();
                    token = new Token
                    {
                        TokenString = response.access_token,
                        TokenType = response.token_type,
                        Expiration = DateTime.Now.Add(TimeSpan.FromSeconds((double)response.expires_in))
                    };
                    scope = response.scope;

#if DEBUG
                    // Debugging information
                    System.Diagnostics.Debug.WriteLine(httpResponse.StatusCode);
                    System.Diagnostics.Debug.WriteLine(token.Expiration);
                    System.Diagnostics.Debug.WriteLine(token.TokenString);
                    System.Diagnostics.Debug.WriteLine(scope);
#endif
                }
                catch (Exception e)
                {
#if DEBUG
                    // Debugging information
                    System.Diagnostics.Debug.WriteLine(e.ToString());
#endif
                    throw new PrintAPI.PrintAPIException("Error while authenticating to server", e);
                }
                finally
                {
                    authenticationInProgess = false;
                }
            }
        }
        
        /// <summary>
        /// Internal helper function to create a credential object
        /// </summary>
        /// <returns>A key value pair wich we use to autheticate against the server</returns>
        internal IEnumerable<KeyValuePair<string, string>> GetCredentialsDictionary()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("client_id", clientId);
            dict.Add("client_secret", clientSecret);
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
