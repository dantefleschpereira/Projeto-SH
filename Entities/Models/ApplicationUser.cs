using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // classe herda do IdentityFramework
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [MaxLength(40)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


    }
}
