using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace testsharp.lib
{
    public class DropdownValue
    {
        public int id { get; set; }
        public string content { get; set; }
        public int fieldId { get; set; }

        public static DropdownValue Load(int id)
        {
            Db db = new Db();

            var reader = db.ExecuteReader("SELECT * FROM dropdown_values WHERE id=" + id.ToString());

            DropdownValue dv = new DropdownValue();

            if (reader.Read())
            {
                dv.id = (int)reader["id"];
                dv.content = (string)reader["content"];
                dv.fieldId = (int)reader["field_id"];
            }

            reader.Close();
            db.Close();

            return dv;           
        }

        public int Insert()
        {
            Db db = new Db();

            db.ExecuteNonQuery("INSERT INTO dropdown_values(content, field_id) VALUES(" + Db.Encode(content) + "," + fieldId + ")");
            int identity = db.ExecuteScalar("SELECT CAST(SCOPE_IDENTITY() AS int)");

            db.Close();

            return identity;
        }

        public void Update()
        {
            Db db = new Db();

            db.ExecuteNonQuery("UPDATE dropdown_values SET content = '" + content + "'," + "field_id = '" + fieldId + "' WHERE id='" + id.ToString()+"'");

            db.Close();
        }

        public void Delete()
        {
            Db db = new Db();

            db.ExecuteNonQuery("DELETE FROM dropdown_values WHERE id = " + id);

            db.Close();
        }

        public static DropdownValue[] List()
        {
            Db db = new Db();
            var reader = db.ExecuteReader("select id from fields order by id asc");
            ArrayList responseList = new ArrayList();

            while (reader.Read())
            {
                DropdownValue currentQuestion = DropdownValue.Load((int)reader["id"]);
                responseList.Add(currentQuestion);
            }

            reader.Close();
            db.Close();
            return (DropdownValue[])responseList.ToArray(typeof(DropdownValue));
        }

    }
}
