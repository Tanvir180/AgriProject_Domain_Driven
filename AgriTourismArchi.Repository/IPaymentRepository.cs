using AgriTourismArchi.Aggregator.Models;
//using AgriTourismArchi.DTO;

namespace AgriTourismArchi.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Payment GetPaymentById(int id);
        void AddPayment(Payment payment);
        // Add this line to define the SaveChanges method
        void SaveChanges();
    }
}
