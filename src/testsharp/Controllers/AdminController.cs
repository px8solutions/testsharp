using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testsharp.lib;

namespace testsharp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            for (int i = 1; i <= 9; i++)
            {
                switch(i)
                {
                    case 1:
                        ViewBag.One = Questions.Load(i).Content;
                        break;
                    case 2:
                        ViewBag.Two = Questions.Load(i).Content;
                        break;
                    case 3:
                        ViewBag.Three = Questions.Load(i).Content;
                        break;
                    case 4:
                        ViewBag.Four = Questions.Load(i).Content;
                        break;
                    case 5:
                        ViewBag.Five = Questions.Load(i).Content;
                        break;
                    case 6:
                        ViewBag.Six = Questions.Load(i).Content;
                        break;
                    case 7:
                        ViewBag.Seven = Questions.Load(i).Content;
                        break;
                    case 8:
                        ViewBag.Eigh = Questions.Load(i).Content;
                        break;
                    case 9:
                        ViewBag.Nine = Questions.Load(i).Content;
                        break;
                    case 10:
                        ViewBag.Ten = Questions.Load(i).Content;
                        break;
                }
                
            }

            return View();
        }
    }
}