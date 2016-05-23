using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using testsharp.lib;
using System.Diagnostics;

namespace testsharp_lib_tests
{
    [TestFixture]
    public class FieldTests
    {
        private int _setupField;

        [SetUp]
        public void Init()
        {
            Field field = new Field();

            field.x = 5;
            field.y = 5;
            field.h = 10;
            field.w = 10;
            field.Response = Response.Load(1);
            field.FieldType = FieldType.DropDown;
            _setupField = field.Insert();
            Debug.WriteLine(_setupField);
        }

        [TearDown]
        public void Dispose()
        {
            Field field = Field.Load(_setupField);
            field.Delete();
        }

        [Test]
        public void FieldLoad()
        {
            Field field = Field.Load(_setupField);

            Assert.AreEqual(field.id, _setupField);
            Assert.AreEqual(field.x, 5);
            Assert.AreEqual(field.y, 5);
            Assert.AreEqual(field.w, 10);
            Assert.AreEqual(field.h, 10);
            Assert.AreEqual(field.Response.Id, Response.Load(1).Id);
            Assert.AreEqual(field.FieldType, FieldType.DropDown);
        }

        [Test]
        public void FieldUpdate()
        {

            Field myField = Field.Load(_setupField);
            myField.h = 77;
            myField.Update();
            Assert.AreEqual(Field.Load(_setupField).h, 77);
        }

        // This is no longer needed, right? The setup test uses the insert method.
        /*
        [Test]
        public void FieldInsert()
        {
            Field myField = new Field();
            myField.x = 7;
            myField.y = 8;
            myField.w = 9;
            myField.h = 22;
            System.Diagnostics.Debug.WriteLine(myField.Insert());
        }
        */

        // Same here.
        /*
        [Test]
        public void FieldDelete()
        {
            Field field = Field.Load(3);
            field.id = 3;
            field.Delete();
        }
        */

        [Test]
        public void FieldList()
        {
            Field[] myFieldList = Field.List();
        }
    }
}
