namespace VehiclesAssignment.Client.Services.VehicleService
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly HttpClient _http;

        public VehicleMakeService(HttpClient http)
        {
            _http = http;
        }

        public List<VehicleMake> VehicleMakes { get; set; } = new List<VehicleMake>();

        public async Task GetVehicleMakes()
        {
            var result = 
                await _http.GetFromJsonAsync<ServiceResponse<List<VehicleMake>>>("api/vehicleMake");
            if(result != null && result.Data!= null)
                VehicleMakes= result.Data;
            
        }
    }
}
