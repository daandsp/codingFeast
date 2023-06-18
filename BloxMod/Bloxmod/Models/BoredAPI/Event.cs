namespace Bloxmod.Models.BoredAPI
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// An activity.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Gets or sets the description of the queried activity.
        /// </summary>
        [JsonProperty("activity")]
        public string Activity { get; set; }

        /// <summary>
        /// Gets or sets a factor describing how possible an event is to do with zero being the most accessible.
        /// </summary>
        [JsonProperty("accessibility")]
        public double Accessibility { get; set; }

        /// <summary>
        /// Gets or sets the type of the activity.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the number of people that this activity could involve.
        /// </summary>
        [JsonProperty("participants")]
        public long Participants { get; set; }

        /// <summary>
        /// Gets or sets a factor describing the cost of the event with zero being free.
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the link of the activity.
        /// </summary>
        [JsonProperty("link")]
        public Uri Link { get; set; }

        /// <summary>
        /// Gets or sets a unique numeric id.
        /// </summary>
        [JsonProperty("key")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Key { get; set; }
    }

    /// <summary>
    /// An activity.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Converts JSON to <see cref="Event"/>.
        /// </summary>
        /// <param name="json">The JSON to be converted.</param>
        /// <returns>A converted <see cref="Event"/> object.</returns>
        public static Event FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Event>(json, Converter.Settings);
        }
    }
}
