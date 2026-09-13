namespace ThemeParkSystem
{
    public class Visitor
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Height { get; set; }

        public VisitorCategory Category { get; set; }

        public bool HasAccompanyingAdult { get; set; }

        public Ticket Ticket { get; set; }


        public Visitor(
            string id,
            string name,
            int age,
            double height,
            VisitorCategory category,
            bool hasAccompanyingAdult)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
            Category = category;
            HasAccompanyingAdult = hasAccompanyingAdult;
            Ticket = null;
        }
    }
}