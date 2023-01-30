namespace VehiclesAssignment.Client.Services.VehicleService
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly HttpClient _http;

        public VehicleModelService(HttpClient http)
        {
            _http = http;
        }

        public List<VehicleModel> VehicleModels { get; set; }

        public async Task GetVehicleModels()
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<List<VehicleModel>>>("api/vehicleModel");
            if (result != null && result.Data != null) 
                VehicleModels= result.Data;
        }
    }
}
