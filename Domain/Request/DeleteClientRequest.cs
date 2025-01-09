using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class DeleteClientRequest
    {
        public string DocumentType { get; set; }
        public long Document { get; set; }
    }
}
