using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace beerrecipes.Models
{
    public class Grain
    {
        public Grain()
        {

        }

        public Grain(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; set; }

        public string Name { get;  set; }

        public string Lovibond{ get; set; }

        public string SpecificGravity { get; set; }

        public string Description { get; set; }
    }
}