using SmartPos.Ui;

namespace SmartPos.Utils
{
    public interface IFormResult
    {
        object Result { get; }
        BaseForm Form { get; }
    }

    public class FormResult : IFormResult
    {
        public object Result { get; }
        public BaseForm Form { get; }

        public FormResult(object result, BaseForm form)
        {
            Result = result;
            Form = form;
        }
    }
}