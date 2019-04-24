using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resources
{

    public class VehicleResource
    {
        
        
        public VehicleResource() {
            this.Features = new Collection<int>();
        }

        public int Id { get; set; }

        public int ModelId { get; set; }

        public ContactResource Contact { get; set; }

        public bool IsRegistered { get; set; } 


        public virtual ICollection<int> Features { get; set; }

    }
}