using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using vega.Models;

namespace vega.Controllers.Resources
{

    public class VehicleResource
    {
        
        public VehicleResource() {
            this.Features = new Collection<KeyValuePairResource>();
        }

        public int Id { get; set; }

        public KeyValuePairResource Model { get; set; }
        public KeyValuePairResource Make { get; set; }

        public bool IsRegistered { get; set; } 

        public ContactResource Contact { get; set; }
        
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<KeyValuePairResource> Features { get; set; }

    }
}