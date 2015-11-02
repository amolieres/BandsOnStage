using Newtonsoft.Json;
using System;

/// <summary>
/// Artist JSON from Bandsintown V2 API
/// </summary>
namespace Bands.Models
{
    [JsonObject]
    public class BitArtist
    {

        /// <summary>
        /// artist name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// artist image url
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// artist thumbnail image url
        /// </summary>
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        /// <summary>
        /// url to the artist's tour dates page on facebook 
        /// </summary>
        [JsonProperty("facebook_tour_dates_url")]
        public string FacebookTourDatesUrl { get; set; }

        /// <summary>
        /// music brainz id or null if not available
        /// </summary>
        [JsonProperty("mbid")]
        public string MusicBrainzId { get; set; }

        /// <summary>
        /// number of upcoming events
        /// </summary>
        [JsonProperty("upcoming_events_count")]
        public int UpcomingEventsCount { get; set; }

        /// <summary>
        /// number of trackers
        /// </summary>
        [JsonProperty("tracker_count")]
        public int TrackersCount { get; set; }


    }
}
