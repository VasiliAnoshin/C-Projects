using System;
using System.Collections.Generic;
using System.Text;

namespace B14_Ex01_3
{
    public class Program
    {
        static void Main()
        {
            int     numbOfRows = 0;
            bool    isTrue = true;
            string  output = null; 

            Console.WriteLine("Please enter number of rows in the rhombus");
            isTrue = Int32.TryParse(Console.ReadLine(), out numbOfRows);
            if (isTrue && numbOfRows > 0)
            {
                output = B14_Ex01_2.Program.GetAsterics(numbOfRows);
                Console.WriteLine(output);                
            }
            else
            {
                Console.WriteLine("Input is in wrong format ");
            }
            Console.ReadLine();
        }
    }
}
