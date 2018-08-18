using SmartPos.Desktop.Properties;

namespace SmartPos.Desktop.Data
{
    internal class FinancialHandler
    {
        public static int GenerateInvoiceNumber()
        {
            var number = Settings.Default.LastInvoiceNumber;

            Settings.Default.LastInvoiceNumber++;

            Settings.Default.Save();

            return number;
        }
    }
}
