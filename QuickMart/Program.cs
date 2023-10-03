namespace QuickMart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paboda Jayamali Senevirathne, 8927315, Psenevirathne7315@conestogac.on.ca");

            Console.WriteLine("=================================================");

            List<string> purchasedItemNames = new List<string>();
            List<double> purchasedItemPrices = new List<double>();

            double grossAmount = 0.0;
            double itemPrice = 0;
            bool hasItemDiscount = false;

            while (true)
            {

                Console.WriteLine("Please enter the name of the sales item purshased: {Chillies, Tomatoes, Apples or Milk} or enter 'done' to finish");
                string item = Console.ReadLine() ?? "default";

                if (purchasedItemNames.Contains(item))
                {
                    Console.WriteLine($"You have already purchased the {item}.");
                    continue;
                }
                else {
                
                    if (item.ToLower() == "done")
                    {
                        break;

                    }
                
                }


                if (item == "Chillies")
                {
                    hasItemDiscount = true;
                    itemPrice = 1.29;
                }

                else if (item == "Tomatoes")
                {
                    hasItemDiscount = true;
                    itemPrice = 1.45;
                }
                else if (item == "Apples")
                {

                    hasItemDiscount = true;
                    itemPrice = 1.75;
                }

                else
                {
                    hasItemDiscount = false;
                    itemPrice = 6.54;
                }



                //get item count
                Console.WriteLine($"How many {item}s did you purchase:");
                int ItemCount = Convert.ToInt32(Console.ReadLine());

                // get weight
                // get weight
                Console.WriteLine($"How much did the {item}s weigh, in total (in lbs):");
                double itemWeigh = Convert.ToDouble(Console.ReadLine());

                //double itemAmount = itemPrice * itemWeigh;

                //get wheather is there a loyality card
                Console.WriteLine($"Do you have a Loyality Card(Yes/No)?:");
                string loyalityCard = Console.ReadLine() ?? "default";

                // get used store bag count
                Console.WriteLine($"How much store bags do you need?");
                int storeBagsCount = Convert.ToInt32(Console.ReadLine());

                double itemAmount = itemPrice * itemWeigh;
                double storeBagsCost = storeBagsCount * 0.50;

                // calculate gross amount without discount

                grossAmount += itemAmount + storeBagsCost;

                if (hasItemDiscount)
                {
                    double discount = grossAmount * 0.1;
                    grossAmount = grossAmount - discount;

                }

                purchasedItemNames.Add(item);
                purchasedItemPrices.Add(grossAmount);




            }


        }
    }
}