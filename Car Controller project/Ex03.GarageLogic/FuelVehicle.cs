using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private readonly eFuelType m_FuelType;
        private float              m_FuelMaxCapacity;

        public FuelVehicle(string i_WheelProducer, float i_CurrentAirPressure, string i_ModelOfCar, string i_License, float i_FuelorElectricyAmount, int i_NumberOfWheels,
            eFuelType i_FuelType, float i_FuelMaxCapacity, float i_MaxWheelAirPressure)
            : base(i_WheelProducer, i_CurrentAirPressure, i_ModelOfCar, i_License, i_FuelorElectricyAmount, i_NumberOfWheels)
        {
            m_FuelMaxCapacity = i_FuelMaxCapacity;
            m_FuelType        = i_FuelType;

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_SetOfWheels[i].MaximalAirPressure = i_MaxWheelAirPressure;
            }
        }
        
        
        public void FillFuel(float i_AmountOfLitresToFill, eFuelType io_FuelType)
        {
            float fuelAvailiableToFillInTank;

            if (io_FuelType != m_FuelType)
            {
                throw new ArgumentException("The given fuel type is not equal to the fuel type of the current vehicle");
            }
            if (i_AmountOfLitresToFill < 0)
            { 
                throw new ArgumentOutOfRangeException("The given amount litres to fill must be > 0 (positive)");
            }

            fuelAvailiableToFillInTank = (m_FuelMaxCapacity - FuelOrElectricityRemainInEnergySaurce);
            
            if ((fuelAvailiableToFillInTank - i_AmountOfLitresToFill) > 0)
            {
                FuelOrElectricityRemainInEnergySaurce += i_AmountOfLitresToFill;
            }
            else
            {
                throw new ValueOutOfRangeException(FuelOrElectricityRemainInEnergySaurce, m_FuelMaxCapacity);
            }
         }

        public void ChargeElectricVehicle(string i_license, float CountTofill) 
        {

        }
    }
}
