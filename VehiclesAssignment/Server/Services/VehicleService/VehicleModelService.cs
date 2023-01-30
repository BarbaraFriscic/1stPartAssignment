namespace VehiclesAssignment.Server.Services.VehicleService
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly DataContext _context;

        public VehicleModelService(DataContext context)
        {
            _context= context;
        }

        public async Task<ServiceResponse<VehicleModel>> GetVehicleModelAsync(int vehicleModelId)
        {
            var response = new ServiceResponse<VehicleModel>
            {
                Data = await _context.VehicleModels.FindAsync(vehicleModelId)
            };
            if (response.Data is null)
            {
                response.Success = false;
                response.Message = "This Vehicle Model does not exist.";
            }
            return response;
        }

        public async Task<ServiceResponse<List<VehicleModel>>> GetVehicleModelsAsync()
        {
            var response = new ServiceResponse<List<VehicleModel>>
            {
                Data = await _context.VehicleModels
                .Include(c => c.Make)
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<VehicleModel>>> Create(VehicleModel newVehicleModel)
        {
            var newVhclModel = new VehicleModel
            {
                MakeID= newVehicleModel.MakeID,
                Name = newVehicleModel.Name,
                Abreviation = newVehicleModel.Abreviation
            };
            _context.VehicleModels.Add(newVhclModel);
            await _context.SaveChangesAsync();
            var response = new ServiceResponse<List<VehicleModel>>
            {
                Data = await _context.VehicleModels
                .ToListAsync()
            };
            if (response.Data is null)
            {
                response.Success = false;
                response.Message = "Unable to create new VehicleModel.";
            }
            return response;
        }

        public async Task<ServiceResponse<VehicleModel>> UpdateVehicleModel(int id, VehicleModel updateVehicleModel)
        {
            var vehicleModelToUpdate = await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == id);
            if (vehicleModelToUpdate is null)
                vehicleModelToUpdate = null;
            else
            {
                vehicleModelToUpdate.Name = updateVehicleModel.Name;
                vehicleModelToUpdate.Abreviation = updateVehicleModel.Abreviation;
                vehicleModelToUpdate.MakeID = updateVehicleModel.MakeID;
            }

            await _context.SaveChangesAsync();

            var response = new ServiceResponse<VehicleModel>
            {
                Data = vehicleModelToUpdate

            };
            if (response.Data is null)
            {
                response.Success = false;
                response.Message = "Unable to update a VehicleModel.";
            }
            return response;
        }

        public async Task<ServiceResponse<List<VehicleModel>>> DeleteVehicleModel(int id)
        {
            var vehicleModelToDelete = await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == id);
            if (vehicleModelToDelete is null)
                vehicleModelToDelete = null;
            else
                _context.VehicleModels.Remove(vehicleModelToDelete);

            await _context.SaveChangesAsync();

            var response = new ServiceResponse<List<VehicleModel>>
            {
                Data = await _context.VehicleModels
                .ToListAsync()
            };
            if (vehicleModelToDelete == null)
            {
                response.Data = await _context.VehicleModels
                .ToListAsync();
                response.Success = false;
                response.Message = "Unable to delete this VehicleModel.";
            }
            return response;
        }
    }
}
