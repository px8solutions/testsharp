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
        public static string[] QuestionContent = new string[Question.GetMaxQuestions()];

        // GET: Admin
        public ActionResult Index()
        {
            for (int i = 1; i <= Question.GetMaxQuestions() - 1; i++)
            {
                QuestionContent[i] = Question.Load(i).Content;
            }

            return View();
        }
    }
}