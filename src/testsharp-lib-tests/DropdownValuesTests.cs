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
    public class DropdownValuesTests
    {
        [Test]
        public void DropdownValuesLoad()
        {
            DropdownValues dv1 = DropdownValues.Load(0);

            Assert.AreEqual(dv1.id, 0);
            Assert.AreEqual(dv1.content, "fix the jqueries");
            Assert.AreEqual(dv1.fieldId, 2);    
        }

        [Test]
        public void DropdownValuesUpdate()
        {
            DropdownValues myDropdownValue = DropdownValues.Load(0);

            myDropdownValue.content = "oh, yeah!";
            myDropdownValue.Update();

            DropdownValues myDropdownValue2 = DropdownValues.Load(0);
            Assert.AreEqual(myDropdownValue2.content.ToString(), "oh, yeah!");

        }
    }
}
