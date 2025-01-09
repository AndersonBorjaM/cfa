using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class DeleteClientRequest
    {
        [JsonPropertyName("tipoDocumento")]
        public string DocumentType { get; set; }
        [JsonPropertyName("documento")]
        public long Document { get; set; }
    }
}
