using Master.Web.Api.Models;
using Master.Web.Api.Models.Requests;
using Master.Web.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Web.Api.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
