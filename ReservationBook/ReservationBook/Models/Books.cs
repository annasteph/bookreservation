using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationBook.Models
{
    public class Books
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? Quantity { get; set; }
    }
}