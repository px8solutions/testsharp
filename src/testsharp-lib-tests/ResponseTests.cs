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
        public void LoadResponse()
        {
            Responses myResponse = Responses.Load(1);

            Assert.AreEqual(myResponse.Id, 1);
            Assert.IsNotNull(myResponse.Ordinal);
            Assert.IsNotNull(myResponse.Question);

        }

        [Test]
        public void UpdateResponse()
        {
            Responses myResponse = Responses.Load(1);
            myResponse.Content = "wow";
            myResponse.Update();
            myResponse = Responses.Load(1);
            Assert.AreEqual(myResponse.Content, "wow");

        }

        [Test]
        public void CreateResponse()
        {
            Responses myResponse = new Responses();
            myResponse.Id = 77;
            myResponse.Content = "test";
            myResponse.Correct = true;
            myResponse.Ordinal = 108;
            myResponse.Insert();

            //myResponse.Question = Questions.Load(1);
            Responses tempResponse = Responses.Load(77);
            Assert.AreEqual(tempResponse.Content.ToString(), "test");
        }
    }
}
