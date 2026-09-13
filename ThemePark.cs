using System;

namespace ThemeParkSystem
{
    public class ThemePark
    {
        public Visitor[] Visitors;

        public Ride[] Rides;

        public Reservation[] Reservations;

        public Employee[] Employees;

        public Facility[] Facilities;

        public int VisitorCount;

        public int RideCount;

        public int ReservationCount;

        public int EmployeeCount;

        public int FacilityCount;

        private int nextTicketId;

        private int nextReservationId;


        public ThemePark()
        {
            Visitors = new Visitor[100];
            Rides = new Ride[20];
            Reservations = new Reservation[100];
            Employees = new Employee[20];
            Facilities = new Facility[20];
            VisitorCount = 0;
            RideCount = 0;
            ReservationCount = 0;
            EmployeeCount = 0;
            FacilityCount = 0;
            nextTicketId = 1;
            nextReservationId = 1;
            AddSampleData();
        }


        // ========================================
        // SAMPLE DATA
        // ========================================

        private void AddSampleData()
        {
            Rides[RideCount] = new Ride("Thunder Peak Coaster", RideType.Thrill, 12, 140, false, 20, false);
            RideCount++;

            Rides[RideCount] = new Ride("Splash Voyage", RideType.Water, 8, 110, false, 15, true);
            RideCount++;

            Rides[RideCount] = new Ride("Kids Train", RideType.Family, 5, 90, true, 10, true);
            RideCount++;

            Employees[EmployeeCount] = new Employee("E1", "Ahmad", "Ride Operator");
            EmployeeCount++;

            Employees[EmployeeCount] = new Employee("E2", "Sara", "Ride Operator");
            EmployeeCount++;

            Employees[EmployeeCount] = new Employee("E3", "Ali", "Manager");
            EmployeeCount++;

            Facilities[FacilityCount] = new Facility("Ticket Booth", true);
            FacilityCount++;

            Facilities[FacilityCount] = new Facility("First Aid Center", true);
            FacilityCount++;

            Facilities[FacilityCount] = new Facility("VIP Lounge", false);
            FacilityCount++;
        }


        // ========================================
        // FIND VISITOR
        // ========================================

        public Visitor FindVisitor(string id)
        {
            for (int i = 0; i < VisitorCount; i++)
            {
                if (Visitors[i].Id == id)
                {
                    return Visitors[i];
                }
            }

            return null;
        }

        public void ValidateFacilityAccess(string visitorId, string facilityName)
        {
            Visitor visitor = FindVisitor(visitorId);

            if (visitor == null)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Visitor not found.");
                return;
            }


            Facility facility = FindFacility(facilityName);

            if (facility == null)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Facility not found.");
                return;
            }

            if (visitor.Ticket == null)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Visitor has no ticket.");
                return;
            }

            if (visitor.Ticket.IsValid() == false)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Ticket is " + visitor.Ticket.Status + ".");
                return;
            }

            if (visitor.Ticket.Type == TicketType.VIP)
            {
                Console.WriteLine("ACCESS GRANTED");
                return;
            }

            if (facility.RegularTicketAllowed == true)
            {
                Console.WriteLine("ACCESS GRANTED");
                return;
            }

            Console.WriteLine("ACCESS DENIED");
            Console.WriteLine("Reason: VIP ticket is required.");
        }

        // ========================================
        // FIND RIDE
        // ========================================
        public Ride FindRide(string name)
        {
            for (int i = 0; i < RideCount; i++)
            {
                if (Rides[i].Name == name)
                {
                    return Rides[i];
                }
            }

            return null;
        }


        // ========================================
        // FIND EMPLOYEE
        // ========================================
        public Employee FindEmployee(string id)
        {
            for (int i = 0; i < EmployeeCount; i++)
            {
                if (Employees[i].Id == id)
                {
                    return Employees[i];
                }
            }

            return null;
        }


        // ========================================
        // FIND FACILITY
        // ========================================
        public Facility FindFacility(string name)
        {
            for (int i = 0; i < FacilityCount; i++)
            {
                if (Facilities[i].Name == name)
                {
                    return Facilities[i];
                }
            }

            return null;
        }

        // ========================================
        // REGISTER VISITOR
        // ========================================
        public void RegisterVisitor(Visitor visitor)
        {
            if (FindVisitor(visitor.Id) != null)
            {
                Console.WriteLine("Registration failed: Visitor already exists.");
                return;
            }

            if (VisitorCount >= Visitors.Length)
            {
                Console.WriteLine("Registration failed: Visitor storage is full.");
                return;
            }

            Visitors[VisitorCount] = visitor;
            VisitorCount++;

            Console.WriteLine("Visitor registered successfully.");
        }

        // ========================================
        // ISSUE TICKET
        // ========================================
        public void IssueTicket(string visitorId)
        {
            Visitor visitor = FindVisitor(visitorId);

            if (visitor == null)
            {
                Console.WriteLine("Ticket failed: Visitor not found.");
                return;
            }

            if (visitor.Ticket != null)
            {
                if (visitor.Ticket.IsValid())
                {
                    Console.WriteLine("Visitor already has an active ticket.");
                    return;
                }
            }

            TicketType ticketType;
            double price;
            int validityDays;


            if (visitor.Category == VisitorCategory.VIP)
            {
                ticketType = TicketType.VIP;
                price = 100;
                validityDays = 2;
            }

            else if (visitor.Category == VisitorCategory.Child)
            {
                ticketType = TicketType.Child;
                price = 30;
                validityDays = 1;
            }

            else if (visitor.Category == VisitorCategory.Senior)
            {
                ticketType = TicketType.Senior;
                price = 40;
                validityDays = 1;
            }

            else
            {
                ticketType = TicketType.Regular;
                price = 60;
                validityDays = 1;
            }

            string ticketId = "T-" + nextTicketId;
            nextTicketId++;

            Ticket ticket = new Ticket(ticketId, ticketType, price, DateTime.Now.AddDays(validityDays));
            visitor.Ticket = ticket;

            Console.WriteLine("Ticket issued successfully.");
            Console.WriteLine("Ticket ID: " + ticket.TicketId);
            Console.WriteLine("Ticket Type: " + ticket.Type);
            Console.WriteLine("Price: $" + ticket.Price);
            Console.WriteLine("Expiry Date: " + ticket.ExpiryDate);
        }

        // ========================================
        // DEACTIVATE TICKET
        // ========================================
        public void DeactivateTicket(string visitorId)
        {
            Visitor visitor = FindVisitor(visitorId);

            if (visitor == null)
            {
                Console.WriteLine("Visitor not found.");
                return;
            }

            if (visitor.Ticket == null)
            {
                Console.WriteLine("Visitor does not have a ticket.");
                return;
            }

            visitor.Ticket.Status = TicketStatus.Cancelled;

            Console.WriteLine("Ticket cancelled successfully.");
        }

        // ========================================
        // REMOVE EXPIRED TICKET
        // ========================================
        public void RemoveExpiredTicket(string visitorId)
        {
            Visitor visitor = FindVisitor(visitorId);

            if (visitor == null)
            {
                Console.WriteLine("Visitor not found.");
                return;
            }

            if (visitor.Ticket == null)
            {
                Console.WriteLine("Visitor does not have a ticket.");
                return;
            }

            // This updates status if expired
            visitor.Ticket.IsValid();

            if (visitor.Ticket.Status != TicketStatus.Expired)
            {
                Console.WriteLine("Ticket is not expired.");
                return;
            }

            visitor.Ticket = null;
            Console.WriteLine("Expired ticket removed successfully.");
        }


        // ========================================
        // CHECK ELIGIBILITY
        // ========================================

        public bool CheckEligibility(Visitor visitor, Ride ride)
        {
            if (visitor.Age < ride.MinimumAge)
            {
                Console.WriteLine("Access denied: Minimum age is " + ride.MinimumAge + ".");
                return false;
            }

            if (visitor.Height < ride.MinimumHeight)
            {
                Console.WriteLine("Access denied: Minimum height is " + ride.MinimumHeight + " cm.");
                return false;
            }

            if (ride.RequiresAdult == true)
            {
                if (visitor.Age < 18 && visitor.HasAccompanyingAdult == false)
                {
                    Console.WriteLine("Access denied: Accompanying adult is required.");
                    return false;
                }
            }

            // VIP can use every ride
            if (visitor.Ticket.Type != TicketType.VIP)
            {
                if (ride.RegularTicketAllowed == false)
                {
                    Console.WriteLine("Access denied: VIP ticket is required.");
                    return false;
                }
            }
            return true;
        }

        // ========================================
        // VALIDATE RIDE ACCESS
        // ========================================
        public void ValidateRideAccess(string visitorId, string rideName)
        {
            Visitor visitor = FindVisitor(visitorId);

            if (visitor == null)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Visitor not found.");
                return;
            }

            Ride ride = FindRide(rideName);

            if (ride == null)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Ride not found.");
                return;
            }

            if (ride.Status != RideStatus.Open)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Ride is " + ride.Status + ".");
                return;
            }

            if (visitor.Ticket == null)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Visitor has no ticket.");
                return;
            }

            if (visitor.Ticket.IsValid() == false)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Ticket is " + visitor.Ticket.Status + ".");
                return;
            }

            if (CheckEligibility(visitor, ride) == false)
            {
                return;
            }

            if (ride.CurrentOccupancy >= ride.MaximumCapacity)
            {
                Console.WriteLine("ACCESS DENIED");
                Console.WriteLine("Reason: Ride has reached maximum capacity.");
                return;
            }

            ride.CurrentOccupancy++;
            Console.WriteLine("ACCESS GRANTED");

            Console.WriteLine("Current Occupancy: " + ride.CurrentOccupancy + "/" + ride.MaximumCapacity);
        }

        // ========================================
        // VISITOR EXITS RIDE
        // ========================================
        public void ExitRide(string rideName)
        {
            Ride ride = FindRide(rideName);

            if (ride == null)
            {
                Console.WriteLine("Ride not found.");
                return;
            }

            if (ride.CurrentOccupancy <= 0)
            {
                Console.WriteLine("Ride currently has no visitors.");
                return;
            }

            ride.CurrentOccupancy--;

            Console.WriteLine("Visitor removed from ride.");
            Console.WriteLine("Current Occupancy: " + ride.CurrentOccupancy + "/" + ride.MaximumCapacity);
        }

        // ========================================
        // CREATE RESERVATION
        // ========================================
        public void CreateReservation(string visitorId, string rideName, string timeSlot)
        {
            Visitor visitor = FindVisitor(visitorId);

            if (visitor == null)
            {
                Console.WriteLine("RESERVATION FAILED");
                Console.WriteLine("Reason: Visitor not found.");
                return;
            }

            Ride ride = FindRide(rideName);

            if (ride == null)
            {
                Console.WriteLine("RESERVATION FAILED");
                Console.WriteLine("Reason: Ride not found.");
                return;
            }

            if (ride.Status != RideStatus.Open)
            {
                Console.WriteLine("RESERVATION FAILED");

                Console.WriteLine("Reason: Ride is " + ride.Status + ".");

                return;
            }


            if (visitor.Ticket == null)
            {
                Console.WriteLine("RESERVATION FAILED");
                Console.WriteLine("Reason: Visitor has no ticket.");
                return;
            }

            if (visitor.Ticket.IsValid() == false)
            {
                Console.WriteLine("RESERVATION FAILED");
                Console.WriteLine("Reason: Ticket is " + visitor.Ticket.Status + ".");
                return;
            }

            if (CheckEligibility(visitor, ride) == false)
            {
                Console.WriteLine("RESERVATION FAILED");
                return;
            }

            // -----------------------------------
            // DUPLICATE RESERVATION
            // -----------------------------------
            // Same visitor cannot reserve two
            // things in the same time slot.

            for (int i = 0; i < ReservationCount; i++)
            {
                if (Reservations[i].Visitor.Id == visitorId && Reservations[i].TimeSlot == timeSlot)
                {
                    Console.WriteLine("RESERVATION FAILED");

                    Console.WriteLine("Reason: Visitor already has a reservation for this time slot.");

                    return;
                }
            }


            // -----------------------------------
            // COUNT RESERVATIONS
            // -----------------------------------

            int reservationsForSlot = 0;


            for (int i = 0; i < ReservationCount; i++)
            {
                if (Reservations[i].Ride.Name == rideName && Reservations[i].TimeSlot == timeSlot)
                {
                    reservationsForSlot++;
                }
            }


            // Direct visitors + reservations
            // share the same maximum capacity.

            int totalCapacityUsed = ride.CurrentOccupancy + reservationsForSlot;

            if (totalCapacityUsed >= ride.MaximumCapacity)
            {
                Console.WriteLine("RESERVATION FAILED");
                Console.WriteLine("Reason: Ride has reached maximum capacity for this time slot.");
                return;
            }


            if (ReservationCount >= Reservations.Length)
            {
                Console.WriteLine("RESERVATION FAILED");
                Console.WriteLine("Reason: Reservation storage is full.");
                return;
            }

            Reservation reservation = new Reservation(nextReservationId, visitor, ride, timeSlot);
            Reservations[ReservationCount] = reservation;
            ReservationCount++;
            nextReservationId++;
            Console.WriteLine("Reservation created successfully.");
            Console.WriteLine("Reservation ID: " + reservation.ReservationId);
        }


        // ========================================
        // CANCEL RESERVATION
        // ========================================

        public void CancelReservation(int reservationId)
        {
            int foundIndex = -1;

            for (int i = 0; i < ReservationCount; i++)
            {
                if (Reservations[i].ReservationId == reservationId)
                {
                    foundIndex = i;

                    break;
                }
            }

            if (foundIndex == -1)
            {
                Console.WriteLine("Reservation not found.");

                return;
            }

            for (int i = foundIndex; i < ReservationCount - 1; i++)
            {
                Reservations[i] = Reservations[i + 1];
            }

            ReservationCount--;
            Reservations[ReservationCount] = null;
            Console.WriteLine("Reservation cancelled successfully.");
        }


        // ========================================
        // ADD RIDE
        // ========================================

        public void AddRide(Ride ride)
        {
            if (FindRide(ride.Name) != null)
            {
                Console.WriteLine("Ride already exists.");
                return;
            }

            if (RideCount >= Rides.Length)
            {
                Console.WriteLine("Cannot add more rides.");
                return;
            }

            Rides[RideCount] = ride;
            RideCount++;
            Console.WriteLine("Ride added successfully.");
        }


        // ========================================
        // UPDATE RIDE STATUS
        // ========================================

        public void UpdateRideStatus(string rideName, RideStatus newStatus)
        {
            Ride ride = FindRide(rideName);

            if (ride == null)
            {
                Console.WriteLine("Ride not found.");
                return;
            }

            ride.Status = newStatus;
            Console.WriteLine("Ride status changed to " + newStatus + ".");
        }


        // ========================================
        // ASSIGN EMPLOYEE TO RIDE
        // ========================================

        public void AssignEmployeeToRide(string employeeId, string rideName)
        {
            Employee employee = FindEmployee(employeeId);


            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            Ride ride = FindRide(rideName);

            if (ride == null)
            {
                Console.WriteLine("Ride not found.");
                return;
            }

            if (employee.IsAvailable() == false)
            {
                Console.WriteLine("Assignment failed: Employee is already assigned to " + employee.AssignedLocation + ".");
                return;
            }


            employee.AssignedLocation = ride.Name;
            Console.WriteLine(employee.Name + " assigned to " + ride.Name + " successfully.");
        }


        // ========================================
        // ASSIGN EMPLOYEE TO FACILITY
        // ========================================

        public void AssignEmployeeToFacility(string employeeId, string facilityName)
        {
            Employee employee = FindEmployee(employeeId);


            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }


            Facility facility = FindFacility(facilityName);

            if (facility == null)
            {
                Console.WriteLine("Facility not found.");
                return;
            }


            if (employee.IsAvailable() == false)
            {
                Console.WriteLine("Assignment failed: Employee is already assigned to " + employee.AssignedLocation + ".");

                return;
            }

            employee.AssignedLocation = facility.Name;
            Console.WriteLine(employee.Name + " assigned to " + facility.Name + " successfully.");
        }


        // ========================================
        // SHOW RIDES
        // ========================================

        public void ShowRides()
        {
            Console.WriteLine();
            Console.WriteLine("--- RIDES ---");

            for (int i = 0; i < RideCount; i++)
            {
                Console.WriteLine(Rides[i].Name + " | Type: " + Rides[i].Type + " | Status: " + Rides[i].Status + " | Capacity: " + Rides[i].CurrentOccupancy + "/" + Rides[i].MaximumCapacity);
            }
        }


        // ========================================
        // SHOW FACILITIES
        // ========================================

        public void ShowFacilities()
        {
            Console.WriteLine();
            Console.WriteLine("--- FACILITIES ---");

            for (int i = 0; i < FacilityCount; i++)
            {
                Console.WriteLine(Facilities[i].Name);
            }
        }


        // ========================================
        // SHOW EMPLOYEES
        // ========================================

        public void ShowEmployees()
        {
            Console.WriteLine();
            Console.WriteLine("--- EMPLOYEES ---");

            for (int i = 0; i < EmployeeCount; i++)
            {
                Console.Write(Employees[i].Id + " - " + Employees[i].Name + " - " + Employees[i].Role + " - ");

                if (Employees[i].AssignedLocation == null)
                {
                    Console.WriteLine("Available");
                }

                else
                {
                    Console.WriteLine(Employees[i].AssignedLocation);
                }
            }
        }


        // ========================================
        // PARK REPORT
        // ========================================

        public void ShowParkReport()
        {
            Console.WriteLine();
            Console.WriteLine("===== PARK REPORT =====");
            Console.WriteLine("Registered Visitors: " + VisitorCount);
            Console.WriteLine("Total Rides: " + RideCount);
            Console.WriteLine("Total Reservations: " + ReservationCount);
            Console.WriteLine("Total Employees: " + EmployeeCount);


            int openRides = 0;
            int closedRides = 0;
            int maintenanceRides = 0;


            for (int i = 0; i < RideCount; i++)
            {
                if (Rides[i].Status == RideStatus.Open)
                {
                    openRides++;
                }

                else if (Rides[i].Status == RideStatus.Closed)
                {
                    closedRides++;
                }

                else
                {
                    maintenanceRides++;
                }
            }

            Console.WriteLine("Open Rides: " + openRides);
            Console.WriteLine("Closed Rides: " + closedRides);
            Console.WriteLine("Rides Under Maintenance: " + maintenanceRides);
        }
    }
}