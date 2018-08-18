namespace SmartPos.Ui.Utils
{
    public static class FormBuilderEx
    {
        public static IFormBuilder<TControl> AddDrawer<TControl>(this IFormBuilder<TControl> builder) 
            where TControl : BaseControl
        {
            builder.Configure(control => control.ParentForm.Drawer = true);
            return builder;
        }
    }
}
