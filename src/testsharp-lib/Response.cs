using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class Response
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public Boolean Correct { get; set; }
        public int Ordinal { get; set; }
        public Question Question { get; set; }

    public static Response Load(int id)
        {
            Db db = new Db();

            var reader = db.ExecuteReader("select * from responses where id=" + id.ToString());

            Response response = new Response();

            if (reader.Read())
            {
                response.Id = (int)reader["id"];
                response.Content = (string)reader["content"];
                response.Correct = (Boolean)reader["correct"];
                response.Ordinal = (int)reader["ordinal"];

               // response.Question = new Question((Question)reader["question_id"]);
            }
            reader.Close();
            db.Close();

            return response;
        }

    public void Insert()
        {
            Db db = new Db();

            db.ExecuteNonQuery("insert into Responses values (" + Id.ToString() + ",'" + Content + ",'" +Correct.ToString()+",'"+Ordinal.ToString()+"',"+Question.Id + "')");

            db.Close();
        }
    public void Update()
        {
            Db db = new Db();

            db.ExecuteNonQuery("update Responses set id='" + Id.ToString() + "'," + "Content='" + Content.ToString() + "'," + "Correct='" + Correct.ToString() + "'," + "ordinal='"
                + Ordinal.ToString() + "'," + "question_id='" + Question.Id + "')");

            db.Close();

        }
       
    }
}
