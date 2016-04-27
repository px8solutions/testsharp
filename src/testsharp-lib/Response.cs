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



        public Response(int Id)
        {
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;
            String sql = null;
            SqlDataReader dataReader;
            //connetionString = "Data Source=Q6600;Initial Catalog=testSharp;Integrated Security=True";
            connetionString = "Data Source=Q6600;Initial Catalog=testSharp;Integrated Security=True";
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                sql = "select content, correct, ordinal, question_id from testsharp.dbo.responses where id=" + Id;
                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Content = (String)dataReader.GetValue(0);
                    Correct = (Boolean)dataReader.GetValue(1);
                    Ordinal = (int)dataReader.GetValue(2);
                    Question = new Question( (int)dataReader.GetValue(3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
        }
    }
}
