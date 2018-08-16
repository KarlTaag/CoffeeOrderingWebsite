using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace CoffeeOrderingWebsite.Models
{
    [Serializable]
    [DataContract]
    public class DataPoint
    {
        [DataMember]
        [JsonProperty("label")]
        public string Label { get; set; }

        [DataMember]
        [JsonProperty("y")]
        public decimal Value { get; set; }
    }
}