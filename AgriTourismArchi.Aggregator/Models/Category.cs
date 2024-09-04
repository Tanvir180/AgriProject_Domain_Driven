using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriTourismArchi.Aggregator.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Place Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Location")]
        public string Location { get; set; }

        [Required]
        [DisplayName("Entry fees")]
        [Range(0, double.MaxValue, ErrorMessage = "Cost must be a positive number.")]
        public double Cost { get; set; }

        [Required]
        [DisplayName("Total Capacity")]
        [Range(3, int.MaxValue, ErrorMessage = "Capacity must be at least 3.")]
        public int Capacity { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
