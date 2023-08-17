using ClinicaSanFelipeAPI.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSanFelipeAPI.Application.Productos
{
    public class ExportPDF
    {
        public class Consulta:IRequest<Stream>
        {

        }

        public class Manejador : IRequestHandler<Consulta, Stream>
        {
            private readonly ClinicaSFDbContext _context;

            public Manejador(ClinicaSFDbContext context)
            {
                _context = context;
            }
            public async Task<Stream> Handle(Consulta request, CancellationToken cancellationToken)
            {
                Font fuenteTitulo = new Font(Font.HELVETICA,8f,Font.BOLD,BaseColor.Blue);
                Font fuenteHeader = new Font(Font.HELVETICA, 7f, Font.BOLD, BaseColor.Black);
                Font fuenteData = new Font(Font.HELVETICA, 7f, Font.NORMAL, BaseColor.Black);

                var productos = await _context.Productos.ToListAsync();

                MemoryStream workStream = new MemoryStream();
                Rectangle rect = new Rectangle(PageSize.A4);

                Document document = new Document(rect, 0,0,50,100);

                PdfWriter writer = PdfWriter.GetInstance(document, workStream);

                writer.CloseStream = false;

                document.Open();
                document.AddTitle("Lista de productos de la Clinica SF");

                PdfPTable tabla = new PdfPTable(1);
                tabla.WidthPercentage = 90;
                PdfPCell celda = new PdfPCell(new Phrase("Lista de Productos Farmacia",fuenteTitulo));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);
                document.Add(tabla);

                PdfPTable tablaProductos = new PdfPTable(3);
                float[] widths = new float[]{40,60,60};
                tablaProductos.SetWidthPercentage(widths,rect);

                PdfPCell celdaHeaderDescripcion = new PdfPCell(new Phrase("Descripcion", fuenteHeader));
                tablaProductos.AddCell(celdaHeaderDescripcion);

                PdfPCell celdaHeaderPrecioVenta = new PdfPCell(new Phrase("Precio Venta", fuenteHeader));
                tablaProductos.AddCell(celdaHeaderPrecioVenta);

                PdfPCell celdaHeaderFechaLote = new PdfPCell(new Phrase("Fecha Lote", fuenteHeader));
                tablaProductos.AddCell(celdaHeaderFechaLote);

                tablaProductos.WidthPercentage = 90;

                foreach (var productoElemento in productos)
                {
                    PdfPCell celdaTablaDescripcion =
                        new PdfPCell(new Phrase(productoElemento.DescripcionProducto, fuenteData));
                    tablaProductos.AddCell(celdaTablaDescripcion);

                    PdfPCell celdaTablaPrecioVenta =
                        new PdfPCell(new Phrase(productoElemento.PrecioVenta.ToString("##,###.00"), fuenteData));
                    tablaProductos.AddCell(celdaTablaPrecioVenta);

                    PdfPCell celdaTablaFechaLote =
                        new PdfPCell(new Phrase(productoElemento.FechaLote.ToString("dd/MM/yyyy"), fuenteData));
                    tablaProductos.AddCell(celdaTablaFechaLote);
                }

                document.Add(tablaProductos);

                document.Close();

                byte[] byteData = workStream.ToArray();

                workStream.Write(byteData,0,byteData.Length);
                workStream.Position = 0;

                return workStream;
            }
        }
    }
}
