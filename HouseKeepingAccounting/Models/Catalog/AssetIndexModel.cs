using System.Collections.Generic;

namespace HouseKeepingAccounting.Models.Catalog
{
    public class AssetIndexModel
    {
        public string Status { get; set; }

        public string NewHouseCity { get; set; }

        public string NewHouseStreet { get; set; }

        public string NewHouseNumber { get; set; }

        public IEnumerable<AssetIndexListingModel> Assets { get; set; }
    }
}
