
namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class DisplayBoard
    {
        private char[]        m_HorizontalCoordinates;
        private DrawBoardLine m_Draw;
        
        public char[] HorizontalCoordinates
        {
            get { return m_HorizontalCoordinates; }            
        }        
        
        public DisplayBoard() 
        {
            m_HorizontalCoordinates = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            m_Draw = new DrawBoardLine();
        }
        
        public struct DrawBoardLine
        {
            string m_longLine;
            string m_shortLine;
            string m_mediumLine;

            public string MediumLine 
            {
                get { return m_mediumLine; }
                set { m_mediumLine = value; }
            }
            public string LongLine
            {
                get { return m_longLine; }
                set { m_longLine = value; }
            }

            public string ShortLine
            {
                get { return m_shortLine; }
                set {m_shortLine = value; }
            }
        }
        
        public void DrawLineDelimeter(int i_CountOfColumns)
        {
            if (i_CountOfColumns == 6)
            {
                Console.WriteLine(m_Draw.LongLine);
            }
            else if (i_CountOfColumns == 4)
            {
                Console.WriteLine(m_Draw.ShortLine);
            }
            else 
            {
                Console.WriteLine(m_Draw.MediumLine);
            }
        }
       
        public void DrawBoard(Board board)
        {
            int countOfColumns = board.GetColumns;
            int countOfRows = board.GetRows;
            m_Draw.LongLine = "  =========================";
            m_Draw.MediumLine = "  =====================";
            m_Draw.ShortLine = "  =================";

            Console.Write("    {0}   ", m_HorizontalCoordinates[0]);
            for (int i = 1; i < countOfColumns; i++)
            {
                Console.Write("{0}   ", m_HorizontalCoordinates[i]);
            }

            Console.WriteLine();
            DrawLineDelimeter(countOfColumns);
            for (int i = 0; i < countOfRows; i++)
            {
                Console.Write("{0} |", i + 1);
                for (int j = 0; j < countOfColumns; j++)
                {
                    if (board.GetCell[i, j].CardFace == false)
                    {
                        Console.Write("   |");
                    }
                    else
                    {
                        Console.Write(" {0} |", board.GetCell[i, j].GetLetter);
                    }
                }

                Console.WriteLine();
                DrawLineDelimeter(countOfColumns);
            }
        }
    }
}
