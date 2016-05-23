using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testsharp.lib;
using NUnit.Framework;

namespace testsharp_lib_tests
{
    [TestFixture]
    public class QuestionCategoryTests
    {
        [Test]
        public void QuestionCategoryLoad()
        {
            QuestionCategories qc = QuestionCategories.Load(3);
            Assert.AreEqual(qc.Name, "Two");
        }

        [Test]
        public void QuestionCategoryInsert()
        {
            QuestionCategories qc = QuestionCategories.Load(2);
            qc.Name = "Use jQuery (25%)";
            qc.Insert();
        }

        [Test]
        public void QuestionCategoryUpdate()
        {

            QuestionCategories qc = QuestionCategories.Load(1);
            qc.Id = 1;
            qc.Name = "Use JavaScript (25%)";
            qc.Update();
        }

        [Test]
        public void QuestionCategoryDelete()
        {
            QuestionCategories qc = QuestionCategories.Load(4);

            qc.Id = 4;
            qc.Delete();
        }

        [Test]
        public void QuestionCategoryList()
        {
            QuestionCategories[] myQuestionCategories = QuestionCategories.List();

        }
    }
}
