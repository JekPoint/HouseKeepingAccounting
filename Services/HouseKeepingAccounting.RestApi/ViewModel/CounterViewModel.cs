using System;
using System.Collections.Generic;
using HouseKeepingAccounting.DAL.Models;

namespace HouseKeepingAccounting.BaseApi.ViewModel
{
    public class CounterViewModel
    {
        public int Id { get; set; }

        public string FactoryNumber { get; set; }

        public DateTime VerificationTimeOver { get; set; }

        public virtual ICollection<Indication> Indications { get; set; }
    }
}
