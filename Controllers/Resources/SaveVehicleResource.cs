using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{

    public class SaveVehicleResource
    {
        
        
        public SaveVehicleResource() {
            this.Features = new Collection<int>();
        }

        public int Id { get; set; }

        public int ModelId { get; set; }

        [Required]
        public ContactResource Contact { get; set; }

        public bool IsRegistered { get; set; } 


        public virtual ICollection<int> Features { get; set; }

    }
}