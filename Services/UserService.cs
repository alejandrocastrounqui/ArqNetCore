using Microsoft.Extensions.Logging;
using ArqNetCore.DTOs.User;
using ArqNetCore.Entities;
using ArqNetCore.Configuration;

namespace ArqNetCore.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        private ArqNetCoreDbContext _dbContext;

        public UserService(
            ILogger<UserService> logger,
            ArqNetCoreDbContext dbContext
        )
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public UserSignUpResultDTO UserSignUp(UserSignUpDTO userSignUpDTO)
        {
            _logger.LogInformation("UserSignUp email:" + userSignUpDTO.Email);
            string passwordRaw = userSignUpDTO.Password;
            Account account = new Account{
                Id = userSignUpDTO.Email,
                //TODO hash passwordRaw
                PasswordHash = null
            };
            _dbContext.Accounts.Add(account);
            User user = new User{
                Account = account
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return new UserSignUpResultDTO();
        }

    }
}