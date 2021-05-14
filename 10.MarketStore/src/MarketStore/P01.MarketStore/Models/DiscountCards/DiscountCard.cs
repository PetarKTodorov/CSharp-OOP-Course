namespace P01.MarketStore.Models.DiscountCards
{
    using System;

    using P01.MarketStore.Models.Users;

    public abstract class DiscountCard
    {
        public DiscountCard()
        {
            this.Id = new Guid();
        }

        public Guid Id { get; set; }

        public User Owner { get; set; }

        public decimal TurnoverForPreviousMonth { get; set; }

        public decimal DiscountRate { get; set; }

        public abstract decimal CalculateDiscountRate();
    }
}
