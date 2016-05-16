﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class Questions
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public int Ordinal { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public QuestionCategories Category { get; set; }
        public Questions Parent { get; set; }
        public String ImageURL { get; set; }

        public Responses[] Responses { get; set; }

        public static Questions Load(int id)
        {
            Db db = new Db();
            var reader = db.ExecuteReader("select * from questions where id=" + id.ToString());

            Questions question = new Questions();

            if (reader.Read())
            {
                question.Id = (int)reader["id"];
                question.Content = (string)reader["content"];
                question.Ordinal = (int)reader["ordinal"];
                question.QuestionType = (QuestionTypes)reader["type_id"];
                question.Category = QuestionCategories.Load((int)reader["category_id"]);

                if (reader["parent_id"] != DBNull.Value)
                {
                    question.Parent = Questions.Load( (int)reader["parent_id"]);
                }

                if (reader["image_url"] != DBNull.Value)
                {
                    question.ImageURL = (string)reader["image_url"];
                }

                reader.Close();
                db.Close();

                
            }

            return question;
        }

        public void Insert()
        {
            Db db = new Db();

            db.ExecuteNonQuery("insert into questions values (" + Id.ToString() + ",'" + Content + "',"
                + "'" + Ordinal.ToString() + "'," + "'" + QuestionType.ToString() + "'," + "'" 
                + Category.Id.ToString() + "'," + "'" + Parent.Id.ToString() + "'," + "'" + ImageURL.ToString());

            db.Close();
        }

        public void Update()
        {
            Db db = new Db();

            db.ExecuteNonQuery("update Questions set content=" + Db.Encode(Content)+", image_url="+ Db.Encode(ImageURL) + " where id="+Id);

            /*db.ExecuteNonQuery("Update Questions set content=" + Db.Encode(Content) + "Ordinal=" + Db.Encode(Ordinal.ToString()) + "type_id=" 
                + Db.Encode(QuestionType.ToString()) + "Category_id=" + Db.Encode(Category.Id.ToString()) + "parent_id="+Db.Encode(Parent.Id.ToString())
                +"image_url="+Db.Encode(ImageURL.ToString()));
                */

           // db.ExecuteNonQuery("update values set " + "content='" + Content + "',"
           //     + "Ordinal='" + Ordinal.ToString() + "'," + "type_id='" + QuestionType.ToString() + "'," + "Category_id='"
           //     + Category.Id.ToString() + "'," + "parent_id='" + Parent.Id.ToString() + "'," + "image_url='" + ImageURL.ToString()+"where id ='"+Id.ToString()+"')");

            db.Close();
        }

    }
}