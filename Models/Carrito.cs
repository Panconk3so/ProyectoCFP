using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoCFP.Models
{
    [Table("t_carrito")]
    public class Carrito
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string? UserID { get; set; }
        public RegistrarCita? RegistrarCita { get; set; }
      

       public DateTime FechaCitaDeseada { get; set; }

        public Decimal Precio { get; set; }
        public String Status { get; set; } ="PENDIENTE";
    }
}