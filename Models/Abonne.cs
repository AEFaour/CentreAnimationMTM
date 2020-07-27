using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace WebApplicationAuthManyToManyTest.Models
{
    public class Abonne
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Champs obligatoire")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Champs obligatoire")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Display(Name = "Photo de l'Abonné")]
        public string Photo { get; set; }

        public virtual ICollection<Activite> Activites { get; set; }
    }
}