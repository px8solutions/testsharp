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
        public QuestionTypes QuestionType { get; set; }
        public Category Category { get; set; }
        public Question Parent { get; set; }
        public String ImageURL { get; set; }

        public Response[] Responses { get; set; }

        public static Question Load(int id)
        {
            Db db = new Db();
            var reader = db.ExecuteReader("select * from questions where id=" + id.ToString());

            Question question = new Question();

            if (reader.Read())
            {
                question.Id = (int)reader["id"];
                question.Content = (string)reader["content"];
                question.Ordinal = (int)reader["ordinal"];
                //question.QuestionType = new QuestionTypes( (int)reader["type_id"]);
                //question.Category = new Category((int)reader["category_id"]);
                //question.Parent = new Question((int)reader["parent_id"]);
                question.ImageURL = (string)reader["image_url"];

                reader.Close();
                db.Close();

                return question;
            }

            //on db connection failure.
            return null;
        }

        public void Insert()
        {
            Db db = new Db();

            db.ExecuteNonQuery("insert into questions values (" + Id.ToString() + ",'" + Content.ToString() + "',"
                + "'" + Ordinal.ToString() + "'," + "'" + QuestionType.ToString() + "'," + "'" 
                + Category.Id.ToString() + "'," + "'" + Parent.Id.ToString() + "'," + "'" + ImageURL.ToString());

            db.Close();
        }

        public void Update()
        {
            Db db = new Db();

            db.ExecuteNonQuery("update values set " + "content='" + Content.ToString() + "',"
                + "Ordinal='" + Ordinal.ToString() + "'," + "type_id='" + QuestionType.ToString() + "'," + "Category_id='"
                + Category.Id.ToString() + "'," + "parent_id='" + Parent.Id.ToString() + "'," + "image_url='" + ImageURL.ToString()+"where id ='"+Id.ToString()+"')");
        }

    }
}
