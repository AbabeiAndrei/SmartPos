namespace SmartPos.GeneralLibrary.Extensions
{
    public static class StringEx
    {
        public static string RemoveLast(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            if (str.Length == 1)
                return string.Empty;

            return str.Substring(0, str.Length - 1);
        }
    }
}
