using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }
    }
}