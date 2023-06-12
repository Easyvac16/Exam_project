using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_project
{
   
        class Question
        {
            public string Text { get; set; }
            public QuestionLevel Level { get; set; }
            public int PrizeMoney { get; set; }
            public Answer CorrectAnswer { get; set; }

        }
    
}
