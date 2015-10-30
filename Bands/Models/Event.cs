using Newtonsoft.Json;
using System;

/// <summary>
/// Event JSON from Bandsintown V2 API
/// </summary>
namespace Bands.Models
{
    [JsonObject]
    public class Event
    {

        /// <summary>
        /// bandsintown.com event id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// event title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// datetime of the event expressed in ISO 8601 format with no timezone.
        /// YYYY-MM-DDThh:mm:ss
        /// </summary>
        [JsonProperty("datetime")]
        public string Datetime { get; set; }

        /// <summary>
        /// readable location string for display purposes
        /// City, State(within US)
        /// City, Country(outside US)
        /// </summary>
        [JsonProperty("formatted_datetime")]
        public string FormattedDatetime { get; set; }

        /// <summary>
        /// direct link to the ticket seller
        /// </summary>
        [JsonProperty("ticket_url")]
        public string TicketUrl { get; set; }


        /// <summary>
        /// direct link to the ticket seller
        /// </summary>
        [JsonProperty("ticket_url")]
        public string TicketUrl { get; set; }




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
