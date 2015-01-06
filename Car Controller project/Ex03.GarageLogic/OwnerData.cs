using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class OwnerData
    {
        private string        m_OwnersName;
        private int           m_TelefonNumber;
        private eVecihleState eVecihleStates;        
        private Vehicle       m_Vecihle;

        public Vehicle GetVecihle
        {
            get { return m_Vecihle; }
            set { m_Vecihle = value; }
        }
                
        public OwnerData(string i_OwnerName, int i_TelNumber, Vehicle i_Vehicle) 
        {
            eVecihleStates  = eVecihleState.Repairing;
            m_OwnersName    = i_OwnerName;
            m_TelefonNumber = i_TelNumber;
            m_Vecihle       = i_Vehicle;
        }

        public eVecihleState EVecihleStates
        {
            get { return eVecihleStates; }
            set { eVecihleStates = value; }
        }

        public string getOwnersName()
        {
            return m_OwnersName;
        }

        public int getTelefonNumber()
        {
            return m_TelefonNumber;
        }

    }
}
