using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservationBook.Models;
using ReservationBook.Entity;
using Account = ReservationBook.Models.Account;

namespace ReservationBook.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index(string search = "", string id = "")
        {

            return View();
        }

        public ActionResult Add(Account acc)
        {
            Save(acc);
            if (acc.Name != null)
            {
                return RedirectToAction("Users");

            }
            return View();
        }
        public static void Save(Account acc)
        {
            using (var db = new Database1Entities())
            {
                var selected = db.Accounts.FirstOrDefault(x => x.Id == acc.Id);
                if (selected != null)
                {
                    selected.Name = acc.Name;
                    selected.Address = acc.Address;
                    selected.Age = acc.Age;
                    selected.Username = acc.Username;
                    selected.Password = acc.Password;

                }
                else
                {

                    db.Accounts.AddObject(new Entity.Account { Name = acc.Name, Age = acc.Age, Username = acc.Username, Password = acc.Password, Address = acc.Address });

                }
                db.SaveChanges();
            }


        }
        public ActionResult Edit(Account acc)
        {



            return View(Information.Context.Accounts.FirstOrDefault(x => x.Id == acc.Id));
        }
        public ActionResult Delete(int id)
        {
            var selected = Information.Context.Accounts.FirstOrDefault(x => x.Id == id);
            if (selected != null)
            {

                Information.Context.Accounts.Remove(selected);

            }
            return RedirectToAction("Users");
        }
        public ActionResult Search(string search)
        {
            return RedirectToAction("Users", "Home", new { search, id = search });
        }

        public ActionResult Login(string username, string password)
        {

            var selectedUser = Information.Context.Accounts.FirstOrDefault(x => x.Username == username && x.Password == password);


            if (selectedUser != null)
            {
                return RedirectToAction("Homepage", "Home");
            }
            if (password != null && username != null)
            {
                ViewBag.Error = "Error message";
            }

            return View();
        }
        public ActionResult Logout()
        {
            return View("Login");
        }


        public ActionResult Users(string search = "", string id = "")
        {

            if (search != "")
            {
                return View(Information.Context.Accounts.Where(a => a.Name == search));
            }

            return View(Information.Context.Accounts);
        }
        public ActionResult toHomePage()
        {
            return RedirectToAction("Homepage", "Home");
        }
    }
}
