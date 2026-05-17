using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUseryRepository _userRepository;

    public UserService(IUseryRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? applicationUser = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);
        return applicationUser == null ? null : new AuthenticationResponse(applicationUser.UserID,
            applicationUser.Email,
            applicationUser.PersonName,applicationUser.Gender,"token", Success : true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        ApplicationUser user = new ApplicationUser
        {
            Email = request.Email,
            Password = request.Password,
            PersonName = request.PersonName,
            Gender = request.Gender.ToString()
        };

        ApplicationUser? createdUser = await _userRepository.AddUser(user);

        if (createdUser == null)
        {
            return null;
        }

        return new AuthenticationResponse(
            createdUser.UserID,
            createdUser.Email,
            createdUser.PersonName,
            createdUser.Gender,
            "token",
            Success: true);
    }
}

