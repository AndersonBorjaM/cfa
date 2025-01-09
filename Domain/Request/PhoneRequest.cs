using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class PhoneRequest
    {
        [JsonPropertyName("Tipo contacto")]
        public string PhoneType { get; set; }
        [JsonPropertyName("Número de telefono")]
        public long PhoneNumber { get; set; }
    }
}
