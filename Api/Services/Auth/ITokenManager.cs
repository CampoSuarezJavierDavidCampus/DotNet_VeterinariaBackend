
using Core.Entities;
using Core.Models.Dtos;

namespace Domain.Interfaces.Auth;
public interface ITokenManager{
    string CreateAccessToken(User user);
    string CreateRefreshToken();
    User CreateUser(UserSignup model);
    bool ValidatePassword(User user, string password);
}
