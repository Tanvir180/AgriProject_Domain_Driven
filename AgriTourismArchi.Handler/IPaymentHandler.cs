using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.DTO;

namespace AgriTourismArchi.Handler.Interfaces
{
    public interface IPaymentHandler
    {
        PaymentDTO GetPaymentById(int id);
        void CreatePayment(PaymentDTO paymentDto);
    }
}
