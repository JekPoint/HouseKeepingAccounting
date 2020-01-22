using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseKeepingAccounting.DAL.Models
{
    public class Counter
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Заводской номер счётчика
        /// </summary>
        public string FactoryNumber { get; set; }

        /// <summary>
        /// Поверка счётчика действительна до этой даты
        /// </summary>
        public DateTime VerificationTimeOver { get; set; }

        /// <summary>
        /// Показания за весь период работы счётчика
        /// </summary>
        public virtual ICollection<Indication> Indications { get; set; }

        [ForeignKey("HouseId")]
        public House House { get; set; }

        public int HouseId { get; set; }
    }
}
