using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
   
    abstract class Questions
    {

        public abstract string Header { get; }
        public string Body { get; set; }
        public int Grade { get; set; }
        public   Answers[] Answer { get; set; } 
        public Questions(string _Body, int _Grade, Answers[]_answer)
        {
            Body = _Body;
            Grade = _Grade;
            Answer=_answer;
        }
        public Questions()
        {

        }

        public abstract Questions CreateQuestion();


    }




    

   
}
