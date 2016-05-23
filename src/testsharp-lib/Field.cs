using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class Field
    {
        public int id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public Response Response { get; set; }
        public FieldType FieldType { get; set; }

        public static Field Load(int id)
        {
            Db db = new Db();

            var reader = db.ExecuteReader("SELECT * FROM fields WHERE id=" + id.ToString());

            Field field = new Field();

            if (reader.Read())
            {
                field.id = (int)reader["id"];
                field.x = (short)reader["x"];
                field.y = (short)reader["y"];
                field.w = (short)reader["w"];
                field.h = (short)reader["h"];
                field.Response = Response.Load((int)reader["response_id"]);
                field.FieldType = (FieldType)reader["field_type_id"];
            }

            reader.Close();
            db.Close();

            return field;
        }

        public int Insert()
        {
            Db db = new Db();

            string insertResponseId = "1";
            if (Response != null)
            {
                insertResponseId = Response.Id.ToString();
            }

            db.ExecuteNonQuery("insert into fields values(" /*+Db.Encode(id.ToString())+","*/+ Db.Encode(x.ToString())
                + "," + Db.Encode(y.ToString()) + "," + Db.Encode(w.ToString()) + "," + Db.Encode(h.ToString()) + ","
                + "'" + insertResponseId + "',"
                + "'" + Convert.ChangeType(FieldType, FieldType.GetTypeCode()) + "'" + ")");

            db.Close();

            //var reader = db.ExecuteReader("SELECT @@IDENTITY AS 'identity'");

            //var reader = db.ExecuteReader("INSERT INTO fields VALUES(" +
            //    Db.Encode(x.ToString()) + "," + Db.Encode(y.ToString()) + "," +
            //    Db.Encode(w.ToString()) + "," + Db.Encode(h.ToString()) + "," +
            //    insertResponseId + "," + Convert.ChangeType(FieldType, FieldType.GetTypeCode())
            //    + ") " + "SELECT @@IDENTITY AS 'identity'");

            // "identity" always returns null. This works fine when I run the query in SQL Server
            // management studio.
            //var reader = db.ExecuteReader("INSERT INTO fields VALUES(10, 10, 10, 10, 1, 1) SELECT @@IDENTITY AS 'identity'");
            Db db2 = new Db();
            var reader = db2.ExecuteReader("SELECT IDENT_CURRENT('fields') as 'identity'");
            int _identity;
            if (reader.Read())
            {
               
                _identity = (int)reader["identity"];
            }
            else
            {
                _identity = 0;
            }

            reader.Close();
            db2.Close();
            return _identity;
        }

        public void Update()
        {
            Db db = new Db();
            db.ExecuteNonQuery("Update fields set x="+ Db.Encode(x.ToString())+","+"y="+ Db.Encode(y.ToString())+","
                +"w="+ Db.Encode(w.ToString())+","+"h="+ Db.Encode(h.ToString())+","+"response_id="
                + Db.Encode(Response.Id.ToString())+","+"field_type_id="+ "'" 
                + Convert.ChangeType(FieldType, FieldType.GetTypeCode()) + "' where id="+ Db.Encode(id.ToString()));

            db.Close();
        }

        public void Delete()
        {
            Db db = new Db();

            db.ExecuteNonQuery("DELETE FROM fields WHERE id = " + id);

            db.Close();
        }       
    }
}
