using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, OwnerData> m_VehicleCollection;       
        private OwnerData                     m_OwnerData;

        public Garage()
        {            
            m_VehicleCollection = new Dictionary<string, OwnerData>();            
        }

        public void AddVehicleToGarrage(string i_License, OwnerData i_OwnerData)         
        {
            m_VehicleCollection.Add(i_License, i_OwnerData);
        }

        public Dictionary<string, OwnerData> VehicleCollection
        {
            get { return m_VehicleCollection; }
        }
        public string GetEveryVehicleThatRepairing() 
        {
            String listOfVehiclesInGarajeFilteredByReparingStatus = null;
            foreach (string i_statusInGaraje in m_VehicleCollection.Keys)
            {
                if (m_VehicleCollection[i_statusInGaraje].EVecihleStates == eVecihleState.Repairing)
                    listOfVehiclesInGarajeFilteredByReparingStatus += String.Concat(i_statusInGaraje, "\n");
            }
            return listOfVehiclesInGarajeFilteredByReparingStatus;
            
        }
        public string GetEveryVehicleThatRepaired() 
        {
            String listOfVehiclesInGarajeFilteredByRepairedStatus = null;
            foreach (string i_statusInGaraje in m_VehicleCollection.Keys)
            {
                if (m_VehicleCollection[i_statusInGaraje].EVecihleStates == eVecihleState.Repaired)
                    listOfVehiclesInGarajeFilteredByRepairedStatus = String.Concat(i_statusInGaraje, "\n");
            }
            return listOfVehiclesInGarajeFilteredByRepairedStatus;
        }
        public string GetEveryVehicleThatPaid() 
        {
            String listOfVehiclesInGarajeFilteredByRepairedStatus = null;
            foreach (string i_statusInGaraje in m_VehicleCollection.Keys)
            {
                if (m_VehicleCollection[i_statusInGaraje].EVecihleStates == eVecihleState.Paid)
                    listOfVehiclesInGarajeFilteredByRepairedStatus = String.Concat(i_statusInGaraje, "\n");
            }
            return listOfVehiclesInGarajeFilteredByRepairedStatus;
        }
        public OwnerData getOwnerDataFromGarage(string i_License)
        {
            OwnerData data;
            if (m_VehicleCollection.TryGetValue(i_License, out data))
            {
                
            }
            return data;
        }
        public void InflateTheWhheels(string i_LicenzeNumber) 
        {
            try 
            {
                for (int i = 0; i < m_VehicleCollection[i_LicenzeNumber].GetVecihle.getWheels.Capacity; i++) 
                {
                    m_VehicleCollection[i_LicenzeNumber].GetVecihle.getWheels[i].VolumeWheelToMax();
                }
            }
            catch(FormatException error)
            {
                Console.WriteLine("Can not find the current vehicle !!!", error.Data);
            }
        }

        public void FillTheFuelInTank(string i_License, int i_Type, float i_Count) 
        {
            try 
            {
                if (m_VehicleCollection[i_License].GetVecihle is FuelVehicle)
                {
                    ((FuelVehicle)(m_VehicleCollection[i_License].GetVecihle)).FillFuel(i_Count, ((eFuelType)(i_Type)));
                }
                else 
                {
                    Console.WriteLine("Can not fuel this type of Car !!!");
                }
            }
            catch(FormatException error)
            {
                Console.WriteLine("This type of vehicle cannot use fuel functions", error.Data);
            }
        }

        public void Chargeengine(string i_License, float i_Count) 
        {
            try
            {
                if (m_VehicleCollection[i_License].GetVecihle is ElectricVehicle)
                {
                    ((ElectricVehicle)(m_VehicleCollection[i_License].GetVecihle)).FillBattery(i_Count);
                }
                else 
                {
                    Console.WriteLine("Can not charge this type of Car !!!");
                }
            }
            catch (FormatException error)
            {
                Console.WriteLine("This type of vehicle cannot use fuel functions", error.Data);
            }
        }
    }
}