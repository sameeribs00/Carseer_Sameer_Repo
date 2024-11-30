namespace SameerIbseleh_Carseer.Services.HomeServices
{
    public interface IHomeService
    {
        Task<List<VehicleAllMakesVM>> GetAllMakes();
        Task<List<VehicleTypesVM>> GetVehicleTypes(int makeId);
        Task<List<VehicleModelsVM>> GetVehicleModels(int makeId, int modelYear);
    }
}
