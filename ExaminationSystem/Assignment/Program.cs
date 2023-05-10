using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Assignment
{

    internal class Program
    {
       
        static void Main(string[] args)
        {

             Subject Sub1 = new Subject(10, "C#");
            Sub1.CreateExam();
            Console.Clear();
            Console.WriteLine("Do You Want Start the Exam(y | n): ");
            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw= Stopwatch.StartNew();
                sw.Start();
                Sub1.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }

        }
    }
}