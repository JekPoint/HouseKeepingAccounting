using System.ComponentModel.DataAnnotations;

namespace HouseData.Models
{
    public class House
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [Required]
        public string City { get; set; }


        /// <summary>
        /// Улица
        /// </summary>
        [Required]
        public string Street { get; set; }


        /// <summary>
        /// Номер дома
        /// </summary>
        [Required]
        public string Number { get; set; }

        /// <summary>
        /// Счётчик установленный в доме
        /// </summary>
        public Counter Counter { get; set; }
    }
}
