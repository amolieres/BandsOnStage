using Newtonsoft.Json;

/// <summary>
/// Venue JSON from Bandsintown V2 API
/// </summary>
namespace Bands.Models
{
    [JsonObject]
    public class BitVenue
    {
        /// <summary>
        /// venue name 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// venue city name
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// venue region name
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        ///  venue country name 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// venue latitude
        /// </summary>
        [JsonProperty("latitude")]
        public long Latitude { get; set; }

        /// <summary>
        /// venue longitude 
        /// </summary>
        [JsonProperty("longitude")]
        public string Longitude { get; set; }


    }
}