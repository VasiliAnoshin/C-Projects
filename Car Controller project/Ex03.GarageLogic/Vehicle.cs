using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string        m_ModelName;
        protected string        m_LicenseNumber;
        protected List<Wheel>   m_SetOfWheels;
        private float           m_FuelOrElectricityRemainInEnergySaurce;

        protected float FuelOrElectricityRemainInEnergySaurce
        {
            get { return m_FuelOrElectricityRemainInEnergySaurce;  } 
            set { m_FuelOrElectricityRemainInEnergySaurce = value; }
        }

        public Vehicle(string i_WheelProducer, float i_CurrentAirPressure, string i_ModelOfCar, string i_License, float i_FuelorElectricyAmount, int i_CountOfWheel)
        {
            m_ModelName     = i_ModelOfCar;
            m_LicenseNumber = i_License;
            m_FuelOrElectricityRemainInEnergySaurce = i_FuelorElectricyAmount;
            m_SetOfWheels = new List<Wheel>(i_CountOfWheel);
            
            for (int i = 0; i < i_CountOfWheel; i++)
            {
                m_SetOfWheels.Add(new Wheel(i_WheelProducer, i_CurrentAirPressure));
            }
        }

        public string GetModelName 
        {
            get { return m_ModelName; }
        }

        public string GetLicencePlate 
        {
            get { return m_LicenseNumber; }
        }

        public List<Wheel> getWheels
        {
            get { return m_SetOfWheels; }
        }
        public float getEnergyState
        {
            get { return m_FuelOrElectricityRemainInEnergySaurce; }
        }
    }
}
