using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    public class Customer
    {
       

        [Required]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // Apply validation for in entity level
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid age")]
        [Range(0, 200, ErrorMessage = "Please enter valid age between 0 to 200")]
        [DefaultValue(0)]
        public int Age { get; set; }
        public string? Address { get; set; }
    }
}
