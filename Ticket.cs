using System;

namespace ThemeParkSystem
{
    public class Ticket
    {
        public string TicketId { get; set; }

        public TicketType Type { get; set; }

        public double Price { get; set; }

        public DateTime ExpiryDate { get; set; }

        public TicketStatus Status { get; set; }


        public Ticket(
            string ticketId,
            TicketType type,
            double price,
            DateTime expiryDate)
        {
            TicketId = ticketId;
            Type = type;
            Price = price;
            ExpiryDate = expiryDate;
            Status = TicketStatus.Active;
        }


        public bool IsValid()
        {
            if (Status == TicketStatus.Cancelled)
            {
                return false;
            }

            if (DateTime.Now > ExpiryDate)
            {
                Status = TicketStatus.Expired;
                return false;
            }

            if (Status == TicketStatus.Expired)
            {
                return false;
            }

            return true;
        }
    }
}