using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.Mappers;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUseryRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUseryRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? applicationUser = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);
        return applicationUser == null ? null : _mapper.Map<AuthenticationResponse>(applicationUser) with
        {
            Success = true,
            Token = "token"
        };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        ApplicationUser user = _mapper.Map<ApplicationUser>(request);

        ApplicationUser? createdUser = await _userRepository.AddUser(user);

        if (createdUser == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(createdUser) with
        {
            Success = true, Token = "token"
        };
    }
}

