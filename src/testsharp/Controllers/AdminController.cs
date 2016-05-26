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
        public static int[] QuestionID = new int[Question.GetMaxQuestions()];

        // GET: Admin
        public ActionResult Index(FormCollection Form)
        {
            for (int i = 1; i <= Question.GetMaxQuestions() - 1; i++)
            {
                QuestionContent[i] = Question.Load(i).Content;
                QuestionID[i] = Question.Load(i).Id;
            }

            int myQuestion = 0;
            Int32.TryParse(Request.QueryString["q"], out myQuestion);

            if (myQuestion != 0 && Request.QueryString["newcontent"] != null)
            {
                Question thisQuestion = Question.Load(myQuestion);
                thisQuestion.Content = Request.QueryString["newcontent"];
                thisQuestion.Update();
            }



            return View();
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    int myQuestion = 0;
        //    Int32.TryParse(Request.QueryString["q"], out myQuestion);
        //    Question.Load(myQuestion);
            
        //    return View();
        //}
    }
}