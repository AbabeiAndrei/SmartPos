namespace SmartPos.Ui
{
    public interface IFormSender
    {
        object Result { get; }
        BaseForm Form { get; }
        BaseControl Control { get; }
    }

    public class FormSender : IFormSender
    {
        public object Result { get; }
        public BaseForm Form { get; }
        public BaseControl Control { get; }

        public FormSender(BaseControl sender, object result, BaseForm form)
        {
            Control = sender;
            Result = result;
            Form = form;
        }
    }
}