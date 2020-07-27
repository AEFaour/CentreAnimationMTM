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

        public string Prenom { get; set; }

        public string Mail { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<Activite> Activites { get; set; }
    }
}