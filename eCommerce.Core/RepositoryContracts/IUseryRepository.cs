using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;
public interface IUseryRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByUserID(Guid? guid);
}

