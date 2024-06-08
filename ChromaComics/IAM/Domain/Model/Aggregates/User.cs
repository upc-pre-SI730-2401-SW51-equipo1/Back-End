using System.Text.Json.Serialization;

namespace ChromaComics.IAM.Domain.Model.Aggregates;

/**
 * <summary>
 *     The user aggregate
 * </summary>
 * <remarks>
 *     This class is used to represent a user
 * </remarks>
 */
public class User(string username, string passwordHash, string cellphoneNumber)
{
    public User() : this(string.Empty, string.Empty, string.Empty)
    {
    }

    public int Id { get; }
    public string Username { get; private set; } = username;
    public string CellphoneNumber { get; private set; } = cellphoneNumber;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }

    public User UpdateCellphoneNumber(string cellphoneNumber)
    {
        CellphoneNumber = cellphoneNumber;
        return this;
    }
}