namespace Commons.Factories
{
    public class AccountFactory
    {
        public Commons.Models.Objects.Account Create(Guid id)
        {
            return new Models.Objects.Account
            {
                AccountId = id,
                Balance = 0
            };
        }
    }
}
