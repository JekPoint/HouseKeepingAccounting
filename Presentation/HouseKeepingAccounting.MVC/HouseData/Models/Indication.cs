using System;
using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.MVC.HouseData.Models
{
    public class Indication
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Предидущие показания
        /// </summary>
        [Required]
        public int PreviousIndication { get; set; }

        /// <summary>
        /// Текущие показания
        /// </summary>
        [Required]
        public int CurrentIndication { get; set; }

        /// <summary>
        /// Дата подачи показаний
        /// </summary>
        [Required]
        public DateTime FillingTime { get; set; }
    }
}
    