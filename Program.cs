using System;

namespace ThemeParkSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThemePark park = new ThemePark();
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("====================================");
                Console.WriteLine("Horizon Adventure Park");
                Console.WriteLine("====================================");

                Console.WriteLine("1. Register Visitor");
                Console.WriteLine("2. Issue Ticket");
                Console.WriteLine("3. Validate Ride Access");
                Console.WriteLine("4. Visitor Exit Ride");
                Console.WriteLine("5. Create Reservation");
                Console.WriteLine("6. Cancel Reservation");
                Console.WriteLine("7. View Ride Capacity");
                Console.WriteLine("8. Add Ride");
                Console.WriteLine("9. Update Ride Status");
                Console.WriteLine("10. Assign Employee");
                Console.WriteLine("11. Deactivate Ticket");
                Console.WriteLine("12. Remove Expired Ticket");
                Console.WriteLine("13. View Employees");
                Console.WriteLine("14. View Park Report");
                Console.WriteLine("15. Validate Facility Access");
                Console.WriteLine("0. Exit");

                Console.Write("\nSelect an option: ");

                string choice =Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterVisitorMenu(park);
                        break;

                    case "2":
                        IssueTicketMenu(park);
                        break;

                    case "3":
                        ValidateRideAccessMenu(park);
                        break;

                    case "4":
                        ExitRideMenu(park);
                        break;

                    case "5":
                        CreateReservationMenu(park);
                       break;

                    case "6":
                        CancelReservationMenu(park);
                        break;

                    case "7":
                        park.ShowRides();
                        break;

                    case "8":

                        AddRideMenu(park);
                        break;

                    case "9":
                        UpdateRideStatusMenu(park);
                        break;

                    case "10":
                       AssignEmployeeMenu(park);
                        break;

                    case "11":
                        DeactivateTicketMenu(park);
                        break;

                    case "12":
                        RemoveExpiredTicketMenu(park);                 
                        break;

                    case "13":
                        park.ShowEmployees();
                        break;

                    case "14":
                        park.ShowParkReport();
                        break;

                    case "15":
                        ValidateFacilityAccessMenu(park);
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("System closed.");
                        break;


                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }


        // ====================================
        // REGISTER VISITOR
        // ====================================

        static void RegisterVisitorMenu(ThemePark park)
        {
            Console.Write("Enter Visitor ID: ");
            string id =Console.ReadLine();

            Console.Write("Enter Visitor Name: ");
            string name =Console.ReadLine();

            int age;
            Console.Write("Enter Age: ");

            while (int.TryParse(Console.ReadLine(), out age) == false)
            {
                Console.Write("Invalid age. Enter a number: ");
            }

            double height;
            Console.Write("Enter Height in cm: ");

            while (double.TryParse(Console.ReadLine(),out height) == false)
            {
                Console.Write("Invalid height. Enter a number: ");
            }

            Console.WriteLine();
            Console.WriteLine("1. General");
            Console.WriteLine("2. VIP");
            Console.WriteLine("3. Child");
            Console.WriteLine("4. Senior");
            Console.Write("Choose Visitor Category: ");

            string categoryChoice = Console.ReadLine();

            VisitorCategory category;

            switch (categoryChoice)
            {
                case "1":
                    category = VisitorCategory.General;
                    break;

                case "2":
                    category = VisitorCategory.VIP;
                    break;

                case "3":
                    category = VisitorCategory.Child;
                    break;

                case "4":
                    category = VisitorCategory.Senior;
                    break;

                default:
                    Console.WriteLine("Invalid category.");
                    return;
            }
            Console.Write("Has accompanying adult? (yes/no): ");

            string adultAnswer = Console.ReadLine();
            bool hasAdult;

            if (adultAnswer.ToLower() == "yes")
            {
                hasAdult = true;
            }
            else
            {
                hasAdult = false;
            }

            Visitor visitor =
                new Visitor(
                    id,
                    name,
                    age,
                    height,
                    category,
                    hasAdult);


            park.RegisterVisitor(visitor);
        }


        // ====================================
        // ISSUE TICKET
        // ====================================

        static void IssueTicketMenu(ThemePark park)
        {
            Console.Write("Enter Visitor ID: ");
            string visitorId = Console.ReadLine();

            park.IssueTicket(visitorId);
        }

        // ====================================
        // VALIDATE RIDE ACCESS
        // ====================================

        static void ValidateRideAccessMenu(ThemePark park)
        {
            park.ShowRides();
            Console.Write("\nEnter Visitor ID: ");

            string visitorId = Console.ReadLine();

            Console.Write("Enter Ride Name: ");

            string rideName = Console.ReadLine();

            park.ValidateRideAccess(visitorId, rideName);
        }


        // ====================================
        // EXIT RIDE
        // ====================================

        static void ExitRideMenu(ThemePark park)
        {
            park.ShowRides();
            Console.Write("\nEnter Ride Name: ");
            string rideName = Console.ReadLine();
            park.ExitRide(rideName);
        }


        // ====================================
        // CREATE RESERVATION
        // ====================================

        static void CreateReservationMenu(ThemePark park)
        {
            park.ShowRides();
            Console.Write("\nEnter Visitor ID: ");
            string visitorId = Console.ReadLine();
            Console.Write("Enter Ride Name: ");
            string rideName = Console.ReadLine();
            Console.Write("Enter Time Slot (example 14:00): ");

            string timeSlot = Console.ReadLine();

            park.CreateReservation(
                visitorId,
                rideName,
                timeSlot);
        }


        // ====================================
        // CANCEL RESERVATION
        // ====================================

        static void CancelReservationMenu(ThemePark park)
        {
            Console.Write("Enter Reservation ID: ");
            int reservationId;

            while (int.TryParse(Console.ReadLine(), out reservationId) == false)
            {
                Console.Write("Invalid ID. Enter a number: ");
            }

            park.CancelReservation(reservationId);
        }


        // ====================================
        // ADD RIDE
        // ====================================

        static void AddRideMenu(ThemePark park)
        {
            Console.Write("Enter Ride Name: ");

            string name = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("1. Thrill");
            Console.WriteLine("2. Family");
            Console.WriteLine("3. Water");
            Console.Write("Choose Ride Type: ");

            string typeChoice = Console.ReadLine();

            RideType rideType;

            switch (typeChoice)
            {
                case "1":
                    rideType = RideType.Thrill;
                    break;
                case "2":
                    rideType = RideType.Family;
                    break;
                case "3":
                    rideType = RideType.Water;
                    break;
                default:
                    Console.WriteLine("Invalid ride type.");
                    return;
            }

            int minimumAge;
            Console.Write("Enter Minimum Age: ");

            while (int.TryParse(Console.ReadLine(), out minimumAge) == false)
            {
                Console.Write("Invalid age. Enter a number: ");
            }

            double minimumHeight;

            Console.Write("Enter Minimum Height: ");

            while (double.TryParse(Console.ReadLine(),out minimumHeight) == false)
            {
                Console.Write("Invalid height. Enter a number: ");
            }

            Console.Write("Requires Adult? (yes/no): ");

            string adultAnswer = Console.ReadLine();
            bool requiresAdult;

            if (adultAnswer.ToLower() == "yes")
            {
                requiresAdult = true;
            }

            else
            {
                requiresAdult = false;
            }

            int maximumCapacity;
            Console.Write("Enter Maximum Capacity: ");

            while (
                int.TryParse(
                    Console.ReadLine(),
                    out maximumCapacity) == false)
            {
                Console.Write("Invalid capacity. Enter a number: ");
            }
            Console.Write("Regular Ticket Allowed? (yes/no): ");

            string ticketAnswer = Console.ReadLine();


            bool regularTicketAllowed;

            if (ticketAnswer.ToLower() == "yes")
            {
                regularTicketAllowed = true;
            }

            else
            {
                regularTicketAllowed = false;
            }

            Ride ride =
                new Ride(
                    name,
                    rideType,
                    minimumAge,
                    minimumHeight,
                    requiresAdult,
                    maximumCapacity,
                    regularTicketAllowed);

            park.AddRide(ride);
        }


        // ====================================
        // UPDATE RIDE STATUS
        // ====================================

        static void UpdateRideStatusMenu(ThemePark park)
        {
            park.ShowRides();

            Console.Write("\nEnter Ride Name: ");
            string rideName = Console.ReadLine();
            Console.WriteLine("1. Open");
            Console.WriteLine("2. Closed");
            Console.WriteLine("3. Maintenance");
            Console.Write("Choose Status: ");

            string statusChoice = Console.ReadLine();
            RideStatus status;

            switch (statusChoice)
            {
                case "1":
                    status = RideStatus.Open;

                    break;
                case "2":
                    status = RideStatus.Closed;

                    break;
                case "3":
                    status = RideStatus.Maintenance;

                    break;
                default:
                    Console.WriteLine("Invalid status.");
                    return;
            }


            park.UpdateRideStatus(rideName, status);
        }


        // ====================================
        // ASSIGN EMPLOYEE
        // ====================================

        static void AssignEmployeeMenu(ThemePark park)
        {
            park.ShowEmployees();
            Console.WriteLine();
            Console.WriteLine("1. Assign to Ride");
            Console.WriteLine("2. Assign to Facility");
            Console.Write("Choose assignment type: ");

            string choice = Console.ReadLine();
            Console.Write("Enter Employee ID: ");

            string employeeId =Console.ReadLine();

            if (choice == "1")
            {
                park.ShowRides();
                Console.Write("\nEnter Ride Name: ");

                string rideName = Console.ReadLine();

                park.AssignEmployeeToRide(employeeId, rideName);
            }

            else if (choice == "2")
            {
                park.ShowFacilities();
                Console.Write("\nEnter Facility Name: ");
                string facilityName = Console.ReadLine();
                park.AssignEmployeeToFacility(employeeId, facilityName);
            }

            else
            {
                Console.WriteLine("Invalid assignment type.");
            }
        }


        // ====================================
        // DEACTIVATE TICKET
        // ====================================

        static void DeactivateTicketMenu(ThemePark park)
        {
            Console.Write("Enter Visitor ID: ");
            string visitorId = Console.ReadLine();
            park.DeactivateTicket(visitorId);
        }


        // ====================================
        // REMOVE EXPIRED TICKET
        // ====================================

        static void RemoveExpiredTicketMenu(ThemePark park)
        {
            Console.Write("Enter Visitor ID: ");
            string visitorId = Console.ReadLine();
            park.RemoveExpiredTicket(visitorId);
        }

        static void ValidateFacilityAccessMenu(ThemePark park)
        {
            park.ShowFacilities();
            Console.Write("\nEnter Visitor ID: ");
            string visitorId = Console.ReadLine();
            Console.Write("Enter Facility Name: ");
            string facilityName = Console.ReadLine();

            park.ValidateFacilityAccess(visitorId, facilityName);
        }
    }
}