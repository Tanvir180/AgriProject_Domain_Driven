using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.DTO;
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

        public void AddPayment(PaymentDTO paymentDto)
        {
            var payment = new Payment
            {
                CategoryId = paymentDto.CategoryId,
                UserId = paymentDto.UserId,
                PlaceName = paymentDto.PlaceName,
                Location = paymentDto.Location,
                Date = paymentDto.Date,
                Name = paymentDto.UserName, // Map UserName to Payment.Name
                Number = paymentDto.UserPhoneNumber, // Map UserPhoneNumber to Payment.Number
                Cost = paymentDto.Cost
            };

            _dbContext.Payments.Add(payment);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

      
    }
}
