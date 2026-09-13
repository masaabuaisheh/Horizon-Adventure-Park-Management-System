namespace ThemeParkSystem
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public Visitor Visitor { get; set; }

        public Ride Ride { get; set; }

        public string TimeSlot { get; set; }


        public Reservation(
            int reservationId,
            Visitor visitor,
            Ride ride,
            string timeSlot)
        {
            ReservationId = reservationId;
            Visitor = visitor;
            Ride = ride;
            TimeSlot = timeSlot;
        }
    }
}