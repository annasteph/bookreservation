using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservationBook.Models;
using ReservationBook.Entity;
using Book = ReservationBook.Models.BookInfo;

namespace ReservationBook.Controllers
{
    public class BookController : Controller
    {
        public ActionResult AddBook()
        {
            return View();
        }
        public ActionResult DeleteBook(int id)
        {
            var selected = BookInfo.Con.Book.FirstOrDefault(x => x.BookId == id);
            if (selected != null)
            {

                BookInfo.Con.Book.Remove(selected);

            }
            return RedirectToAction("Books");
        }
        public static void SaveBook(Books bb)
        {
            using (var db = new Database1Entities())
            {
                var selected = db.Books.FirstOrDefault(x => x.BookId == bb.BookId);
                if (selected != null)
                {
                    selected.Title = bb.Title;
                    selected.Author = bb.Author;
                    selected.Quantity = bb.Quantity;


                }
                else
                {

                    db.Books.AddObject(new Entity.Book { Title = bb.Title, Author = bb.Author, Quantity = bb.Quantity });

                }
                db.SaveChanges();
            }

        }
        public ActionResult Books()
        {
            return View(BookInfo.Con.Book);
        }
        public ActionResult EditBook(Books bb)
        {

            return View(BookInfo.Con.Book.FirstOrDefault(x => x.BookId == bb.BookId));
        }

        public ActionResult toHomePage()
        {
            return RedirectToAction("HomePage", "Home");
        }
    }
}
