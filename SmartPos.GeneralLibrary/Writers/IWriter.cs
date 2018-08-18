namespace SmartPos.GeneralLibrary.Writers
{
    public interface IWriter
    {
        void Write(string text);
        void Save();
    }
}