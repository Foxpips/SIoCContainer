namespace Shop.Domain.Entities.Cards
{
    public class VisaDebit : ICreditCard
    {
        public string Charge()
        {
            return "Charged €50 to your account using visa card";
        }
    }
}