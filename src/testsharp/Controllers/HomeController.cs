using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            /*
            Question myQuestion = new Question(8);
            myQuestion.Content = "wubwubwub";
            Response myResponse = new Response(16);
            Field myField = new Field(1);

            ViewBag.myQuestion = myQuestion.Content;
            //ViewBag.myQuestio = myQuestion.Category.Name;
            ViewBag.myQuest = myQuestion.Parent.Content;
            ViewBag.myResponse = myResponse.Content;
            ViewBag.MyField = myField.Response.Content;

            DropdownValue myDropdownValue = new DropdownValue(0);

            ViewBag.myDropdownValue = myDropdownValue.Content;
            */
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //ViewBag.CategoryTest = Category.Display(0);

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
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;
            String sql = null;
            SqlDataReader dataReader;
            //connetionString = "Data Source=Q6600;Initial Catalog=testSharp;Integrated Security=True";
            connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=testSharp;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            sql = "INSERT INTO testsharp.dbo.questions VALUES (content='" + form["content"].ToString() + "' WHERE id=" + form["id"].ToString()+")";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();


            ViewBag.Yolo = form["id"].ToString();
            ViewBag.rofl = form["content"].ToString();
            return View();

        }

        // it's destin. i added this to check out the code joe wrote and also test my thing.
        public ActionResult Insert()
        {
            return View();
        }


        //TODO: doesn't work
        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            int outputID;

            if (Int32.TryParse(form["id"], out outputID))
            {
                Category cat = Category.Load(outputID);
                cat.Name = form["name"];
                cat.Update();

                ViewBag.CatId = outputID.ToString();
                //ViewBag.CatId = Category.Display(outputID);
            }
            else
            {
                ViewBag.CatId = "I'm afraid I can't let you do that...";
            }



            return View();
        }

    }
}