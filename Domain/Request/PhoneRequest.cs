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
        [JsonPropertyName("tipoContacto")]
        public string PhoneType { get; set; }
        [JsonPropertyName("numeroTelefono")]
        public long PhoneNumber { get; set; }
    }
}
