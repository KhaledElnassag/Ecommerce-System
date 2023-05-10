using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class FinalExam : Exams
    {
        public FinalExam(int _Time, int _NumberQuestion) : base(_Time, _NumberQuestion)
        {

        }
        public override void ShowExam()
        {
            ShowQuestionsAndUserAnswer();
            Console.Clear();
            Console.WriteLine("Your Answers");
            int totalgrade = 0, usergrade = 0;
            for (int i = 0; i < ExamQuestion.Count; i++)
            {
                int rightanswer_idx = ExamQuestion[i].Answer.Length;
                Console.WriteLine($"Q{i + 1})    {ExamQuestion[i].Body} : {ExamQuestion[i].Answer[UserAnswer[i] - 1].Text}");
                if (UserAnswer[i] == ExamQuestion[i].Answer[rightanswer_idx - 1].Id) usergrade += ExamQuestion[i].Grade;
                totalgrade += ExamQuestion[i].Grade;
            }
            Console.WriteLine($"Your Exam Grade is {usergrade} from {totalgrade}");
        }

    }
}
