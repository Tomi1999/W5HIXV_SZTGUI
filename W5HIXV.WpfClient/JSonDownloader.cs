using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace W5HIXV.WpfClient
{
    internal class JSonDownloader
    {
        private string baseURL;
        private HttpClient client;


        public JSonDownloader(string baseURL)
        {
                this.baseURL = baseURL;
                
        }

        public async Task<List<T>> Download<T>(string endpoint)
        {
            try
            {
                using (client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);

                    HttpResponseMessage response = await client.GetAsync(endpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        List<T> result = await response.Content.ReadAsAsync<List<T>>();
                        return result;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return null;
            }
        }
    }

         
    }

