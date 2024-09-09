using AgriTourismArchi.DTO;
using AgriTourismArchi.Handler.Interfaces;
using AgriTourismArchi.Aggregator.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgriTourismArchi.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentHandler _paymentHandler;
        private readonly IUserHandler _userHandler;
        private readonly ICategoryHandler _categoryHandler;

        public PaymentController(IPaymentHandler paymentHandler, IUserHandler userHandler, ICategoryHandler categoryHandler)
        {
            _paymentHandler = paymentHandler;
            _userHandler = userHandler;
            _categoryHandler = categoryHandler;
        }

        // Show payment page with category info and user id=1 info
        public IActionResult Payment(int id)
        {
            // Fetch the category details
            var categoryDto = _categoryHandler.GetCategoryById(id); // Now using 'id' as the parameter
            if (categoryDto == null)
            {
                return NotFound(); // Category not found
            }

            // Fetch the user with Id = 1 (as per your requirement)
            var userDto = _userHandler.GetUserById(1001);
            if (userDto == null)
            {
                return NotFound(); // User with Id=1 not found
            }

            // Populate the PaymentViewModel with data
            var paymentViewModel = new PaymentViewModel
            {
                UserId = userDto.Id,
                UserName = userDto.Name,
                UserEmail = userDto.Email,
                UserPhoneNumber = userDto.PhoneNumber,
                UserAddress = userDto.Address,
                Id = categoryDto.Id,
                PlaceName = categoryDto.Name,
                Location = categoryDto.Location,
                Date = categoryDto.Date,
                Cost = (double)categoryDto.Cost
            };

            // Return the view with the populated PaymentViewModel
            return View(paymentViewModel);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult ConfirmPayment(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var categoryDto = _categoryHandler.GetCategoryById(model.Id);
                var userDto = _userHandler.GetUserById(model.UserId);

                if (categoryDto == null || userDto == null || categoryDto.Capacity <= 0)
                {
                    TempData["Error"] = "Invalid payment details or out of capacity.";
                    return RedirectToAction("Payment", new { categoryId = model.Id });
                }

                var paymentDto = new PaymentDTO
                {
                    CategoryId = model.Id,
                    UserId = model.UserId,
                    PlaceName = model.PlaceName,
                    Location = model.Location,
                    Date = model.Date,
                    UserName = model.UserName,
                    UserPhoneNumber = model.UserPhoneNumber,
                    Cost = model.Cost
                };

                // Save payment using the handler
                _paymentHandler.CreatePayment(paymentDto);

                // Update category capacity
                categoryDto.Capacity--;
                _categoryHandler.UpdateCategory(categoryDto);

                TempData["success"] = "Payment confirmed successfully.";
                return RedirectToAction("PaymentShow", "Payment");
            }

            return View(model);
        }

        public IActionResult PaymentShow()
        {
           

            return View(); // Passing data to the Index view
        }


    }
}
