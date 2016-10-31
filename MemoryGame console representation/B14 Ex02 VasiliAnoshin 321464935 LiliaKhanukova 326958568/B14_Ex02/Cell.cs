
namespace B14_Ex02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cell
    {
        private char m_Letter;
        private bool m_CardOnFace;
        
        public Cell(char i_Letter) 
        {
            this.m_CardOnFace = false;
            m_Letter = i_Letter;
        }
        
        public char GetLetter 
        {
            get { return this.m_Letter; }
        }
        
        public bool CardFace
        {
            get { return m_CardOnFace; }
            set { m_CardOnFace = value; }
        }
    }
}
