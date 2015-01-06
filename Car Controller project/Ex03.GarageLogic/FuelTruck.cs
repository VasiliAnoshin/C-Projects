using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTruck : FuelVehicle
    {
        private bool            m_ExistDangerousMaterials;
        private float           m_MaximumHoldingCapacityWeight;
        protected const int     k_NumberOfWheels = 10;
        private const float     k_MaxWheelAirPressure = 31;
        private const eFuelType m_FuelType = eFuelType.Solar;
        private const float     k_MaximalFuelCapacity = 190f;

        public FuelTruck(string i_WheelProducer, float i_CurrentAirPressure, string i_ModelOfCar, string i_License, float i_FuelorElectricyAmount,
                bool i_ExistDangerousMaterials, float i_MaximumHoldingCapacityWeight)
            : base(i_WheelProducer, i_CurrentAirPressure, i_ModelOfCar, i_License, i_FuelorElectricyAmount,
                k_NumberOfWheels, m_FuelType, k_MaximalFuelCapacity, k_MaxWheelAirPressure) 
        {
            m_ExistDangerousMaterials       = i_ExistDangerousMaterials;
            m_MaximumHoldingCapacityWeight  = i_MaximumHoldingCapacityWeight;

        }

        public bool ExistDangerousMaterials
        {
            get { return m_ExistDangerousMaterials; }
            set { m_ExistDangerousMaterials = value; }
        }
        public float MaximumHoldingCapacityWeight
        {
            get { return m_MaximumHoldingCapacityWeight; }
            set { m_MaximumHoldingCapacityWeight = value; }
        }
        public float K_MaximalFuelCapacity
        {
            get { return k_MaximalFuelCapacity; }
        }
        public eFuelType FuelType
        {
            get { return m_FuelType; }
        } 


    }
}
