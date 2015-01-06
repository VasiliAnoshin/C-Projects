using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    class Menu
    {
        string m_ClientName;
        public static string GetStartScreenMessage()
        {
            string firstMenuMsg = string.Format(
 @"Welcome to the garage!
 Please, select the desired option: 
 1 - Registration of a new client 
 2 - Representation of the list of license plate numbers of the vehicles in the garage 
 3 - Representation of complete data of a vehicle by license plate number
 4 - Quit the program");
            return firstMenuMsg;
        }
        public static string GetVehicleMessageForChoose()
        {
            string selectTypeOfVericleMsg;
            return selectTypeOfVericleMsg = string.Format(
@"Please, select a type of the vericle:
1 - Fuel bike
2 - Electric bike
3 - Fuel car
4 - Electric car
5 - Truck");
        }      
        public void FirstOptionMenu()
        {
            Console.WriteLine("Please, type the client name");
            m_ClientName = Console.ReadLine();

            Console.WriteLine("Please, type the telefon number of the client");
            int telefonNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please, type the license number of clients vehicle");
            string licenseNumber = Console.ReadLine();

            string selectTypeOfVericleMsg = string.Format(
@"Please, select a type of the vericle:
1 - Fuel bike
2 - Electric bike
3 - Fuel car
4 - Electric car
5 - Truck");
            Console.WriteLine(selectTypeOfVericleMsg);
            string selectedTypeVehicle = Console.ReadLine();

            Console.WriteLine("Please, type the model of the vericle");
            string modelType = Console.ReadLine();

        }
        public static string GetSecondOptionMenu()
        {
            string firstMenuMsg = null;
            return firstMenuMsg = string.Format(
@"Choose option to represent  state of the vehicle :
1: Repairing
2: Repaired
3: Paid");

        }
        public static string ImproveYourVehicle()
        {
            string firstMenuMsg = null;
            return firstMenuMsg = string.Format(
@"Choose option to represent  to improve the vehicle :
1: Change Vehicle State (for example : From repairing to repaired ).
2: Emplate the wheels to maximum.
3: Set fuel in the Vehicle (if vehicle work in fuel ).
4: Charge the battery in Vehicle to maxiumum (if vehicle work on battary !)
5: Exit to mainMenu");

        }
        public static string getUpdateStateMsg()
        {
            string stateToUpdate;
            return stateToUpdate = string.Format(
@"Please, choose state to update:
1 - Repairing
2 - Repaired
3 - Paid
");
        }
    }
}