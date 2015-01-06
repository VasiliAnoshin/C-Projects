using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcicle : ElectricVehicle
    {
        private const float               k_BattaryMaxCapacity = 1.9f;
        private const int                 k_NumberOfWheels = 2;
        private const float               k_MaxWheelAirPressure = 29;
        private readonly eLicense         eLicenseType;
        private readonly int              m_EngineSize;

        public ElectricMotorcicle(string i_WheelProducer, float i_CurrentAirPressure, string i_ModelOfCar, string i_License, float i_CurrentElectricyAmount, eLicense i_eLicenseType, int i_EngineSize)
            : base(i_WheelProducer, i_CurrentAirPressure, i_ModelOfCar, i_License, i_CurrentElectricyAmount, k_NumberOfWheels, k_BattaryMaxCapacity, k_MaxWheelAirPressure) 
        {
            m_EngineSize = i_EngineSize;
            eLicenseType = i_eLicenseType;
        }

        public int EngineSize
        {
            get { return m_EngineSize; }
        }
        public eLicense ELicenseType
        {
            get { return eLicenseType; }
        }
        public float K_BattaryMaxCapacity
        {
            get { return k_BattaryMaxCapacity; }
        } 
    }
}
