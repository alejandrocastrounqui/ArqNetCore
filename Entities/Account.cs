using System.ComponentModel.DataAnnotations;

namespace ArqNetCore.Entities
{
    public class Account
    {
        [Key]
        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool Enable { get; set; }
    }
}