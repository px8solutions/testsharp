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
   public class ResponseTests
    {
        [Test]
        public void Load()
        {
            Responses myResponse = Responses.Load(1);

            Assert.AreEqual(myResponse.Id, 1);
            Assert.IsNotNull(myResponse.Ordinal);
            Assert.IsNotNull(myResponse.Question);

        }
    }
}
