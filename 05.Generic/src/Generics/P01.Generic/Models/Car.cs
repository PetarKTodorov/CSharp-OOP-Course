namespace P01.Generic.Models
{
    public class Car : BaseModel<string>
    {
        public Car(string id, string model)
            :base(id)
        {
            this.Model = model;
        }

        public string Model { get; set; }

        public override string ToString()
        {
            string result = $"{this.Id} - Model: {this.Model}";

            return result;
        }
    }
}
