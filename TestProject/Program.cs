using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args) {
            Class1 c1 = new Class1();
            for(int i = 0; i < 10; i++) {
                c1.ShowError();
                Console.WriteLine("Test " + i);
            }
        }
    }
}
