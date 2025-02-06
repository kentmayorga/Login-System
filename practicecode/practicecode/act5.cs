class HelloWorld {
    
  public void payment(int value){
      int discount = 100;
      int result = value + discount;
      
      Console.WriteLine("Processing fee added: "+ discount);
      Console.WriteLine("Updated total (Call by value): $" + result);
  }
  
  public void discount(ref int value, double disc){
      double total = value -(value * disc);
      Console.WriteLine("Discount applied: " + disc);
      Console.WriteLine("Total after Discount (Call by reference): $" + total);
      
  }
  public void final(out int value, ref double finaloutput){
      Console.WriteLine("Enter discount value: ");
      double disval = Convert.ToDouble(Console.ReadLine()) / 100;
      
      value = 1000;
      int disc1 = 100;
      
      double discounted = value * disval;
      finaloutput =  value - discounted + disc1; 
      Console.WriteLine("Final Price after Discount(Using out parameter): $" + finaloutput);      
  }
  
  static void Main(string [] args) {
    bool exit = true;
    while(exit){
        int value = 1000;
        double disc = 0.15;
        
        HelloWorld program = new HelloWorld();
        
        Console.WriteLine("Welcome to the Simple Payment System");
        Console.WriteLine("User: Kent P. Mayorga");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Menu Options");
        Console.WriteLine("1: Make a Payment(Call by value)");
        Console.WriteLine("2: Apply discount(Call by reference)");
        Console.WriteLine("3: Calculate Final Price with Discount(Using out parameter)");
        Console.WriteLine("4: Exit");
        
        Console.Write("Enter option (1-4): ");
        int option = Convert.ToInt32(Console.ReadLine());

        
        switch(option){
            case 1:
                program.payment(value);
            break;
            case 2:
                program.discount(ref value, disc);
            break;
            case 3:
                double finaloutput = 0;
                program.final(out value, ref finaloutput);
            break;
            case 4:
                Console.WriteLine("Exiting the system. Thankyou for using the simple Payment System!");
                exit = false;
            break;
        }
        Console.WriteLine();
    }
  }
}
