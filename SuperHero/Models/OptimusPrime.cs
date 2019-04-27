using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHero.Models
{
    public class OptimusPrime : Heroes
    {
        public OptimusPrime()
        {
            heroName = "Optimus Prime";
            alterEgoName = "Truck";
            primaryAbility = "Giant transforming mech";
            secondaryAbility = "Reducing mobility by turning into a semi truck.  Very inefficient, but looks cool";
            catchphrase = "Autobots rollout";
        }
    }
}