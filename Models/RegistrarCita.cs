using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

 

namespace ProyectoCFP.Models

{

    [Table("t_registroCita")]

    public class RegistrarCita

    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]

       
    public int Id { get; set; }

    
    public string? Nombre { get; set; }

  
    public string? ApellidoPaterno { get; set; }

   
    public string? ApellidoMaterno { get; set; }

 
    public string? Email { get; set; }

    
    public string? Phone { get; set; }
   
  
    public DateTime FechaNacimiento { get; set; }

   
    public string? DNI { get; set; }

   

    public string? Departamento { get; set; }

 
    public string? Especialidad { get; set; }



    public DateTime FechaCitaDeseada { get; set; }
}

}