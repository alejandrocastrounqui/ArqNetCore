using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using ArqNetCore.Services;
using ArqNetCore.DTOs;

namespace ArqNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IMapper _mapper;

        private IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IMapper mapper,
            IUserService userService
        )
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("UserSignUp")]
        public UserSignUpResponseDTO UserSignUp(UserSignUpRequestDTO userSignUpRequestDTO)
        {
            _logger.LogInformation("email:" + userSignUpRequestDTO.Email);
            UserSignUpDTO userSignUpDTO = _mapper.Map<UserSignUpDTO>(userSignUpRequestDTO);
            UserSignUpResultDTO userSignUpResultDTO = _userService.UserSignUp(userSignUpDTO);
            UserSignUpResponseDTO userSignUpResponseDTO = _mapper.Map<UserSignUpResponseDTO>(userSignUpResultDTO);
            return userSignUpResponseDTO;
        }
    }
}
