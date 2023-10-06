using System.Collections.Generic;

namespace QuickMart
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> purchasedItemNames = new List<string>();
            List<string> itemList = new List<string> { "Chillies", "Tomatoes", "Apples", "Milk" };
            string loyalityCard = null;

            double subTotal = 0.0;
            bool hasItemDiscount = false;
            double itemPrice = 0.0;
            double grossAmount = 0.0;
            double tax;
            double discountedPrice = 0.0;
            Console.WriteLine("Available Items: " + string.Join(", ", itemList));

            while (true)
            {
                Console.WriteLine("Please enter the name of the sales item purshased or enter 'done' to finish");
                string item = Console.ReadLine() ?? "default";

                if (purchasedItemNames.Contains(item))
                {
                    Console.WriteLine($"You have already purchased the {item}.");
                    Console.WriteLine("Remaining items: " + string.Join(", ", itemList));
                    continue;
                }
                else
                {
                    if (item.ToLower() == "done")
                    {
                        break;
                    }
                }

                //determine the base price

                if (item == "Chillies")
                {
                    itemPrice = 1.29;
                }
                else if (item == "Tomatoes")
                {
                    itemPrice = 1.45;
                }
                else if (item == "Apples")
                {
                    itemPrice = 1.75;
                }
                else
                {
                    itemPrice = 6.54;
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

                double itemWeigh = Convert.ToDouble(Console.ReadLine());

                //calculate initial amount
                double itemAmount = itemPrice * itemWeigh;


                // remove item from the item list
                itemList.Remove(item);

                //add purshased items to purchasedItemNames list
                purchasedItemNames.Add(item);

                //get wheather is there a loyality card at once
                if (loyalityCard == null)
                {
                    Console.WriteLine($"Do you have a Loyality Card(Yes/No)?:");
                    loyalityCard = Console.ReadLine() ?? "default";
                }

                // check if the items has discount or not
                if (item == "Chillies" || item == "Tomatoes" || item == "Apples")
                {

                    hasItemDiscount = true;
                }
                else
                {
                    hasItemDiscount = false;
                }

                // get used store bag count
                Console.WriteLine($"How much store bags do you need?");
                int storeBagsCount = Convert.ToInt32(Console.ReadLine());
                double storeBagsCost = storeBagsCount * 0.50;


                //calculate discounted price
                if (loyalityCard == "Yes" && hasItemDiscount)
                {
                    discountedPrice = itemAmount * 0.1;
                    grossAmount = (itemAmount - discountedPrice) + storeBagsCost;
                }

                grossAmount = itemAmount + storeBagsCost;


                Console.WriteLine("Paboda Jayamali Senevirathne, 8927315, Psenevirathne7315@conestogac.on.ca");
                Console.WriteLine("=========================================================================");

                Console.WriteLine($"Item : {item}");
                Console.WriteLine($"Quantity : {itemWeigh}");
                Console.WriteLine($"Base: {itemPrice}");
                Console.WriteLine($"Number of Bags: {storeBagsCount}");
                Console.WriteLine($"Price of Bags: {storeBagsCost}");
                Console.WriteLine($"Loyality Card: {loyalityCard}");

                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine($"SubTotal : {grossAmount}");

                if (hasItemDiscount)
                {
                    Console.WriteLine("--");
                    Console.WriteLine($"Discounts: {discountedPrice}");
                    Console.WriteLine("--");
                }
                else
                {
                    Console.WriteLine($"subTotal: {grossAmount}");
                }


                //calculate subtotal

                tax = grossAmount * 0.13;
                subTotal = (grossAmount + tax) + subTotal;
                Console.WriteLine($"Tax: {tax}\n");




                Console.WriteLine("========================================================================");
                Console.WriteLine($"TOTAL: {subTotal}");


            }





        }
    }
}