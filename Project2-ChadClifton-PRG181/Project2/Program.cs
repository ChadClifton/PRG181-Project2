using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Program
    {                
        static Dictionary<string, double> orders = new Dictionary<string, double>();    // A dictionary collection that stores the order and the corresponding price.

        static int choice;  // Value which identifies which option they want from the menu
        static int pick = 0;    // Value is going to be used to pick an option from the second menu option they choose from 
        static int p = 0;   // Value is going to be used to pick an option from the third menu option they chose from

        static char more;   // Used to stay at the current selection menu, so more options can be added

        enum MainMenu   // An enum that holds the main menu's values
        {
            Breakfast = 1,
            Combos,
            Chips,
            Burgers,
            Drinks,
            Checkout,
            Exit
        }

        enum Breakfast  // An enum that holds the breakfast options. Followed by variables that hold the prices for the options
        {
            Breakfast_Special = 1,
            Hashbrown_and_egg,
            Sunday_Special,
            PoBoy_and_egg,
            Back
        }
        static double breakfastSpecial = 40;
        static double hashBrownAndEgg = 20;
        static double sundaySpecial = 60;
        static double poBoyAndEgg = 55;

        enum Combos // An enum that holds the combo deals. Followed by variables that hold the prices for the deals
        {
            Cheese_Burger_mid_Chips_Coke = 1,
            Smash_Burger_mid_Chips_Lime_Milkshake,
            Juicy_Lucy_mid_Chips_Apple_juice,
            Regular_Burger_small_Chips_Tea,
            Back
        }
        static double cheeseBurgereMidChipsCoke = 99;
        static double smashBurgerMidChipsLimeMilkshake = 115;
        static double juicyLucyMidChipsAppleJuice = 120;
        static double regularBurgerSmallChipsTea = 57;


        enum Chips  // An enum that holds the chip serving sizes. Followed by variables that hold the prices for the different sizes
        {
            Small = 1,
            Mid,
            Large,
            Family,
            Back
        }
        static double small = 25;
        static double mid = 40;
        static double large = 60;
        static double family = 85;


        enum Burgers    // An enum that holds the burger options. Followed by variables that hold the prices for the options
        {
            Regular_Burger = 1,
            Cheese_Burger,
            Smash_Burger,
            Juicy_Lucy,
            Back
        }
        static double regularBurger = 35;
        static double cheeseBurger = 45;
        static double smashBurger = 56;
        static double juicyLucy = 70;

        enum Drinks // An enum that holds the main drinks menu values
        {
            Soft_Drinks = 1,
            Milkshake,
            Juice,
            Hot_Drinks,
            Back
        }

        enum SoftDrinks // An enum that holds the different Soft drinks available. Followed by variables that hold the prices for the drink.
        {
            Coke = 1,
            Sprite,
            Cream_Soda,
            Root_beer,
            Back
        }
        static double coke = 20;
        static double sprite = 20;
        static double creamSoda = 19;
        static double rootBeer = 23;

        enum Milkshake  // An enum that holds the milkshakes flavors. Followed by variables that hold the prices for the flavors
        {
            Chocolate = 1,
            Strawberry,
            Lime,
            Vanilla,
            Back
        }
        static double chocolate = 27;
        static double strawberry = 27;
        static double lime = 27;
        static double vanilla = 26;

        enum Juice  // An enum that holds the Juices options. Followed by variables that hold the prices for the options
        {
            Apple = 1,
            Orange,
            Fruit_Punch,
            Mango,
            Back
        }
        static double apple = 18;
        static double orange = 18;
        static double fruitPunch = 19;
        static double mango = 18;

        enum HotDrinks  // An enum that holds the Hot drinks available. Followed by variables that hold the prices for the drinks
        {
            Cappuccino = 1,
            Hot_Chocolate,
            Coffee,
            Tea,
            Back
        }
        static double cappuccino = 23;
        static double hotChocolate = 22;
        static double coffee = 22;
        static double tea = 19;

        static void Menus()     // A method that displays the Main Menu, and calls other methods that correspond to the menu
        {
            double orderTotal = 0;

            Console.WriteLine("Main MENU:\r\n");

            foreach (MainMenu meal in Enum.GetValues(typeof(MainMenu))) // Displays Main Menu
            {
                Console.WriteLine($"{(int)meal}. {meal.ToString()}");
            }
            Console.Write("\r\nPlease make your choice: ");
            choice = int.Parse(Console.ReadLine()); // Value from user which identifies which option they want from the Main Menu 

            switch (choice) // A switch case loop that calls the corresponding chosen menu
            {
                case (int)MainMenu.Breakfast:
                    Console.Clear();
                    BreakfastOptions();
                    break;
                case (int)MainMenu.Combos:
                    Console.Clear();
                    combos();
                    break;
                case (int)MainMenu.Chips:
                    Console.Clear();
                    chips();
                    break;
                case (int)MainMenu.Burgers:
                    Console.Clear();
                    burgers();
                    break;
                case (int)MainMenu.Drinks:
                    Console.Clear();
                    DrinksEx(); // Created a separate method for the Drinks Menu options                  
                    break;
                case (int)MainMenu.Checkout:
                    Console.Clear();                    
                    Console.WriteLine("Your order:");
                    foreach (var meal in orders) // Displays all the key Values or orders in the dictionary, and then adds its price to the total.
                    {
                        Console.WriteLine(meal.Key);
                        orderTotal += meal.Value;
                    }

                    Console.WriteLine("Your Total amounts to: R{0}", orderTotal);

                    orderTotal = 0;   // empties cart total price
                    orders.Clear();  // empties cart 

                    Console.ReadLine();
                    Console.Clear();
                    Menus();
                    break;
                case (int)MainMenu.Exit:
                    Environment.Exit(0); //Exits the console.
                    break;

                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    Menus();
                    break;
            }
        }

        static void BreakfastOptions()  // Method that displays the breakfast options. Adds the chosen meals to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", MainMenu.Breakfast.ToString());

            rows = "1. Break fast Special R{0}\r\n2. Hashbrown and egg R{1}\r\n3. Sunday Special R{2}\r\n4. Poyboy and egg R{3}\r\n5. Back";
            Console.WriteLine(rows, breakfastSpecial, hashBrownAndEgg, sundaySpecial, poBoyAndEgg); // Displays the options in rows.

            Console.Write("\r\nPlease make your choice: ");
            pick = int.Parse(Console.ReadLine());

            switch (pick)   // Adds the chosen option to the collection
            {
                case (int)Breakfast.Breakfast_Special:
                    orders.Add("Breakfast Special", breakfastSpecial);
                    break;
                case (int)Breakfast.Hashbrown_and_egg:
                    orders.Add("Hashborwn and egg", hashBrownAndEgg);
                    break;
                case (int)Breakfast.Sunday_Special:
                    orders.Add("Sunday Special", sundaySpecial);
                    break;
                case (int)Breakfast.PoBoy_and_egg:
                    orders.Add("Poboy and egg", poBoyAndEgg);
                    break;
                case (int)Breakfast.Back:
                    Console.Clear();
                    Menus();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    BreakfastOptions();
                    break;
            }

            Console.WriteLine("Order added successfully");
            
            Console.Write("\r\nDo you wish to add anything else from the breakfast menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')    //Displays the breakfast list again.
            {
                Console.Clear();
                BreakfastOptions();
            }
            else    //Return to the main menu
            {
                Console.Clear();
                Menus();
            }
        }

        static void combos()    // Method that displays the combo lists. Adds the chosen meals to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", MainMenu.Combos.ToString());

            rows = "1. Cheese burger with mid Chips and Coke R{0}\r\n2. Smash burger with mid Chips and Lime milkshake R{1}\r\n3. Juicy Lucy with mid Chips and Apple juice R{2}\r\n4. Regular burger with small chips and Tea R{3}\r\n5. Back";
            Console.WriteLine(rows, cheeseBurgereMidChipsCoke, smashBurgerMidChipsLimeMilkshake, juicyLucyMidChipsAppleJuice, regularBurgerSmallChipsTea);

            Console.Write("\r\nPlease make your choice: ");
            pick = int.Parse(Console.ReadLine());

            switch (pick)
            {
                case (int)Combos.Cheese_Burger_mid_Chips_Coke:
                    orders.Add("Cheese burger with mid Chips and Coke", cheeseBurgereMidChipsCoke);
                    break;
                case (int)Combos.Smash_Burger_mid_Chips_Lime_Milkshake:
                    orders.Add("Smash burger with mid Chips and Lime milkshake", smashBurgerMidChipsLimeMilkshake);
                    break;
                case (int)Combos.Juicy_Lucy_mid_Chips_Apple_juice:
                    orders.Add("Juicy Lucy with mid Chips and Apple juice", juicyLucyMidChipsAppleJuice);
                    break;
                case (int)Combos.Regular_Burger_small_Chips_Tea:
                    orders.Add("Regular burger with small chips and Tea", regularBurgerSmallChipsTea);
                    break;
                case (int)Combos.Back:
                    Console.Clear();
                    Menus();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    combos();
                    break;
            }

            Console.WriteLine("Order added successfully");
            
            Console.Write("\r\nDo you wish to add anything else from the Combos menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')
            {
                Console.Clear();
                BreakfastOptions();
            }
            else
            {
                Console.Clear();
                Menus();
            }
        }

        static void chips()     // Method that displays the chip sizes. Adds the chosen size to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", MainMenu.Chips.ToString());

            rows = "1. Small R{0}\r\n2. Mid R{1}\r\n3. Large R{2}\r\n4. Family R{3}\r\n5. Back";
            Console.WriteLine(rows, small, mid, large, family);

            Console.Write("\r\nPlease make your choice: ");
            pick = int.Parse(Console.ReadLine());

            switch (pick)
            {
                case (int)Chips.Small:
                    orders.Add("Small", small);
                    break;
                case (int)Chips.Mid:
                    orders.Add("Mid", mid);
                    break;
                case (int)Chips.Large:
                    orders.Add("Large", large);
                    break;
                case (int)Chips.Family:
                    orders.Add("Family", family);
                    break;
                case (int)Chips.Back:
                    Console.Clear();
                    Menus();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    BreakfastOptions();
                    break;
            }

            Console.WriteLine("Order added successfully");

            Console.Write("\r\nDo you wish to add anything else from the Chips menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')
            {
                Console.Clear();
                chips();
            }
            else
            {
                Console.Clear();
                Menus();
            }
        }

        static void burgers()   // Method that displays the burger options. Adds the chosen meals to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", MainMenu.Burgers.ToString());

            foreach (Burgers meal in Enum.GetValues(typeof(Burgers)))
            {
                Console.WriteLine($"{(int)meal}. {meal.ToString()}");
            }

            rows = "1. Regular Burger R{0}\r\n2. Cheese Burger R{1}\r\n3. Smash Burger R{2}\r\n4. Juicy Lucy R{3}\r\n5. Back";
            Console.WriteLine(rows, regularBurger, cheeseBurger, smashBurger, juicyLucy);

            Console.Write("\r\nPlease make your choice: ");
            pick = int.Parse(Console.ReadLine());

            switch (pick)
            {
                case (int)Burgers.Regular_Burger:
                    orders.Add("Regular Burger", regularBurger);
                    break;
                case (int)Burgers.Cheese_Burger:
                    orders.Add("Cheese Burger", cheeseBurger);
                    break;
                case (int)Burgers.Smash_Burger:
                    orders.Add("Smash Burger", smashBurger);
                    break;
                case (int)Burgers.Juicy_Lucy:
                    orders.Add("Juicy Lucy", juicyLucy);
                    break;
                case (int)Burgers.Back:
                    Console.Clear();
                    Menus();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    BreakfastOptions();
                    break;
            }

            Console.WriteLine("Order added successfully");

            Console.Write("\r\nDo you wish to add anything else from the Burger menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')
            {
                Console.Clear();
                burgers();
            }
            else
            {
                Console.Clear();
                Menus();
            }
        }

        static void DrinksEx()  // Method that displays the drinks main menu. Calls the chosen method to choose the drink
        {
            int choice; // Value from user which identifies which option they want from the Drink Menu 

            Console.WriteLine(MainMenu.Drinks.ToString());
            foreach (Drinks meal in Enum.GetValues(typeof(Drinks)))
            {
                Console.WriteLine($"{(int)meal}. {meal.ToString()}");
            }

            Console.Write("\r\nPlease make your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case (int)Drinks.Soft_Drinks:
                    Console.Clear();
                    softDrinks();
                    break;
                case (int)Drinks.Milkshake:
                    Console.Clear();
                    milkshake();
                    break;
                case (int)Drinks.Juice:
                    Console.Clear();
                    juice();
                    break;
                case (int)Drinks.Hot_Drinks:
                    Console.Clear();
                    hotDrinks();
                    break;
                case (int)Drinks.Back:
                    Console.Clear();
                    Menus();
                    break;
            }
        }

        static void softDrinks()    // Method that displays the Soft drink options. Adds the chosen drink to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", Drinks.Soft_Drinks.ToString());

            rows = "1. Coke R{0}\r\n2. Sprite R{1}\r\n3. Cream Soda R{2}\r\n4. Root beer R{3}\r\n5. Back";
            Console.WriteLine(rows, coke, sprite,creamSoda, rootBeer);

            Console.Write("\r\nPlease make your choice: ");
            p = int.Parse(Console.ReadLine());

            switch (p)
            {
                case (int)SoftDrinks.Coke:
                    orders.Add("Coke", coke);
                    break;
                case (int)SoftDrinks.Sprite:
                    orders.Add("Sprite", sprite);
                    break;
                case (int)SoftDrinks.Cream_Soda:
                    orders.Add("Cream Soda", creamSoda);
                    break;
                case (int)SoftDrinks.Root_beer:
                    orders.Add("Root beer", rootBeer);
                    break;
                case (int)Burgers.Back:
                    Console.Clear();
                    DrinksEx();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    softDrinks();
                    break;
            }

            Console.WriteLine("Order added successfully");

            Console.Write("\r\nDo you wish to add anything else from the Soft drinks menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')
            {
                Console.Clear();
                softDrinks();
            }
            else
            {
                Console.Clear();
                DrinksEx();
            }
        }

        static void milkshake()     // Method that displays the different Milkshake flavors. Adds the chosen  flavor to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", Drinks.Milkshake.ToString());

            rows = "1. Chocolate R{0}\r\n2. Strawberry R{1}\r\n3. Lime R{2}\r\n4. Vanilla R{3}\r\n5. Back";
            Console.WriteLine(rows, chocolate, strawberry, lime, vanilla);

            Console.Write("\r\nPlease make your choice: ");
            p = int.Parse(Console.ReadLine());

            switch (p)
            {
                case (int)Milkshake.Chocolate:
                    orders.Add("Chocolate", chocolate);
                    break;
                case (int)Milkshake.Strawberry:
                    orders.Add("Strawberry", strawberry);
                    break;
                case (int)Milkshake.Lime:
                    orders.Add("Lime", lime);
                    break;
                case (int)Milkshake.Vanilla:
                    orders.Add("Vanilla", vanilla);
                    break;
                case (int)Milkshake.Back:
                    Console.Clear();
                    DrinksEx();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    softDrinks();
                    break;
            }

            Console.WriteLine("Order added successfully");

            Console.Write("\r\nDo you wish to add anything else from the Milkshakes menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')
            {
                Console.Clear();
                milkshake();
            }
            else
            {
                Console.Clear();
                DrinksEx();
            }
        }

        static void juice()     // Method that displays the available Juice options. Adds the chosen juice to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", Drinks.Juice.ToString());

            rows = "1. Apple R{0}\r\n2. Orange R{1}\r\n3. Fruit Punch R{2}\r\n4. Mango R{3}\r\n5. Back";
            Console.WriteLine(rows, apple, orange, fruitPunch, mango);

            Console.Write("\r\nPlease make your choice: ");
            p = int.Parse(Console.ReadLine());

            switch (p)
            {
                case (int)Juice.Apple:
                    orders.Add("Apple", apple);
                    break;
                case (int)Juice.Orange:
                    orders.Add("Orange", orange);
                    break;
                case (int)Juice.Fruit_Punch:
                    orders.Add("Fruit Punch", fruitPunch);
                    break;
                case (int)Juice.Mango:
                    orders.Add("Mango", mango);
                    break;
                case (int)Juice.Back:
                    Console.Clear();
                    DrinksEx();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    juice();
                    break;
            }

            Console.WriteLine("Order added successfully");

            Console.Write("\r\nDo you wish to add anything else from the Juice menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')
            {
                Console.Clear();
                juice();
            }
            else
            {
                Console.Clear();
                DrinksEx();
            }
        }

        static void hotDrinks()     // Method that displays the Hot drink options. Adds the chosen drink to the collection
        {
            string rows;

            Console.WriteLine("{0}: \r\n", Drinks.Hot_Drinks.ToString());

            rows = "1. Cappuccino R{0}\r\n2. Hot Chocolate R{1}\r\n3. Coffee R{2}\r\n4. Tea R{3}\r\n5. Back";
            Console.WriteLine(rows, cappuccino, hotChocolate, coffee, tea);

            Console.Write("\r\nPlease make your choice: ");
            p = int.Parse(Console.ReadLine());

            switch (p)
            {
                case (int)HotDrinks.Cappuccino:
                    orders.Add("Cappuccino",cappuccino);
                    break;
                case (int)HotDrinks.Hot_Chocolate:
                    orders.Add("Hot Chocolate", hotChocolate);
                    break;
                case (int)HotDrinks.Coffee:
                    orders.Add("Coffee",coffee);
                    break;
                case (int)HotDrinks.Tea:
                    orders.Add("Tea", tea);
                    break;
                case (int)HotDrinks.Back:
                    Console.Clear();
                    DrinksEx();
                    break;
                default:
                    Console.Write("Unrecognized option chosen. Press ENTER to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    hotDrinks();
                    break;
            }

            Console.WriteLine("Order added successfully");

            Console.Write("\r\nDo you wish to add anything else from the Hot Drinks menu? Y/N: ");
            more = char.Parse(Console.ReadLine());
            if (more == 'Y')
            {
                Console.Clear();
                hotDrinks();
            }
            else
            {
                Console.Clear();
                DrinksEx();
            }
        }

        public static void Main(string[] args)
        {
            Menus();    // Calls the main menu method.
            Console.ReadLine(); // Holds the console so display and interaction can occur.
        }
    }
}
