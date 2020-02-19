using System.ComponentModel.DataAnnotations;

namespace hiredlincs.core
{
    public class RegisterHLModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Biography { get; set; }

    }
}