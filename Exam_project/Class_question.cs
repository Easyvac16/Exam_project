using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_project
{
    internal class Class_question
    {
        class Question
        {
            public string Text { get; set; }
            public QuestionLevel Level { get; set; }
            public int PrizeMoney { get; set; }
            public Answer CorrectAnswer { get; set; }

        }
    }
}
