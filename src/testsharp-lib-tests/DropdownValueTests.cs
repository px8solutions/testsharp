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
    public class DropdownValueTests
    {
        [Test]
        public void DropdownValueLoad()
        {
            DropdownValue dv1 = DropdownValue.Load(2);

            Assert.AreEqual(dv1.id, 2);
            Assert.AreEqual(dv1.content, "oh, yeah!");
            Assert.AreEqual(dv1.fieldId, 2);    
        }

        [Test]
        public void DropdownValueInsert()
        {
            DropdownValue dv = DropdownValue.Load(2);

            dv.id = 1;
            dv.content = "I've been dropped down.";
            dv.fieldId = 1;
            dv.Insert();

            DropdownValue dv1 = DropdownValue.Load(2);

            Assert.AreEqual(dv1.id, 2);
            Assert.AreEqual(dv1.content, "I've been dropped down.");
            Assert.AreEqual(dv1.fieldId, 1);
        }

        [Test]
        public void DropdownValueUpdate()
        {
            DropdownValue myDropdownValue = DropdownValue.Load(2);

            myDropdownValue.content = "oh, yeah!";
            myDropdownValue.Update();

            DropdownValue myDropdownValue2 = DropdownValue.Load(2);
            Assert.AreEqual(myDropdownValue2.content.ToString(), "oh, yeah!");
        }

        [Test]
        public void DropdownValueDelete()
        {
            DropdownValue dv = DropdownValue.Load(1);

            dv.id = 1;
            dv.Delete();
        }
    }
}
