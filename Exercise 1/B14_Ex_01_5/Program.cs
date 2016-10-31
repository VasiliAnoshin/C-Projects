using System;
using System.Collections.Generic;
using System.Text;

namespace B14_Ex_01_5
{
    public class Program
    {
        static void Main() 
        {
            String  inputString = null;
            short   countOfLetters = 0;
            short   countOfCapitalLetters = 0;
            short   countOfSpaces = 0;
            short   countOfDigits = 0;           

            Console.WriteLine("Please enter some string : ");
            inputString = Console.ReadLine();
            foreach (char c in inputString)
            {                
                if (Char.IsWhiteSpace(c))
                {
                    countOfSpaces++;
                }
                if (Char.IsDigit(c))
                {
                    countOfDigits++;
                }
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    if (Char.IsLower(c)) 
                    {
                        countOfLetters++;
                    }
                    if (Char.IsUpper(c)) 
                    {
                        countOfCapitalLetters++;
                    }
                }
            }
            String msg = string.Format(
@"Count of letters           : {0} 
Count of capital Letters   : {1}   
Count of Spaces            : {2}
Count of digits            : {3}", 
                   countOfLetters, countOfCapitalLetters, countOfSpaces, countOfDigits);
            
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}
