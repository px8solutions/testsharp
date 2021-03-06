﻿using System;
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

        
            if (myQuestion != 0)
            {
                Question thisQuestion = Question.Load(myQuestion);

                ViewBag.responses = thisQuestion.Responses;
                ViewBag.responses = new List<string>() { "a", "b", "c" };


                if (Request.QueryString["newcontent"] != null)
                {
                    thisQuestion.Content = Request.QueryString["newcontent"];
                    thisQuestion.Update();
                }



            }

            return View();
        }

    }
}