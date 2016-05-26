using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class Question
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public int Ordinal { get; set; }
        public QuestionType QuestionType { get; set; }
        public QuestionCategories Category { get; set; }
        public Question Parent { get; set; }
        public String ImageURL { get; set; }

        //public Response[] Responses { get; set; }
        public List<Response> Responses{ get; set; }

        public static Question Load(int id)
        {
            Db db = new Db(); //questions
            
            

            var reader = db.ExecuteReader("select * from questions where id=" + id.ToString());

            Question question = new Question();

            if (reader.Read())
            {
                question.Id = (int)reader["id"];
                question.Content = (string)reader["content"];
                question.Ordinal = (int)reader["ordinal"];
                question.QuestionType = (QuestionType)reader["type_id"];
                question.Category = QuestionCategories.Load((int)reader["category_id"]);

                if (reader["parent_id"] != DBNull.Value)
                {
                    question.Parent = Question.Load( (int)reader["parent_id"]);
                }

                if (reader["image_url"] != DBNull.Value)
                {
                    question.ImageURL = (string)reader["image_url"];
                }

                
  
             }
                

            // questions reader
            reader.Close();
            db.Close();

            return question;
        }

        public int Insert()
        {
            Db db = new Db();

            var reader = db.ExecuteReader("insert into questions (content,ordinal,image_url,type_id,category_id,parent_id) values (" + Db.Encode(Content.ToString()) + ","
                + Ordinal.ToString() + "," + Db.Encode(ImageURL.ToString()) + "," + Convert.ChangeType(QuestionType, QuestionType.GetTypeCode()) 
                + "," + Category.Id + "," + Parent.Id + ") SELECT CONVERT(INT, @@IDENTITY) as 'ident'");

            int identity;
            if (reader.Read())
            {
                identity = (int)reader["ident"];
            }
            else
            {
                identity = 0;
            }

            reader.Close();
            db.Close();

            return identity;
        }

        public void Update()
        {
            Db db = new Db();

            db.ExecuteNonQuery("update Questions set content=" + Db.Encode(Content) + ", image_url=" + Db.Encode(ImageURL) 
                + ", ordinal =" + Ordinal.ToString() + ", category_id=" + Category.Id.ToString() + ", parent_id=" 
                + Parent.Id.ToString() + ", type_id=" + Convert.ChangeType(QuestionType, QuestionType.GetTypeCode()) + "where id=" + Id);


            db.Close();
        }

        public static int GetMaxQuestions()
        {
            int _castedInt;

            Db db = new Db();
            var reader = db.ExecuteReader("SELECT MAX(id) AS 'max' FROM questions");

            if (reader.Read())
            {
                _castedInt = 5;
                 var worked = Int32.TryParse(reader["max"].ToString(), out _castedInt);
                db.Close();
                return _castedInt;
            }
            else
            {
                db.Close();
                return 0;
            }            
        }

        public void Delete()
        {
            Db db = new Db();

            var reader = db.ExecuteNonQuery("DELETE FROM questions WHERE id = " + Id.ToString());

            db.Close();
        }


        public static Question[] List()
        {
            Db db = new Db();
            var reader = db.ExecuteReader("select id from questions order by ordinal asc");
            ArrayList responseList = new ArrayList();

            while (reader.Read())
            {
                Question currentQuestion = Question.Load((int)reader["id"]);
                responseList.Add(currentQuestion);
            }

            reader.Close();
            db.Close();
            return (Question[])responseList.ToArray(typeof(Question));
        }
    }
}
