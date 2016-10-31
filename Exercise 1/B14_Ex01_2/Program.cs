using System;
using System.Collections.Generic;
using System.Text;

namespace B14_Ex01_2
{  
    public class Program
    {
        static void Main()
        {            
            string  asteriskOutput = GetAsterics(5);
            Console.WriteLine(asteriskOutput);
            Console.ReadLine();
        }

        public static string GetAsterics(int sizeOfRhombus)
        {
            int iIndex = sizeOfRhombus / 2;
            int jIndex = sizeOfRhombus / 2;
            StringBuilder asteriskStringBuilder = new StringBuilder();            
            
            if((sizeOfRhombus % 2).Equals(0))
            {
                sizeOfRhombus++;
            }             
            for (int row = 0; row < sizeOfRhombus; row++)
            {
                for (int column = 0; column <= sizeOfRhombus; column++)
                {
                    if (column < iIndex || column > jIndex)
                    {
                        asteriskStringBuilder.Append(" ");
                    }
                    else 
                    {
                        asteriskStringBuilder.Append("*");
                    }                                                
                }
                if (row <= (sizeOfRhombus / 2)-1)
                {
                    iIndex--;
                    jIndex++;
                }
                if(row >= sizeOfRhombus / 2 )
                {
                    iIndex++;
                    jIndex--;
                }

                asteriskStringBuilder.Append("\n");
            }

            return asteriskStringBuilder.ToString();
        } 
    }
}
