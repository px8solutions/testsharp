using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class Responses
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public Boolean Correct { get; set; }
        public int Ordinal { get; set; }
        public Questions Question { get; set; }

    public static Responses Load(int id)
        {
            Db db = new Db();

            var reader = db.ExecuteReader("select * from responses where id=" + id.ToString());

            Responses response = new Responses();

            if (reader.Read())
            {
                response.Id = (int)reader["id"];
                response.Content = (string)reader["content"];
                response.Correct = (Boolean)reader["correct"];
                response.Ordinal = (int)reader["ordinal"];
                response.Question = Questions.Load((int)reader["question_id"]);
            }
            reader.Close();
            db.Close();

            return response;
        }

    public void Insert()
        {
            Db db = new Db();

            string insertQuestionId = "1";
            if (Question!=null)
            {
                insertQuestionId = Question.Id.ToString();
            }

            //db.ExecuteNonQuery("insert into Responses values (" + Id.ToString() + ",'" + Content + ",'" +Correct.ToString()+"','"+Ordinal.ToString()+"',"+ insertQuestionId + "')");

            db.ExecuteNonQuery("insert into Responses (id,content,correct,ordinal,question_id) values ("+Db.Encode(Id.ToString()) + "," + Db.Encode(Content.ToString()) 
                + ","+Db.Encode(Correct.ToString()) + "," + Db.Encode(Ordinal.ToString()) + "," + Db.Encode(insertQuestionId) + ")");

            db.Close();
        }
    public void Update()
        {
            Db db = new Db();

            db.ExecuteNonQuery("update Responses set " + "Content='" + Content.ToString() + "'," + "Correct='" + Correct.ToString() + "'," + "ordinal='"
                + Ordinal.ToString() + "'," + "question_id='" + 1 + "'where id ='"+Id.ToString()+"'");

            db.Close();

        }
       
    }
}
