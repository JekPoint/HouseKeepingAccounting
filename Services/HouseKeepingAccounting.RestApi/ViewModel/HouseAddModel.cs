using System.ComponentModel.DataAnnotations;

namespace HouseKeepingAccounting.BaseApi.ViewModel
{
    public class HouseAddModel
    {
        [Required(ErrorMessage = "City name is required")]
        [MaxLength(100, ErrorMessage = "City name cannot be greater than 100")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        [MaxLength(100, ErrorMessage = "Street name cannot be greater than 100")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Home number is required")]
        [MaxLength(10, ErrorMessage = "Home number cannot be greater than 10")]
        public string HomeNumber { get; set; }
    }
}
