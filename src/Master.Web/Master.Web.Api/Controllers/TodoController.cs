using Master.Web.Api.Common;
using Master.Web.Api.ViewModels;
using Master.Web.Api.ViewModels.Requests;
using Master.Web.Api.ViewModels.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ApiControllerBase
    {
        public TodoController(ILogger logger) : base(logger)
        {

        }

       
        [HttpGet]
        public async Task<GetTodosResponse> GetTodosAsync(GetTodosRequest request)
        {
            var todods = new List<Todo>
            {
                new Todo { Id = 1, Name="First", Description = "First", CreationTime = DateTime.Now, StartTime = DateTime.Now.AddDays(20), IsActive = true },
                new Todo { Id = 2, Name="Second", Description = "Second", CreationTime = DateTime.Now, StartTime = DateTime.Now.AddDays(20), IsActive = true },
                new Todo { Id = 3, Name="Third", Description = "Third", CreationTime = DateTime.Now, StartTime = DateTime.Now.AddDays(20), IsActive = true },
                new Todo { Id = 4, Name="Four", Description = "Four", CreationTime = DateTime.Now, StartTime = DateTime.Now.AddDays(20), IsActive = true },
                new Todo { Id = 5, Name="Five", Description = "Five", CreationTime = DateTime.Now, StartTime = DateTime.Now.AddDays(20), IsActive = true }
            };

            return await Task.FromResult(new GetTodosResponse { Todos = todods });
        }
    }
}
