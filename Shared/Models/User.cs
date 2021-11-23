namespace SnackCorp.Shared.Models
{

    public record class User
    {
        public Guid id { get; init; }

        public String firstname {get; init;}

        public String lastname {get; init;}
        
        public float balance {get; init;}
    }
}