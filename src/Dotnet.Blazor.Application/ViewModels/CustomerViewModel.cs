using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet.Blazor.Application.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Deve conter no máximo 50 caracteres.")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Deve conter no máximo 150 caracteres.")]
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
