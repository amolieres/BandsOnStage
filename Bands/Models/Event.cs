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
        /// type of tickets available (presale, tickets, etc), only set when tickets are available.
        /// </summary>
        [JsonProperty("ticket_type")]
        public string TicketType { get; set; }


        /// <summary>
        /// tickets available/unavailable for the event
        /// </summary>
        [JsonProperty("ticket_status")]
        public string TicketStatus { get; set; }


        /// <summary>
        /// on sale datetime for event tickets expressed in ISO 8601 format with no timezone, or null if unknown
        /// </summary>
        [JsonProperty("on_sale_datetime")]
        public string OnSaleDatetime { get; set; }


        /// <summary>
        /// additional details for the event
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }


        //TODO : Add artists and venue informations


    }
}
