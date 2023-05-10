using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    abstract class Exams
    {
        public int Time { get; set; }
        public int NumberQuestion { get; set; }
        public List<Questions> ExamQuestion { get; set; }
        public List<int> UserAnswer { get; set; }
        public Exams(int _Time,int _NumberQuestion)
        {
            Time= _Time;
            NumberQuestion = _NumberQuestion;
            ExamQuestion = new List<Questions>(_NumberQuestion);
            UserAnswer = new List<int>(_NumberQuestion);
        }
        public void ShowQuestionsAndUserAnswer()
        {
            Console.Clear();

            for (int i = 0; i < ExamQuestion.Count; i++)
            {
                Console.WriteLine(ExamQuestion[i].ToString());
                int useranswer;
                int.TryParse(Console.ReadLine(),out useranswer);
                UserAnswer.Add(useranswer);
                Console.WriteLine("================================================================");
            }
        }

        public abstract void ShowExam();

    }

   
   
}
