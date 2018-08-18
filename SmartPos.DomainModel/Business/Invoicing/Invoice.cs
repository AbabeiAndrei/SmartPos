using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using SmartPos.GeneralLibrary.Writers;

namespace SmartPos.DomainModel.Business.Invoicing
{
    public class Invoice
    {
        public int Number { get; set; }
        public IInvoiceCustomer Customer { get; set; }
        public IEnumerable<string> Header { get; set; }
        public IDictionary<string, IEnumerable<object>> Items { get; set; }
        public decimal Total { get; set; }

        public void Print(IWriter writer)
        {
            writer.Write(ToString());
            writer.Save();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("<html><head>");
            sb.Append("<style>table {border-collapse: collapse;}table, th, td {border: 1px solid black;}</style>");
            sb.Append("</head><body>");
            sb.Append("<h1>FACTURA</h1>");
            sb.Append("<h2>SmartPos - InBar</h2>");
            sb.Append($"<p>Numar factura : <b>{Number:D6}</b></p>");
            sb.Append($"<p>Data emiterii : <b>{DateTime.Now:D}</b></p>");
            sb.Append("</br>");
            sb.Append("</br>");
            sb.Append("</br>");

            sb.Append($"<p>Client : <b>{Customer.Name}</b></p>");
            sb.Append($"<p>Adresa : {Customer.Address}</p>");
            
            sb.Append("</br>");
            sb.Append("<table><tr>");
            foreach (var header in Header)
                sb.Append($"<th>{header}</th>");

            sb.Append("</tr>");

            var columns = Items.Values.ToList();
            var count = columns[0].Count();

            for(var i = 0 ; i < count ; i++)
            {
                sb.Append("<tr>");
                foreach (var column in columns)
                    sb.Append($"<td>{column.ElementAt(i)}</td>");

                sb.Append("</tr>");
            }

            sb.Append("</table>");
            sb.Append($"<h4>Total : <b>{Total:N} LEI</b></h4>");
                
            sb.Append("</body></html>");
            return sb.ToString();
        }
    }
}