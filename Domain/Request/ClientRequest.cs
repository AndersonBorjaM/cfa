using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Request
{
    public class ClientRequest
    {
        [JsonPropertyName("Tipo documento")]
        public string DocumentType { get; set; }
        [JsonPropertyName("Documento")]
        public long Document { get; set; }
        [JsonPropertyName("Nombres")]
        public string Name { get; set; }
        [JsonPropertyName("Apellido 1")]
        public string LastName { get; set; }
        [JsonPropertyName("Apellido 2")]
        public string LastName2 { get; set; }
        [JsonPropertyName("Genero")]
        public string Gender { get; set; }
        [JsonPropertyName("Fecha de nacimiento")]
        public DateTime DateOfBirth { get; set; }
        [JsonPropertyName("Direcciones")]
        public List<AddressRequest> Addresses { get; set; }
        [JsonPropertyName("Teléfonos")]
        public List<PhoneRequest> Phones { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }

    }
}
