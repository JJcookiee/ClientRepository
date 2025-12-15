using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRepository
{
    internal class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Cat> Categories { get; set; }

    }
}
