using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) 
        {
            float i_LitresAvailableToFill = (i_MaxValue - i_MinValue);
            string ErrorMessage = String.Format("You cannot enter thise amount of fuel/energy, you can enter to {0} litres/energy  maximum", i_LitresAvailableToFill);
            Exception e = new Exception(ErrorMessage);
            Console.WriteLine(ErrorMessage, e.Message);
            throw e;
        }

    }
}
