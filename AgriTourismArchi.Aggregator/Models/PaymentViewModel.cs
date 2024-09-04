using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTourismArchi.Aggregator.Models
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("User Email")]
        public string UserEmail { get; set; }
        [DisplayName("User Phone Number")]
        public string UserPhoneNumber { get; set; }
        [DisplayName("User Address")]
        public string UserAddress { get; set; }
        [DisplayName("Place Name")]
        public string PlaceName { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string PaymentNumber { get; set; }
        public double Cost { get; set; }
    }
}
