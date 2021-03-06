﻿using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.DAL.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }

        public string HomeNumber { get; set; }

        public Counter Counter { get; set; }
    }
}
