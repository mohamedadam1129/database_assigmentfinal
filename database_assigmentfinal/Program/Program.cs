using database_assigmentfinal;
using database_assigmentfinal.DataContext;
using Microsoft.EntityFrameworkCore;

namespace database_assigmentfinal
{
    class Program
    {
        private static readonly Databasecontext _context = new();

        static void Main(string[] args)
        {
            InitializeDatabase();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Project Management System");
                Console.WriteLine("1. View All Projects");
                Console.WriteLine("2. Add New Project");
                Console.WriteLine("3. Exit");
                Console.Write("\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewProjects();
                        break;
                    case "2":
                        AddProject();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void InitializeDatabase()
        {
            _context.Database.EnsureCreated();
        }

        private static void ViewProjects()
        {
            while (true)
            {
                Console.Clear();
                var projects = _context.Projects.OrderBy(p => p.ProjectNumber).ToList();

                Console.WriteLine("Current Projects:");
                Console.WriteLine("No.\tName\tPeriod\t\t\tStatus");
                Console.WriteLine(new string('-', 50));

                foreach (var project in projects)
                {
                    Console.WriteLine($"{project.ProjectNumber}\t{project.Name}\t{project.StartDate:d} - {project.EndDate:d}\t{project.Status}");
                }

                Console.WriteLine("\nEnter project number to edit, or 0 to return to main menu:");
                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    if (selection == 0) break;
                    var selectedProject = projects.FirstOrDefault(p => p.ProjectNumber == selection);
                    if (selectedProject != null)
                    {
                        EditProject(selectedProject);
                    }
                    else
                    {
                        Console.WriteLine("Project not found. Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private static void AddProject()
        {
            Console.Clear();
            var project = new database_assigmentfinal.Project  
            {
                ProjectNumber = _context.Projects.Any() ? _context.Projects.Max(p => p.ProjectNumber) + 1 : 1
            };
            Console.WriteLine("Add New Project");
            Console.WriteLine("Enter project details:");

            Console.Write("Name: ");
            project.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("Start Date (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime startDate);
            project.StartDate = startDate;

            Console.Write("End Date (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime endDate);
            project.EndDate = endDate;

            Console.Write("Project Manager: ");
            project.ProjectManager = Console.ReadLine() ?? string.Empty;

            Console.Write("Customer: ");
            project.Customer = Console.ReadLine() ?? string.Empty;

            Console.Write("Hourly Rate (SEK): ");
            decimal.TryParse(Console.ReadLine(), out decimal hourlyRate);
            project.HourlyRate = hourlyRate;

            Console.Write("Total Price: ");
            decimal.TryParse(Console.ReadLine(), out decimal totalPrice);
            project.TotalPrice = totalPrice;

            project.Status = ProjectStatus.NotStarted;

            _context.Projects.Add(project);
            _context.SaveChanges();

            Console.WriteLine("\nProject added successfully! Press any key to continue...");
            Console.ReadKey();
        }

        private static void EditProject(database_assigmentfinal.Project project)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Editing Project {project.ProjectNumber}");
                Console.WriteLine("1. Name: " + project.Name);
                Console.WriteLine("2. Start Date: " + project.StartDate.ToShortDateString());
                Console.WriteLine("3. End Date: " + project.EndDate.ToShortDateString());
                Console.WriteLine("4. Project Manager: " + project.ProjectManager);
                Console.WriteLine("5. Customer: " + project.Customer);
                Console.WriteLine("6. Hourly Rate: " + project.HourlyRate);
                Console.WriteLine("7. Total Price: " + project.TotalPrice);
                Console.WriteLine("8. Status: " + project.Status);
                Console.WriteLine("9. Save and Exit");
                Console.WriteLine("0. Cancel and Exit");

                Console.Write("\nSelect field to edit: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("New Name: ");
                        project.Name = Console.ReadLine() ?? project.Name;
                        break;
                    case "2":
                        Console.Write("New Start Date (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
                            project.StartDate = startDate;
                        break;
                    case "3":
                        Console.Write("New End Date (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
                            project.EndDate = endDate;
                        break;
                    case "4":
                        Console.Write("New Project Manager: ");
                        project.ProjectManager = Console.ReadLine() ?? project.ProjectManager;
                        break;
                    case "5":
                        Console.Write("New Customer: ");
                        project.Customer = Console.ReadLine() ?? project.Customer;
                        break;
                    case "6":
                        Console.Write("New Hourly Rate: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal hourlyRate))
                            project.HourlyRate = hourlyRate;
                        break;
                    case "7":
                        Console.Write("New Total Price: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal totalPrice))
                            project.TotalPrice = totalPrice;
                        break;
                    case "8":
                        Console.WriteLine("Select Status:");
                        Console.WriteLine("1. Not Started");
                        Console.WriteLine("2. Ongoing");
                        Console.WriteLine("3. Completed");
                        if (int.TryParse(Console.ReadLine(), out int status) && status >= 1 && status <= 3)
                            project.Status = (ProjectStatus)(status - 1);
                        break;
                    case "9":
                        _context.SaveChanges();
                        return;
                    case "0":
                        return;
                }
            }
        }
    }
}

