using butterfly.com.rest;
using butterfly.com.rest.client;
using butterfly.com.rest.Model;
using Butterfly.Service.Expenses.DataModel;
using Butterfly.Service.Expenses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.Service.Expenses.Dispatchers
{
    public class CategoryRestDispatcher : RestDispatcher
    {
        public override void DispatchRestMethod(RestMethod method)
        {
            throw new NotImplementedException();
        }

        public override void GET(HttpContext context)
        {
            List<Category> categories = ExpensesDataService.GetCategories(String.Empty);
            Serializer.Serialize(categories, context.Response.OutputStream);
        }

        public override void POST(HttpContext context)
        {
            CreateCategoryRequest request = Serializer.Deserialize(context.Request.InputStream, typeof(CreateCategoryRequest)) as CreateCategoryRequest;
            BaseResult result = new BaseResult();
            if (request != null)
            {
                Response resp = ExpensesDataService.CreateCategory(request);
                if (resp != null)
                {

                    switch (resp.ResultCode)
                    {
                        case 0:
                            result.ResultCode = ResultCodes.Created;
                            result.ResultMessage = resp.ResultMessage;
                            context.Response.StatusCode = 201;
                            context.Response.Status = "201 Created";
                            break;
                        case 1:
                            result.ResultCode = ResultCodes.NotCreated;
                            result.ResultMessage = resp.ResultMessage;
                            context.Response.StatusCode = 400;
                            context.Response.Status = "400 Bad Request";
                            break;
                        default:
                            context.Response.StatusCode = 400;
                            context.Response.Status = "400 Bad Request";
                            result.ResultCode = ResultCodes.NotCreated;
                            result.ResultMessage = "Undefined ResultCode";
                            break;
                    }

                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Status = "400 Bad Request";
                    result.ResultCode = ResultCodes.NotCreated;
                    result.ResultMessage = "CreateCategory Response is null";
                }
            }
            else
            {
                result.ResultCode = ResultCodes.EmptyParam;
            }
            Serializer.Serialize(result, context.Response.OutputStream);
        }

        public override void DELETE(HttpContext context)
        {
            DeleteCategoryRequest request = Serializer.Deserialize(context.Request.InputStream, typeof(DeleteCategoryRequest)) as DeleteCategoryRequest;
            BaseResult result = new BaseResult();
            if (request != null)
            {
                Response response = ExpensesDataService.DeleteCategory(request);
                if (response != null)
                {
                    switch (response.ResultCode)
                    {
                        case 0:
                            result.ResultCode = ResultCodes.Deleted;
                            result.ResultMessage = response.ResultMessage;
                            context.Response.StatusCode = 200;
                            context.Response.Status = "200 OK";
                            break;
                        case 1:
                            result.ResultCode = ResultCodes.NotDeleted;
                            result.ResultMessage = response.ResultMessage;
                            context.Response.Status = "400 Bad Request";
                            context.Response.StatusCode = 400;
                            break;
                    }
                }
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Status = "400 Bad Request";
                result.ResultCode = ResultCodes.NotCreated;
                result.ResultMessage = "CreateCategory Response is null";
            }
            Serializer.Serialize(result, context.Response.OutputStream);
        }
    }
}