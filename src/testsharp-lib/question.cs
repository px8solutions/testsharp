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
        public String Content { get; set; }
        public int Ordinal { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public Category Category { get; set; }
        public Question Parent { get; set; }
        public String ImageURL { get; set; }

        public Response[] Responses { get; set; }

        public Question(int Id)
        {
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;
            String sql = null;
            SqlDataReader dataReader;
            //connetionString = "Data Source=Q6600;Initial Catalog=testSharp;Integrated Security=True";
            connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=testSharp;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                sql = "select content, ordinal, type_id, category_id, parent_id, image_url from testsharp.dbo.questions where id="+Id;
                command = new SqlCommand(sql, cnn);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Content =(String) dataReader.GetValue(0);
                    Ordinal = (int)dataReader.GetValue(1);
                    QuestionType = (QuestionTypes) dataReader.GetValue(2);
                    Category = new Category((int) dataReader.GetValue(3));

                    if (dataReader.GetValue(4) != null)
                    {

                        Parent  = new Question( (int)dataReader.GetValue(4));
                    }

                    ImageURL = (String)dataReader.GetValue(5);

                }
                dataReader.Close(); command.Dispose();

                Console.WriteLine("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
            
            


        }
    }
}
