using System.Text.Json.Serialization;

namespace Domain.Request
{
    public class UpdateClientRequest
    {
        [JsonPropertyName("codigo")]
        public int ClientId { get; set; }
        [JsonPropertyName("tipoDocumento")]
        public string DocumentType { get; set; }
        [JsonPropertyName("documento")]
        public long Document { get; set; }
        [JsonPropertyName("fechaNacimiento")]
        public DateTime DateOfBirth { get; set; }
    }
}
