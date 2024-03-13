using AuctionVehicleProperty.Core.Models.Auctions;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IAuctionService
    {
        Task<IEnumerable<AuctionIndexServiceModel>> LatestAuctionsAsync();




    }
}
