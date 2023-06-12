using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_project
{
    static void FiftyFifty(Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
    {
        List<Answer> answers = GetAnswersForQuestion(question, easyAnswers, mediumAnswers, hardAnswers);

        Console.WriteLine("Дві відповіді:");
        int countRemovedAnswers = 0;
        for (int i = 0; i < answers.Count; i++)
        {
            if (!answers[i].IsCorrect)
            {
                answers.RemoveAt(i);
                answers.RemoveAt(i);
                countRemovedAnswers++;
                countRemovedAnswers++;
                i--;
            }

            if (countRemovedAnswers == 2)
                break;
        }

        Answer.PrintAnswers(answers);
    }

    
    static void CallFriend(Question question)
    {
        Console.WriteLine("\n[Дзвінок другу] Твій друг говорить, що він впевнений, що правильна відповідь - " +
                          $"{question.CorrectAnswer.Text}.");
    }

    
    static void AudienceHelp(Question question)
    {
        Console.WriteLine("\n[Допомога з залу] Більшість глядачів вважають, що правильна відповідь - " +
                          $"{question.CorrectAnswer.Text}.");
    }
}
