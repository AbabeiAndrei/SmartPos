using PdfSharp;
using PdfSharp.Pdf;

using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace SmartPos.GeneralLibrary.Writers
{
    public class PdfWriter : IWriter
    {
        #region Fields

        private readonly string _path;
        private PdfDocument _pdf;

        #endregion

        #region Constructors

        public PdfWriter(string path)
        {
            _path = path;
        }

        #endregion

        #region Implementation of IWriter

        /// <inheritdoc />
        public void Write(string text)
        {
            _pdf = PdfGenerator.GeneratePdf(text, PageSize.A4);
        }

        /// <inheritdoc />
        public void Save()
        {
            _pdf.Save(_path);
        }

        #endregion
    }
}
