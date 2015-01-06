using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        
        private float m_MaxEnergyCapacity;
        public ElectricVehicle(string i_WheelProducer, float i_CurrentAirPressure, string i_ModelOfCar, string i_License, float i_CurrentElectricyAmount, int i_NumberOfWheels,
            float i_energyMaxCapacity, float i_MaxWheelAirPressure)
            : base(i_WheelProducer, i_CurrentAirPressure, i_ModelOfCar, i_License, i_CurrentElectricyAmount, i_NumberOfWheels)
        {
            m_MaxEnergyCapacity = i_energyMaxCapacity;

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_SetOfWheels[i].MaximalAirPressure = i_MaxWheelAirPressure;
            }
        }

        public void FillBattery(float i_EnergyToFill)
        {
            float batteryAvailableCapacity =0 ;
            if (i_EnergyToFill < 0)
            {
                throw new IndexOutOfRangeException("Cannot charge the Battery with negative charge !!!");
            }

            batteryAvailableCapacity = m_MaxEnergyCapacity - FuelOrElectricityRemainInEnergySaurce;               
            if ((batteryAvailableCapacity - i_EnergyToFill) > 0)
            {
                FuelOrElectricityRemainInEnergySaurce += i_EnergyToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(FuelOrElectricityRemainInEnergySaurce, m_MaxEnergyCapacity);
            }
        }
    }
}
