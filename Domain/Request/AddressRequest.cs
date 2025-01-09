using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class AddressRequest
    {
        [JsonPropertyName("tipoDireccion")]
        public string AddressType { get; set; }
        [JsonPropertyName("direccion")]
        public string AddressText { get; set; }

    }
}
