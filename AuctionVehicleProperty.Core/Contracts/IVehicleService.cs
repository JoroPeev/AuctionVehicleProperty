namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IVehicleService
    {
        Task<bool> VehicleExistsByIdAsync(int vehicleId);

        Task<bool> OwnerExistsByIdAsync(string ownerId);
    }
}
