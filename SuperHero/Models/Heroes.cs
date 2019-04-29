using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Heroes
    {
        [Key]
        public int heroId { get; set; }
        [Display(Name = "Name")]
        public string heroName { get; set; }
        [Display(Name = "Alter Ego")]
        public string alterEgoName { get; set; }
        [Display(Name = "Primary Ability")]
        public string primaryAbility { get; set; }
        [Display(Name = "Secondary Ability")]
        public string secondaryAbility { get; set; }
        [Display(Name = "Catchphrase")]
        public string catchphrase { get; set; }
    }
}