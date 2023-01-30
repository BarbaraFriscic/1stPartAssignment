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

        public async Task<ServiceResponse<List<VehicleMake>>> GetVehicleMakeAsync(int vehicleMakeId)
        {
            var response = new ServiceResponse<List<VehicleMake>>
            {
                Data = await _context.VehicleMakes
                .Where(c => c.Id == vehicleMakeId)
                .Include(c => c.Models)
                .ToListAsync()
            };
            if (response.Data is null)
            {
                response.Success = false;
                response.Message = "This Vehicle Make does not exist.";
            }
            return response;
        }

        public async Task<ServiceResponse<List<VehicleMake>>> GetVehicleMakesAsync()
        {
            var response = new ServiceResponse<List<VehicleMake>>
            {
                Data = await _context.VehicleMakes
                .Include(c => c.Models)
                .ToListAsync()
            };
            return response;
        }
        public async Task<ServiceResponse<List<VehicleMake>>> Create(VehicleMake newVehicleMake)
        {
            var newVhclMake = new VehicleMake
            {
                Name = newVehicleMake.Name,
                Abreviation = newVehicleMake.Abreviation

            };
            _context.VehicleMakes.Add(newVhclMake);
            await _context.SaveChangesAsync();
            var response = new ServiceResponse<List<VehicleMake>>
            {
                Data = await _context.VehicleMakes
                .ToListAsync()
            };
            if (response.Data is null)
            {
                response.Success = false;
                response.Message = "Unable to create new VehicleMake.";
            }
            return response;
        }

        public async Task<ServiceResponse<VehicleMake>> UpdateVehicleMake(int id, VehicleMake updateVehicleMake)
        {
            var vehicleMakeToUpdate = await _context.VehicleMakes.FirstOrDefaultAsync(c => c.Id == id);
            if (vehicleMakeToUpdate is null)
                vehicleMakeToUpdate = null;
            else
            {
                vehicleMakeToUpdate.Name = updateVehicleMake.Name;
                vehicleMakeToUpdate.Abreviation = updateVehicleMake.Abreviation;
            }
            
            await _context.SaveChangesAsync();

            var response = new ServiceResponse<VehicleMake>
            {
                Data = vehicleMakeToUpdate
                
            };
            if (response.Data is null)
            {
                response.Success = false;
                response.Message = "Unable to update a VehicleMake.";
            }
            return response;


        }

        public async Task<ServiceResponse<List<VehicleMake>>> DeleteVehicleMake(int id)
        {
            
            var vehicleMakeToDelete = await _context.VehicleMakes.FirstOrDefaultAsync(c => c.Id == id);
            if (vehicleMakeToDelete is null)
                vehicleMakeToDelete = null;
            else
           _context.VehicleMakes.Remove(vehicleMakeToDelete);

            await _context.SaveChangesAsync();

            var response = new ServiceResponse<List<VehicleMake>>
                {
                    Data = await _context.VehicleMakes
                .ToListAsync() 
                };
            if (vehicleMakeToDelete == null)
            {
                response.Data = await _context.VehicleMakes
                .ToListAsync();
                response.Success = false;
                response.Message = "Unable to delete this VehicleMake.";           
            }      
            return response;
        }
    }
}
