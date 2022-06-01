using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using wpfEFac.Helpers;

namespace wpfEFac.Models
{
    public class ConnectorImportCsv : ConnectorTypes
    {
        int idCliente = 0;
        string strFormaPago;
        string strMetodoPago;
        string RegimenFiscalReceptor;
        string dataInfoGlobal;
        List<ConceptoPreFactura> conceptosPrefactura = new List<ConceptoPreFactura>();

        

        
        decimal subTotal = 0;
        decimal descuento = 0;
        decimal iva = 0;
        decimal retIva = 0;
        decimal retIsr = 0;
        decimal retIeps = 0;
        decimal total = 0;
        
        int intIdProd = 0;
        

        public int getIdCliente(string[] words)
        {
            

            eFacDBEntities myEntidad = new eFacDBEntities();
            strRfcCliente = words[1].Replace("-", "").Replace(" ", "");
            Clientes myCliente = myEntidad.Clientes.FirstOrDefault(c => c.strRFC == strRfcCliente);
            idCliente = myCliente.intID;

            return idCliente;
        }


        public void getTotales(string[] words)
        {


            subTotal = decimal.Parse(words[0]);
            descuento = decimal.Parse(words[1]);
            iva = decimal.Parse(words[2]);
            total = decimal.Parse(words[3]);
            strFormaPago = words[4];
            strMetodoPago = words[5];   
            retIva = 0;
            retIsr = decimal.Parse(words[7]);
            retIeps = decimal.Parse(words[6]);
        }
        

      
        public int savePrefactura(string FacturaTXT)
        {
            CFDModels cfd = new CFDModels();
            eFacDBEntities mydb = new eFacDBEntities();
            CFD MyCFD = mydb.CFD.FirstOrDefault(f => f.intID == 1);
             String Serie = MyCFD.Folios.strSerie;
            int Folio = MyCFD.Folios.intFolioActual;

            int idReceptor = idCliente;

            Clientes myCliente = mydb.Clientes.FirstOrDefault(c => c.intID == idCliente);
            if (myCliente.chrRetencionIVA == "Si")
            {
                retIva = iva;
                total = subTotal;
            }

           
            
            DateTime fecha = DateTime.Now;
            

            cfd.SaveFactura(1,
                        1,
                        Serie,
                        Folio.ToString(),
                        fecha,
                        1,
                        idReceptor,
                        strFormaPago,//"PAGO EN UNA SOLA EXHIBICION",// 
                        strObservaciones,
                        subTotal,
                        descuento,
                        iva,
                        total,
                        strTicket,
                        "",
                        strRegimenFiscal,
                        strUsoCfdi,
                        1,
                        FacturaTXT,
                        conceptosPrefactura,
                        retIva,
                        retIsr,
                        retIeps,
                        "",
                         strMetodoPago,
                        "",
                        "MXN",
                        decimal.Parse("1.00"),
                        "",
                        "",
                        dataInfoGlobal,
                        "",
                        "", 
                        "",
                        ""
                        ,null

                        );

            return 0;
        }

        public int importCsv(String strFilePath, String type)
        {
            
            int n = 1;

            try
            {
                StreamReader re = File.OpenText(strFilePath);
                string input = null;

                conSave = new ConnectorSave();
                
                while ((input = re.ReadLine()) != null)
                {
                    string[] words = input.Split('|');
                    if (words.Length > 1)
                    {
                        if (type == "Producto")
                        {
                            if (n > 3)
                            {
                                if (!ValuesParameters.rfcCliente.Equals("XAXX010101000"))
                                {
                                    importProducto(words);
                                    addConceptos(words);
                                }
                              
                            }

                        }
                        if (type == "Cliente")
                        {
                            if (n == 2) break;
                            {
                                importCliente(words);
                                getIdCliente(words);
                            }
                        }


                        if (type == "Datos")
                        {
                            if (n == 2)
                            {
                                importData(words);
                                
                            }
                            if (n == 3) {
                                break;
                            }
                        }



                        if (type == "Totales")
                        {
                            if (n > 2) 
                            {
                                getTotales(words);
                                
                                break;
                            }
                        }
                        n++;
                    }
                }
                re.Close();


                
            }
            catch (IOException e)
            {

            }


            return n;
        }

        private void importProducto(string[] words)
        {
            
            intIdCategoriaProducto = 1;
            strNombreProducto = words[5];
            strCodigoSat = words[4];
            strCodigoProducto = words[3];
            dcmPrecioProducto = words[6];
            dcmActos_IVAProducto = words[5];
            dcmDescuentoProducto = words[6];
            intUnidadProducto = 1;
            strDescripcionProducto = words[5];


            /*iva*/
            var dcmPorIva = (decimal.Parse(words[8]) - decimal.Parse("1.0")).ToString();
            var dcmIva = decimal.Parse(words[6]) * decimal.Parse(dcmPorIva);

            /*ieps*/
            var dcmIporIeps = decimal.Parse(words[10]);
            var dcmIeps = decimal.Parse(words[6]) * dcmIporIeps;
            

            /*isr*/
            var dcmporIsr = decimal.Parse(words[11]);
            var dcmIrs = decimal.Parse(words[6]) * dcmporIsr;
            

            BusClientes myCliente = new BusClientes();
            eFacDBEntities myEntidad = new eFacDBEntities();

            Productos myProd = myEntidad.Productos.FirstOrDefault(p => p.strCodigo == strCodigoProducto);

            try
            {
                intIdProd = myProd.intID;
            }
            catch(Exception ex) { }

            if (myProd == null)
            {
                myCliente.AgregarProducto(/*ID,*/

                     strCodigoProducto,
                     strCodigoSat,
                     strNombreProducto,
                     strNombreProducto,
                     strNombreProducto,
                     Decimal.Parse(dcmDescuentoProducto),

                     Decimal.Parse(dcmPrecioProducto),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),

                     1,
                     1,

                     "S",
                     Decimal.Parse(dcmPorIva),

                     "N",
                     Decimal.Parse("0.0"),

                     "N",
                     dcmporIsr,//Decimal.Parse("0.0"),


                    "N",
                    dcmIporIeps,

                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     1);
            }
            else
            {
                myCliente.EditarProducto(/*ID,*/

                     strCodigoProducto,
                     strCodigoSat,
                     strNombreProducto,
                     strNombreProducto,
                     strNombreProducto,
                     Decimal.Parse("0.0"),

                     Decimal.Parse(dcmPrecioProducto),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),

                     1,
                     1,

                     "S",
                     Decimal.Parse(dcmPorIva),

                     "N",
                     Decimal.Parse("0.0"),

                     "N",
                     dcmporIsr,//Decimal.Parse("0.0"),


                    "N",
                    dcmIporIeps,

                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0"),
                     Decimal.Parse("0.0")
                     );

            }
                 
        }


        private void addConceptos(string[] words)
        {
            

                ConceptoPreFactura conceptoPrefactura =
                                new ConceptoPreFactura();
            
            eFacDBEntities myEntidad = new eFacDBEntities();
            strCodigoProducto = words[3];

            Productos myProd = myEntidad.Productos.FirstOrDefault(p => p.strCodigo == strCodigoProducto);
           // strNombreProducto = words[3];

            dcmPrecioProducto = words[4];
            dcmActos_IVAProducto = (decimal.Parse(words[8]) - decimal.Parse("1.0")).ToString();

            

            //intUnidadProducto = 1;
            //strDescripcionProducto = words[3];

            //if (myProd != null)
           // {
                conceptoPrefactura.intIdProducto = myProd.intID;
                conceptoPrefactura.intCantidad = decimal.Parse(words[0]);
                conceptoPrefactura.dcmDescuento = decimal.Parse("0.00");//decimal.Parse(dcmPrecioProducto.ToString()) * decimal.Parse(words[6]) / 100;
                conceptoPrefactura.dcmImporte = (decimal.Parse(words[0]) * decimal.Parse(words[6]));
                conceptoPrefactura.strUnidad = words[1] + "-" + words[2];
                conceptoPrefactura.strConcepto = words[5];
                conceptoPrefactura.dcmPrecioUnitario = (decimal.Parse(words[6]));
                conceptoPrefactura.dcmIVA = decimal.Parse(dcmActos_IVAProducto);
                conceptoPrefactura.dcmRetIVA = decimal.Parse("0.0");
                conceptoPrefactura.dcmRetISR = decimal.Parse(words[11]);
                conceptoPrefactura.dcmRetIEPS = decimal.Parse(words[10]);

                conceptoPrefactura.strPartida = string.Empty;

            //}

            /*
                


            
                conceptoPrefactura.intIdProducto = 1;
                conceptoPrefactura.intCantidad = decimal.Parse(words[0]);
                conceptoPrefactura.dcmDescuento = decimal.Parse("0.0");
                conceptoPrefactura.dcmImporte = decimal.Parse(words[4]);
                conceptoPrefactura.strUnidad = words[1];
                conceptoPrefactura.strConcepto = words[3];
                conceptoPrefactura.dcmPrecioUnitario = decimal.Parse(words[4]);
                conceptoPrefactura.dcmIVA = decimal.Parse("0.16");
                conceptoPrefactura.dcmRetIVA = decimal.Parse("0.0");
                conceptoPrefactura.dcmRetISR = decimal.Parse("0.0");
                conceptoPrefactura.dcmRetIEPS = decimal.Parse("0.0");

                conceptoPrefactura.strPartida = string.Empty;
            *
             */

                conceptosPrefactura.Add(conceptoPrefactura);
            
        }

        private void importCliente(string[] words)
        {

            try
            {

                strIdCliente = "";
                strRfcCliente = words[1].Replace("-", "").Replace(" ", "");
                strRazonSocialCliente = words[0];
                strNombreComercialCliente = words[0];
               // strGiroCliente = words[10];
                strTipoInscripcionCliente = "";
                strMobilCliente = "";
                strEmailCliente = words[7];
                strRetieneIvaCliente = "";
                strContactoCliente = words[8];
                strWebsiteCliente = words[9];
                strTelefonoCliente = words[11];

                ValuesParameters.rfcCliente = strRfcCliente;

                string strDireccionCliente = words[2];
                string strColoniaCliente = words[3];
                string strCiudad = words[4];
                string strEstado = words[5];
                string strCp = words[6];
                string strEmail = words[7];
                RegimenFiscalReceptor = words[8];
                strTicket = words[9];
              //  string strCondPago = words[10];
             //   strMetodoPago = words[11];





                eFacDBEntities myEntidad = new eFacDBEntities();
                BusClientes myBusCliente = new BusClientes();
                Clientes myCliente = myEntidad.Clientes.FirstOrDefault(p => p.strRFC == strRfcCliente);

                Estado myEstado = myEntidad.Estado.FirstOrDefault(e => e.strNombreEstado == strEstado);
                int IdEdo = 30;

                if (myEstado != null)
                    IdEdo = myEstado.intID;


                if (myCliente == null)
                {


                    myBusCliente.AgregarCliente(
                        strRfcCliente,
                        strRazonSocialCliente,
                        strRazonSocialCliente,
                    "",
                    "1",
                    RegimenFiscalReceptor,
                    "272-()",
                    strEmail,
                    "S",
                    "N",
                   "",// strFormaPago,
                    "",
                    strDireccionCliente,
                    "",
                    "",
                    strColoniaCliente,
                    1,
                    IdEdo,
                    strCiudad,
                    "",
                    strCp,
                    1,
                    0);
                }
                else
                {


                    myBusCliente.EditarCliente(
                        
                        myCliente.intID,
                        strRfcCliente,
                        strRazonSocialCliente,
                        strRazonSocialCliente,
                "",
                myCliente.strTipodeInscripcion,
                strDireccionCliente,
                "",
                "",
                strColoniaCliente,
                1,
                IdEdo,
                strCiudad,
                "",
                strCp,
                RegimenFiscalReceptor,
                "272-()",
                strEmail,
                 "",
                 "S",
                 "N",
                 "",
                 0
                 );

                }
            }
            catch (Exception ex) {

                strIdCliente = "";
                strRfcCliente = words[1].Replace("-", "").Replace(" ", "");
                strRazonSocialCliente = words[0];
                strNombreComercialCliente = words[0];
               // strGiroCliente = words[10];
                strTipoInscripcionCliente = "";
                strMobilCliente = "";
                strEmailCliente = words[7];
                strRetieneIvaCliente = "";
                RegimenFiscalReceptor = words[8];
                strTicket = words[9];
                //strTelefonoCliente = words[11];

                ValuesParameters.rfcCliente = strRfcCliente;

                string strDireccionCliente = words[2];
                string strColoniaCliente = words[3];
                string strCiudad = words[4];
                string strEstado = words[5];
                string strCp = words[6];
                string strEmail = words[7];
                string strContacto = words[8];
              
                
              




                eFacDBEntities myEntidad = new eFacDBEntities();
                BusClientes myBusCliente = new BusClientes();
                Clientes myCliente = myEntidad.Clientes.FirstOrDefault(p => p.strRFC == strRfcCliente);

                Estado myEstado = myEntidad.Estado.FirstOrDefault(e => e.strNombreEstado == strEstado);
                int IdEdo = 30;

                if (myEstado != null)
                    IdEdo = myEstado.intID;


                if (myCliente == null)
                {


                    myBusCliente.AgregarCliente(
                        strRfcCliente,
                        strRazonSocialCliente,
                        strRazonSocialCliente,
                    "CONTADO",
                    "1",
                    RegimenFiscalReceptor,
                    "272-()",
                    strEmail,
                    "S",
                    "N",
                    "",
                    "",
                    strDireccionCliente,
                    "",
                    "",
                    strColoniaCliente,
                    1,
                    IdEdo,
                    strCiudad,
                    "",
                    strCp,
                    1,
                    0);
                }
                else
                {


                    myBusCliente.EditarCliente(myCliente.intID,
                        strRfcCliente,
                        strRazonSocialCliente,
                        strRazonSocialCliente,
                "CONTADO",
                myCliente.strTipodeInscripcion,
                strDireccionCliente,
                "",
                "",
                strColoniaCliente,
                1,
                IdEdo,
                strCiudad,
                "",
                strCp,
                RegimenFiscalReceptor,
                "272-()",
                strEmail,
                 "",
                 "N",
                 "N",
                 "",
                 0
                 );

                }
            
            
            
            
            
            }
        }

        private void importData(string[] words)
        {


            try
            {
                strRegimenFiscal = words[0];
                strTipoComprobante = "I";
                strUsoCfdi = words[1];
                strObservaciones = words[2];
                dataInfoGlobal = words[3];
            }
            catch (Exception e) { }
            
            
  
        }


        public void addListProduct(string[] words)
        {


            var iva  = (decimal.Parse(words[8]) - decimal.Parse("1.0")).ToString();


            ConceptoPreFactura concepto =
                            new ConceptoPreFactura();

            concepto.intIdProducto = int.Parse(words[3]); //myProd.intID;
            concepto.intCantidad = decimal.Parse(words[0]);
            concepto.dcmDescuento = decimal.Parse("0.00");//decimal.Parse(dcmPrecioProducto.ToString()) * decimal.Parse(words[6]) / 100;
            concepto.dcmImporte = (decimal.Parse(words[0]) * decimal.Parse(words[6]));
            concepto.strUnidad = words[1] + "-" + words[2];
            concepto.strConcepto = words[5];
            concepto.dcmPrecioUnitario = (decimal.Parse(words[6]));
            concepto.dcmIVA = decimal.Parse(iva);
            concepto.dcmRetIVA = decimal.Parse("0.0");
            concepto.dcmRetISR = decimal.Parse("0.0");
            concepto.dcmRetIEPS = decimal.Parse(words[10]);
            concepto.strPartida = string.Empty;

            dataConcepts.conceptosPrefactura.Add(concepto);
            

        }

     

    }
   


    
}
