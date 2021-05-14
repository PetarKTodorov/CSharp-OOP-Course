namespace P01.MarketStore.Models.Users
{
    using System;

    public class User
    {
        public User()
        {
            this.Id = new Guid();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
