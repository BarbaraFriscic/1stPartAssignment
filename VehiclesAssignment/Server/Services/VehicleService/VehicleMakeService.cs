using AutoMapper;
using System.Reflection.Metadata.Ecma335;
using VehiclesAssignment.Shared;

namespace VehiclesAssignment.Server.Services.VehicleService
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly DataContext _context;

        public VehicleMakeService(DataContext context)
        {
            _context = context;
        }

        public async Task<VehicleMake> GetVehicleMakeAsync(int vehicleMakeId)
        {
            var response = await _context.VehicleMakes.FirstOrDefaultAsync(vm => vm.Id == vehicleMakeId);
            return response;
        }

        public async Task<List<VehicleMake>> GetVehicleMakesAsync()
        {
            var response = await _context.VehicleMakes.ToListAsync();
            return response;
        }
        public async Task<List<VehicleMake>> Create(VehicleMake newVehicleMake)
        {
            var newVhclMake = new VehicleMake
            {
                Name = newVehicleMake.Name,
                Abreviation = newVehicleMake.Abreviation

            };
            _context.VehicleMakes.Add(newVhclMake);
            await _context.SaveChangesAsync();
            var response = await _context.VehicleMakes.ToListAsync();
            return response;
        }

        public async Task<List<VehicleMake>> UpdateVehicleMake(int id, VehicleMake updateVehicleMake)
        {
            var vehicleMakeToUpdate = await _context.VehicleMakes.FirstOrDefaultAsync(vm => vm.Id == id);
                vehicleMakeToUpdate.Name = updateVehicleMake.Name;
                vehicleMakeToUpdate.Abreviation = updateVehicleMake.Abreviation;
      
            await _context.SaveChangesAsync();

            var response = await _context.VehicleMakes.ToListAsync();
            return response;
        }

        public async Task<List<VehicleMake>> DeleteVehicleMake(int id)
        {
            
            var vehicleMakeToDelete = await _context.VehicleMakes.FirstOrDefaultAsync(vm => vm.Id == id);
           
            _context.VehicleMakes.Remove(vehicleMakeToDelete);
            await _context.SaveChangesAsync();

            var response = await _context.VehicleMakes.ToListAsync();
            return response;
        }
    }
}
