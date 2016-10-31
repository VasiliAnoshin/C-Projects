
namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex02.ConsoleUtils;


    public class UserInterface
    {
        static void Main(string[] args)
        {
            int        m_Height = 0;
            int        m_Width = 0;
            Controller m_Control = null;
            bool       m_ValidChoice = true;
            string     m_GameOpponent = String.Empty;
            int        m_GameChoice = 0;
            bool       m_InputIsNumber = true;
            Player     m_PlayerTwo = null;
            Player     m_PlayerOne = null;
            Test       m_Test = null;
            bool       m_EndGame = false;
            string     m_ChoiceOfTheUserToContinue = null;
            bool       m_QuitTheGame = false;

            m_Test = new Test();
            Console.WriteLine("Hello , welcome to memory game !!! Please enter your name , and press enter : ");
            m_PlayerOne = m_Test.ChechkForValidUserName(m_PlayerOne);                      
            Console.WriteLine(@"Please select (1 or 2) the style of the game , and then press enter : 
1) Against the computer 
2) Two Players");
            m_GameOpponent = Console.ReadLine();           
            m_InputIsNumber = Int32.TryParse(m_GameOpponent, out m_GameChoice);
            while (m_ValidChoice)
            {
                if (m_GameChoice < 1 || m_GameChoice > 2 || !m_InputIsNumber)
                {
                    Screen.Clear();
                    Console.WriteLine(@"Wrong choice! Please reenter ! Select (1 or 2) the style of the game , and then press enter : 
1) Against the computer 
2) Two Players");
                    m_GameOpponent = Console.ReadLine();
                    m_InputIsNumber = Int32.TryParse(m_GameOpponent, out m_GameChoice);
                }
                else 
                {
                    m_ValidChoice = false;
                }
                Screen.Clear();
            }
            if (m_GameChoice == 2)
            {
                Console.WriteLine("Please enter the name of second player , and then press enter.");
                m_PlayerTwo = m_Test.ChechkForValidUserName(m_PlayerTwo);
            }

            Screen.Clear();
            while (!m_EndGame)
            {
                Console.WriteLine(@"Please enter the height and width of the board , minimum 4x4 and maximum 6x6,
required amount of double slots test.ChechkForValidUserName(playerOne);
Please enter the HEIGHTxWIDTH : ");
                string validBoardCoordinates = Console.ReadLine();
                while (!m_Test.ChechForValidBoard(validBoardCoordinates))
                {
                    Console.WriteLine("Wrong coordinates , Please enter HeightXWidth of the board : ");
                    validBoardCoordinates = Console.ReadLine();
                    Screen.Clear();
                }

                m_Height = Convert.ToInt32(validBoardCoordinates[0]) - 48;
                m_Width  = Convert.ToInt32(validBoardCoordinates[2]) - 48;
                Screen.Clear();
                if (m_GameChoice == 2)
                {
                    m_Control = new Controller(m_PlayerOne, m_PlayerTwo, m_Height, m_Width, m_GameChoice);
                    m_QuitTheGame = m_Control.StartGame();
                }
                if (m_GameChoice == 1)
                {
                    m_PlayerTwo = new Player("computer");
                    m_Control = new Controller(m_PlayerOne, m_PlayerTwo, m_Height, m_Width, m_GameChoice);
                    m_QuitTheGame = m_Control.StartGame();
                }
                if (m_QuitTheGame)
                {
                    Console.WriteLine("Bye bye !");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine(@"Do you want another play ?
1)yes
2)no");
                m_ChoiceOfTheUserToContinue = Console.ReadLine();
                if (!(m_ChoiceOfTheUserToContinue.Equals("YES") || m_ChoiceOfTheUserToContinue.Equals("yes")
                    || m_ChoiceOfTheUserToContinue.Equals("1")))
                {
                    m_EndGame = true;
                    Console.WriteLine("It was a good game. Bye bye bye ! ");
                    Console.ReadKey();
                }
                else 
                {
                    Screen.Clear();
                    Console.WriteLine("Lets play , yeah ! ");
                }
            }
        }                

    }
}
