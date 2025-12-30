namespace Commons.Factories
{
    public class OrderFactory
    {
        public Commons.Models.Objects.Order Create(Guid userId, int amount, string desc)
        {
            return new Commons.Models.Objects.Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Amount = amount,
                Desc = desc
            };
        }
    }
}
