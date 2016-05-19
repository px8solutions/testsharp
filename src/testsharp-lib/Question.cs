using System;
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
            Db db2 = new Db(); //responses
            

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

                // get all responses for each question and add to the responses<> list
  
             }
                
                var reader2 = db2.ExecuteReader("select * from responses where question_id=" + id.ToString());
                
                 Response response = new Response();


                int resIndex = 0;
                while (reader2.Read())
                {
                    response.Id = (int)reader2["id"];
                    response.Content = (string)reader2["content"];
                    response.Correct = (Boolean)reader2["correct"];
                    response.Ordinal = (int)reader2["ordinal"];
                // response.Question = Question.Load((int)reader2["question_id"]);
                //response.Question = new Question();


               // question.Responses.Add(response);

                    resIndex++;
                }
                reader2.Close();
            

            // responses reader
            
            db2.Close();


            // questions reader
            reader.Close();
            db.Close();

            return question;
        }

        public void Insert()
        {
            Db db = new Db();

            if (ImageURL == null)
            {
                ImageURL = "NULL";
            }

            db.ExecuteNonQuery("insert into questions values (" + Id.ToString() + "," + Db.Encode(Content.ToString()) + ","
                + Ordinal.ToString() + "," + Db.Encode(ImageURL.ToString()) + "," + Convert.ChangeType(QuestionType, QuestionType.GetTypeCode()) 
                + "," + Category.Id.ToString() + "," + Parent.Id.ToString() + ")");

            db.Close();
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

        public static object[,] List()
        {
            object[,] values = new object[Question.GetMaxQuestions(),7];
            Db db = new Db();
            
            for (int i=1;i<Question.GetMaxQuestions();i++)
            {
               var reader = db.ExecuteReader("SELECT * FROM questions WHERE id = " + i);
                if (reader.Read())
                {
                    values[i, 0] = reader["id"];
                    values[i, 1] = reader["content"].ToString();
                    values[i, 2] = reader["ordinal"];
                    values[i, 3] = reader["image_url"].ToString();
                    values[i, 4] = reader["type_id"];
                    values[i, 5] = reader["category_id"];
                    values[i, 6] = reader["parent_id"];

                    

                    reader.Close();
                }
            }

            db.Close();

            return values;
        }
    }
}
