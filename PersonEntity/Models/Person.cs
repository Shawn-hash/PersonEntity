namespace PersonEntity.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime LastModifiedOn { get; set; }

        // Constructor to initialize properties
        public Person(string firstName, string lastName, int age)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            LastModifiedOn = DateTime.UtcNow;
        }

        // Parameterless constructor for model binding
        public Person() { }
    }
}
