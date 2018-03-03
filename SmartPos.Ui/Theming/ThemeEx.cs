using System;

namespace SmartPos.Ui.Theming
{
    public static class ThemeEx
    {
        public static T GetValue<T>(this ITheme theme, string data)
        {
            if (theme == null)
                throw new ArgumentNullException(nameof(theme));

            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            var type = theme.GetType();

            var property = type.GetProperty(data);

            if (property == null)
                throw new ArgumentException("Data not found in theme", nameof(data));

            var value = property.GetValue(theme);

            if (!(value is T))
                throw new Exception("Wrong tye refered");

            return (T)value;
        }

        public static IFormBuilder<TControl> ApplyTheme<TControl>(this IFormBuilder<TControl> builder, ITheme theme) 
            where TControl : BaseControl
        {
            builder.Configure(bf => bf.ParentForm.ApplyTheme(theme));
            return builder;
        }

        public static IFormBuilder<TForm, TControl> ApplyTheme<TForm, TControl>(this IFormBuilder<TForm, TControl> builder, ITheme theme)
            where TForm : BaseForm
            where TControl : BaseControl
        {
            builder.ConfigureForm(form => form.ApplyTheme(theme));
            return builder;
        }
    }
}
