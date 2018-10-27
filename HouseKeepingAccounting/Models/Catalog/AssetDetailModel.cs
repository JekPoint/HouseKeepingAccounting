using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.Models.Catalog
{
    public class AssetDetailModel
    {
        public int HouseId { get; set; }    

        public string FactoryNumder { get; set; }

        public int NewIndication { get; set; }

        public int LastIndication { get; set; }

        public DateTime CurrentDate { get; set; }

        public string HouseCity { get; set; }

        public string HousePlace { get; set; }

        public string HouseNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? VerificationTimeOver { get; set; }  

        public string FullAdress { get; set; }

        public IEnumerable<AssetDetailListingModel> Asset { get; set; }  
    }
}
    