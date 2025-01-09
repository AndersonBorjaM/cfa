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
        [JsonPropertyName("Tipo dirección")]
        public string AddressType { get; set; }
        [JsonPropertyName("Dirección")]
        public string AddressText { get; set; }

    }
}
