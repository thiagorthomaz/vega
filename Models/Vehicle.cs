using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.Models
{
    public class Vehicle
    {
        public Vehicle() {
            this.Features = new Collection<VehicleFeature>();
        }

        public int Id { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        [Required]
        public bool IsRegistered { get; set; } 

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactEmail { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<VehicleFeature> Features { get; set; }

    }
}