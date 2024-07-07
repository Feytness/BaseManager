using BaseManagerUI.Models.Enums;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace BaseManager.Models
{
    internal class Resource
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceType Name { get; set; }
        public double Quantity { get; set; }

        public Resource(ResourceType rtype, double qty)
        {
            Name = rtype;
            Quantity = qty;
        }
    }
}