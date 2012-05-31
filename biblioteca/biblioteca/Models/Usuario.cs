using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace biblioteca.Models
{
   
    public class publicar_libroModel
    {
        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        
        [Required]
        [Display(Name = "Autor")]
        public string Autor { get; set; }
     
        
        [DataType(DataType.Date)]
        [Display(Name = "AñoPublicacion")]
        public DateTimeStyles AñoPublicacion { get; set; }
        
        [Required]
        [Display(Name = "Tema")]
        public string Tema { get; set; }
        
        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
    public class crear_articuloModel
    {
        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        
        [Required]
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }
        }
    
    public class crear_cursoModel
    {
        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        
        [Required]
        [Display(Name = "Indice")]
        public string Indice { get; set; }
        
        [Required]
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }

        
      }
    public class crear_tutorialModel
    {
        [Required]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        
        [Required]
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }
        
        [Display(Name = "Indice")]
        public String Indice { get; set; }
    }

}