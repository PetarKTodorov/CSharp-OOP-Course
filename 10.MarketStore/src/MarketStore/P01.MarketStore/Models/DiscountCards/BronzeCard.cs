namespace P01.MarketStore.Models.DiscountCards
{
    public class BronzeCard : DiscountCard
    {
        private const decimal DEFAULT_DISCOUNT_RATE = 0;
        private const decimal NORMAL_DISCOUNT_RATE = 1;
        private const decimal BIG_DISCOUNT_RATE = 2.5m;

        public BronzeCard(decimal turnoverForPreviousMonth)
        {
            this.TurnoverForPreviousMonth = turnoverForPreviousMonth;
            this.DiscountRate = this.CalculateDiscountRate();
        }

        public override decimal CalculateDiscountRate()
        {
            decimal discountRatePrecentage = DEFAULT_DISCOUNT_RATE;

            if (this.TurnoverForPreviousMonth >= 100 && this.TurnoverForPreviousMonth <= 300)
            {
                discountRatePrecentage = NORMAL_DISCOUNT_RATE;
            }
            else if(this.TurnoverForPreviousMonth > 300)
            {
                discountRatePrecentage = BIG_DISCOUNT_RATE;
            }

            return discountRatePrecentage;
        }
    }
}
