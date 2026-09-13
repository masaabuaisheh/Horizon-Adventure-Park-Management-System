using System;

namespace ThemeParkSystem
{
    public class Ride
    {
        public string Name { get; set; }

        public RideType Type { get; set; }

        public int MinimumAge { get; set; }

        public double MinimumHeight { get; set; }

        public bool RequiresAdult { get; set; }

        public int MaximumCapacity { get; set; }

        public int CurrentOccupancy { get; set; }

        public RideStatus Status { get; set; }

        public bool RegularTicketAllowed { get; set; }


        public Ride(
            string name,
            RideType type,
            int minimumAge,
            double minimumHeight,
            bool requiresAdult,
            int maximumCapacity,
            bool regularTicketAllowed)
        {
            Name = name;
            Type = type;
            MinimumAge = minimumAge;
            MinimumHeight = minimumHeight;
            RequiresAdult = requiresAdult;
            MaximumCapacity = maximumCapacity;
            RegularTicketAllowed = regularTicketAllowed;
            CurrentOccupancy = 0;
            Status = RideStatus.Open;
        }


        public bool HasAvailableSpace()
        {
            if (CurrentOccupancy < MaximumCapacity)
            {
                return true;
            }

            return false;
        }


        public void ShowCapacity()
        {
            Console.WriteLine(
                Name + " | "
                + CurrentOccupancy + "/"
                + MaximumCapacity);
        }
    }
}