using AuctionVehicleProperty.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Models.Vehicles
{
    public class VehicleIndexQueryModel
    {
        public int VehiclesPerPage { get; } = 3;

        public string Category { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public VehicleFiltering Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalVehiclesCount { get; set; }

        public IEnumerable<VehicleCategoryServiceModel> Categories { get; set; } = null!;

        public IEnumerable<VehicleServiceModel> Vehicles { get; set; } = new List<VehicleServiceModel>();


    }
}
