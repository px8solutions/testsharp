using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class QuestionCategories
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
        public static QuestionCategories Load(int id)
        {
            Db db = new Db();

            var reader = db.ExecuteReader("select * from question_categories where id=" + id.ToString());

            QuestionCategories category = new QuestionCategories();

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
            db.ExecuteNonQuery("insert into question_categories values ('"+ Name + "')");

            db.Close();

        }

        public void Update()
        {
            Db db = new Db();

            //don't change id
            db.ExecuteNonQuery("update question_categories set name='" + Name + "' where id=" + _id.ToString());

            db.Close();
        }

        public void Delete()
        {
            Db db = new Db();

            var reader = db.ExecuteNonQuery("DELETE FROM question_categories WHERE id = " + Id.ToString());

            db.Close();
        }

        public static int GetMax()
        {
            int _castedInt;

            Db db = new Db();
            var reader = db.ExecuteReader("SELECT MAX(id) AS 'max' FROM question_categories");

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

        public static object[,] List()
        {
            object[,] values = new object[QuestionCategories.GetMax(), 2];
            Db db = new Db();

            for (int i = 1; i < QuestionCategories.GetMax(); i++)
            {
                var reader = db.ExecuteReader("SELECT * FROM question_categories WHERE id = " + i);
                if (reader.Read())
                {
                    values[i, 0] = reader["id"];
                    values[i, 1] = reader["name"].ToString();

                    reader.Close();
                }
            }

            db.Close();

            return values;
        }
    }

}
