using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testsharp.lib;
// Hey it's Destin. Isn't that cool?
namespace testsharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Question myQuestion = new Question(8);
            myQuestion.Content = "wubwubwub";
            Response myResponse = new Response(16);
            Field myField = new Field(1);

            ViewBag.myQuestion = myQuestion.Content;
            ViewBag.myQuestio = myQuestion.Category.Description;
            ViewBag.myQuest = myQuestion.Parent.Content;
            ViewBag.myResponse = myResponse.Content;
            ViewBag.MyField = myField.Response.Content;

            DropdownValue myDropdownValue = new DropdownValue(0);

            ViewBag.myDropdownValue = myDropdownValue.Content;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            ViewBag.Yolo = form["id"].ToString();
            ViewBag.rofl = form["content"].ToString();
            return View();

        }

    }
}