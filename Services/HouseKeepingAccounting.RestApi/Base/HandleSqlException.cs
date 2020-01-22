using System;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace HouseKeepingAccounting.RestApi.Base
{
    public static class HandleException
    {
        public static ServiceResponse HandleSqlException(Exception exception)
        {
            if (!(exception is SqliteException dbUpdateEx))
            {
                return new ServiceResponse
                {
                    Status = ServiceResponseStatus.OtherError,
                    Result = $"{exception.Message}"
                };
            }

            if (dbUpdateEx.InnerException?.InnerException == null)
            {
                return new ServiceResponse
                {
                    Status = ServiceResponseStatus.OtherError,
                    Result = $"{exception.Message}"
                };
            }

            if (!(dbUpdateEx.InnerException.InnerException is SqlException sqlException))
            {
                return new ServiceResponse
                {
                    Status = ServiceResponseStatus.OtherError,
                    Result = $"{exception.Message}"
                };
            }

            switch (sqlException.Number)
            {
                case 2627:  // Unique constraint error
                case 547:   // Constraint check violation
                case 2601:  // Duplicated key row error
                    return new ServiceResponse()
                    {
                        Status = ServiceResponseStatus.UniqueConstraintError,
                        Result = "Unique constraint error"
                    };
                default:
                    // A custom exception of yours for other DB issues
                    return new ServiceResponse()
                    {
                        Status = ServiceResponseStatus.OtherError,
                        Result = $"{exception.Message}"
                    };
            }
        }
    }
}
