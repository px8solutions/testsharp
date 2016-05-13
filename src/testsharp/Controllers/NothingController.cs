using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testsharp.lib;

namespace testsharp.Controllers
{
    public class NothingController : Controller
    {
        // GET: Nothing
        public ActionResult Nothing()
        {

            Db db = new Db();
            db.Open();

            var reader = db.ExecuteReader("select * from questions where id in (2,3,4)");

            while (reader.Read())
            {
                ViewBag.blah += reader["id"] +"; " ;
            }

            reader.Close();
            db.Close();

            ViewBag.db = testsharp.lib.Db.ConnectionString;
            return View();
        }
    }
}