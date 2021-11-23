namespace SnackCorp.Shared.Models
{

    public record class Product
    {
        public Guid id { get; init; }

        public String name {get; init;}

        public String desc {get; init;}

        public int quantity {get; init;}

        public float price {get; init;}
    }
}