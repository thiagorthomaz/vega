using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;

        public VehiclesController(IMapper _mapper, VegaDbContext _context) {
            this.mapper = _mapper;
            this.context = _context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource SaveVehicleResource) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(SaveVehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]SaveVehicleResource SaveVehicleResource) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if(vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(SaveVehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, SaveVehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id){

            var vehicle = await context.Vehicles.FindAsync(id);
            if(vehicle == null)
                return NotFound();

            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id){

            var vehicle = await context.Vehicles
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
            .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
            .SingleOrDefaultAsync(v => v.Id == id);
            if(vehicle == null)
                return NotFound();

            var SaveVehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(SaveVehicleResource);
        }
        
    }
}