namespace SmartPos.DomainModel.Security
{
    public interface IPasswordHasher<in T>
    {
        string Hash(string password, T salt);
    }
}
