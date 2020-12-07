using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TärningsUppgift
{
    class Program
    {
      public static int RollTheDice(Random randomObject)
        {
            int nr = randomObject.Next(1, 7);                                 
            return nr;
        }

      public static void Main()
        {
            int number;
            Random random = new Random();
           
            List<int> dices = new List<int>();

            Console.WriteLine("Loam 2019/05/12");


            bool go = true;
            while (go)
            {
                Console.WriteLine("\n\t[1] Spela\n" +
                    "\t[2] Avsluta");
                Console.Write("\tVälj: ");
                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        dices = new List<int>();
                            Console.Write("\nHur många tärningar vill du slå?: ");
                       
                        bool input = int.TryParse(Console.ReadLine(), out int amount);
                        while (amount > 4 || amount < 1)
                        {
                           
                            Console.WriteLine("Välj mellan 1-4");
                            input = int.TryParse(Console.ReadLine(), out amount);

                        }
                       
                            if (input)
                            {

                                for (int i = 0; i < amount; i++)
                                {
                                    number = RollTheDice(random);
                                    dices.Add(number);
                                    Console.WriteLine("Du kastade:" + number);
                                    if (number == 6)
                                    {
                                        for (int y = 0; y < 2; y++)
                                        {
                                            number = RollTheDice(random);
                                            dices.Add(number);
                                            Console.WriteLine("Du kastade bonus kast:" + number);
                                        }
                                    }
                                }
                                Console.WriteLine("Du kastade: " + dices.Count + "tärningar " + " och den total summan blev: " + dices.Sum());
                            }
                        
                        break;
                    case 2:
                        Console.WriteLine("\nHej då!");
                        Thread.Sleep(1000);
                        go = false;
                        break;
                    default:
                        Console.WriteLine("\n\tVälj mellan 1 eller 2.");
                        break;
                }
            }
        }
    }
}
    
