namespace Minedraft.Models
{
    public abstract class BaseModel
    {
        protected BaseModel(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }

        public abstract string Type { get; }
    }
}
