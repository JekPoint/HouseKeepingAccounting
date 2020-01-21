using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.DAL.Models
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string CityName { get; set; }


        /// <summary>
        /// Улица
        /// </summary>

        public string StreetName { get; set; }


        /// <summary>
        /// Номер дома
        /// </summary>
        public string HomeNumber { get; set; }

        /// <summary>
        /// Счётчик установленный в доме
        /// </summary>
        public Counter Counter { get; set; }
    }
}
