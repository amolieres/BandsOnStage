using Newtonsoft.Json;
using System;
using System.Collections.Generic;

/// <summary>
/// Events list JSON from Bandsintown V2 API
/// </summary>
namespace Bands.Models
{
    public class BitEventsList 
    {
        /// <summary>
        /// array of events
        /// </summary>
        public List<BitEvent> Events
        {
            get;
            set;
        }

    }
}
