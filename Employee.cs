namespace ThemeParkSystem
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string AssignedLocation { get; set; }


        public Employee(
            string id,
            string name,
            string role)
        {
            Id = id;
            Name = name;
            Role = role;
            AssignedLocation = null;
        }


        public bool IsAvailable()
        {
            if (AssignedLocation == null)
            {
                return true;
            }

            return false;
        }
    }
}