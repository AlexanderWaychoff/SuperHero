using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Hulk : Heroes
    {
        public Hulk()
        {
            heroName = "Incredible Hulk";
            alterEgoName = "Banner";
            primaryAbility = "Incredible strength when green";
            secondaryAbility = "Intellectual when not green";
            catchphrase = "Puny Banner, Hulk Smash!";
        }
    }
}