using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelMotorcicle : FuelVehicle
    {
        private const int                 k_NumberOfWheels = 2;
        private const float               k_MaxWheelAirPressure = 29;
        private const float               k_MaximalFuelCapacity = 7.5f;
        private readonly eLicense         eLicenseType;
        private readonly int              m_EngineSize;
        private const eFuelType           m_FuelType = eFuelType.Octan98;

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        } 


        public FuelMotorcicle(string i_WheelProducer, float i_CurrentAirPressure, string i_ModelOfCar, string i_License, float i_CurrentFuel, int i_EngineSize, eLicense i_LicenseType)
            : base(i_WheelProducer, i_CurrentAirPressure, i_ModelOfCar,
            i_License, i_CurrentFuel, k_NumberOfWheels, m_FuelType, k_MaximalFuelCapacity, k_MaxWheelAirPressure) 

        {
            eLicenseType = i_LicenseType;
            m_EngineSize = i_EngineSize;
        
        }
        public float K_MaximalFuelCapacity
        {
            get { return k_MaximalFuelCapacity; }
        } 
        public int EngineSize
        {
            get { return m_EngineSize; }
        }
        public eLicense ELicenseType
        {
            get { return eLicenseType; }
        }

    }
}
