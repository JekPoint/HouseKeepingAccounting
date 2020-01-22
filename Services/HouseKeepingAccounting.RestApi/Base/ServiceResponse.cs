namespace HouseKeepingAccounting.RestApi.Base
{
    public class ServiceResponse
    {
        public object Result { get; set; }

        public ServiceResponseStatus Status { get; set; }
    }
}
