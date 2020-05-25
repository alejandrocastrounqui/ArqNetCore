using AutoMapper;

namespace ArqNetCore.UserMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserSignUpRequestDTO, DTOs.UserSignUpDTO>();
            CreateMap<DTOs.UserSignUpResultDTO, UserSignUpResponseDTO>();
        }
    }
}