using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Client
    {
        public Client() { }

        public int ClientId { get; set; }
        public string DocumentType { get; set; }
        public long Document { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public string Email { get; set; }


    }
}
