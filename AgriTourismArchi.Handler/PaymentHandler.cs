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

        //public void CreatePayment(PaymentDTO paymentDto)
        //{
        //    var payment = new Payment
        //    {
        //        CategoryId = paymentDto.CategoryId,
        //        UserId = paymentDto.UserId,
        //        PlaceName = paymentDto.PlaceName,
        //        Location = paymentDto.Location,
        //        Date = paymentDto.Date,
        //        Name = paymentDto.UserName,
        //        Number = paymentDto.UserPhoneNumber,
        //        Cost = paymentDto.Cost
        //    };

        //    _paymentRepository.AddPayment(payment);
        //    _paymentRepository.SaveChanges();
        //}
        public void CreatePayment(PaymentDTO paymentDto)
        {
            _paymentRepository.AddPayment(paymentDto);
            _paymentRepository.SaveChanges();
        }


    }
}

