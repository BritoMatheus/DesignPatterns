using System;

namespace DesignPattern.Prototype
{
    public class PrototypeManager
    {
        private Dictionary<string, ICloneable<object>> _prototypes = new Dictionary<string, ICloneable<object>>();

        public void RegisterPrototype(string key, ICloneable<object> prototype)
        {
            _prototypes[key] = prototype;
        }

        public T GetPrototype<T>(string key) where T : class
        {
            if (_prototypes.TryGetValue(key, out var prototype))
            {
                return (prototype.Clone() as T)!;
            }
            throw new ArgumentException($"Prototype with key '{key}' not found.");
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

            var originalDoc = new Document("Design Patterns", "This document explains design patterns.", "John Doe");
            originalDoc.AddTag("Programming");
            originalDoc.AddTag("Design");
            originalDoc.IsPublic = true;

            Console.WriteLine("Original Document:");
            originalDoc.Display();

            // Clone the document
            var clonedDoc = originalDoc.Clone();
            clonedDoc.Title = "Design Patterns - Copy";
            clonedDoc.UpdateContent("This is a modified copy of the original document.");
            clonedDoc.AddTag("Copy");

            Console.WriteLine("Cloned Document (modified):");
            clonedDoc.Display();

            Console.WriteLine("Original Document (unchanged):");
            originalDoc.Display();

            var originalCharacter = new GameCharacter("Aragorn", "Warrior");
            originalCharacter.Level = 5;
            originalCharacter.Health = 150;
            originalCharacter.Mana = 75;
            originalCharacter.Strength = 18;
            originalCharacter.Intelligence = 12;
            originalCharacter.Dexterity = 15;
            originalCharacter.AddSkill("Sword Mastery");
            originalCharacter.AddSkill("Shield Block");
            originalCharacter.AddItem("Iron Sword", 1);
            originalCharacter.AddItem("Health Potion", 3);

            Console.WriteLine("Original Character:");
            originalCharacter.Display();

            Console.WriteLine("4. Prototype Manager Example:");
            var manager = new PrototypeManager();
            
            // Register prototypes
            manager.RegisterPrototype("warrior", originalCharacter);
            manager.RegisterPrototype("document_template", originalDoc);
            manager.RegisterPrototype("user_template", originalProfile);

            // Create new instances from prototypes
            var newWarrior = manager.GetPrototype<GameCharacter>("warrior");
            newWarrior.Name = "New Warrior";
            newWarrior.Level = 1;
            newWarrior.Health = 100;

            var newDoc = manager.GetPrototype<Document>("document_template");
            newDoc.Title = "New Document";
            newDoc.Content = "This is a new document created from template.";

            Console.WriteLine("New Warrior from Prototype Manager:");
            newWarrior.Display();

            Console.WriteLine("New Document from Prototype Manager:");
            newDoc.Display();
            
        }
    }
}
