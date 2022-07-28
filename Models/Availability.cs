using System.Text.Json.Serialization;

namespace cam_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Availability
    {
        Available = 1,
        Assigned = 2,
        Damaged = 3
    }
}