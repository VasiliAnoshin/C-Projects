using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Automobile : FuelVehicle
    {
        private readonly eCarColor      m_CarColor;
        private const eFuelType         m_FuelType = eFuelType.Octan95;
        private const float             k_MaximalFuelCapacity = 48f;
        protected const int             k_NumberOfWheels = 4;
        private readonly eCountOfDoors  eCountOfdoors;
        private const float             k_MaxWheelAirPressure = 32;
      
        public Automobile(string i_WheelProducer, float i_CurrentAirPressure,string i_ModelOfCar, string i_License, float i_FuelorElectricyAmount, eCarColor i_Color,
            eCountOfDoors i_NumberOfDoors) : base(i_WheelProducer, i_CurrentAirPressure, i_ModelOfCar, i_License, i_FuelorElectricyAmount,
            k_NumberOfWheels, m_FuelType, k_MaximalFuelCapacity, k_MaxWheelAirPressure) 
        {           
            m_CarColor    = i_Color;
            eCountOfdoors = i_NumberOfDoors;        
        }
        public eCarColor CarColor
        {
            get { return m_CarColor; }
        }
        public eCountOfDoors ECountOfdoors
        {
            get { return eCountOfdoors; }
        }
        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }
        public float K_MaximalFuelCapacity
        {
            get { return k_MaximalFuelCapacity; }
        }
       
    }
}
