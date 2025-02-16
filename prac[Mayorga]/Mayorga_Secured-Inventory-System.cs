using System;

class Secured_Invetory_System {
  static void Main() {
    string[,] users = {{"admin", "admin123"}, {"manager", "manager123"}};
    string[,] products = {{"Apples", "Milk" , "Bread"},
                          {"10", "5", "20"}
    };
    int attempt = 0;
    bool test = false;
    
    while(attempt < 3 && !test){
        
        Console.Write("Enter Username: ");
        string username = Console.ReadLine() ?? " ";// this is to not return null since my compiler promps many errors about this line sir. 
                                                    // I just searched for solution and know about this.
        Console.Write("Enter Password: ");
        string password = Console.ReadLine() ?? " ";
        
        
        for(int i = 0; i < users.GetLength(0);i++){
            if(username == users[i, 0] && password == users[i, 1]){
                    Console.WriteLine("Login succesful! Welcome to the inventory management System.");
                
                bool exit = false;
                while(!exit){
                    test = true;
                    Console.WriteLine("\nSelect an option from the Menu: ");    
                    Console.WriteLine("1. View Inventory");
                    Console.WriteLine("2. Update Stock");
                    Console.WriteLine("3. Calculate Total");
                    Console.WriteLine("4. Logout");

                    Console.Write("Enter choice: ");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch(option){
                        case 1:
                            Console.WriteLine("Current Inventory:");
                            for(int j = 0; j < products.GetLength(1); j++){
                                Console.WriteLine(products[0,j] + ": " + products[1, j] + " units.");
                            }
                        break;
                        case 2:
                            Console.WriteLine("Enter product name: ");
                            string name = Console.ReadLine() ?? " ";

                            Console.WriteLine("Enter quantity to add: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            int index = -1;
                            for (int j = 0; j < products.GetLength(1); j++) {
                                if (products[0, j] == name) {
                                    index = j;
                                    break;
                                }
                            }

                            if (index != -1) {
                                int currentStock = Convert.ToInt32(products[1, index]);
                                currentStock += quantity;
                                products[1, index] = currentStock.ToString();

                                Console.WriteLine($"Updated Inventory: {name} now has {currentStock} units.");
                            } else {
                                Console.WriteLine("Product not found!");
                            }
                        break;
                        case 3:
                            int totalStock = 0;
                            
                            for(int j = 0; j < products.GetLength(1); j++){
                                totalStock += Convert.ToInt32(products[1, j]);
                            }
                            Console.WriteLine($"Total products in stock = {totalStock} units");
                        break;
                        case 4:
                            exit = true;
                            Console.WriteLine("Logout Succesfully! Exiting System.");
                            break;
                        default: 
                            Console.WriteLine("Error");
                        break;
                    }
                }
            }
        } 
        if(!test){
            attempt++;
            Console.WriteLine("Login failed! Attempt " + attempt + " of 3.");
        }
    }
  }
}