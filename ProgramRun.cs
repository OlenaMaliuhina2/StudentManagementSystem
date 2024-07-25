using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class ProgramRun
    {
        private static bool _running = true;

        public void Run()
        {
            {
                var userManager = new UserManager();
                var studentManager = new StudentManagement();

                while (true)
                {
                    Console.WriteLine("Welcome to the Student Management System");
                    Console.WriteLine("1. Sign In");
                    Console.WriteLine("2. Log In");
                    Console.WriteLine("3. Exit");
                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            userManager.SignIn();
                            break;
                        case "2":
                            if (userManager.LogIn())
                            {
                                ShowMainMenu(studentManager);
                            }
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }

        static void ShowMainMenu(StudentManagement studentManager)
        {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Manage Students");
                Console.WriteLine("2. Manage Marks");
                Console.WriteLine("3. View Information");
                Console.WriteLine("4. Log Out");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        studentManager.ManageStudents();
                        break;
                    case "2":
                        studentManager.ManageMarks();
                        break;
                    case "3":
                        studentManager.ViewInformation();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        class UserManager
        {
            private Dictionary<string, string> users = new Dictionary<string, string>();

            public void SignIn()
            {
                Console.Write("Enter username: ");
                var username = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                if (!users.ContainsKey(username))
                {
                    users[username] = password;
                    Console.WriteLine("User registered successfully.");
                }
                else
                {
                    Console.WriteLine("Username already exists.");
                }
            }

            public bool LogIn()
            {
                Console.Write("Enter username: ");
                var username = Console.ReadLine();
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                if (users.ContainsKey(username) && users[username] == password)
                {
                    Console.WriteLine("Login successful.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    return false;
                }
            }
        }

    }
}

