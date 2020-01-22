namespace HouseKeepingAccounting.RestApi.ViewModel
{
    public class HouseViewModel
    {
        public int Id { get; set; }

        public string CityName { get; set; }
        
        public string StreetName { get; set; }

        public string HomeNumber { get; set; }

        public CounterViewModel Counter { get; set; }
    }
}
