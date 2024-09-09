using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.DTO;
using AgriTourismArchi.Handler.Interfaces;
using AgriTourismArchi.Repository.Interfaces;

namespace AgriTourismArchi.Handler
{
    public class PaymentHandler : IPaymentHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentHandler(ICategoryRepository categoryRepository, IUserRepository userRepository, IPaymentRepository paymentRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
        }

        public PaymentDTO GetPaymentById(int id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            if (payment == null)
                return null;

            var category = _categoryRepository.GetCategoryById(payment.CategoryId);
            var user = _userRepository.GetUserById(payment.UserId);

            return new PaymentDTO
            {
                Id = payment.Id,
                CategoryId = payment.CategoryId,
                UserId = payment.UserId,
                PlaceName = payment.PlaceName,
                Location = payment.Location,
                Date = payment.Date,
                UserName = user?.Name,
                UserPhoneNumber = user?.PhoneNumber,
                Cost = category?.Cost ?? 0
            };
        }

        public PaymentHandler(
            ICategoryRepository categoryRepository,
            IPaymentRepository paymentRepository,
            IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
        }

        public void CreatePayment(PaymentDTO paymentDto)
        {
            // Map the PaymentDTO to a Payment model
            var payment = new Payment
            {
                CategoryId = paymentDto.CategoryId,
                UserId = paymentDto.UserId,
                PlaceName = paymentDto.PlaceName,
                Location = paymentDto.Location,
                Date = paymentDto.Date,
                Name = paymentDto.UserName, // Map UserName from DTO
                Number = paymentDto.UserPhoneNumber, // Map UserPhoneNumber from DTO
                Cost = paymentDto.Cost
            };

            // Now pass the Payment model to the repository
            _paymentRepository.AddPayment(payment);
            _paymentRepository.SaveChanges();
        }



    }
}

