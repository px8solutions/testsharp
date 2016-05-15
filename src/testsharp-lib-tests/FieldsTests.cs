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
    public class FieldsTests
    {
        [Test]
        public void Load()
        {
            Field field = Field.Load(1);

            Assert.AreEqual(field.id, 1);
            Assert.AreEqual(field.x, 21);
            Assert.AreEqual(field.x, 32);
            Assert.AreEqual(field.x, 30);
            Assert.AreEqual(field.x, 10);
            Assert.AreEqual(field.Response, Response.Load(6));
            Assert.AreEqual(field.FieldType, 0);
        }
    }
}
