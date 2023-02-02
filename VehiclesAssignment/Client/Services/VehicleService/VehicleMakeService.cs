using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;

namespace VehiclesAssignment.Client.Services.VehicleService
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public VehicleMakeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<VehicleMake> VehicleMakes { get; set; } = new List<VehicleMake>();

        public async Task GetVehicleMakes()
        {
            var result = 
                await _http.GetFromJsonAsync<List<VehicleMake>>("api/vehiclemake");
            if(result != null)
                VehicleMakes = result;          
        }

        public async Task<VehicleMake> GetVehicleMake(int id)
        {
            var result =
                await _http.GetFromJsonAsync<VehicleMake>($"api/vehiclemake/{id}");
            if(result != null)
                return result;
            throw new Exception("Hero not found");
        }

        public async Task CreateVehicleMake(VehicleMake vehicleMake)
        {
            var result = await _http.PostAsJsonAsync("api/vehiclemake", vehicleMake);
            var response = await result.Content.ReadFromJsonAsync<List<VehicleMake>>();
            VehicleMakes = response;
            _navigationManager.NavigateTo("vehiclemakes");
        }

        public async Task UpdateVehicleMake(VehicleMake vehicleMake)
        {
            var result = await _http.PutAsJsonAsync($"api/vehiclemake/{vehicleMake.Id}", vehicleMake);
            var response = await result.Content.ReadFromJsonAsync<List<VehicleMake>>();
            VehicleMakes = response;
            _navigationManager.NavigateTo("vehiclemakes");
        }

        public async Task DeleteVehicleMake(int id)
        {
            var result = await _http.DeleteAsync($"api/vehiclemake/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<VehicleMake>>();
            VehicleMakes = response;
            _navigationManager.NavigateTo("vehiclemakes");
        }
    }
}
