using System;

namespace DesignPattern.Prototype
{
    // Concrete Prototype - Document
    public class Document : ICloneable<Document>
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public bool IsPublic { get; set; }

        public Document(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        // Copy constructor for deep cloning
        public Document(Document other)
        {
            Title = other.Title;
            Content = other.Content;
            Author = other.Author;
            CreatedDate = other.CreatedDate;
            ModifiedDate = other.ModifiedDate;
            Tags = new List<string>(other.Tags); // Deep copy of list
            IsPublic = other.IsPublic;
        }

        public Document Clone()
        {
            return new Document(this);
        }

        public void Display()
        {
            Console.WriteLine($"=== Document: {Title} ===");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Created: {CreatedDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Modified: {ModifiedDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Content: {Content}");
            Console.WriteLine($"Tags: {(Tags.Count > 0 ? string.Join(", ", Tags) : "None")}");
            Console.WriteLine($"Public: {(IsPublic ? "Yes" : "No")}");
            Console.WriteLine();
        }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
            ModifiedDate = DateTime.Now;
        }

        public void UpdateContent(string newContent)
        {
            Content = newContent;
            ModifiedDate = DateTime.Now;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Document Prototype Example:");
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
        }
    }
}
