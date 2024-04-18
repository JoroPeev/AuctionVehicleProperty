using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionIndexServiceModel>> CurrentAuctionsAsync();

        Task<bool> AuctionValidationCreator(int auctionId, string creatorId);

        Task<IEnumerable<AuctionIndexServiceModel>> AllAuctionsAsync();

        Task<bool> VehicleExistsInOtherAuctionsAsync(int vehicleId);

        Task CreateAsync(AuctionCreationServiceModel auctionData);

        Task<bool> AuctionExistAsync(int auctionId);

        Task CloseAuctionAgentAsync(int auctionId, int winnerId);

        Task<AuctionDetailsModel> GetAuctionDetailsAsync(int auctionId);

        Task<ICollection<Bid>> GetAuctionBidsAsync(int auctionId);

        Task<IEnumerable<AuctionIndexServiceModel>> LatestAuctionsAsync();
        Task DeleteAuctionAsync(int auctionId);


    }
}
