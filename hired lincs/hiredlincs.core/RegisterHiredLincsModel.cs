using System.ComponentModel.DataAnnotations;

namespace hiredlincs.core
{
    class RegisterHiredLincsModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
