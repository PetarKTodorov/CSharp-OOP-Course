namespace P01.MarketStore.Models.DiscountCards
{
    public class GoldCard : DiscountCard
    {
        private const decimal DEFAULT_DISCOUNT_RATE = 2;
        private const decimal GROWING_DISCOUNT_RATE = 1;
        private const decimal MAX_DISCOUNT_RATE = 10;

        public GoldCard(decimal turnoverForPreviousMonth)
        {
            this.TurnoverForPreviousMonth = turnoverForPreviousMonth;
            this.DiscountRate = this.CalculateDiscountRate();
        }

        public override decimal CalculateDiscountRate()
        {
            decimal discountRatePrecentage = DEFAULT_DISCOUNT_RATE;
            decimal tempTurnoverForPreviousMonth = this.TurnoverForPreviousMonth;

            while (discountRatePrecentage < MAX_DISCOUNT_RATE && tempTurnoverForPreviousMonth > 99)
            {
                tempTurnoverForPreviousMonth -= 100;
                discountRatePrecentage += GROWING_DISCOUNT_RATE;
            }

            return discountRatePrecentage;
        }
    }
}
