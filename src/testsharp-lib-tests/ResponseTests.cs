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
   public class ResponseTests
    {
        [Test]
        public void ResponseLoad()
        {
            Response myResponse = Response.Load(1);

            Assert.AreEqual(myResponse.Id, 1);
            Assert.IsNotNull(myResponse.Ordinal);
            Assert.IsNotNull(myResponse.Question);

        }

        [Test]
        public void ResponseUpdate()
        {
            Response myResponse = Response.Load(1);
            myResponse.Content = "wow";
            myResponse.Update();
            myResponse = Response.Load(1);
            Assert.AreEqual(myResponse.Content, "wow");

        }

        [Test]
        public void ResponseInsert()
        {
            Response myResponse = new Response();
            //myResponse.Id = 77;
            myResponse.Content = "test";
            myResponse.Correct = true;
            myResponse.Ordinal = 108;
            Debug.WriteLine(myResponse.Insert());

            //myResponse.Question = Questions.Load(1);
            Response tempResponse = Response.Load(20);
            Assert.AreEqual(tempResponse.Content.ToString(), "test");
        }

        [Test]
        public void ResponseDelete()
        {
            Response response = new Response();
            response.Id = 19;
            response.Delete();
        }

        [Test]
        public void ResponseList()
        {
            Debug.WriteLine("List: " + Response.List());
        }
    }
}
