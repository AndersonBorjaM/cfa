using System.Text.Json.Serialization;

namespace Domain.Request
{
    public class ClientRequest
    {
        [JsonPropertyName("tipoDocumento")]
        public string DocumentType { get; set; }
        [JsonPropertyName("documento")]
        public long Document { get; set; }
        [JsonPropertyName("nombres")]
        public string Name { get; set; }
        [JsonPropertyName("apellido1")]
        public string LastName { get; set; }
        [JsonPropertyName("apellido2")]
        public string LastName2 { get; set; }
        [JsonPropertyName("genero")]
        public string Gender { get; set; }
        [JsonPropertyName("fechaNacimiento")]
        public DateTime DateOfBirth { get; set; }
        [JsonPropertyName("direcciones")]
        public List<AddressRequest> Addresses { get; set; }
        [JsonPropertyName("telefonos")]
        public List<PhoneRequest> Phones { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }

    }
}
