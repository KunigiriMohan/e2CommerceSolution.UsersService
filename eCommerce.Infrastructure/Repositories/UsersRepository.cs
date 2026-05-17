using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUseryRepository
{
    private readonly DapperDbContext _dapperDbContext;

    public UsersRepository(DapperDbContext dapperDbContext)
    {
        _dapperDbContext = dapperDbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowsAffected = await _dapperDbContext.DbConnection.ExecuteAsync(query, user);

        if (rowsAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var parameters = new { Email = email, Password = password };

        ApplicationUser? applicationUser = await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        if (applicationUser == null) 
        {
            return null;
        }
        else
        {
            return applicationUser;
        }
    }
}

