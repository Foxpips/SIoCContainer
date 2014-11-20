namespace Shop.Domain.Entities.Cards
{
    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Charged €50 to your account with Master Card";
        }
    }
}