namespace MandatoryAssignment1
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }

        
        public void ValidateName()
        {
            if (Name == null) throw new ArgumentNullException("Cannot be null");
            if (Name.Length <= 1) throw new ArgumentOutOfRangeException("Must be above 2");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Cannot be blank");
        }

        public void ValidateAge()
        {
            if (Age < 2) throw new ArgumentOutOfRangeException("Must be above 2");
        }

        public void ValidateShirtNumber()
        {
            if (ShirtNumber < 1) throw new ArgumentOutOfRangeException("Cannot be less than 1");
            if (ShirtNumber > 99) throw new ArgumentOutOfRangeException("Cannot be more than 99");
        }

        public void Validate()
        {
            ValidateName();
            ValidateAge();
            ValidateShirtNumber();
        }
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Age)}={Age.ToString()}, {nameof(ShirtNumber)}={ShirtNumber.ToString()}}}";
        }


    }
}