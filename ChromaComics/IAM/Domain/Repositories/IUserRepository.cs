using ChromaComics.IAM.Domain.Model.Aggregates;
using ChromaComics.Shared.Domain.Repositories;

namespace ChromaComics.IAM.Domain.Repositories;

/**
 * <summary>
 *     The user repository
 * </summary>
 * <remarks>
 *     This repository is used to manage users
 * </remarks>
 */
public interface IUserRepository : IBaseRepository<User>
{
    /**
     * <summary>
     *     Find a user by id
     * </summary>
     * <param name="username">The username to search</param>
     * <returns>The user</returns>
     */
    Task<User?> FindByUsernameAsync(string username);

    /**
     * <summary>
     *     Check if a user exists by username
     * </summary>
     * <param name="username">The username to search</param>
     * <returns>True if the user exists, false otherwise</returns>
     */
    bool ExistsByUsername(string username);
}