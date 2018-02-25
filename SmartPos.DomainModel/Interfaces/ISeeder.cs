namespace SmartPos.DomainModel.Interfaces
{
    public interface ISeeder
    {
        bool NeedSeed { get; }
        void Seed();
    }
}