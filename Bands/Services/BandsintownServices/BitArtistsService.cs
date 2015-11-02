using Bands.Extensions;
using Bands.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Bands.Services.BandsintownServices
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SettingsService
    public class BitArtistsService
    {
        private static string APP_ID = "BANDS_UNIVERSALLWINDOWS10";
        private static string BIT_API_VERSION = "2.0";


        public async Task<BitArtist> GetArtistAsync(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (query.IsBlank())
            {
                throw new ArgumentException("BandsInTown query could not be empty.", nameof(query));
            }

            //string queryEncoded = WebUtility.UrlEncode(query);
            string queryEncoded = query.Trim();
            string url = string.Format("http://api.bandsintown.com/artists/{0}.json?api_version={1}&app_id={2}", queryEncoded, BIT_API_VERSION, APP_ID);

            Debug.WriteLine("BandsintownArtistSearch>Request : " + url);

            string webresponse;
            using (HttpClient client = new HttpClient())
            {

                //client.DefaultRequestHeaders.TryAppendWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10240");
                webresponse = await client.GetStringAsync(new Uri(url));
                Debug.WriteLine("BandsintownArtistSearch>result : " + webresponse);
            }

            return JsonConvert.DeserializeObject<BitArtist>(webresponse);
        }
    }
}

