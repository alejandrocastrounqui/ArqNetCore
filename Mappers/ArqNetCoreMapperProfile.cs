using AutoMapper;
using ArqNetCore.DTOs.User;
using ArqNetCore.DTOs.Account;
using ArqNetCore.Entities;

namespace ArqNetCore.Mappers
{
    public class ArqNetCoreMapperProfile : Profile
    {
        public ArqNetCoreMapperProfile()
        {
            //User
            CreateMap<UserSignUpRequestDTO, UserSignUpDTO>();
            CreateMap<UserSignUpResultDTO, UserSignUpResponseDTO>();
            //Account
            CreateMap<Account, AccountFindResultDTO>();
        }
    }
}