using eCommerce.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest request);

    Task<AuthenticationResponse?> Register(RegisterRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    Task<UserDTO?> GetUserByUserID(Guid? UserID);

}

