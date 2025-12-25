namespace Commons.Factories
{
    public class OutboxMessageFactory
    {
        public Commons.Models.Messages.OutboxMessage Create(Guid messageId)
        {
            return new Commons.Models.Messages.OutboxMessage
            {
                Id = Guid.NewGuid(),
                MessageId = messageId,
            };
        }
    }
}
