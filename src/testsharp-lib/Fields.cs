﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class Fields
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public Responses Response { get; set; }
        public FieldTypes FieldType { get; set; }

        public static Fields Load(int id)
        {
            Db db = new Db();

            var reader = db.ExecuteReader("SELECT * FROM fields WHERE id=" + id.ToString());

            Fields field = new Fields();

            if (reader.Read())
            {
                field.id = (int)reader["id"];
                field.x = (short)reader["x"];
                field.y = (short)reader["y"];
                field.w = (short)reader["w"];
                field.h = (short)reader["h"];
                field.Response = Responses.Load((int)reader["response_id"]);
                field.FieldType = (FieldTypes)reader["field_type_id"];
            }

            reader.Close();
            db.Close();

            return field;
        }



        /*
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public Response Response { get; set; }
        public FieldTypes FieldType { get; set; }

        public Field(int Id)
        {
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;
            String sql = null;
            SqlDataReader dataReader;
            //connetionString = "Data Source=Q6600;Initial Catalog=testSharp;Integrated Security=True";
            connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=testSharp;Integrated Security=True";
            cnn = new SqlConnection(connetionString);

          //  try
            {
                cnn.Open();
                sql = "select x, y, w, h, response_id, field_type_id from testsharp.dbo.fields where id=" + Id;
                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    //X = (int)dataReader.GetValue(0);
                   // Y = (int)dataReader.GetValue(1);
                   // W = (int)dataReader.GetValue(2);
                   // H = (int)dataReader.GetValue(3);
                   // Response = new Response((int)dataReader.GetValue(4));
                    FieldType= (FieldTypes)dataReader.GetValue(5);
                }
            }
            //catch (Exception ex)
            {
               // Console.WriteLine("Can not open connection ! ");
            }
        }
        */
    }
}