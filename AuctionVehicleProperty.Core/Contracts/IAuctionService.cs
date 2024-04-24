using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IAuctionService
    {
        Task<bool> AuctionValidationCreator(int auctionId, string creatorId);

        Task<IEnumerable<AuctionIndexServiceModel>> AllAuctionsAsync();

        Task<bool> VehicleExistsInOtherAuctionsAsync(int vehicleId);

        Task<bool> AuctionExistAsync(int auctionId);

        Task CreateAsync(AuctionCreationServiceModel auctionData);

        Task<AuctionDetailsModel> GetAuctionDetailsAsync(int auctionId);

        Task<ICollection<Bid>> GetAuctionBidsAsync(int auctionId);

        Task DeleteAuctionAsync(int auctionId);

        Task UpdateAuctionAsync(AuctionCreationServiceModel updatedAuction);
    }
}
