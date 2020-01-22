using System;
using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.DAL.Models
{
    public class Indication
    {
        [Key]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int PreviousIndication { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CurrentIndication { get; set; }

        public DateTime FillingTime { get; set; }
    }
}
    