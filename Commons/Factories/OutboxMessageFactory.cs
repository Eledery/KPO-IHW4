namespace Commons.Factories
{
    public class OutboxMessageFactory
    {
        public Commons.Models.Messages.PaymentOutboxMessage Create(Guid messageId)
        {
            return new Commons.Models.Messages.PaymentOutboxMessage
            {
                Id = Guid.NewGuid(),
                MessageId = messageId,
            };
        }
    }
}
