using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models
{
    public class UserModel 
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 10, ErrorMessage = "First name should have a maximum length of 250 characters and a minimum length of 10 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 10, ErrorMessage = "Last name should have a maximum length of 250 characters and a minimum length of 10 characters.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(maximumLength: 400, MinimumLength = 10, ErrorMessage = "Addres should have a maximum length of 400 characters and a minimum length of 10 characters.")]
        public string Address { get; set; }

    }
}
