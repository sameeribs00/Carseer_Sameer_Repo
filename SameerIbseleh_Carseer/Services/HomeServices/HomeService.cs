using System.Text.Json;

namespace SameerIbseleh_Carseer.Services.HomeServices
{
    public class HomeService : IHomeService
    {
        public async Task<List<VehicleAllMakesVM>> GetAllMakes()
        {
            try
            {
                List<VehicleAllMakesVM> allMakes = [];
                using var client = new HttpClient();

                var response = await client.GetAsync("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var content = JsonSerializer.Deserialize<ResponseVM<VehicleAllMakesVM>>(jsonContent);
                    allMakes = content != null ? content.Results : allMakes;

                    return allMakes;
                }
                else
                {
                    var errorMessage = $"API call failed with status code: {response.StatusCode}, Reason: {response.ReasonPhrase}";
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<VehicleTypesVM>> GetVehicleTypes(int makeId)
        {
            try
            {
                List<VehicleTypesVM> vehicleTypes = [];
                using var client = new HttpClient();
                var url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/" + makeId + "?format=json";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var content = JsonSerializer.Deserialize<ResponseVM<VehicleTypesVM>>(jsonContent);
                    vehicleTypes = content != null ? content.Results : vehicleTypes;

                    return vehicleTypes;
                }
                else
                {
                    var errorMessage = $"API call failed with status code: {response.StatusCode}, Reason: {response.ReasonPhrase}";
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<VehicleModelsVM>> GetVehicleModels(int makeId, int modelYear)
        {
            try
            {
                List<VehicleModelsVM> vehicleModels = [];
                using var client = new HttpClient();
                var url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/" + makeId + "/modelyear/" + modelYear + "?format=json";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var content = JsonSerializer.Deserialize<ResponseVM<VehicleModelsVM>>(jsonContent);
                    vehicleModels = content != null ? content.Results : vehicleModels;

                    return vehicleModels;
                }
                else
                {
                    var errorMessage = $"API call failed with status code: {response.StatusCode}, Reason: {response.ReasonPhrase}";
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
