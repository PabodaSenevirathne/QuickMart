using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace QuickMart
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> purchasedItemNames = new List<string>();
            List<double> purchasedItemWeights = new List<double>();
            List<double> purshasedItemPrices = new List<double>();

            List<string> itemList = new List<string> { "Chillies", "Tomatoes", "Apples", "Milk" };


             
            string loyalityCard = "";
            double subTotal = 0.0;
            double itemPrice = 0.0;
            double itemAmount = 0.0;
            double tax;
            double discountedPrice = 0.0;
            double totalDiscount = 0.0;

            Console.WriteLine("Paboda Jayamali Senevirathne, 8927315, Psenevirathne7315@conestogac.on.ca\n");

            Console.WriteLine("=========================================================================\n");
            // display available item list
            Console.WriteLine("Available Items: " + string.Join(", ", itemList));

            while (true)
            {
                Console.WriteLine("\nPlease enter the name of the sales item purshased or enter 'done' to finish");
                string item = Console.ReadLine()?.ToLower() ?? "default";

                if (purchasedItemNames.Contains(item))
                {
                    Console.WriteLine($"You have already purchased the {item}.");
                    Console.WriteLine("Remaining items: " + string.Join(", ", itemList));
                    continue;
                }
                else
                {
                    if (item == "done")
                    {
                        break;
                    }
                }

                //determine the base price

                if (item == "chillies")
                {
                    itemPrice = 1.29;
                }
                else if (item == "tomatoes")
                {
                    itemPrice = 1.45;
                }
                else if (item == "apples")
                {
                    itemPrice = 1.75;
                }
                else if (item == "milk")
                {
                    itemPrice = 6.54;
                }
                else
                {
                    Console.WriteLine("Please enter a valid item name");
                    continue;
                }


                // get item weight according to the lb or carton
                if (item == "Chillies" || item == "Tomatoes" || item == "Apples")
                {
                    Console.WriteLine($"How much did the {item}s weigh, in total (in lb):");
                    
                }
                else
                {
                    Console.WriteLine($"How much did the {item}s weigh, in total (in carton):");
                    
                }

                //validate weight
                if (!int.TryParse(Console.ReadLine(), out int itemWeigh) || itemWeigh <= 0)
                {
                    Console.WriteLine("Invalid weight. Please enter a valid weight.");
                    continue;
                }

                //calculate initial item price
                itemAmount = itemPrice * itemWeigh;

                //add purshased items to purchasedItemNames list
                purchasedItemNames.Add(item);
                purchasedItemWeights.Add(itemWeigh);
                purshasedItemPrices.Add(itemPrice);

                // remove item from the item list
                itemList.Remove(item);


                //get wheather is there a loyality card at once
                if (loyalityCard == "")
                {
                    Console.WriteLine($"Do you have a Loyality Card(Yes/No)?:");
                    loyalityCard = Console.ReadLine()?.ToLower() ?? "default";

                }
                bool hasItemDiscount;

                // check if the items has discount or not before calculate discounted price
                if (item == "chillies" || item == "tomatoes" || item == "apples")
                {
                    
                    hasItemDiscount = true;
                }
                else
                {
                    hasItemDiscount = false;
                }

              
             
                //calculate discounted price
                if (loyalityCard == "yes" && hasItemDiscount)
                {
                    discountedPrice = itemAmount * 0.1;
                    totalDiscount += discountedPrice;

                    //itemAmount = (itemAmount - discountedPrice);
                }


            }
    
           
            // get used store bag count
            Console.WriteLine($"How much store bags do you need?");
            if (!int.TryParse(Console.ReadLine(), out int storeBagsCount) || storeBagsCount < 0)
            {
                Console.WriteLine("Please enter a valid number.");
            }

           // storeBagsCount = Convert.ToInt32(Console.ReadLine());
            double storeBagsCost = storeBagsCount * 0.50;
            Console.WriteLine("=========================================================================\n");
            Console.WriteLine("---------------------------QUICK MART SHOP-------------------------------\n");
            Console.WriteLine("-------------------------------Reciept-----------------------------------\n");
            Console.WriteLine("=========================================================================\n");
            for (int i = 0; i < purchasedItemNames.Count; i++)
            {
                Console.WriteLine($"Item: {purchasedItemNames[i]}\nQty: {purchasedItemWeights[i]}\nBase: ${purshasedItemPrices[i]}\n");
            }
            
            Console.WriteLine($"Number of Bags: {storeBagsCount}");
            Console.WriteLine($"Price of Bags: {storeBagsCost}");
            Console.WriteLine($"Loyality Card: {loyalityCard}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            double grossAmount = itemAmount + storeBagsCost;
            Console.WriteLine($"SubTotal : {grossAmount}");

            {
                Console.WriteLine("--\n");
                Console.WriteLine($"Discounts: {totalDiscount:F2}");
                Console.WriteLine("\n--\n");
            }

            grossAmount = (grossAmount - totalDiscount);

            Console.WriteLine($"SubTotal: {grossAmount}");

            //calculate subtotal

            tax = grossAmount * 0.13;
            subTotal = (grossAmount + tax) + subTotal;

            Console.WriteLine($"Tax: {tax:F2}\n");

            Console.WriteLine("========================================================================\n");
            Console.WriteLine($"TOTAL: {subTotal:F2}");
            Console.WriteLine("========================================================================\n");


        }
    }
}