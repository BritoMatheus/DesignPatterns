using System;
using System.Text;

namespace DesignPattern.Builder
{
    public class Email
    {
        public string To { get; set; } = "";
        public string From { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public List<string> CC { get; set; } = new List<string>();
        public List<string> BCC { get; set; } = new List<string>();
        public List<string> Attachments { get; set; } = new List<string>();
        public bool IsHtml { get; set; }
        public bool IsHighPriority { get; set; }

        public void Send()
        {
            Console.WriteLine("=== Sending Email ===");
            Console.WriteLine($"To: {To}");
            Console.WriteLine($"From: {From}");
            Console.WriteLine($"Subject: {Subject}");
            Console.WriteLine($"Body: {Body}");
            Console.WriteLine($"CC: {(CC.Count > 0 ? string.Join(", ", CC) : "None")}");
            Console.WriteLine($"BCC: {(BCC.Count > 0 ? string.Join(", ", BCC) : "None")}");
            Console.WriteLine($"Attachments: {(Attachments.Count > 0 ? string.Join(", ", Attachments) : "None")}");
            Console.WriteLine($"HTML Format: {(IsHtml ? "Yes" : "No")}");
            Console.WriteLine($"High Priority: {(IsHighPriority ? "Yes" : "No")}");
            Console.WriteLine("Email sent successfully!");
            Console.WriteLine();
        }
    }

    public interface IEmailBuilder
    {
        IEmailBuilder To(string to);
        IEmailBuilder From(string from);
        IEmailBuilder Subject(string subject);
        IEmailBuilder Body(string body);
        IEmailBuilder AddCC(string cc);
        IEmailBuilder AddBCC(string bcc);
        IEmailBuilder AddAttachment(string attachment);
        IEmailBuilder SetHtml(bool isHtml);
        IEmailBuilder SetHighPriority(bool isHighPriority);
        Email Build();
    }

    public class EmailBuilder : IEmailBuilder
    {
        private Email _email = new Email();

        public IEmailBuilder To(string to)
        {
            _email.To = to;
            return this;
        }

        public IEmailBuilder From(string from)
        {
            _email.From = from;
            return this;
        }

        public IEmailBuilder Subject(string subject)
        {
            _email.Subject = subject;
            return this;
        }

        public IEmailBuilder Body(string body)
        {
            _email.Body = body;
            return this;
        }

        public IEmailBuilder AddCC(string cc)
        {
            _email.CC.Add(cc);
            return this;
        }

        public IEmailBuilder AddBCC(string bcc)
        {
            _email.BCC.Add(bcc);
            return this;
        }

        public IEmailBuilder AddAttachment(string attachment)
        {
            _email.Attachments.Add(attachment);
            return this;
        }

        public IEmailBuilder SetHtml(bool isHtml)
        {
            _email.IsHtml = isHtml;
            return this;
        }

        public IEmailBuilder SetHighPriority(bool isHighPriority)
        {
            _email.IsHighPriority = isHighPriority;
            return this;
        }

        public Email Build()
        {
            return _email;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Email Builder Example
            Console.WriteLine("2. Email Builder Example:");
            var emailBuilder = new EmailBuilder();

            Console.WriteLine("Building Simple Email:");
            var simpleEmail = emailBuilder
                .To("john@example.com")
                .From("sender@example.com")
                .Subject("Hello")
                .Body("This is a simple email.")
                .Build();
            simpleEmail.Send();

            Console.WriteLine("Building Complex Email:");
            var complexEmail = emailBuilder
                .To("team@company.com")
                .From("manager@company.com")
                .Subject("Project Update - Urgent")
                .Body("<h1>Project Status</h1><p>Please review the attached documents.</p>")
                .AddCC("supervisor@company.com")
                .AddBCC("hr@company.com")
                .AddAttachment("project_report.pdf")
                .AddAttachment("budget_analysis.xlsx")
                .SetHtml(true)
                .SetHighPriority(true)
                .Build();
            complexEmail.Send();
            
        }
    }
}
