package practicecode;

import java.util.ArrayList;
import java.util.Scanner;

public class DynamicAuthenticationSystem {
    private static ArrayList<String> usernames = new ArrayList<>();
    private static ArrayList<String> passwords = new ArrayList<>();
    private static ArrayList<String> roles = new ArrayList<>();

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Welcome to the Student Registration System");
        while (true) {
            System.out.println("\n[1] Login");
            System.out.println("[2] Register");
            System.out.println("[3] Exit");
            System.out.print("Choose an option: ");
            int choice = scanner.nextInt();
            scanner.nextLine(); 

           switch (choice) {
            case 1:
                login(scanner);
                break;
            case 2:
                register(scanner);
                break;
            case 3:
                System.out.println("Goodbye!");
                scanner.close();
                return;
            default:
        System.out.println("Invalid option. Please try again.");
}
        }
    }

    private static void login(Scanner scanner) {
        System.out.print("Enter username: ");
        String username = scanner.nextLine();

        System.out.print("Enter password: ");
        String password = scanner.nextLine();

        int userIndex = authenticate(username, password);
        if (userIndex != -1) {
            String role = roles.get(userIndex);
            System.out.println("Login successful! Role: " + role);

            if ("Admin".equalsIgnoreCase(role)) {
                showAdminMenu();
            } else if ("User".equalsIgnoreCase(role)) {
                showUserMenu();
            }
        } else {
            System.out.println("Invalid username or password.");
        }
    }

    private static void register(Scanner scanner) {
        System.out.print("Enter new username: ");
        String username = scanner.nextLine();

        if (usernames.contains(username)) {
            System.out.println("Username already exists. Please try a different one.");
            return;
        }

        System.out.print("Enter new password: ");
        String password = scanner.nextLine();

        System.out.print("Enter role (Admin/User): ");
        String role = scanner.nextLine();

        usernames.add(username);
        passwords.add(password);
        roles.add(role);
        System.out.println("Registration successful! You can now log in.");
    }

    private static int authenticate(String username, String password) {
        for (int i = 0; i < usernames.size(); i++) {
            if (usernames.get(i).equals(username) && passwords.get(i).equals(password)) {
                return i; 
            }
        }
        return -1;
    }

    private static void showAdminMenu() {
        Scanner scanner = new Scanner(System.in);
        ArrayList<User> users = new ArrayList<>();

        while (true) {
            
            System.out.println("\nAdmin Menu:");
            System.out.println("\n[1] - Add Record");
            System.out.println("[2] - Update Record");
            System.out.println("[3] - Search Record");
            System.out.println("[4] - Delete Record");
            System.out.println("[5] - Display All Records");
            System.out.println("[6] - Exit");
            
            try {
                System.out.print("Enter your choice: ");
                int choice = Integer.parseInt(scanner.nextLine());

                switch (choice) {
                    case 1:
                        try {
                            System.out.print("\nEnter ID No      : ");
                            int idNo = scanner.nextInt();
                            scanner.nextLine();

                            boolean idExists = false;
                            for (User user : users) {
                                if (user.idNo == idNo) {
                                    idExists = true;
                                    break;
                                }
                            }

                            if (idExists) {
                                System.out.println("Caution: ID No " + idNo + " already exists! Please enter a unique ID.\n");
                            } else {
                                System.out.print("Enter First Name : ");
                                String firstName = scanner.nextLine();
                                System.out.print("Enter Middle Name: ");
                                String middleName = scanner.nextLine();
                                System.out.print("Enter Last Name  : ");
                                String lastName = scanner.nextLine();

                                boolean NameExists = false;
                                    for (User user : users) {
                                        if (user.firstName.equals(firstName) && user.middleName.equals(middleName) && user.lastName.equals(lastName)) {
                                            NameExists = true;
                                            break;
                                        }
                                    }
                                    if(NameExists){
                                        System.out.println("Caution: Identity " + firstName +" "+ middleName +" "+ lastName + " is already added to the list.");
                                    }else{
                                        System.out.print("Enter Course     : ");
                                        String course = scanner.nextLine();

                                        users.add(new User(idNo, firstName, middleName, lastName, course));
                                        System.out.println("Record added successfully!\n");
                                        }
                            }
                        } catch (NumberFormatException e) {
                            System.out.println("Invalid ID.");
                        }
                        break;

                    case 2:  
                        try {
                            System.out.print("\nEnter ID No to update: ");
                            int updateId = scanner.nextInt();
                            scanner.nextLine();  // consume the newline
                            boolean foundUpdate = false;

                            for (User user : users) {
                                if (user.idNo == updateId) {
                                    foundUpdate = true;
                                    System.out.println("Record found. Select the attribute to update:");
                                    boolean updateAnother = true;

                                    while (updateAnother) {
                                        System.out.println("\n[1] - First Name");
                                        System.out.println("[2] - Middle Name");
                                        System.out.println("[3] - Last Name");
                                        System.out.println("[4] - Course");
                                        System.out.println("[5] - Exit update");

                                        System.out.print("Enter your choice: ");
                                        int choiceUpdate = scanner.nextInt();
                                        scanner.nextLine();

                                        switch (choiceUpdate) {
                                            case 1:
                                                System.out.print("Enter new First Name: ");
                                                user.firstName = scanner.nextLine();
                                                break;
                                            case 2:
                                                System.out.print("Enter new Middle Name: ");
                                                user.middleName = scanner.nextLine();
                                                break;
                                            case 3:
                                                System.out.print("Enter new Last Name: ");
                                                user.lastName = scanner.nextLine();
                                                break;
                                            case 4:
                                                System.out.print("Enter new Course: ");
                                                user.course = scanner.nextLine();
                                                break;
                                            case 5:
                                                updateAnother = false;
                                                break;
                                            default:
                                                System.out.println("Invalid option, please try again.");
                                        }

                                        if (updateAnother) {
                                            System.out.println("Updated successfully! Do you want to update another field?");
                                        }
                                    }
                                    System.out.println("Update complete.");
                                    break;
                                }
                            }

                            if (!foundUpdate) {
                                System.out.println("Record not found!\n");
                            }
                        } catch (Exception e) {
                            System.out.println("Error while updating record: " + e.getMessage() + "\n");
                        }
                        break;

                    case 3:
                        try {
                            System.out.print("\nEnter ID No to search: ");
                            int searchId = scanner.nextInt();
                            scanner.nextLine();  // consume the newline
                            boolean foundSearch = false;

                            for (User user : users) {
                                if (user.idNo == searchId) {
                                    System.out.println("Record Found:");
                                    System.out.println(user);
                                    foundSearch = true;
                                    break;
                                }
                            }

                            if (!foundSearch) {
                                System.out.println("Record not found!\n");
                            }
                        } catch (Exception e) {
                            System.out.println("Error while searching record: " + e.getMessage() + "\n");
                        }
                        break;

                    case 4:
                        try {
                            System.out.print("\nEnter ID No to delete: ");
                            int deleteId = scanner.nextInt();
                            scanner.nextLine();  // consume the newline
                            boolean foundDelete = false;

                            for (User user : users) {
                                if (user.idNo == deleteId) {
                                    users.remove(user);
                                    System.out.println("Record deleted successfully!\n");
                                    foundDelete = true;
                                    break;
                                }
                            }

                            if (!foundDelete) {
                                System.out.println("Record not found!\n");
                            }
                        } catch (Exception e) {
                            System.out.println("Error while deleting record: " + e.getMessage() + "\n");
                        }
                        break;

                    case 5:
                        try {
                            System.out.println("\nAll Records:");
                            if (users.isEmpty()) {
                                System.out.println("No records available.\n");
                            } else {
                                for (User user : users) {
                                    System.out.println(user);
                                }
                            }
                        } catch (Exception e) {
                            System.out.println("Error while displaying records: " + e.getMessage() + "\n");
                        }
                        break;

                    case 6:
                        System.out.println("Exiting the application. Goodbye!");
                        scanner.close();
                        return;

                    default:
                        System.out.println("Invalid choice! Please try again.\n");
                }
            } catch (NumberFormatException e) {
                System.out.println("Invalid input! Please enter a valid number.\n");
            } catch (Exception e) {
                System.out.println("An unexpected error occurred: " + e.getMessage() + "\n");
            }
        }

    }

    private static void showUserMenu() {
        System.out.println("\nUser Menu:");
        System.out.println("[1] Search Record");
        System.out.println("[2] View All Records");
        System.out.println("[3] Logout");

    }
}
