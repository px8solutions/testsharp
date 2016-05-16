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
        public static string[] QuestionContent = new string[Questions.GetMaxQuestions()];

        // GET: Admin
        public ActionResult Index()
        {
            for (int i = 1; i <= Questions.GetMaxQuestions() - 1; i++)
            {
                QuestionContent[i] = Questions.Load(i).Content;
            }

            return View();
        }
    }
}