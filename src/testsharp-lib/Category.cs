using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
   public class Category
    {
        public int Id { get; set; }
        public String Description { get; set; }
   

        public Category(int Id)
        { 
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;
            String sql = null;
            SqlDataReader dataReader;
            connetionString = "Data Source=Q6600;Initial Catalog=testSharp;Integrated Security=True";
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();
                sql = "select name from testsharp.dbo.question_categories where id=" + Id;
                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Description = (String)dataReader.GetValue(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
        }
      }
    }
