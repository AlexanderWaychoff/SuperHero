using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Goliath : Heroes
    {
        public Goliath()
        {
            heroName = "Goliath";
            alterEgoName = "none";
            primaryAbility = "Being a overweight french fry";
            secondaryAbility = "Immunity to lipo suction";
            catchphrase = "*frown*";
        }
    }
}