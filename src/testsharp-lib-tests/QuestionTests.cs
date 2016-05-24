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
        public void QuestionLoad()
        {
            Question myQuestion = Question.Load(2);

            Assert.AreEqual(myQuestion.Id, 2);
            Assert.IsNotNull(myQuestion.Ordinal);
            Assert.IsNotNull(myQuestion.Content);

            Assert.AreEqual(myQuestion.QuestionType, QuestionType.MultipleChoiceSingle);
            Assert.AreEqual(myQuestion.ImageURL, null);
            Assert.AreEqual(myQuestion.Category.Id, QuestionCategories.Load(2).Id);
            Assert.AreEqual(myQuestion.Parent.Id, Question.Load(1).Id);
        }

        [Test]
        public void QuestionInsert()
        {
            // insert new data
            Question myQuestion = Question.Load(10);

           // myQuestion.Id = 10;
            myQuestion.Content = "How do you compile your JSONs?";
            myQuestion.Ordinal = 1;
            myQuestion.QuestionType = QuestionType.MultipleChoiceMultiple;
            myQuestion.Category = QuestionCategories.Load(1);
            myQuestion.Parent = Question.Load(5);
            myQuestion.ImageURL = "NULL";
            myQuestion.Insert();

            // match inserted data
            Question insTest = Question.Load(4);

            Assert.AreEqual(insTest.Id, 4);
            Assert.AreEqual(insTest.Content, "what is an HTML?");
            Assert.AreEqual(insTest.Ordinal, 1);
            Assert.AreEqual(insTest.QuestionType, QuestionType.MultipleChoiceSingle);
            Assert.AreEqual(insTest.Category.Id, QuestionCategories.Load(2).Id);
            //Assert.AreEqual(insTest.Parent.Id, "NULL");
            Assert.AreEqual(insTest.ImageURL, null);
        }

        [Test]
        public void QuestionUpdate()
        {
            Question upTest = Question.Load(10);

            upTest.Id = 10;
            upTest.Content = "True or False: Screaming into the void for hours on end will make JavaScript write itself.";
            upTest.Ordinal = 2;
            upTest.QuestionType = QuestionType.MultipleChoiceSingle;
            upTest.Category = QuestionCategories.Load(1);
            upTest.Parent = Question.Load(5);
            upTest.ImageURL = "I hate images";
            upTest.Update();
        }

        [Test]
        public void QuestionDelete()
        {
            Question question = Question.Load(10);

            question.Id = 10;
            question.Delete();
        }

        [Test]
        public void QuestionList()
        {
            //var a =Question.GetMaxQuestions();
          Question[] myQuestionlist=  Question.List();
            Question[] myQuestionlist2 = myQuestionlist;


        }
    }
}
