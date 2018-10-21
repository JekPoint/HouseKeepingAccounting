namespace HouseKeepingAccounting.Models.Catalog
{
    public class AssetIndexListingModel
    {
        public int Id { get; set; }

        public string HouseAddress { get; set; }

        public string HouseCounterVerificationTimeOver { get; set; }    

        public string HouseCounterFactorNumber { get; set; }

        public string HouseCounterLastIndication { get; set; }

        public string HouseCounterLastIndicationDate { get; set; }
    }
}