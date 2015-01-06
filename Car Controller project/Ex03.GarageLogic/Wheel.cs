using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        string m_WheelProducer;
        float  m_CurrentAirPressure;
        float  m_MaximalAirPressure;

        public float MaximalAirPressure
        {
            get { return m_MaximalAirPressure; }
            set { m_MaximalAirPressure = value; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }
        public Wheel(string i_Producer, float i_CurrentAirPressure) 
        {
            m_WheelProducer = i_Producer;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }       
        public string WheelProducer
        {
            get { return m_WheelProducer; }
        }

        public void VolumeWheel(float i_AmountOfRequiredAir) 
        {
            float totalAirInWheel = i_AmountOfRequiredAir + m_CurrentAirPressure;

            if (totalAirInWheel > m_MaximalAirPressure)
            {
                throw new ArgumentException("Amount of air is more than maximum wheel capacity allowed");
            }

            m_CurrentAirPressure = totalAirInWheel;
        }

        public void VolumeWheelToMax()
        {
            VolumeWheel(m_MaximalAirPressure - m_CurrentAirPressure);
        }
    }
}
