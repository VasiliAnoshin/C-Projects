namespace Ex03.GarageManagementSystem.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GarageLogic;

    public class UserInterface
    {
        const int          k_Quit = 4;
        const int          k_QuirFromSubMenu = 5;
        string             m_ClientName    = null;
        string             m_LicenseNumber = null;
        string             m_SelectTypeOfVericleMsg = null;
        string             m_WheelManufacturer = null;
        string             m_ModelCar;
        float              m_CurrentPressure = 0;
        int                m_TelefonNumber = 0; 
        Garage             m_MyGarage;
        string             m_SelectedTypeVehicle  = null;
        int                m_SelectedOption = 0;
        OwnerData          m_DesiredData = null;
        bool               m_ValidInput = true; 

        public void Start()
        {
            m_MyGarage = new Garage();
            Menu    UserMenu          = new Menu();            
            int     m_SecondMenuOption = 0;            

            while (m_SelectedOption != k_Quit)
            {
                m_SelectedOption = PrintMainMenu();
                switch (m_SelectedOption)
                {
                    case 1:
                    FirstOptionFromTheMainMenu();                       
                    switch (m_SelectedTypeVehicle)
                        {                            
                            case "1":
                                TheChoiseOfUserIsFuelBike();
                             break;
                            case "2":
                                TheChoiseOfUserIsElectricBike();
                             break;
                            case "3":
                                TheChoiseOfUserIsAutomobile();
                             break;
                            case "4":
                                TheChoiceOfUserIsElectricAutomobile();
                             break;
                            case "5":
                                TheChoiseOfUserIsTruck();
                             break;
                            default:
                             Console.WriteLine("Wrong Option , try once again");
                             Console.ReadKey();
                             break;
                        }
                        break;
                     case 2:
                         Console.WriteLine(Menu.GetSecondOptionMenu());
                         m_SecondMenuOption = Convert.ToInt32(Console.ReadLine());
                         SecondOptionMenu(m_SecondMenuOption);                        
                         break;
                     case 3:
                         int isVehicleInGarage = 0;
                         isVehicleInGarage = ThirdOptionMenu();
                         if (!Convert.ToBoolean(isVehicleInGarage))
                         {                         
                             int currentntOption = 0;
                             while (currentntOption != k_QuirFromSubMenu)
                             {
                                 Console.WriteLine(Menu.ImproveYourVehicle());
                                 
                                 currentntOption = Convert.ToInt32(Console.ReadLine());
                                 switch (currentntOption)
                                 {
                                     case 1:
                                         Console.Clear();
                                         UserChooseUpdateHisVehicleStatus();
                                         Console.Clear();
                                         break;
                                     case 2:
                                         Console.Clear();
                                         Console.WriteLine("Please enter the licence number");                                         
                                         m_MyGarage.InflateTheWhheels(Console.ReadLine());
                                         Console.Clear();
                                         break;
                                     case 3:
                                         UserChooseToFillFuel();
                                         break;
                                     case 4:
                                         UserChooseChargeBaloons();
                                         break;
                                     case 5:
                                         currentntOption = 5;
                                         Console.Clear();
                                         break;
                                     default:
                                         Console.WriteLine("Wrong Option , try once again");
                                         Console.ReadKey();
                                         break;
                                 }
                             }
                         }
                         break;
                     case 4:
                        Console.WriteLine("Thank you for visiting us , Bye Bye !!!");
                        Console.ReadLine();
                        m_SelectedOption = 4;
                        break;                    
                     }               
            }            
        }
        public void FirstOptionFromTheMainMenu()
        {
                         Console.WriteLine("Please, type the client name");
                         m_ClientName = Console.ReadLine();                         
                         Console.Clear();
                         while (m_ValidInput)
                         {
                             try
                             {
                                 Console.WriteLine("Please, type the telefon number of the client");
                                 m_TelefonNumber = Convert.ToInt32(Console.ReadLine());
                                 m_ValidInput = false;
                             }
                             catch (FormatException i_Error)
                             {
                                 Console.WriteLine(i_Error.Message);
                             }
                         }

                         Console.Clear();
                         Console.WriteLine("Please, type the license number of clients vehicle");
                         m_LicenseNumber = Console.ReadLine();
                         Console.Clear();
                         Console.WriteLine("Please, type the who is your wheel Manufacturer");
                         m_WheelManufacturer = Console.ReadLine();
                         Console.Clear();                         
                         Console.WriteLine("Please, type model of car");
                         m_ModelCar = Console.ReadLine();
                         Console.Clear();                                                  
                         Console.WriteLine("Please, type Air pressure :");
                         try
                         {
                             m_CurrentPressure = Convert.ToInt32(Console.ReadLine());
                         }
                         catch (FormatException i_Error)
                         {
                             Console.WriteLine(i_Error.Message);
                             Console.ReadKey();
                         }

                         Console.Clear();
                         m_SelectTypeOfVericleMsg = Menu.GetVehicleMessageForChoose();
                         Console.WriteLine(m_SelectTypeOfVericleMsg);
                         m_SelectedTypeVehicle = Console.ReadLine();
                         Console.Clear();
        }
        public void TheChoiseOfUserIsFuelBike() 
        {
            float currentAmountFuel = 0;
            int engineCapacityFuelBike = 0;
            Console.WriteLine("Please, type current engine capacity of Bike");
            try
            {
                engineCapacityFuelBike = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException i_Error)
            {
                Console.WriteLine(i_Error);
                Console.ReadKey();
            }

            Console.Clear();
            String LicenseTypeOfFuelByke = String.Format(@"Please, type your license : 
1: A1
2: AA
3: AB
4: C");
            Console.WriteLine(LicenseTypeOfFuelByke);
            eLicense fuelBikeLicense = (eLicense)(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();
            Console.WriteLine("Please type your current fuel ");
            try
            {
                float.TryParse(Console.ReadLine(), out currentAmountFuel);
            }
            catch(FormatException i_Error)
            {
                Console.WriteLine(i_Error.Message);
                Console.ReadKey();
            }

            Console.Clear();
            if (m_MyGarage.VehicleCollection.ContainsKey(m_LicenseNumber))
            {
                Console.WriteLine("FuelAuto exist in Garraje && in repairing !!!!");
                m_MyGarage.VehicleCollection[m_LicenseNumber].EVecihleStates = eVecihleState.Repairing;
            }
            else
            {
                OwnerData fuelBikeOwner = new OwnerData(m_ClientName, m_TelefonNumber,
                            new FuelMotorcicle(m_WheelManufacturer, m_CurrentPressure, m_ModelCar, m_LicenseNumber, currentAmountFuel,
                            engineCapacityFuelBike, fuelBikeLicense));
                m_MyGarage.AddVehicleToGarrage(m_LicenseNumber, fuelBikeOwner);
            }
        }
        public void TheChoiseOfUserIsElectricBike() 
        {
            int         engineCapacityOfElectricBike = 0;
            eLicense    fuelBikeLicense;
            float       currentAmountEnergy = 0;

            Console.WriteLine("Please, type current engine capacity of Bike");
            try
            {
                engineCapacityOfElectricBike = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException i_Error)
            {
                Console.WriteLine(i_Error.Message);
                Console.ReadKey();
            }

            Console.ReadKey();
            String LicenseTypeOfElectricByke = String.Format(@"Please, type your license : 
1: A1
2: AA
3: AB
4: C");
            Console.WriteLine(LicenseTypeOfElectricByke);
            fuelBikeLicense = (eLicense)(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();          
            Console.WriteLine("Please type your current energy in hours , maximum capacity of time is 1.9 hour ");
            float.TryParse(Console.ReadLine(), out currentAmountEnergy);
            Console.Clear();

            if (m_MyGarage.VehicleCollection.ContainsKey(m_LicenseNumber))
            {
                Console.WriteLine("Motorcicle exist in Garraje && in repairing !!!!");
                m_MyGarage.VehicleCollection[m_LicenseNumber].EVecihleStates = eVecihleState.Repairing;
            }
            else
            {
                OwnerData ElectricBikeOwner = new OwnerData(m_ClientName, m_TelefonNumber,
                    new ElectricMotorcicle(m_WheelManufacturer, m_CurrentPressure, m_ModelCar, m_LicenseNumber, currentAmountEnergy,
                                         fuelBikeLicense, engineCapacityOfElectricBike));

                m_MyGarage.AddVehicleToGarrage(m_LicenseNumber, ElectricBikeOwner);
            }
        }
        public void TheChoiseOfUserIsAutomobile() 
        {
            String ColorOfCar = String.Format(@"Please, type your color : 
1: Green
2: Black
3: Red
4: Silver");
            Console.WriteLine(ColorOfCar);
            eCarColor colorOfCar = (eCarColor)(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();

            String CountOfDoors = String.Format(@"Please, type your countOfDoors : 
2: TwoDoors
3: TreeDoors
4: FourDoors
5: FiveDoors");
            Console.WriteLine(ColorOfCar);
            eCountOfDoors countOfDoors = (eCountOfDoors)(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();

            Console.WriteLine("Please type your current fuel ");
            float currentAmountFuel = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

           
            if (m_MyGarage.VehicleCollection.ContainsKey(m_LicenseNumber))
            {
                Console.WriteLine("Auto exist in Garraje && in repairing !!!!");
                m_MyGarage.VehicleCollection[m_LicenseNumber].EVecihleStates = eVecihleState.Repairing;
            }
            else 
            {
                OwnerData AutomobileOwner = new OwnerData(m_ClientName, m_TelefonNumber,
                          new Automobile(m_WheelManufacturer, m_CurrentPressure, m_ModelCar, m_LicenseNumber,
                          currentAmountFuel, colorOfCar, countOfDoors));

                m_MyGarage.AddVehicleToGarrage(m_LicenseNumber, AutomobileOwner);            
            }
        }
        public void TheChoiceOfUserIsElectricAutomobile() 
        {
            float currentEnergyCharge = 0;
            String ColorOfCar = String.Format(@"Please, type your color : 
1: Green
2: Black
3: Red
4: Silver");
            Console.WriteLine(ColorOfCar);            
            eCarColor colorOfCar = (eCarColor)(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();

            String CountOfDoors = String.Format(@"Please, type your countOfDoors : 
2: TwoDoors
3: TreeDoors
4: FourDoors
5: FiveDoors");
            Console.WriteLine(ColorOfCar);
            eCountOfDoors countOfDoors = (eCountOfDoors)(Convert.ToInt32(Console.ReadLine()));
            Console.Clear();

            Console.WriteLine("Please type your current energy status in Hours , for example if you get 1/2 of hours type 0.5");
            float.TryParse(Console.ReadLine(), out currentEnergyCharge);
            Console.Clear();
            
            if (m_MyGarage.VehicleCollection.ContainsKey(m_LicenseNumber))
            {
                Console.WriteLine("Auto exist in Garraje && in repairing !!!!");
                m_MyGarage.VehicleCollection[m_LicenseNumber].EVecihleStates = eVecihleState.Repairing;
            }
            else
            {
                OwnerData ElectricAutomobileOwner = new OwnerData(m_ClientName, m_TelefonNumber,
                    new ElectricAutomobile(m_WheelManufacturer, m_CurrentPressure, m_ModelCar, m_LicenseNumber,
                        currentEnergyCharge, colorOfCar, countOfDoors));
                m_MyGarage.AddVehicleToGarrage(m_LicenseNumber, ElectricAutomobileOwner);
            }
        }
        public void TheChoiseOfUserIsTruck() 
        {
            bool    dangerousTruck = true;
            float   truckMaximalWeight  = 0;
            int     dangerousMAterials  = 0;
            float   currentAmountFuel   = 0;

            String DangerousMaterialQuestion = String.Format(@"Please type if the Truck have a dangreous materials
1) Yes
0) NO");
            Console.WriteLine(DangerousMaterialQuestion);
            dangerousMAterials = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (Convert.ToBoolean(dangerousMAterials))
            {                
            }
            else 
            {
                dangerousTruck = false;
            }
            
            Console.WriteLine("Please type what is the maximal weight for the truck");
            truckMaximalWeight = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please type your current fuel ");
            currentAmountFuel = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (m_MyGarage.VehicleCollection.ContainsKey(m_LicenseNumber))
            {
                Console.WriteLine("Truck exist in Garraje && in repairing !!!!");
                m_MyGarage.VehicleCollection[m_LicenseNumber].EVecihleStates = eVecihleState.Repairing;
            }
            else
            {
                OwnerData truckOwner = new OwnerData(m_ClientName, m_TelefonNumber,
                   new FuelTruck(m_WheelManufacturer, m_CurrentPressure, m_ModelCar, m_LicenseNumber,
                       currentAmountFuel, dangerousTruck, truckMaximalWeight));

                m_MyGarage.AddVehicleToGarrage(m_LicenseNumber, truckOwner);
            }
        }
        public void SecondOptionMenu(int m_SecondMenuOption)
        {
            //  TO DO
            switch (m_SecondMenuOption)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Vehicles Filtered by the Repairing Status represented by License Number:");
                    Console.WriteLine(m_MyGarage.GetEveryVehicleThatRepairing());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Vehicles Filtered by the Repaired Status represented by License Number:");
                    Console.WriteLine(m_MyGarage.GetEveryVehicleThatRepaired());
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Vehicles Filtered by the Paid Status represented by License Number:");
                    Console.WriteLine(m_MyGarage.GetEveryVehicleThatPaid());
                    Console.ReadKey();
                    Console.Clear();

                    break;
            }
        }
        public int  ThirdOptionMenu()
        {
            Console.WriteLine("Please, type license number of desired vehicle");
            m_DesiredData                       = null;
            string ownerName                    = null;
            string ownerTelefon                 = null;
            string vehicleState                 = null;
            string licenseOfDesiredVehicle      = null;
            string modelNameOfdesiredVehicle    = null;
            List<Wheel> wheelsOfDesiredVehicle  = null; 
            string vehicleEnergyState           = null;
            string vehicleDataRepresentation    = null;
            int    vehicleDoesNotExistInGarraje = 0;

            string licenseNumOfDesiredVehicle   = Console.ReadLine();            
            m_DesiredData = m_MyGarage.getOwnerDataFromGarage(licenseNumOfDesiredVehicle);           
            try
            {
                ownerName                  = m_DesiredData.getOwnersName();
                ownerTelefon               = Convert.ToString(m_DesiredData.getTelefonNumber());
                vehicleState               = m_DesiredData.EVecihleStates.ToString();
                licenseOfDesiredVehicle    = m_DesiredData.GetVecihle.GetLicencePlate;
                modelNameOfdesiredVehicle  = m_DesiredData.GetVecihle.GetModelName;
                wheelsOfDesiredVehicle     = m_DesiredData.GetVecihle.getWheels;
                vehicleEnergyState         = m_DesiredData.GetVecihle.getEnergyState.ToString();
                vehicleDataRepresentation  = string.Format(
@"Vehicle data of vehicle that number of his license is {0}:
Name of model           :   {1}
Name of owner           :   {2}
Telefon of owner        :   {3} 
Vehicle state           :   {4}
Energy state            :   {5}
Data about the wheels   :   ", licenseOfDesiredVehicle, modelNameOfdesiredVehicle, ownerName, ownerTelefon, vehicleState, vehicleEnergyState);
                Console.WriteLine(vehicleDataRepresentation);
                wheelsOfDesiredVehicle.ForEach(DisplayWheelData);
                GetVehicle(m_DesiredData.GetVecihle);
                
            }
            catch(Exception i_error)
            {
                Console.WriteLine("License Number does not exist in Garrage" , i_error.Data);
                vehicleDoesNotExistInGarraje = 1;
            }

            return vehicleDoesNotExistInGarraje;
        }
        public int  PrintMainMenu() 
        {
            int selectedOption;
            Console.WriteLine(Menu.GetStartScreenMessage());
            selectedOption = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return selectedOption;
        }
        public void DisplayWheelData(Wheel wheel)
        {
            string wheelManufacturer = wheel.WheelProducer;
            float  wheelCurrentPressure = wheel.CurrentAirPressure;
            string wheelMsg = string.Format(
@"The producer - {0}; current air pressure - {1}", wheelManufacturer, wheelCurrentPressure);
            Console.WriteLine(wheelMsg);
        }
        public Garage MyGarage { get; set; }
        public Garage myGarage { get; set; }
        public void GetVehicle(Vehicle i_vehicle) 
        {
            string vehicalData = null;
            if ( i_vehicle is FuelMotorcicle )
            {
                vehicalData = String.Format(@"
Lisense type is         :  {0}
Engine weight           :  {1}
Maximal Tank Capacity   :  {2}
Type of Fuel            :  {3}", ((FuelMotorcicle)(i_vehicle)).ELicenseType.ToString(), ((FuelMotorcicle)(i_vehicle)).EngineSize,
                               ((FuelMotorcicle)(i_vehicle)).K_MaximalFuelCapacity, ((FuelMotorcicle)(i_vehicle)).FuelType);               
            }
            if (i_vehicle is Automobile)
            {
                vehicalData = String.Format(@"
Color of Car            :  {0}
Count of Doors          :  {1}
Maximal Tank Capacity   :  {2}
Type of Fuel            :  {3}", ((Automobile)(i_vehicle)).CarColor.ToString(), ((Automobile)(i_vehicle)).ECountOfdoors.ToString(),
                               ((Automobile)(i_vehicle)).K_MaximalFuelCapacity, ((Automobile)(i_vehicle)).FuelType.ToString());               
            }
            if (i_vehicle is FuelTruck)
            {
                vehicalData = String.Format(@"
Is Dangerous maeterials exist:  {0}
Maximal weigth               :  {1}
Maximal Tank Capacity        :  {2}
Type of Fuel                 :  {3}", ((FuelTruck)(i_vehicle)).ExistDangerousMaterials, ((FuelTruck)(i_vehicle)).MaximumHoldingCapacityWeight,
                               ((FuelTruck)(i_vehicle)).K_MaximalFuelCapacity, ((FuelTruck)(i_vehicle)).FuelType.ToString());      
            }
            if (i_vehicle is ElectricMotorcicle)
            {
                vehicalData = String.Format(@"
Lisense type is              :  {0}
Engine weight                :  {1}
Maximal Battary Capacity     :  {2}", ((ElectricMotorcicle)(i_vehicle)).ELicenseType.ToString(), ((ElectricMotorcicle)(i_vehicle)).EngineSize,
                               ((ElectricMotorcicle)(i_vehicle)).K_BattaryMaxCapacity ); 
            }
            if (i_vehicle is ElectricAutomobile)
            {
                vehicalData = String.Format(@"
Color of Car            :  {0}
Count of Doors          :  {1}
Maximal Battary Capacity:  {2} ", ((ElectricAutomobile)(i_vehicle)).ECarColor.ToString(), ((ElectricAutomobile)(i_vehicle)).ECountOfdoors.ToString(),
                                 ((ElectricAutomobile)(i_vehicle)).K_BattaryMaxCapacity);
            }
            Console.WriteLine(vehicalData);
        }
        public void UpdateVehicalState(int i_newState, OwnerData i_desiredData) 
        {
            switch (i_newState)
            {
                case 1:
                    i_desiredData.EVecihleStates = eVecihleState.Repairing;
                    break;
                case 2:
                    i_desiredData.EVecihleStates = eVecihleState.Repaired;
                    break;
                case 3:
                    i_desiredData.EVecihleStates = eVecihleState.Paid;
                    break;
            }
        }
        public void UserChooseUpdateHisVehicleStatus() 
        {
            int changeStatus = 0;
            Console.WriteLine(Menu.getUpdateStateMsg());
            changeStatus = Convert.ToInt32(Console.ReadLine());
            UpdateVehicalState(changeStatus, m_DesiredData);     
        }
        public void UserChooseChargeBaloons() 
        {
            string ElecricLicense = null;
            float countTocharge = 0;
            Console.Clear();
            Console.WriteLine("Please enter License Number: ");
            ElecricLicense = Console.ReadLine();
            Console.WriteLine("Please choose desireable time. If you want enter 1/2 of hour type : 0,5");
            float.TryParse(Console.ReadLine(), out countTocharge);
            m_MyGarage.Chargeengine(ElecricLicense, countTocharge);
        }
        public void UserChooseToFillFuel() 
        {
            string License = null;
            int    FuelChoose = 0;
            float  countToFill = 0;

            Console.Clear();
            Console.WriteLine("Please enter License Number: ");
            License = Console.ReadLine();
            Console.WriteLine("Please choose FuelType : 1-Octan98 2-Octan96 3-Octan95 4-Solar");
            FuelChoose = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please choose count to fill");
            float.TryParse(Console.ReadLine(), out countToFill);
            m_MyGarage.FillTheFuelInTank(License, FuelChoose, countToFill);
            Console.Clear();
        }
    }
}



