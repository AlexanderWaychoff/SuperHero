﻿using System;
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
        public string heroName { get; set; }
    }
}