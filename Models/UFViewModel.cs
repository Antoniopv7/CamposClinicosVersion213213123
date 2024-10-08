using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class UFViewModel
    {
        [Required]
        public decimal MontoCLP { get; set; }

        [Required]
        public decimal MontoUF { get; set; }
    }
}
