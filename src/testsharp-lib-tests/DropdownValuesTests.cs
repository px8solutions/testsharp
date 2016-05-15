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
        public void Load()
        {
            DropdownValue dv1 = DropdownValue.Load(0);

            Assert.AreEqual(dv1.id, 0);
            Assert.AreEqual(dv1.content, "fix the jqueries");
            Assert.AreEqual(dv1.fieldId, 2);

            DropdownValue dv2 = DropdownValue.Load(1);

            Assert.AreEqual(dv2.id, 1);
            Assert.AreEqual(dv2.content, "Kroger Brand Seltzer Water");
            Assert.AreEqual(dv2.fieldId, 2);
        }
    }
}
