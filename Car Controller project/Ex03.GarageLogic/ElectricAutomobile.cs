using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricAutomobile : ElectricVehicle
    {
        private const float   k_BattaryMaxCapacity = 1.8f;
        private eCarColor     eCarColor;
        protected const int   k_NumberOfWheels = 4;
        private const float   k_MaxWheelAirPressure = 32;
        private eCountOfDoors eCountOfdoors;                
       
        public eCountOfDoors ECountOfdoors
        {
            get { return eCountOfdoors; }
            set { eCountOfdoors = value; }
        }       
        public ElectricAutomobile(string i_WheelProducer, float i_CurrentAirPressure, string i_ModelOfCar, string i_License, float i_CurrentElectricyAmount, eCarColor i_CarColor, eCountOfDoors i_countOfDoors)
            : base(i_WheelProducer, i_CurrentAirPressure, i_ModelOfCar, i_License, i_CurrentElectricyAmount, k_NumberOfWheels, k_BattaryMaxCapacity, k_MaxWheelAirPressure) 
        {
            eCountOfdoors = i_countOfDoors;
            eCarColor     = i_CarColor;
        }
        public float K_BattaryMaxCapacity
        {
            get { return k_BattaryMaxCapacity; }
        }
        public eCarColor ECarColor
        {
            get { return eCarColor; }
            set { eCarColor = value; }
        }       
    }
}
