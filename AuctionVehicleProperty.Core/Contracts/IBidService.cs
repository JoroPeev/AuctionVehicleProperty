namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IBidService
    {
        Task<bool> AuctionExistsAsync(string auctionId);

        Task<bool> UserExistsAsync(string userId);
        
        Task<bool> VehicleExistsAsync(string vehicleId);
    }
}
