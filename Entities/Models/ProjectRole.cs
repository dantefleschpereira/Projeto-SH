using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ProjectRole
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Usuário")]
        public string RoleName { get; set; }
    }
}
