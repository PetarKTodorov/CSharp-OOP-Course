namespace P01.MarketStore.Core
{
    using System;

    using P01.MarketStore.Models.DiscountCards;

    public class Engine
    {
        public void Run()
        {
            Console.Write("Enter a card: ");
            // Input: Bronze 0 150
            // Input: Silver 600 850
            // Input: Gold 1500 1300

            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');

            string cardType = tokens[0];
            decimal turnoverForPreviousMonth = decimal.Parse(tokens[1]);
            decimal purchaseValue = decimal.Parse(tokens[2]);

            DiscountCard card = null;

            switch (cardType)
            {
                case "Bronze": card = new BronzeCard(turnoverForPreviousMonth); break;
                case "Silver": card = new SilverCard(turnoverForPreviousMonth); break;
                case "Gold": card = new GoldCard(turnoverForPreviousMonth); break;
            }

            PayDesk.PrintPurchaseValue(purchaseValue);
            PayDesk.PrintDiscountRate(card.DiscountRate);
            PayDesk.PrintDiscount(card.DiscountRate, purchaseValue);
            PayDesk.PrintTotalPurchase(card.DiscountRate, purchaseValue);
        }
    }
}
