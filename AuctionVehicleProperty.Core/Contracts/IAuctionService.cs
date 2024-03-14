using AuctionVehicleProperty.Core.Models.Auctions;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionIndexServiceModel>> CurrentAuctionsAsync();

        Task<IEnumerable<AuctionIndexServiceModel>> AllAuctionsAsync();

        Task CreateAsync(string userId, string email, AuctionCreationServiceModel auctionData);

        Task<bool> AuctionExistAsync(int auctionId);

        Task<AuctionCreationServiceModel> GetAuctionDetailsAsync(int auctionId);

        Task<IEnumerable<AuctionBidServiceModel>> GetAuctionBidsAsync(int auctionId);

        Task PlaceBidAsync(int auctionId, string userId, decimal amount);

        Task CloseAuctionAsync(int auctionId);




    }
}
