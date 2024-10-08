
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Presupuesto
    {
        [Key]
        public int Id_Presupuesto { get; set; }
        public float MontoInicial { get; set; }
        public float MontoActual { get; set; }

        // Relación con Convenio (uno a muchos)
        public virtual ICollection<Convenio> Convenios { get; set; }

        // Relación con Centro_Costo (uno a muchos)
        public virtual ICollection<Centro_Costo> Centro_Costos { get; set; }
    }
}
