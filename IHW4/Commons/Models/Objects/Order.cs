namespace Commons.Models.Objects
{
    public class Order()
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Amount { get; set; }
        public string Desc { get; set; }
        public enums.Status Status { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}