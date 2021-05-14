namespace P01.MarketStore.Models.DiscountCards
{
    public class SilverCard : DiscountCard
    {
        private const decimal DEFAULT_DISCOUNT_RATE = 2;
        private const decimal NORMAL_DISCOUNT_RATE = 3.5m;

        public SilverCard(decimal turnoverForPreviousMonth)
        {
            this.TurnoverForPreviousMonth = turnoverForPreviousMonth;
            this.DiscountRate = this.CalculateDiscountRate();
        }

        public override decimal CalculateDiscountRate()
        {
            decimal discountRatePrecentage = DEFAULT_DISCOUNT_RATE;

            if (this.TurnoverForPreviousMonth > 300)
            {
                discountRatePrecentage = NORMAL_DISCOUNT_RATE;
            }

            return discountRatePrecentage;
        }
    }
}
