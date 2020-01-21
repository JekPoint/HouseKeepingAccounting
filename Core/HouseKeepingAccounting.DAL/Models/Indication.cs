using System;
using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.DAL.Models
{
    public class Indication
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Предидущие показания
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int PreviousIndication { get; set; }

        /// <summary>
        /// Текущие показания
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CurrentIndication { get; set; }

        /// <summary>
        /// Дата подачи показаний
        /// </summary>
        public DateTime FillingTime { get; set; }
    }
}
    