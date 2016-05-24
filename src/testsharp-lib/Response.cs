using System;
using System.Collections;
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
                //response.Question = Question.Load((int)reader["question_id"]);
                response.Question = new Question();
            }
            reader.Close();
            db.Close();

            return response;
        }

        public int Insert()
        {
            Db db = new Db();

            string insertQuestionId = "1";
            if (Question!=null)
            {
                insertQuestionId = Question.Id.ToString();
            }

            var reader = db.ExecuteReader("insert into Responses (content,correct,ordinal,question_id) values ("+ Db.Encode(Content.ToString()) 
                + "," + Db.Encode(Correct.ToString()) + "," + Ordinal + "," + insertQuestionId + ") SELECT CONVERT(INT, @@IDENTITY) as 'ident'");

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

            db.ExecuteNonQuery("update Responses set " + "Content='" + Content.ToString() + "'," + "Correct='" + Correct.ToString() + "'," + "ordinal='"
                + Ordinal.ToString() + "'," + "question_id='" + 1 + "'where id ='"+Id.ToString()+"'");

            db.Close();
        }
        
        public void Delete()
        {
            Db db = new Db();

            db.ExecuteNonQuery("DELETE FROM responses WHERE id = " + Id);

            db.Close();
        }
        
        public static Response[] List()
        {
            Db db = new Db();
            var reader = db.ExecuteReader("SELECT id FROM responses ORDER BY id ASC");
            ArrayList list = new ArrayList();

            while (reader.Read())
            {
                Response response = Response.Load((int)reader["id"]);
                list.Add(response);
            }

            reader.Close();
            db.Close();
            return (Response[])list.ToArray(typeof(Response));
        }       
    }
}
