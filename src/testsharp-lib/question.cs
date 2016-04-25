 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    public class Question
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public int Ordinal { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public Category Category { get; set; }
        public Question Parent { get; set; }
        public String ImageURL { get; set; }

        public Response[] Responses { get; set; }
    }
}
