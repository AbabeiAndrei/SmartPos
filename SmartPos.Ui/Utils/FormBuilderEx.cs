namespace SmartPos.Ui.Utils
{
    public static class FormBuilderEx
    {
        public static IFormBuilder<TControl> SetTitleBar<TControl>(this IFormBuilder<TControl> builder,
                                                                   bool showTitle, bool showClose) 
            where TControl : BaseControl
        {
            builder.Configure(control => control.ParentForm.ShowTitle = showTitle);
            builder.Configure(control => control.ParentForm.ShowClose = showClose);
            return builder;
        }
    }
}
