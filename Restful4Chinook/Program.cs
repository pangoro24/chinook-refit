using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using System.IO;
using System.Text.RegularExpressions;
using Restful4Chinook.Models;
using Restful4Chinook.Interfaces;
using Restful4Chinook.Services;

namespace Restful4Chinook
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataConverter.convertToJson(@".txt file", @".txt file", DataConverter.Properties.$$$);
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            
            try
            {
                string url = "http://localhost:3000";
                var client = new HttpClient
                {
                    BaseAddress = new Uri(url),
                    Timeout = new TimeSpan(0, 0, 5),
                    DefaultRequestHeaders = { { "Connection", "close" } }
                };
                IchinookAPI apiResponse = RestService.For<IchinookAPI>(client);
                List<Artist> artists = await apiResponse.GetAllArtists();
                Customer customerSelected = await apiResponse.GetCustomer("frantisekw@jetbrains.com");
                List<Response1> response = await apiResponse.GetAlbumsOfArtist("audio");
                List<Response2> response2 = await apiResponse.GetTracksOfAlbum("califor");

                Console.ReadKey();
            }
            catch (ApiException ex)//Some Server error e.g. 500, 401, 403 etc.
            {
                string errorMessage = "";
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                { errorMessage = ex.Uri + " " + ex.StatusCode; }
                else
                {
                    errorMessage = ex.StatusCode.ToString();
                }
                Debug.WriteLine(errorMessage);
            }
            catch (System.Net.WebException ex)
            {
                Debug.Write(ex.Message);
            }
            catch (Exception ex)// HTTP RequestTimeout, ServiceUnavailable, bad or unknown response
            {
                Debug.Write(ex.Message);
            }
        }

    }


    public class Response1
    {
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
    }


    public class Response2
    {
        public string TrackName { get; set; }
        public string AlbumName { get; set; }
        public long Duration { get; set; } //in seconds
    }

}
