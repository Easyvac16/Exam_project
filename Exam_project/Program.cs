using System.Numerics;
using System.Text;

namespace Exam_project
{
   
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            List<Question> easyQuestions = GetEasyQuestions();
            List<Question> mediumQuestions = GetMediumQuestions();
            List<Question> hardQuestions = GetHardQuestions();

            List<Answer> easyAnswers = GetEasyAnswers();
            List<Answer> mediumAnswers = GetMediumAnswers();
            List<Answer> hardAnswers = GetHardAnswers();

            Player player = new Player();
            bool isGameActive = true;

            Console.WriteLine("Ласкаво просимо до гри \"Хто хоче стати мільйонером\"!");

            while (isGameActive)
            {
                // Виведення питання та варіантів відповідей
                Question currentQuestion = GetNextQuestion(player.QuestionLevel, easyQuestions, mediumQuestions, hardQuestions);
                string text = currentQuestion.Text;
                Console.WriteLine(text);

                // Перевірка правильності відповіді
                bool isAnswerCorrect = CheckAnswer(currentQuestion, easyAnswers, mediumAnswers, hardAnswers);

                if (isAnswerCorrect)
                {
                    Console.WriteLine("\nВідповідь правильна!");
                    player.IncrementQuestionLevel();
                    player.IncreasePrizeMoney(currentQuestion.PrizeMoney);
                }
                else
                {
                    Console.WriteLine("\nВідповідь неправильна!");
                    isGameActive = false;
                    break;
                }

                // Перевірка, чи досягнуто позначних запитань
                if (player.QuestionLevel == 5)
                {
                    Console.WriteLine("\nБажаєте скористатися підказкою? (Так/Ні)");
                    string hintChoice = Console.ReadLine().ToLower();

                    if (hintChoice == "так")
                    {
                        ProvideHint(player.QuestionLevel, currentQuestion, easyAnswers, mediumAnswers, hardAnswers);
                    }
                }
                if (player.QuestionLevel == 9)
                {
                    Console.WriteLine("\nБажаєте скористатися підказкою? (Так/Ні)");
                    string hintChoice = Console.ReadLine().ToLower();

                    if (hintChoice == "так")
                    {
                        CallFriend(currentQuestion);
                    }
                }
                if (player.QuestionLevel == 14)
                {
                    Console.WriteLine("\nБажаєте скористатися підказкою? (Так/Ні)");
                    string hintChoice = Console.ReadLine().ToLower();

                    if (hintChoice == "так")
                    {
                        AudienceHelp(currentQuestion);
                    }
                }

                // Перевірка, чи гравець бажає закінчити гру
                if (player.QuestionLevel == 15)
                {
                    Console.WriteLine("\nВітаємо! Ви виграли максимальний призовий грошовий фонд!");
                    isGameActive = false;
                    break;
                }

                Console.WriteLine("\nНаступне запитання:");
            }

            Console.WriteLine($"\nГра закінчена. Ви виграли {player.PrizeMoney} грн. Дякуємо за участь!");

        }

       
    }
    
}