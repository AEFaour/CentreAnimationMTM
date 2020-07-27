using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationAuthManyToManyTest.Models
{
    public class Activite
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Champs obligatoire")]
        [Display(Name = "Description")]
        public string Libelle { get; set; }


        public virtual ICollection<Abonne> Abonnes { get; set; }
    }
}