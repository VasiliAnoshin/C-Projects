
namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex02.ConsoleUtils;

    public class Test
    {
        public Player ChechkForValidUserName(Player io_Player)
        {
            string playerName = null;
            playerName = Console.ReadLine();

            while (String.IsNullOrEmpty(playerName))
            {
                Screen.Clear();
                Console.WriteLine(@"You not enter the valid name , name must consist at least from a single char !
Enter the name once again");
                playerName = Console.ReadLine();
            }

            Screen.Clear();
            io_Player = new Player(playerName);

            return io_Player;                
        }

        public bool ChechForValidBoard(string i_HeightAndWidth) 
        {
            bool validInput = true;

            if ((i_HeightAndWidth.Length == 3))
            {
                if ((i_HeightAndWidth[1].Equals('X') || i_HeightAndWidth[1].Equals('x')))
                {
                    int height = Convert.ToInt32(i_HeightAndWidth[0]) - 48;
                    int width = Convert.ToInt32(i_HeightAndWidth[2]) - 48;

                    if (height < 4 || height > 6 || width < 4 || width > 6)
                    {
                        validInput = false;
                    }
                    else
                    {
                        validInput = true;
                    }
                    if (height == 5 && width == 5)
                    {
                        validInput = false;
                    }
                }
                else 
                {
                    validInput = false;
                }               
            }
            else 
            {
                validInput = false;
            }
            return validInput;
        }
    }
}
