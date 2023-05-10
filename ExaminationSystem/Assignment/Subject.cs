using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exams Exam { get; set; }
        public Subject(int _SubjectId, string _SubjectName)
        {
            SubjectId = _SubjectId;
            SubjectName = _SubjectName;
        }

        
        public void CreateExam()
        {
            Console.Write("Please Enter Type Of Exam You Want To Create(1 for Practical and 2 for Final):");
            int E_choice, Time, Number_Question;
            int.TryParse(Console.ReadLine(), out E_choice);
            Console.Write("Please Enter Time Of Exam in Minutes: ");
            int.TryParse(Console.ReadLine(), out Time);
            Console.Write("Please Enter The Number of the Questions You Want to Create: ");
            int.TryParse(Console.ReadLine(), out Number_Question);
            Console.Clear();
            Questions QuestionType;

            if (E_choice == 1)
            {
                Exam = new PracticalExam(Time, Number_Question);

                for (int i = 0; i < Number_Question; i++)
                {
                    QuestionType = new Mcq();
                    Exam.ExamQuestion.Add((Mcq)QuestionType.CreateQuestion());
                    Console.Clear();

                }

            }
            else if (E_choice == 2)
            {

                Exam = new FinalExam(Time, Number_Question);
               

                for (int i = 0; i < Number_Question; i++)
                {
                    int Ques_Type;
                    Console.Write($"Please Enter the Type Of Question{i+1}(1 for True or False 2 for Mcq):");

                    int.TryParse(Console.ReadLine(), out Ques_Type);
                    Console.Clear();


                    if (Ques_Type == 1)
                    {
                        QuestionType = new TOrF();
                        Exam.ExamQuestion.Add( (TOrF)QuestionType.CreateQuestion() );
                    }
                    else if(Ques_Type == 2)
                    {
                        QuestionType = new Mcq();
                        Exam.ExamQuestion.Add( (Mcq)QuestionType.CreateQuestion());
                    }
                    Console.Clear();
                }


            }
        }
    }
}