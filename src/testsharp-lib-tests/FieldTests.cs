using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using testsharp.lib;

namespace testsharp_lib_tests
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void FieldLoad()
        {
            Field field = Field.Load(1);

            Assert.AreEqual(field.id, 1);
            Assert.AreEqual(field.x, 21);
            Assert.AreEqual(field.y, 32);
            Assert.AreEqual(field.w, 30);
            Assert.AreEqual(field.h, 10);
            Assert.AreEqual(field.Response.Id, Response.Load(6).Id);
            Assert.AreEqual(field.FieldType, FieldType.TextBox);
        }

        [Test]
        public void FieldUpdate()
        {

            Field myField = Field.Load(2);
            myField.h = 77;
            myField.Update();
            Assert.AreEqual(Field.Load(2).h, 77);
        }

        [Test]
        public void FieldInsert()
        {
            Field myField = new Field();
            myField.id = 8080;
            myField.x = 7;
            myField.y = 8;
            myField.w = 9;
            myField.h = 22;
            myField.Insert();
        }

        [Test]
        public void FieldDelete()
        {
            Field field = Field.Load(3);
            field.id = 3;
            field.Delete();
        }
    }
}
