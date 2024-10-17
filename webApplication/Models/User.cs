using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace webApplication.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public long? PhoneNumber { get; set; }

        public long? AlternatePhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
