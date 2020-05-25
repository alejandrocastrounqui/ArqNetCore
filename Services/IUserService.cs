using ArqNetCore.DTOs;
namespace ArqNetCore.Services
{
    public interface IUserService
    {
        UserSignUpResultDTO UserSignUp(UserSignUpDTO userSignUpDTO);
    }
}