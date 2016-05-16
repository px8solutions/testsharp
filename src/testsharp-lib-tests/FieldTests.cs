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
        public void LoadField()
        {
            Fields field = Fields.Load(1);

            Assert.AreEqual(field.id, 1);
            Assert.AreEqual(field.x, 21);
            Assert.AreEqual(field.y, 32);
            Assert.AreEqual(field.w, 30);
            Assert.AreEqual(field.h, 10);
            Assert.AreEqual(field.Response.Id, Responses.Load(6).Id);
            Assert.AreEqual(field.FieldType, FieldTypes.TextBox);
        }

        [Test]
        public void UpdateField()
        {

            Fields myField = Fields.Load(2);
            myField.h = 77;
            
            
        }
        
    }
}
