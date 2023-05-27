using iTextSharp.text.pdf;
using System;

namespace StudentEVL
{
    internal class PdfPTable
    {
        private int count;

        public PdfPTable(int count)
        {
            this.count = count;
        }

        public object DefaultCell { get; internal set; }
        public int HorizontalAlignment { get; internal set; }
        public int WidthPercentage { get; internal set; }

        internal void AddCell(PdfPCell cell)
        {
            throw new NotImplementedException();
        }

        internal void AddCell(string v)
        {
            throw new NotImplementedException();
        }
    }
}