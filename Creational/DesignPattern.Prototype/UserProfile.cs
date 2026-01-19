using System;

namespace DesignPattern.Prototype
{
    
    // Concrete Prototype - User Profile
    public class UserProfile : ICloneable<UserProfile>
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public List<string> Interests { get; set; } = new List<string>();
        public Dictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();
        public bool IsActive { get; set; }

        public UserProfile(string username, string email, string firstName, string lastName)
        {
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
        }

        // Copy constructor for deep cloning
        public UserProfile(UserProfile other)
        {
            Username = other.Username;
            Email = other.Email;
            FirstName = other.FirstName;
            LastName = other.LastName;
            DateOfBirth = other.DateOfBirth;
            Interests = new List<string>(other.Interests); // Deep copy
            Settings = new Dictionary<string, string>(other.Settings); // Deep copy
            IsActive = other.IsActive;
        }

        public UserProfile Clone()
        {
            return new UserProfile(this);
        }

        public void Display()
        {
            Console.WriteLine($"=== User Profile: {Username} ===");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Date of Birth: {DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine($"Interests: {(Interests.Count > 0 ? string.Join(", ", Interests) : "None")}");
            Console.WriteLine($"Settings: {(Settings.Count > 0 ? string.Join(", ", Settings.Select(kv => $"{kv.Key}={kv.Value}")) : "None")}");
            Console.WriteLine($"Active: {(IsActive ? "Yes" : "No")}");
            Console.WriteLine();
        }

        public void AddInterest(string interest)
        {
            Interests.Add(interest);
        }

        public void SetSetting(string key, string value)
        {
            Settings[key] = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var originalProfile = new UserProfile("johndoe", "john@example.com", "John", "Doe");
            originalProfile.DateOfBirth = new DateTime(1990, 5, 15);
            originalProfile.AddInterest("Programming");
            originalProfile.AddInterest("Gaming");
            originalProfile.SetSetting("Theme", "Dark");
            originalProfile.SetSetting("Language", "English");

            Console.WriteLine("Original Profile:");
            originalProfile.Display();

            // Clone the profile
            var clonedProfile = originalProfile.Clone();
            clonedProfile.Username = "johndoe_clone";
            clonedProfile.Email = "john_clone@example.com";
            clonedProfile.AddInterest("Music");
            clonedProfile.SetSetting("Theme", "Light");

            Console.WriteLine("Cloned Profile (modified):");
            clonedProfile.Display();
            
        }
    }
}
