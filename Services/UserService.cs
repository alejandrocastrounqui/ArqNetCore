using Microsoft.Extensions.Logging;
using ArqNetCore.DTOs;
using ArqNetCore.Entities;
//using ArqNetCore.Configuration;

namespace ArqNetCore.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        //private DbContext _dbContext;

        public UserService(
            ILogger<UserService> logger
            //DbContext dbContext
        )
        {
            _logger = logger;
            //_dbContext = dbContext;
        }

        public UserSignUpResultDTO UserSignUp(UserSignUpDTO userSignUpDTO)
        {
            _logger.LogInformation("email:" + userSignUpDTO.Email);
            User user = new User{
                Email = userSignUpDTO.Email
            };
            //_dbContext.Users.Add(user);
            //_dbContext.SaveChanges();
            return new UserSignUpResultDTO();
        }
    }
}