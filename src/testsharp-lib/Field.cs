using System;
using System.Collections;
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

            db.ExecuteNonQuery("INSERT INTO fields(x,y,w,h,response_id,field_type_id) VALUES(" + x + "," + y + "," + w + "," + h + "," + Response.Id + "," + (int)FieldType + ")");
            int identity = db.ExecuteScalar("SELECT CAST(SCOPE_IDENTITY() AS int)");

            db.Close();

            return identity;
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

        public static Field[] List()
        {
            Db db = new Db();
            var reader = db.ExecuteReader("select id from fields order by id asc");
            ArrayList responseList = new ArrayList();

            while (reader.Read())
            {
                Field currentQuestion = Field.Load((int)reader["id"]);
                responseList.Add(currentQuestion);
            }

            reader.Close();
            db.Close();
            return (Field[])responseList.ToArray(typeof(Field));
        }
    }
}
