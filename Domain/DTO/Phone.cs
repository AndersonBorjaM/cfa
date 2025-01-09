using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public int ClientId { get; set; }
        public string PhoneType { get; set; }
        public long PhoneNumber { get; set; }

        public virtual Client Client { get; set; }
        
    }
}
