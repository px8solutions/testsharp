﻿using System;
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
            Question myQuestion = Question.Load(6);

            Assert.AreEqual(myQuestion.Id, 6,"id not equal.");
            Assert.IsNotNull(myQuestion.Ordinal);
            Assert.IsNotNull(myQuestion.Content);
            Assert.AreEqual(myQuestion.QuestionType, QuestionType.CreateDoubleList,"type not equal.");     
        }

        [Test]
        public void QuestionInsert()
        {
            // insert new data
            Question myQuestion = Question.Load(10);

            myQuestion.Id = 10;
            myQuestion.Content = "How do you compile your JSONs?";
            myQuestion.Ordinal = 1;
            myQuestion.QuestionType = QuestionType.MultipleChoiceSingle;
            myQuestion.Category = QuestionCategories.Load(0);
            myQuestion.Parent = Question.Load(5);
            myQuestion.ImageURL = null;
            myQuestion.Insert();

            // match inserted data
            Question insTest = Question.Load(10);

            Assert.AreEqual(insTest.Id, 10);
            Assert.AreEqual(insTest.Content, "How do you compile your JSONs?");
            Assert.AreEqual(insTest.Ordinal, 1);
            Assert.AreEqual(insTest.QuestionType, QuestionType.MultipleChoiceSingle);
            Assert.AreEqual(insTest.Category.Id, QuestionCategories.Load(0).Id);
            Assert.AreEqual(insTest.Parent.Id, Question.Load(5).Id);
            Assert.AreEqual(insTest.ImageURL, "NULL");
        }

        [Test]
        public void QuestionUpdate()
        {
            Question upTest = Question.Load(10);

            upTest.Id = 10;
            upTest.Content = "True or False: Screaming into the void for hours on end will make JavaScript write itself.";
            upTest.Ordinal = 2;
            upTest.QuestionType = QuestionType.MultipleChoiceSingle;
            upTest.Category = QuestionCategories.Load(0);
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
            var a =Question.GetMaxQuestions();
            Question.List();
            
        }
    }
}
