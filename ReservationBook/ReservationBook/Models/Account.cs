using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationBook.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}