using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_project
{
    class Player
    {
        public int QuestionLevel { get; set; }
        public int PrizeMoney { get; set; }

        public Player()
        {
            QuestionLevel =  1;
            PrizeMoney = 0;
        }

        public void IncrementQuestionLevel()
        {
            QuestionLevel++;
        }

        public void IncreasePrizeMoney(int amount)
        {
            PrizeMoney += amount;
        }
    }
}
