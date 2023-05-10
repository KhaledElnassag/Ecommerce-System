using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Answers
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Answers()
        {

        }
        public Answers(int _Id, string _Text) : this()
        {
            Id = _Id;
            Text = _Text;
        }
    }
}
