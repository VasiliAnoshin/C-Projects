
namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex02.ConsoleUtils;
    using System.Collections;

    public class Controller
    {
        static int                s_CounterX;
        static int                s_CounterY;
        bool                      m_checkInput;
        bool                      m_CheckInput2;
        private eOpponent         m_GameOpponent;
        private Player            m_FirstPlayer;
        private Player            m_SecondPlayer;
        private int[]             m_CoordinatesX;
        private int[]             m_CoordinatesY;
        private ArrayList         m_PoolOfCells;
        private List<Coordinates> m_BufferForTimeCoordinates;
        private Board             m_Board;
        enum    eOpponent 
        { 
            Computer = 1, 
            User = 2 
        }
        bool                      m_ExitRequired;
        Player                    m_CurrentPlayer;
        string                    m_ExitGame;
        ArrayList                 m_ListOfRandomCoordinates;
        string                    m_FirstCoordinate;
        string                    m_SecondCoordinate; 

        private eOpponent GameOpponent
        {
            get { return m_GameOpponent; }
        } 
      
        public Board Board
        {
            get { return m_Board; }
        } 
          
        public Controller(Player io_Player1 , Player io_player2, int i_HeightCoordinates, int i_WidthCoordinates, int i_Rival)
        {
            m_ExitGame = string.Empty;
            m_FirstCoordinate = string.Empty;
            m_SecondCoordinate = string.Empty;
            m_checkInput = false;
            m_CheckInput2 = false;
            s_CounterX = 0;
            s_CounterY = 0;
            this.m_CoordinatesX = new int[2];
            this.m_CoordinatesY = new int[2];
            m_FirstPlayer = io_Player1;
            m_SecondPlayer = io_player2;
            m_ExitRequired = false;
            m_Board = new Board(i_HeightCoordinates, i_WidthCoordinates); 
           
            if(i_Rival == (int)eOpponent.Computer)
            {
                m_GameOpponent = eOpponent.Computer;
            }
            else
            {
                m_GameOpponent = eOpponent.User;
            }
        }
        
        public bool StartGame() 
        {                       
            m_Board.PositionsCells();
            DisplayBoard display = new DisplayBoard();
            if (GameOpponent.Equals(eOpponent.User))
            {
                GameAgainstPlayer(display);
            }
            else 
            {
                GameAgainstComputer(display);
            }

            return m_ExitRequired;
        }        

        public Player FirstPlayer
        {
            get { return m_FirstPlayer; }            
        }
        
        public Player SecondPlayer
        {
            get { return m_SecondPlayer; }            
        }        
        
        public bool testForCorrectInput(string i_Input , DisplayBoard io_Display) 
        {
            bool correct = false;

            if (i_Input.Length == 2)
            {
                for (int i = 0; i < m_Board.GetColumns; i++)
                {
                    if (i_Input[0].Equals(io_Display.HorizontalCoordinates[i]) && i_Input.Length == 2)
                    {
                        correct = true;
                        break;
                    }
                }
                if (((i_Input[1] - 48) < 1) || (i_Input[1] - 48) > Board.GetRows)
                {
                    correct = false;
                }
            }

            return correct;
        }
        
        public int  getNumericValueOfHorizontalCoordinate(string i_HorizontalCoordinate) 
        {
            int value = 0;

            return value;
        }        
        
        public void GameAgainstPlayer(DisplayBoard io_Display) 
        {            
            Board board = Board;
            m_CurrentPlayer = FirstPlayer;

            while (!GameOver() && !m_ExitRequired)
            {               
                while (!m_checkInput && !m_ExitRequired)
                {
                    m_FirstCoordinate = ReadCoordinate(io_Display, board, m_CurrentPlayer);
                    if (m_FirstCoordinate.Equals("q") || m_FirstCoordinate.Equals("Q"))
                    {
                        m_ExitRequired = true;
                    }
                    else
                    { 
                        m_checkInput = testForCorrectInput(m_FirstCoordinate.ToUpper(), io_Display);
                        if (m_checkInput)
                        {
                            Screen.Clear();
                            UserMove(board, m_FirstCoordinate.ToUpper(), io_Display);
                            while (!m_CheckInput2 && !m_ExitRequired)
                            {
                                m_SecondCoordinate = ReadSecondCoordinate(io_Display, board, m_CurrentPlayer);
                                if (m_SecondCoordinate.Equals("q") || m_SecondCoordinate.Equals("Q")) 
                                {
                                    m_ExitRequired = true;
                                }
                                else 
                                {                                
                                    m_CheckInput2 = testForCorrectInput(m_SecondCoordinate.ToUpper(), io_Display);
                                    if (m_CheckInput2)
                                    {
                                        Screen.Clear();
                                        UserMove(board, m_SecondCoordinate.ToUpper(), io_Display);
                                        if (Board.GetCell[m_CoordinatesX[0], m_CoordinatesY[0]].GetLetter.Equals
                                                (Board.GetCell[m_CoordinatesX[1], m_CoordinatesY[1]].GetLetter))
                                        {
                                             RightGuess(m_CurrentPlayer, board, io_Display, m_ExitGame);   
                                        }
                                        else
                                        {
                                            m_CurrentPlayer = WrongGuessForPlayer(io_Display, board, m_CurrentPlayer, m_ExitGame);
                                        }
                                    }
                                    else
                                    {
                                        MessageAboutInvalidcoordinates(m_SecondCoordinate, io_Display, board);
                                    }
                                }
                            }
                        }
                        else
                        {                            
                            MessageAboutInvalidcoordinates(m_FirstCoordinate, io_Display, board);
                        }
                    }
            }
   
                m_checkInput = false;
                m_CheckInput2 = false;                
                Screen.Clear();
            }
            if (!m_ExitRequired)
            {
                PrintTheWinner(FirstPlayer, SecondPlayer);
            }
        }        
        
        public void PrintTheWinner(Player io_PlayerOne , Player io_PlayerTwo) 
        {
            if (m_FirstPlayer.Score > m_SecondPlayer.Score)
            {
                Console.WriteLine("Congratulations to {0}!!! He is the winner of the game !!!!", m_FirstPlayer.GetPlayerName);
            }
            else if (m_SecondPlayer.Score > m_FirstPlayer.Score)
            {
                Console.WriteLine("Congratulations to {0}!!! He is the winner of the game !!!!", m_SecondPlayer.GetPlayerName);
            }
            else 
            {
                Console.WriteLine(" DRAW !!!!!");
            }           
        }
        
        public void GameAgainstComputer(DisplayBoard display)
        {          
            Board       board = Board;
            Player      currentPlayer = FirstPlayer;
            int         turn = 2;
            Coordinates CoordinateA;
            Coordinates CoordinateB;

            CreateArrayOfCoordinates();
            while (!GameOver() && !m_ExitRequired)
            {
                if (turn == (int)eOpponent.User)
                {
                    while (!m_checkInput && !m_ExitRequired)
                    {
                        m_FirstCoordinate = ReadCoordinate(display, board, currentPlayer);
                        if (m_FirstCoordinate.Equals("q") || m_FirstCoordinate.Equals("Q"))
                        {
                            m_ExitRequired = true;
                        }
                        else
                        {
                            m_checkInput = testForCorrectInput(m_FirstCoordinate.ToUpper(), display);
                            if (m_checkInput)
                            {
                                UserMove(board, m_FirstCoordinate.ToUpper(), display);
                                while (!m_CheckInput2 && !m_ExitRequired)
                                {

                                    m_SecondCoordinate = ReadSecondCoordinate(display, board, currentPlayer);
                                    if (m_SecondCoordinate.Equals("q") || m_SecondCoordinate.Equals("Q"))
                                    {
                                        m_ExitRequired = true;
                                    }
                                    else
                                    {
                                        m_CheckInput2 = testForCorrectInput(m_SecondCoordinate.ToUpper(), display);
                                        if (m_CheckInput2)
                                        {
                                            Screen.Clear();
                                            UserMove(board, m_SecondCoordinate.ToUpper(), display);
                                            if (Board.GetCell[m_CoordinatesX[0], m_CoordinatesY[0]].GetLetter.Equals
                                                    (Board.GetCell[m_CoordinatesX[1], m_CoordinatesY[1]].GetLetter))
                                            {
                                                CoordinateA = new Coordinates(m_CoordinatesX[0], m_CoordinatesY[0]);
                                                CoordinateB = new Coordinates(m_CoordinatesX[1], m_CoordinatesY[1]);
                                                PlayerGuessRigthAgainstComputer(board, display, CoordinateA, CoordinateB, currentPlayer);
                                            }
                                            else
                                            {
                                                Screen.Clear();
                                                turn = 1;
                                                display.DrawBoard(board);
                                                Console.WriteLine("Wrong answer , try again later !!! Press any key to continue , q for exit");
                                                currentPlayer = PlayerGuessWrongAgainstComputer(currentPlayer);
                                            }
                                        }
                                        else
                                        {
                                            MessageAboutInvalidcoordinates(m_SecondCoordinate, display, board);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageAboutInvalidcoordinates(m_FirstCoordinate, display, board);
                            }
                        }                                                
                    }

                    m_checkInput = false;
                    m_CheckInput2 = false;
                    Screen.Clear();
                }
                else
                {
                    Screen.Clear();
                    m_ListOfRandomCoordinates = ChooseRandomCell();
                    CoordinateA = (Coordinates)m_ListOfRandomCoordinates[0];
                    board.GetCell[CoordinateA.CoordinateX, CoordinateA.CoordinateY].CardFace = true;
                    display.DrawBoard(board);                   
                    Console.WriteLine(@"Now is Computer turn !!! This is a first choise of computer . 
Press enter to continue. Or press q to exit");
                    if (Console.ReadLine().Equals("q"))
                    {
                        Screen.Clear();
                        m_ExitRequired = true;
                    }
                    else
                    {
                        Screen.Clear();
                        m_ListOfRandomCoordinates = ChooseRandomCell();
                        CoordinateB = (Coordinates)m_ListOfRandomCoordinates[0];
                        board.GetCell[CoordinateB.CoordinateX, CoordinateB.CoordinateY].CardFace = true;
                        display.DrawBoard(board);
                        Console.WriteLine("Second choice of Computer ! Press any key to continue : ");
                        if (board.GetCell[CoordinateA.CoordinateX, CoordinateA.CoordinateY].GetLetter.
                            Equals(board.GetCell[CoordinateB.CoordinateX, CoordinateB.CoordinateY].GetLetter))
                        {
                            Console.WriteLine("Rigth guess for computer !!! Press any key to continue , for exit press q");
                            currentPlayer.Score++;
                            if (Console.ReadLine().Equals("q"))
                            {
                                Screen.Clear();
                                m_ExitRequired = true;
                            }
                        }
                        else
                        {
                            turn = 2;
                            Console.WriteLine("Wrong guess ! Turn pass to user ! For exit press q ");
                            if (Console.ReadLine().Equals("q")) 
                            {
                                Screen.Clear();
                                m_ExitRequired = true;
                            }
                            currentPlayer = ComputerGuessWrong(board, CoordinateA, CoordinateB, currentPlayer);
                        }
                    }
                }
            }
            if (!m_ExitRequired)
            {
                PrintTheWinner(m_FirstPlayer, m_SecondPlayer);
            }
        }               
        
        public ArrayList ChooseRandomCell() 
        {
            ArrayList list = new ArrayList();
            int indexOfRandomCoordinate = 0;
            m_BufferForTimeCoordinates = new List<Coordinates>();
            Random randNumberGenerator = new Random();

            indexOfRandomCoordinate  = randNumberGenerator.Next(0, m_PoolOfCells.Count);
            Coordinates Coordinate = (Coordinates)m_PoolOfCells[indexOfRandomCoordinate];
            m_BufferForTimeCoordinates.Add(Coordinate);
            m_PoolOfCells.Remove(Coordinate);
            list.Add(Coordinate);
            
            return list;
        }
        
        public void CreateArrayOfCoordinates()
        {
            Coordinates boardCoordinates;
            m_PoolOfCells = new ArrayList();

            for (int i = 0; i < m_Board.GetRows; i++)
            {
                for (int j = 0; j < m_Board.GetColumns; j++)
                {
                    boardCoordinates = new Coordinates(i,j);
                    m_PoolOfCells.Add(boardCoordinates);
                }
            }
        }
        
        public Player NextPlayer(Player io_Next) 
        {
            if (io_Next == FirstPlayer)
            {
                io_Next = SecondPlayer;
            }
            else 
            {
                io_Next = FirstPlayer;
            }
            return io_Next;
        }
        
        public bool GameOver() 
        {
            bool boardComplete = true;

            for (int i = 0; i < Board.GetRows; i++)
            {
                if (!boardComplete)
                {
                    break;
                }
                else
                {
                    for (int j = 0; j < Board.GetColumns; j++)
                    {
                        if (Board.GetCell[i, j].CardFace == false)
                        {
                            boardComplete = false;
                            break;
                        }
                    }
                }
            }

            return boardComplete;
        }
        
        public void SaveCell(int i_Row, int i_Column) 
        {
            m_CoordinatesX[s_CounterY++] = i_Row;
            m_CoordinatesY[s_CounterX++] = i_Column;
        }
        
        public void UserMove(Board io_Board, string i_Coordinate, DisplayBoard io_Display) 
        {
            int indexColumn = 0;
            int indexRow = Convert.ToInt32(i_Coordinate[1]-49);

            for (int i = 0; i < io_Board.GetColumns; i++)
            {
                if(i_Coordinate[0].Equals(io_Board.HorizontalCoordinates[i]))
                {
                    indexColumn = i;
                    SaveCell(indexRow, indexColumn);
                    break;
                }
            }
            io_Board.GetCell[indexRow, indexColumn].CardFace = true;
            io_Display.DrawBoard(io_Board);
        }
        
        public struct Coordinates 
        {
            int m_coordinateX;            
            int m_coordinateY;

            public int CoordinateX
            {
                get { return m_coordinateX; }
                set { m_coordinateX = value; }
            }
            public int CoordinateY
            {
                get { return m_coordinateY; }
                set { m_coordinateY = value; }
            }

            public Coordinates(int x, int y) 
            {
                m_coordinateX = x;
                m_coordinateY = y;
            }
        }
        
        public void RightGuess(Player io_CurrentPlayer, Board io_Board, DisplayBoard io_Display, string i_Exit) 
        {
            Screen.Clear();
            io_CurrentPlayer.Score += 1;
            io_Display.DrawBoard(io_Board);
            Console.WriteLine(@"Congratulation {0}!!! You succcesfully guessed choosen compbination ! 
Press any key to continue ! For exit press q !", io_CurrentPlayer.GetPlayerName);
            i_Exit = Console.ReadLine();
            if (i_Exit.Equals("q") || i_Exit.Equals("Q"))
            {
                m_ExitRequired = true;
            }

            io_Display.DrawBoard(io_Board);
            s_CounterX = 0;
            s_CounterY = 0;
        }
        
        public Player WrongGuessForPlayer(DisplayBoard io_Display, Board io_Board, Player io_CurrentPlayer, string i_Exit) 
        {
            Screen.Clear();
            io_Display.DrawBoard(io_Board);
            io_CurrentPlayer = NextPlayer(io_CurrentPlayer);
            Console.WriteLine("Wrong answer , Try again later !!! Press any key to continue . Press q for exit");
            i_Exit = Console.ReadLine();
            if (i_Exit.Equals("q") || i_Exit.Equals("Q"))
            {
                m_ExitRequired = true;
            }

            Board.GetCell[m_CoordinatesX[0], m_CoordinatesY[0]].CardFace = false;
            Board.GetCell[m_CoordinatesX[1], m_CoordinatesY[1]].CardFace = false;
            s_CounterX = 0;
            s_CounterY = 0;

            return io_CurrentPlayer;
        }
        
        public void MessageAboutInvalidcoordinates(string i_coordinate , DisplayBoard io_display, Board io_board) 
        {
            Screen.Clear();
            io_display.DrawBoard(io_board);
            Console.WriteLine(@"You choose invalid option ,{0} is not existing !!!! Try once again , 
for continue press enter!", i_coordinate);
            Console.ReadKey();
            Screen.Clear();
        }
        
        public Player ComputerGuessWrong(Board io_Board, Coordinates io_CoordinateA, Coordinates io_CoordinateB, Player io_CurrentPlayer) 
        {
            io_CurrentPlayer = NextPlayer(io_CurrentPlayer);
            io_Board.GetCell[io_CoordinateA.CoordinateX, io_CoordinateA.CoordinateY].CardFace = false;
            io_Board.GetCell[io_CoordinateB.CoordinateX, io_CoordinateB.CoordinateY].CardFace = false;
            m_PoolOfCells.Add(io_CoordinateA);
            m_PoolOfCells.Add(io_CoordinateB);
            Screen.Clear();

            return io_CurrentPlayer;
        }
        
        public void PlayerGuessRigthAgainstComputer(Board io_Board, DisplayBoard io_Display, Coordinates io_CoordinateA, Coordinates io_CoordinateB, Player io_CurrentPlayer) 
        {
            Screen.Clear();
            io_CurrentPlayer.Score += 1;
            io_Display.DrawBoard(io_Board);
            Console.WriteLine(@"Congratulation {0}!!! You succcesfully guessed choosen compbination ! 
Press any key to continue ! Press q for exit !", io_CurrentPlayer.GetPlayerName);
            m_ExitGame = Console.ReadLine();
            if (m_ExitGame.Equals("q") || m_ExitGame.Equals("Q"))
            {
                m_ExitRequired = true;
            }

            io_Display.DrawBoard(io_Board);
            s_CounterX = 0;
            s_CounterY = 0;
            m_PoolOfCells.Remove(io_CoordinateA);
            m_PoolOfCells.Remove(io_CoordinateB);
        }
        
        public Player PlayerGuessWrongAgainstComputer(Player io_CurrentPlayer) 
        {
            m_ExitGame = Console.ReadLine();
            if (m_ExitGame.Equals("q") || m_ExitGame.Equals("Q"))
            {
                m_ExitRequired = true;
            }

            Board.GetCell[m_CoordinatesX[0], m_CoordinatesY[0]].CardFace = false;
            Board.GetCell[m_CoordinatesX[1], m_CoordinatesY[1]].CardFace = false;
            s_CounterX = 0;
            s_CounterY = 0;
            io_CurrentPlayer = NextPlayer(io_CurrentPlayer);

            return io_CurrentPlayer;
        }
        
        public string ReadCoordinate(DisplayBoard io_display, Board io_Board, Player io_CurrentPlayer) 
        {
            io_display.DrawBoard(io_Board);
            Console.WriteLine("Your turn : {0} ! Choose the first sloat you want to expose (for example : A1, B2) . For exir press Q",
                                io_CurrentPlayer.GetPlayerName);

            return  Console.ReadLine();
        }
        
        public string ReadSecondCoordinate(DisplayBoard io_Display, Board io_Board, Player io_CurrentPlayer) 
        {
            Screen.Clear();
            io_Display.DrawBoard(io_Board);
            Console.WriteLine(@"Your turn : {0} ! Choose the second sloat you want to expose 
(for example : B3, E2) ! for exir press q !", io_CurrentPlayer.GetPlayerName);

            return Console.ReadLine();
        }
    }
}
