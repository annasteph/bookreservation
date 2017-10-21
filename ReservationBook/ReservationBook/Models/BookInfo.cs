using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationBook.Models
{
    public class BookInfo
    {
         public List<Account> Account { get; set; }
        public List<Books> Book { get; set; }
        //public List<BookReservation> BookReservation { get; set; }
        public List<BookReservationInfo> BookReservationInfo { get; set; }
         public static BookInfo Con
        {
            get
            {
                if (_BookInfo == null)
                {
                    _BookInfo = new BookInfo();
                }
                return _BookInfo;
            }
        }

        public BookInfo()
        {
            Account = new List<Account>();
            Book = new List<Books>();
           // BookReservation = new List<BookReservation>();
            BookReservationInfo = new List<Models.BookReservationInfo>();
        }
    
public static BookInfo _BookInfo { get; set; }}

    public class BookReservationInfo
    {
        public int Id { get; set; }
        public string BorrowersName { get; set; }
        public string BookName { get; set; }
        public int? Qty { get; set; }
    }
}

