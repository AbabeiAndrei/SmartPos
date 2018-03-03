namespace SmartPos.GeneralLibrary.Extensions
{
    public static class StringEx
    {
        public static string RemoveLast(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.Length != 1
                       ? str.Substring(0, str.Length - 1)
                       : string.Empty;
        }
    }
}
