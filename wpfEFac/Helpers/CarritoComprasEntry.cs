using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpfEFac.Helpers
{
    public class CarritoComprasEntry
    {
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal IVA { get; set; }
        public decimal retIVA { get; set; }
        public decimal retISR { get; set; }
        public decimal retIEPS { get; set; }

        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }
        public string Divisa { get; set; }
        public string FormatPrecioUnitario { get; set; }
        
        public string FormatDescuento { get; set; }
        public string FormatImporte { get; set; }
        public int intID { get; set; }
    }
}
