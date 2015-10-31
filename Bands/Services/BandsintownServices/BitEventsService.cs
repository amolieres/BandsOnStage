using Bands.Extensions;
using Bands.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Bands.Services.BandsintownServices
{


    public class BitEventsService
    {
        private static string APP_ID = "BANDS_UNIVERSALLWINDOWS10";
        private static string BIT_API_VERSION = "2.0";


        public async Task<ObservableCollection<BitEvent>> GetEventsForArtistAsync(BitArtist query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (query.Name.IsBlank())
            {
                throw new ArgumentException("BandsInTown band name query could not be empty.", nameof(query));
            }

            string queryEncoded = WebUtility.UrlEncode(query.Name);
            string url = string.Format("http://api.bandsintown.com/artists/{0}/events.json?api_version={1}&app_id={2}",queryEncoded, BIT_API_VERSION, APP_ID);

            Debug.WriteLine("GetEventsForArtistAsync>Request : " + url);

            string webresponse;
            using (HttpClient client = new HttpClient())
            {

                //client.DefaultRequestHeaders.TryAppendWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10240");
                webresponse = await client.GetStringAsync(new Uri(url));
                Debug.WriteLine("GetEventsForArtistAsync>result : " + webresponse);
            }


            //TODO : Decompose
            return new ObservableCollection<BitEvent>(JsonConvert.DeserializeObject<List<BitEvent>>(webresponse, new JsonSerializerSettings{Error = HandleDeserializationError}));

        }


        public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
            Debug.WriteLine(currentError);
        }
    }
}

