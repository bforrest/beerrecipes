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
            this.id = Guid.NewGuid().ToString();
        }

        public Grain(string Id)
        {
            this.id = Id;
        }

        public string id { get; set; }

        public string name { get;  set; }

        public string lovibond{ get; set; }

        public string specificGravity { get; set; }

        public string description { get; set; }
    }
}