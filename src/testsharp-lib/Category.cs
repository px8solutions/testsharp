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
