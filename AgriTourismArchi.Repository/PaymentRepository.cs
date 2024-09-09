using AgriTourismArchi.Aggregator.Models;
//using AgriTourismArchi.DTO;
using AgriTourismArchi.Repository.Data;
using AgriTourismArchi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgriTourismArchi.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Payment GetPaymentById(int id)
        {
            return _dbContext.Payments.Find(id);
        }

        public void AddPayment(Payment payment)
        {
            var newPayment = new Payment
            {
                CategoryId = payment.CategoryId,
                UserId = payment.UserId,
                PlaceName = payment.PlaceName,
                Location = payment.Location,
                Date = payment.Date,
                Name = payment.Name, // Map UserName to Payment.Name
                Number = payment.Number, // Map UserPhoneNumber to Payment.Number
                Cost = payment.Cost
            };

            _dbContext.Payments.Add(newPayment);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

       
    }
}
