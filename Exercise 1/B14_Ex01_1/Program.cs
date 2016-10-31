using System;
using System.Collections.Generic;
using System.Text;

namespace B14_Ex01_1
{
    public class Program
    {
        static void Main()
        {
            int     inputNumber  = 0;           
            int     higherNumber = Int32.MinValue;
            int     lowerNumber  = Int32.MaxValue;
            int     counter = 0;
            decimal average = 0;
            int     sum = 0;
            int     firstNumber = 0;
            int     countOfNumbersDividableByFirstNumber = 0;
            bool    result = true;
            string  msg = null;
            
            Console.WriteLine("Please enter the positive and whole number : ");
            while (inputNumber != -1)
            {                
                result = Int32.TryParse(Console.ReadLine(), out inputNumber);
                if (result)
                {
                    if (inputNumber > 0)
                    {
                        if (counter == 0) 
                        {
                            firstNumber = inputNumber; 
                        }
 
                        sum += inputNumber;                                             
                        if (higherNumber < inputNumber)
                        {
                            higherNumber = inputNumber;
                        }
                        if (inputNumber < lowerNumber)
                        {
                            lowerNumber = inputNumber;      
                        }
                        if (inputNumber % firstNumber == 0 && counter != 0) 
                        {
                            countOfNumbersDividableByFirstNumber++;
                        }

                        counter++;  
                    }
                    else 
                    {
                        if (inputNumber != -1)
                        {
                            Console.WriteLine("Number is not a positive !!!");                           
                        }

                        continue;
                    }                      
                }
                else 
                {
                    Console.WriteLine("The entered value is not an integer number ! ");
                    continue;
                }
            }

            average = (Convert.ToDecimal(sum) / counter);
            msg = string.Format(@"
Higher number is  : {0}
Lower number is   : {1}
Amount of numbers : {2}
Average           : {3}
How many numbers divide first number without division : {4}",
                higherNumber, lowerNumber, counter, average, countOfNumbersDividableByFirstNumber);
            
            Console.WriteLine(msg);
            Console.ReadLine();
        }

    }
}
    


