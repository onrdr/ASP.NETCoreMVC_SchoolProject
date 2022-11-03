using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.Identity
{
    public class AppUser : IdentityUser
    {
        public int? StudentId { get; set; } 
        public Student Student { get; set; }

        public int? TeacherId { get; set; } 
        public Student Teacher { get; set; } 
    }
}

