using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exfob1.Models
{
    public interface IResponse
    {
        string Message { get; set; }
        public int CodeMessage { get; set; }
        bool IsError { get; set; }
        string ErrorMessage { get; set; }
    }
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }

    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }
        double PageCount { get; }
    }
    public class WebApiSingleResponse<TModel> : ISingleResponse<TModel>
    {
        public TModel Model { get; set; }
        public string Message { get; set; }
        public int CodeMessage { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class WebApiListResponse<TModel> : IListResponse<TModel>
    {

        public string Message { get; set; }
        public int CodeMessage { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<TModel> Model { get; set; }

    }

    public class WebApiPagedResponse<TModel> : IPagedResponse<TModel>
    {

        public string Message { get; set; }
        public int CodeMessage { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<TModel> Model { get; set; }
        public int ItemsCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public double PageCount => ItemsCount < PageSize ? 1 : (int)(((double)ItemsCount / PageSize) + 1);
    }
    public static class ResponseExtensions
    {
        public static ActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {

            if (response.IsError)
            {
                if (response.CodeMessage == StatusCodes.Status400BadRequest)
                {
                    var message = new BadRequestObjectResult(response);
                    message.StatusCode = StatusCodes.Status400BadRequest;
                    return message;
                }
                else
                if (response.CodeMessage == StatusCodes.Status404NotFound)
                {
                    var message = new BadRequestObjectResult(response);
                    message.StatusCode = StatusCodes.Status404NotFound;
                    return message;
                }

            }

            return new OkObjectResult(response)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public static ActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {

            if (response.IsError)
            {
                if (response.CodeMessage == StatusCodes.Status400BadRequest)
                {
                    var message = new BadRequestObjectResult(response);
                    message.StatusCode = StatusCodes.Status400BadRequest;
                    return message;
                }
                else
                if (response.CodeMessage == StatusCodes.Status404NotFound)
                {
                    var message = new BadRequestObjectResult(response);
                    message.StatusCode = StatusCodes.Status404NotFound;
                    return message;
                }

            }

            return new OkObjectResult(response)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public static ActionResult ToHttpResponse<TModel>(this IPagedResponse<TModel> response)
        {

            if (response.IsError)
            {
                if (response.CodeMessage == StatusCodes.Status400BadRequest)
                {
                    var message = new BadRequestObjectResult(response);
                    message.StatusCode = StatusCodes.Status400BadRequest;
                    return message;
                }
                else
                if (response.CodeMessage == StatusCodes.Status404NotFound)
                {
                    var message = new BadRequestObjectResult(response);
                    message.StatusCode = StatusCodes.Status404NotFound;
                    return message;
                }

            }

            return new OkObjectResult(response)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
