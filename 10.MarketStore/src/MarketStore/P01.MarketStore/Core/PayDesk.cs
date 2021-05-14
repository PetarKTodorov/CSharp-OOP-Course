namespace P01.MarketStore.Core
{
    using System;

    public class PayDesk
    {
        public static void PrintPurchaseValue(decimal purchaseValue)
        {
            string message = $"Purchase value: ${purchaseValue}";

            Console.WriteLine(message);
        }

        public static void PrintDiscountRate(decimal discountRate)
        {
            string message = $"Discount rate: {discountRate:F1}%";

            Console.WriteLine(message);
        }

        public static void PrintDiscount(decimal discountRate, decimal purchaseValue)
        {
            decimal discountSum = (discountRate / 100m) * purchaseValue;

            string message = $"Discount: ${discountSum:F2}";

            Console.WriteLine(message);
        }

        public static void PrintTotalPurchase(decimal discountRate, decimal purchaseValue)
        {
            decimal discountSum = (discountRate / 100m) * purchaseValue;
            decimal totalSum = purchaseValue - discountSum;

            string message = $"Total: ${totalSum:F2}";

            Console.WriteLine(message);
        }
    }
}
