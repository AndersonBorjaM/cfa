using System.Text.Json.Serialization;

namespace Domain.DTO
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public int ClientId { get; set; }
        public string PhoneType { get; set; }
        public long PhoneNumber { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }
        
    }
}
