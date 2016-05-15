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
        public void Load()
        {
            Question myQuestion = Question.Load(6);

            Assert.AreEqual(myQuestion.Id, 6,"id not equal.");
            Assert.AreEqual(myQuestion.QuestionType, QuestionTypes.CreateDoubleList,"type not equal.");
            

        }
    }
}