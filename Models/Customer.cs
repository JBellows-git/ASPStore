using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace GroupProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage ="A State is required")]
        [MaxLength(3, ErrorMessage ="Please use the State Abbreviation")]
        public string State { get; set; }
        [Required]
        [MinLength(5, ErrorMessage ="Please a US zip code. Minimum 5 digits")]        
        public string Zipcode { get; set; }
        [EmailAddress(ErrorMessage ="Please use a valid Email Address")]
        public string Email { get; set; }
    }
}
