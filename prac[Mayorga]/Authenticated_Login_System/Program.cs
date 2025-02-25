using System;
using System.Collections.Generic;

public class RegisterUser {
    public string Fname { get; set; }
    public string Lname { get; set; }
    public string Mname { get; set; }
    public string Number { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    private string pass;
    
    public string Password {
        get { return pass; }
        set {
            if (string.IsNullOrEmpty(value)) {
                Console.WriteLine("Password shouldn't be empty.");
            } else {
                pass = value;
            }
        }
    }
    public string Role { get; set; }
    public void Records(){
        Console.WriteLine($"Name    : {Fname} {Mname} {Lname}");
        Console.WriteLine($"Number  : {Number}");
        Console.WriteLine($"Email   : {Email}\n");
    }
}

class authenticated_Login_System {
    static List<string> usernames = new List<string>();
    static List<string> passwords = new List<string>();
    static List<string> roles = new List<string>();
    static List<RegisterUser> record = new List<RegisterUser>();

    static void Main() {
        int chance = 0;
        bool exit = false;
        while (!exit && chance < 3) {
            Console.WriteLine("Authenticated_Login_System");
            Console.WriteLine("------Menu------");
            Console.WriteLine("1. Log-in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                case 3:
                    Console.WriteLine("Thank you for using Authenticated_Login_System.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Error: Invalid choice.");
                    break;
            }
        }
    }

    private static void Login() {
        Console.WriteLine("\nLogin");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        int userIndex = usernames.IndexOf(username);

        if (userIndex != -1 && passwords[userIndex] == password) {
            string role = roles[userIndex];
            Console.WriteLine($"Login successful! Role: {role}");

            if (role.ToLower() == "admin") {
                Admin(username);
            } else if (role.ToLower() == "user") {
                User(username);
            }
        } else {
            Console.WriteLine("Invalid username or password.");
        }
    }

    private static void Register() {
        RegisterUser reg = new RegisterUser();

        Console.WriteLine("\nAccount Registration.");
        Console.Write("First Name: ");
        reg.Fname = Console.ReadLine();

        Console.Write("Last Name: ");
        reg.Lname = Console.ReadLine();

        Console.Write("Middle Name (Optional): ");
        reg.Mname = Console.ReadLine();

        Console.Write("Contact Number: ");
        reg.Number = Console.ReadLine();

        Console.Write("Email (Must be Unique): ");
        reg.Email = Console.ReadLine();

        Console.Write("Username (Must be Unique): ");
        reg.Username = Console.ReadLine();

        if (usernames.Contains(reg.Username)) {
            Console.WriteLine("Error: Username already taken.");
            return;
        }

        bool ps = false;
        while (!ps) {
            Console.Write("Password: ");
            reg.Password = Console.ReadLine();

            if (string.IsNullOrEmpty(reg.Password)) {
                Console.WriteLine("Error: Password shouldn't be empty.");
            } else {
                ps = true;
            }
        }

        Console.Write("Role (User/Admin): ");
        reg.Role = Console.ReadLine();

        if (reg.Role.ToLower() != "user" && reg.Role.ToLower() != "admin") {
            Console.WriteLine("Error: Role must be either 'User' or 'Admin'.");
            return;
        }

        usernames.Add(reg.Username);
        passwords.Add(reg.Password);
        roles.Add(reg.Role);
        record.Add(reg);

        Console.WriteLine("Registration successful!");
    }

    private static void ChangePassword(string username) {
        int userIndex = usernames.IndexOf(username);
        if (userIndex == -1) {
            Console.WriteLine("User not found.");
            return;
        }

        Console.Write("Enter current password: ");
        if (Console.ReadLine() != passwords[userIndex]) {
            Console.WriteLine("Incorrect current password.");
            return;
        }

        Console.Write("Enter new password: ");
        string newPassword = Console.ReadLine();
        if (!string.IsNullOrEmpty(newPassword)) {
            passwords[userIndex] = newPassword;
            Console.WriteLine("Password changed successfully!");
        } else {
            Console.WriteLine("Error: Password shouldn't be empty.");
        }
    }

    private static void Admin(string username) {
    while (true) {
        Console.WriteLine("\nAdmin Menu.");
        Console.WriteLine("1. View Profile");
        Console.WriteLine("2. View All Profiles");
        Console.WriteLine("3. Change Password");
        Console.WriteLine("4. Logout");
        Console.Write("Enter Choice: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice) {
            case 1: 
                foreach (var user in record) {
                    if (user.Username == username) {
                        user.Records();
                    }
                }
                break;
            case 2:
                foreach (var user in record) {
                    user.Records();
                }
                break;
            case 3:
                ChangePassword(username);
                break;
            case 4:
                Console.WriteLine("Logging out...");
                return;
            default:
                Console.WriteLine("Error: Invalid choice.");
                break;
        }
    }
}

    private static void User(string username) {
        while (true) {
            Console.WriteLine("\nUser Menu.");
            Console.WriteLine("1. View Profile");
            Console.WriteLine("2. View All Profiles");
            Console.WriteLine("3. Change Password");
            Console.WriteLine("4. Logout");
            Console.Write("Enter Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) {
                case 1:
                    foreach (var user in record) {
                        if (user.Username == username) {
                            user.Records();
                        }
                    }
                    break;
                case 2:
                    if(roles[usernames.IndexOf(username)] == "admin"){
                        foreach(var user in record){
                            user.Records();
                        }
                    }else{
                        Console.WriteLine("Admin access only.");
                    }
                break;
                case 3:
                    ChangePassword(username);
                    break;
                case 4:
                    Console.WriteLine("Logging out...");
                    return;
                default:
                    Console.WriteLine("Error: Invalid choice.");
                    break;
            }
        }
    }
}
