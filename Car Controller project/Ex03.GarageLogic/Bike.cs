using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public abstract class Bike : Vehicle
    {
        protected int       m_EngineSize;
        protected eLicense  eLicenseType;
        protected const int k_NumberOfWheels = 2;
        private const float k_MaxWheelAirPressure = 29;

        public Bike(string i_ModelOfCar, string i_License, int i_FuelElectricyAmount, int i_EngineSize, eLicense i_TypeLicense)
            : base(i_ModelOfCar, i_License, i_FuelElectricyAmount, k_NumberOfWheels)
        {
            m_EngineSize = i_EngineSize;
            //eLicenseType = (eLicense)Enum.Parse(typeof(eLicense), Convert.ToString(i_TypeLicense));
            eLicenseType = i_TypeLicense;
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_SetOfWheels[i].MaximalAirPressure = k_MaxWheelAirPressure;
            }
        }

        public int GetEngineSize
        {
            get { return m_EngineSize; }
        }
        public eLicense getLicenseType
        {
            get { return this.eLicenseType; }
        }

        public virtual float FillBatteryOrFualTank(float i_EnergyToFill, float k_BattaryMaxCapacity)
        {
            float batteryCapacity;
            float energyException = 0;

            if (i_EnergyToFill > 0)
            {
                if ((batteryCapacity = (k_BattaryMaxCapacity - FuelOrElectricityRemainInEnergySaurce)) > 0)
                {
                    if ((batteryCapacity - i_EnergyToFill) > 0)
                    {
                        FuelOrElectricityRemainInEnergySaurce += i_EnergyToFill;
                    }
                    else
                    {
                        energyException = batteryCapacity - i_EnergyToFill;
                    }
                }
                else
                {
                    energyException = batteryCapacity;
                }
            }
            return energyException;
        }
        public virtual float FillFuel(float i_AmountOfLitresToFill, float k_BattaryMaxCapacity, eFuelType FuelType) 
        {
            float energyException = 0;
            return energyException;
        }
    }
}