using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassList
{
    class Program
    {
        class MyClass
        {
            int x = 4;
        }
        static void Main(string[] args)
        {
            CustomList<int> Run = new CustomList<int>();
            Run.Add(1);
            Run.Add(2);
            Run.Add(3);
            Console.WriteLine(Run.ToString());
            Console.ReadLine();

            CustomList<int> Walk = new CustomList<int>();
            Walk.Add(9);
            Walk.Add(8);
            Walk.Add(7);
            Console.WriteLine(Walk.ToString());
            Console.ReadLine();

            CustomList<int> Jog = Walk + Run;
            Console.WriteLine(Jog.ToString());
            Console.ReadLine();

            CustomList<int> Test = new CustomList<int>();
            Test.Add(1);
            Test.Add(3);
            Test.Add(5);
            Console.WriteLine(Test.ToString());
            Console.ReadLine();

            CustomList<int> Test2 = new CustomList<int>();
            Test2.Add(2);
            Test2.Add(1);
            Test2.Add(6);
            Test = Test - Test2; //syntax ClssList = ClassList - ClassList
            Console.WriteLine(Test.ToString());
            Console.ReadLine();

            Test = CustomList<int>.ZIPO(Run, Walk);
            Console.WriteLine(Test.ToString());
            Console.ReadLine();



        }
    }
}
