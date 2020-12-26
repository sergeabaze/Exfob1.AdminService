using Exfob1.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exfob1.Communs
{
    public static  class CommunValidators
    {
        public static WebApiSingleResponse<T> BadRequestMessage<T>(WebApiSingleResponse<T> response,string messageError)
        {
            response.IsError = true;
            response.CodeMessage = StatusCodes.Status400BadRequest;
            response.ErrorMessage = messageError;
            return response;
        }

        public static WebApiSingleResponse<T> NotFoundRequestMessage<T>(WebApiSingleResponse<T> response, string messageError)
        {
            response.IsError = true;
            response.CodeMessage = StatusCodes.Status404NotFound;
            response.ErrorMessage = messageError;
            return response;
        }

        public static WebApiListResponse<T> NotFoundRequestMessage<T>(WebApiListResponse<T> response, string messageError)
        {
            response.IsError = true;
            response.CodeMessage = StatusCodes.Status404NotFound;
            response.ErrorMessage = messageError;
            return response;
        }

        public static WebApiListResponse<T> ExceptionRequestMessage<T>(WebApiListResponse<T> response, string messageError)
        {
            response.IsError = true;
            response.CodeMessage = StatusCodes.Status404NotFound;
            response.ErrorMessage = messageError;
            return response;
        }

        public static WebApiSingleResponse<T> ExceptionRequestMessage<T>(WebApiSingleResponse<T> response, string messageError)
        {
            response.IsError = true;
            response.CodeMessage = StatusCodes.Status400BadRequest;
            response.ErrorMessage = messageError;
            return response;
        }
    }
}
