using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_project
{
    static Question GetNextQuestion(int questionLevel, List<Question> easyQuestions, List<Question> mediumQuestions, List<Question> hardQuestions)
    {
        switch (questionLevel)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                return GetRandomQuestion(easyQuestions);
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                return GetRandomQuestion(mediumQuestions);
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
                return GetRandomQuestion(hardQuestions);
            default:
                return null;
        }
    }



    // Отримати випадкове запитання зі списку запитань
    static Question GetRandomQuestion(List<Question> questions)
    {
        Random random = new Random();
        int randomIndex = random.Next(0, questions.Count);
        return questions[randomIndex];
    }

    // Отримати варіанти відповідей для питання залежно від рівня складності
    static List<Answer> GetAnswersForQuestion(Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
    {
        switch (question.Level)
        {
            case QuestionLevel.Easy:
                return GetRandomAnswers(question, easyAnswers);
            case QuestionLevel.Medium:
                return GetRandomAnswers(question, mediumAnswers);
            case QuestionLevel.Hard:
                return GetRandomAnswers(question, hardAnswers);
            default:
                return null;
        }
    }

    // Отримати випадкові відповіді для питання
    static List<Answer> GetRandomAnswers(Question question, List<Answer> answers)
    {
        //Random random = new Random();
        List<Answer> randomAnswers = new List<Answer>();
        randomAnswers.Add(question.CorrectAnswer);

        for (int i = 0; i < answers.Count; i += 4)
        {
            if (answers[i].Cont(question.CorrectAnswer) == true)
            {
                randomAnswers.Add(answers[++i]);
                randomAnswers.Add(answers[++i]);
                randomAnswers.Add(answers[++i]);

                randomAnswers = ListExtensions.RandomSwap(randomAnswers);
                Answer.PrintAnswers(randomAnswers);
                return randomAnswers;
            }
        }
        return randomAnswers;
    }

    // Перевірити правильність відповіді
    static bool CheckAnswer(Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
    {
        List<Answer> answers = GetAnswersForQuestion(question, easyAnswers, mediumAnswers, hardAnswers);
        Console.Write("\nВаша відповідь (введіть номер варіанту): ");
        int userChoice = int.Parse(Console.ReadLine());
        Answer selectedAnswer = answers[userChoice - 1];
        return selectedAnswer.IsCorrect;
    }

    // Надати підказку гравцю
    static void ProvideHint(int questionLevel, Question question, List<Answer> easyAnswers, List<Answer> mediumAnswers, List<Answer> hardAnswers)
    {
        switch (questionLevel)
        {
            case 5:
                FiftyFifty(question, easyAnswers, mediumAnswers, hardAnswers);
                break;
            case 10:
                CallFriend(question);
                break;
            case 15:
                AudienceHelp(question);
                break;
        }
    }
}
