using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Mcq : Questions
    {
        public override string Header { get { return "Choose One Answer Question"; } }
        public Mcq(string _Body, int _Grade, Answers[] _Answers) : base(_Body, _Grade, _Answers)
        {

        }
        public Mcq()
        {

        }
        public override string ToString()
        {
            return $"{Header}    Marks({Grade})\n{Body}\n1. {Answer[0].Text}                   2. {Answer[1].Text}                   3. {Answer[2].Text}\n------------------------------------------";
        }
        public override Questions CreateQuestion()
        {
            string body;
            int mark, rightanswer;
            Console.WriteLine(Header);
            Console.WriteLine("Please Enter the Body Of Question:");
            body = Console.ReadLine();

            Console.WriteLine("Please Enter the Marks Of Question:");
            int.TryParse(Console.ReadLine(), out mark);
            Answers[] mcq = new Answers[4];
            Console.WriteLine("the Choices Of Question:");
            for (int j = 0; j < 3; j++)
            {
                string ch;
                Console.Write($"Please Enter the Choice Number {j + 1}:");
                ch = Console.ReadLine();
                mcq[j] = new Answers(j + 1, ch);
            }
            Console.WriteLine("Please Enter the Right Answer Of Question:");
            int.TryParse(Console.ReadLine(), out rightanswer);
            mcq[3] = mcq[rightanswer - 1];
            this.Body = body;
            this.Grade = mark;
            this.Answer = mcq;
            return this;

        }
    }
}
