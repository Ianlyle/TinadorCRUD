using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinadorCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<Table_1>();
            using (var db = new CRUDEntities())
            {
                list = db.Table_1.ToList();
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Table_1 u)
        {
            using (var db = new CRUDEntities())
            {
                var newUser = new Table_1();
                newUser.username = u.username;
                newUser.password = u.password;

                db.Table_1.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"Added {newUser.username} Successfuly!";

            }

            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var u = new Table_1();
            using (var db = new CRUDEntities())
            {
                u = db.Table_1.Find(id);
            }
            return View(u);
        }
        [HttpPost]
        public ActionResult Update(Table_1 u)
        {
            using (var db = new CRUDEntities())
            {
                var newUser = db.Table_1.Find(u.id);
                newUser.username = u.username;
                newUser.password = u.password;

                db.SaveChanges();

                TempData["msg"] = $"Updated {newUser.username} Successfuly!";

            }

            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var u = new Table_1();
            using (var db = new CRUDEntities())
            {
                u = db.Table_1.Find(id);
                db.Table_1.Remove(u);
                db.SaveChanges();

                TempData["msg"] = $"Deleted {u.username} Succesfuly!";
            }
            return RedirectToAction("Index");
        }
    }

}