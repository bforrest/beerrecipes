using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerrecipes.Models
{
    public class Recipe
    {
        public string id { get; set; }

        public IEnumerable<Grain> grains { get; set; }

        public IEnumerable<Hop> hops { get; set; }

        public int boilTime { get; set; }

        public Yeast yeast { get; set; }

        public string description { get; set; }
    }
}