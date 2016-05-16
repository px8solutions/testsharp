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
    public class QuestionCategoriesTests
    {
        [Test]
        public void LoadQuestionCategory()
        {
            QuestionCategories qc = QuestionCategories.Load(0);
        }

        [Test]
        public void InsertQuestionCategory()
        {
            QuestionCategories qc = QuestionCategories.Load(1);
            qc.Id = 1;
            qc.Name = "Use jQuery (25%)";
            qc.Insert();
        }

        [Test]
        public void UpdateQuestionCategory()
        {
            QuestionCategories qc = QuestionCategories.Load(1);
            qc.Id = 1;
            qc.Name = "Use JavaScript (25%)";
            qc.Update();
        }
    }
}
