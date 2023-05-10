using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class TOrF : Questions
    {
        public override string Header { get { return "True | False Question"; } }
        public TOrF()
        {

        }
        public TOrF(string _Body, int _Grade, Answers Right_Answers) : base(_Body, _Grade, new Answers[3] { new Answers(1, "True"), new Answers(2, "False"), Right_Answers })
        {

        }
        public override string ToString()
        {
            return $"{Header}    Marks({Grade})\n{Body}\n1. True                   2. False\n------------------------------------------";
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
            Console.WriteLine("Please Enter the Right Answer Of Question(1 for True 2 for False):");
            int.TryParse(Console.ReadLine(), out rightanswer);
            this.Body = body;
            this.Grade = mark;
            this.Answer = new Answers[3] { new Answers(1, "True"), new Answers(2, "False"), new Answers(rightanswer, rightanswer == 1 ? "True" : "False") };

            return this;
        }

    }

}
