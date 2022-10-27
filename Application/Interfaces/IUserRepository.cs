using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    public User CreateNewUser(User user);

    public User getUserByEmail(string email);

}