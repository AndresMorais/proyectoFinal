using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_comunidad_it.Models
{
   public class Legislacion
     {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Tipo { get; set; }
        public int Numero {get;set;}
        public string Origen {get;set;}
        public string Objeto {get;set;}
        // [DataType(DataType.Date)]
        // public DateTime ReleaseDate { get; set; }   
    } 
}