namespace SmartPos.Ui.Components
{
    public interface ILoadingToken
    {
        bool Loading { get; set; }
        int TimeOut { get; set; }
    }
}
