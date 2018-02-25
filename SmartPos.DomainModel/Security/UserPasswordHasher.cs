using SmartPos.DomainModel.Entities;
using SmartPos.DomainModel.Security.Crypto;

namespace SmartPos.DomainModel.Security
{
    public class UserPasswordHasher : IPasswordHasher<User>
    {
        public string Hash(string password, User salt)
        {
            return Hasher.CreateMd5(password + salt.CreatedAt.Ticks);
        }
    }
}
