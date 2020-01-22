using System;

namespace HouseKeepingAccounting.RestApi.ViewModel
{
    public class CounterAddModel
    {
        public string FactoryNumber { get; set; }
        
        public DateTime VerificationTimeOver { get; set; }

        public int HouseId { get; set; }
    }
}
