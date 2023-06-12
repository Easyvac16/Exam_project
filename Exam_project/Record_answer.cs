using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_project
{ 
    record Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public static void PrintAnswers(List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {answers[i].Text}");
            }
        }

        public bool Cont(Answer answer) => (this.Text == answer.Text && this.IsCorrect == answer.IsCorrect);

    }
}
