using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PruebaFall.Model
{
    public class Dato
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres maximo 50")]
        [DataType(DataType.Text)]
        public string oc { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres maximo 50")]
        [DataType(DataType.Text)]
        public string f12 { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres maximo 50")]
        [DataType(DataType.Text)]
        public string sku { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres maximo 50")]
        [DataType(DataType.Text)]
        public string cc { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Minimo 2 caracteres maximo 50")]
        [DataType(DataType.Text)]
        public string estado { get; set; }

    }
}