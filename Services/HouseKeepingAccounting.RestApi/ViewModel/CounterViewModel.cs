using System;
using System.Collections.Generic;
using HouseKeepingAccounting.DAL.Models;

namespace HouseKeepingAccounting.RestApi.ViewModel
{
    public class CounterViewModel
    {
        public int Id { get; set; }

        public string FactoryNumber { get; set; }

        public DateTime VerificationTimeOver { get; set; }

        public List<Indication> Indications { get; set; }

        public int HouseId { get; set; }
    }
}
