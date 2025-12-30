namespace Commons.Models.Messages
{
    public class PaymentOutboxMessage
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public bool IsProcessed { get; set; } = false;
    }
}
