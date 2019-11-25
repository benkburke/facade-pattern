using System.Text.Json;
using FacadePattern.Domain;
using FacadePattern.Infrastructure;

namespace FacadePattern.Systems
{
    public static class PaymentSystem
    {
        public static void MakePayment(decimal amount, Customer customer)
        {
            var payment = new Payment
            {
                Amount = amount,
                CustomerName = customer.Name
            };

            Db.Payments.Add(payment);
        }

        public static string ViewPayments()
        {
            return JsonSerializer.Serialize(Db.Payments);
        }
    }
}
