namespace ThemeParkSystem
{
    public class Facility
    {
        public string Name { get; set; }

        public bool RegularTicketAllowed { get; set; }


        public Facility(string name, bool regularTicketAllowed)
        {
            Name = name;
            RegularTicketAllowed = regularTicketAllowed;
        }
    }
}