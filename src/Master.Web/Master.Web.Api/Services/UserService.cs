﻿using Master.Common.Logging;
using Master.Web.Api.Common;
using Master.Web.Api.Models;
using Master.Web.Api.Models.Requests;
using Master.Web.Api.Models.Responses;
using Master.Web.Api.Providers.TokenProvider;
using System.Collections.Generic;
using System.Linq;

namespace Master.Web.Api.Services
{
    public class UserService : ServiceBase<UserService>, IUserService
    {
        private ITokenProvider _tokenProvider;
        private const string userIdClaim = "id";
        private const string userEmailClaim = "email";

        public UserService(ITokenProvider tokenProvider, ILog<UserService> log) : base(log)
        {
            _tokenProvider = tokenProvider;
        }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Sonu", LastName = "Kumar", Username = "test", Password = "test", Email="sonu.econnect@gmail.com" }
        };

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = _tokenProvider.GetJwtToken(new List<UserClaim> 
            { new UserClaim(userIdClaim, user.Id.ToString()), new UserClaim(userEmailClaim, user.Email) });
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }      
    }
}
