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
   public class QuestionTests
    {
        [Test]
        public void Load()
        {
            Question myQuestion = Question.Load(6);

            Assert.AreEqual(myQuestion.Id, 6,"id not equal.");
            Assert.IsNotNull(myQuestion.Ordinal);
            Assert.IsNotNull(myQuestion.Content);
            Assert.AreEqual(myQuestion.QuestionType, QuestionTypes.CreateDoubleList,"type not equal.");

          

            

        }

        [Test]
        public void Update()
        {
            Question myQuestion = Question.Load(1);
           
            myQuestion.Content = "swag' o'att";
            myQuestion.ImageURL = null;
            myQuestion.Update();

        }
    }
}
