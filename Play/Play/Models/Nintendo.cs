using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Play.Models
{
    public class Nintendo
    {
        [Key]
        public string nombre { get; set; }
        [Display(Name = "Nombre del juego")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 3 a 60 caracteres")]
        [Required(ErrorMessage = "Empresa del juego")]
        public string autor { get; set; }
        [Display(Name = "descripcion del juego")]
        public string letra { get; set; }
        [Url]
        [Display(Name = "Link de una foto o video del juego")]
        public string link { get; set; }
    }
}
