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
<<<<<<< HEAD
        public int Id { get; set; }
        public String Description { get; set; }
   

        public Category(int Id)
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
                sql = "select name from testsharp.dbo.question_categories where id=" + Id;
                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Description = (String)dataReader.GetValue(0);
                }
            }
            catch (Exception ex)
=======
        //backing field for property
        private int _id=-1;

        // property accessors (primary key is read only)
        public int Id
        {
            set { _id =value; }
            get { return _id; }
        }


        //using auto-implemented property
        public string Name { get; set; }


        //static load method
        public static Category Load(int id)
        {
            Db db = new Db();

            var reader = db.ExecuteReader("select * from question_categories where id=" + id.ToString());

            Category category = new Category();

            if (reader.Read())
>>>>>>> a796c0cea1a99404e241689726361d36d4adb90e
            {
                category._id = (int)reader["id"];
                category.Name = (string)reader["name"];
            }


            reader.Close();
            db.Close();

            return category;

        }


        public void Insert()
        {
            Db db = new Db();


            //need id on insert
            db.ExecuteNonQuery("insert into question_categories values (" + _id.ToString() + ",'" + Name + "')");

            db.Close();

        }

        public void Update()
        {
            Db db = new Db();

            //don't change id
            db.ExecuteNonQuery("update question_categories set name='" + Name + "' where id=" + _id.ToString());

            db.Close();

        }

    }

}
