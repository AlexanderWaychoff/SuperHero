using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class Batman : Heroes
    {
        public Batman()
        {
            heroName = "Batman";
            alterEgoName = "Bruce Payne";
            primaryAbility = "Being a bat";
            secondaryAbility = "Being a man";
            catchphrase = "I'm Batman.";
        }
    }
}