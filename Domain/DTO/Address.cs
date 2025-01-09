using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Address
    {
        public Address()
        {
        }

        public int AddressId { get; set; }
        public int ClientId { get; set; }
        public string AddressText { get; set; }
        public string AddressType { get; set; }

        public virtual Client Client { get; set; }
    }
}
