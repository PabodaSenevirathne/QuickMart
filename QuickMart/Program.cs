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
            List<double> purchasedItemPrices = new List<double>();

            List<string> itemList = new List<string> { "Chillies", "Tomatoes", "Apples", "Milk" };

            string loyaltyCard = "";
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
                Console.WriteLine("\nPlease enter the name of the purchased item or enter 'Done' to finish");
                string item = Console.ReadLine()?.ToLower() ?? "default";

                if (purchasedItemNames.Contains(item))
                {
                    Console.WriteLine($"You have already purchased {item}.");
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
                    Console.WriteLine("Please enter a valid item!");
                    continue;
                }

                // get item weight based on lb or carton quantity
                if (item == "chillies" || item == "tomatoes" || item == "apples")
                {
                    Console.WriteLine($"How much did the {item} weigh, in total (in lb):");
                    
                }
                else
                {
                    Console.WriteLine($"How much did the {item} weigh, in total (in carton):");
                    
                }

                //validate weight
                if (!int.TryParse(Console.ReadLine(), out int itemWeigh) || itemWeigh <= 0)
                {
                    Console.WriteLine("Invalid weight! Please enter a valid weight.");
                    continue;
                }

                //calculate initial item price
                itemAmount = itemPrice * itemWeigh;

                //add purchased items to purchasedItemNames list
                purchasedItemNames.Add(item);
                purchasedItemWeights.Add(itemWeigh);
                purchasedItemPrices.Add(itemPrice);

                // remove item from the item list
                itemList.Remove(item);


                //check loyalty card availability (initial question)
                if (loyaltyCard == "")
                {
                    Console.WriteLine($"Do you have a Loyalty Card (Yes/No)?");
                    loyaltyCard = Console.ReadLine()?.ToLower() ?? "default";

                    if (loyaltyCard != "yes" && loyaltyCard != "no")
                    {
                        Console.WriteLine("Please enter a valid input (Yes/No)!");
                        loyaltyCard = Console.ReadLine()?.ToLower() ?? "default";
                    }

                }

                // check if the item has discount or not before calculating the discounted price
                bool hasItemDiscount;

                if (item == "chillies" || item == "tomatoes" || item == "apples")
                {
                    
                    hasItemDiscount = true;
                }
                else
                {
                    hasItemDiscount = false;
                }

                

                //calculate discounted price
                if (loyaltyCard == "yes" && hasItemDiscount)
                {
                    discountedPrice = itemAmount * 0.1;
                    totalDiscount += discountedPrice;
                }

                subTotal += itemAmount;
            }
    
            //calulate store bag cost
            Console.WriteLine($"How many store bags do you need?");
            if (!int.TryParse(Console.ReadLine(), out int storeBagsCount) || storeBagsCount < 0)

            {
                Console.WriteLine("Please enter a valid number!");
            }

            double storeBagsCost = storeBagsCount * 0.50;

            Console.WriteLine("=========================================================================\n");
            Console.WriteLine("---------------------------QUICK MART SHOP-------------------------------\n");
            Console.WriteLine("-------------------------------Receipt-----------------------------------\n");
            Console.WriteLine("=========================================================================\n");


            //display receipt
            for (int i = 0; i < purchasedItemNames.Count; i++)
            {
                Console.WriteLine($"Item: {purchasedItemNames[i]}\nQty: {purchasedItemWeights[i]}\nBase: ${purchasedItemPrices[i]}\n");
            }
            
            Console.WriteLine($"Number of Bags: {storeBagsCount}");
            Console.WriteLine($"Price of Bags: {storeBagsCost}");
            Console.WriteLine($"Loyalty Card: {loyaltyCard}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            subTotal = subTotal + storeBagsCost;
            Console.WriteLine($"Sub Total : {subTotal}");

            {
                Console.WriteLine("--\n");
                Console.WriteLine($"Discounts: {totalDiscount:F2}");
                Console.WriteLine("\n--\n");
            }

            subTotal = subTotal - totalDiscount;

            Console.WriteLine($"Sub Total: {subTotal:F2}");

            //calculate total price after tax
            tax = subTotal * 0.13;
            subTotal = subTotal + tax;

            Console.WriteLine($"Tax: {tax:F2}\n");

            Console.WriteLine("========================================================================\n");
            Console.WriteLine($"TOTAL: {subTotal:F2}");
            Console.WriteLine("========================================================================\n");

        }
    }
}