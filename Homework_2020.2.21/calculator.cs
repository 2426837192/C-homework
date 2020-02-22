using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            int Int1 = 0, Int2 = 0;
            double result = 0;

            try
            {
                Console.WriteLine("Input the first Integer:");
                Int1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Input the second Integer:");
                Int2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Input a operator:");
                string Operator = Console.ReadLine();

                switch (Operator)
                {
                    case "+":
                        result = Int1 + Int2;
                        break;
                    case "-":
                        result = Int1 - Int2;
                        break;
                    case "*":
                        result = Int1 * Int2;
                        break;
                    case "/":
                        result = Int1 / Int2;
                        break;
                    default:
                        Console.WriteLine("Invalid operator!");
                        return;
                }
                Console.WriteLine($"The result is:{result}");
            }
            
            catch(OverflowException)
            {
                Console.WriteLine("Overflow input!");
                return;
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid Input!");
                return;
            }
        }
    }
}
