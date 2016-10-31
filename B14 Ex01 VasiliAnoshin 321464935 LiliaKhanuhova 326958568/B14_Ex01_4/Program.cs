using System;
using System.Collections.Generic;
using System.Text;

namespace B14_Ex01_4
{
    public class Program
    {
        static void Main()
        {
            string  binaryOrder = null;
            bool    isBinary = true;
            int     decimalNumber = 0;
            char[]  charArray;  
            int     binaryLetter = 0; 

            Console.WriteLine("Please enter a string of numbers in size of 9 characters : ");
            binaryOrder = Console.ReadLine();
            charArray = binaryOrder.ToCharArray();
            for (int i = 0, j=charArray.Length-1; i < charArray.Length; i++, j--)
            {
                binaryLetter = Convert.ToInt32(charArray[j] - 48);
                decimalNumber += binaryLetter * Convert.ToInt32((Math.Pow(2,i)));
                if(!((charArray[j].Equals('0'))) && !((charArray[j].Equals('1'))))
                {                    
                    isBinary = false;
                    break;
                }
            }
            if (isBinary)
            {
                Console.Write("Input is binary representation !!!");                
                if (binaryOrder.Length == 9)
                {
                    Console.WriteLine(@"
Input length equal 9 !!!
Decimal representation of the number is {0}
If Number is a prime number : {1}", decimalNumber, isPrime(decimalNumber));
                   
                }
                else
                {
                    Console.WriteLine("Input length is not equal 9 !!!");
                }
            }
            else 
            {
                Console.WriteLine("Input is not binary representation !!!!");
            }

            Console.WriteLine("Please enter a key to exit the program.");
            Console.ReadKey();
        }
        public static bool isPrime(int i_checkForPrime) 
        {
            bool isPrime  = true;
            int boundary = Convert.ToInt32(Math.Ceiling(Math.Sqrt(i_checkForPrime)));                      
            for (int i = 2; i <= boundary; i++)
            {
                if (i_checkForPrime % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (i_checkForPrime == 1)
            {
                isPrime = false;
            }
            if (i_checkForPrime == 2)
            {
                isPrime = true;
            }
            return isPrime;
        }
    }
}
