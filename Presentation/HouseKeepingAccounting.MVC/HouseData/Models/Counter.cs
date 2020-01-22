using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.MVC.HouseData.Models
{
    public class Counter
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Заводской номер счётчика
        /// </summary>
        [Required]
        public string FactoryNumber { get; set; }

        /// <summary>
        /// Поверка счётчика действительна до этой даты
        /// </summary>
        [Required]
        public DateTime VerificationTimeOver { get; set; }

        /// <summary>
        /// Показания за весь период работы счётчика
        /// </summary>
        [Required]
        public IList<Indication> Indications { get; set; }    
    }
}
