using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using wpfEFac.Models;
using wpfEFac.Views.PuntoVenta;
using System.Transactions;
using wpfEFac.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using GenCode128;
using System.Net.Mail;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.Xml;
using System.Collections;
using Newtonsoft.Json;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace wpfEFac.Views
{
    /// <summary>
    /// Interaction logic for DefaultPuntoVenta.xaml
    /// </summary>
    public partial class DefaultPuntoVenta : Page
    {
        private DataGridColumn currentSortColumn;
        private PreFacturaViewModel pfvm;

        private ListSortDirection currentSortDirection;

        decimal sumaRetIva = 0;
        decimal sumaRetIsr = 0;
        decimal sumaImpLocal = 0;
        decimal totalRet = 0;
    

        //private PageC

        public DefaultPuntoVenta()
        {
            InitializeComponent();

            DataContext = new PuntoVentaViewModel();

            pfvm = new PreFacturaViewModel();
            radMes.IsChecked = true;
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
            cmbAaa.SelectedIndex = DateTime.Now.Year - 1;
            txtAaaa.Text = DateTime.Now.Year.ToString();
            buscar();

           
        }





    


        private void buscar()
        {
            eFacDBEntities db = new eFacDBEntities();
            List<Factura> fact = db.Factura.Where(f => f.chrStatus != "E").OrderByDescending(d => d.dtmFecha).ToList();

            ICollectionView facturas = CollectionViewSource.GetDefaultView(fact);
            dtgFacturasHistorico.ItemsSource = facturas;
            facturas.Filter = TextFilter;



           

        }

        private void dtpInicio_Loaded(object sender, RoutedEventArgs e)
        {
            eFacDBEntities db = new eFacDBEntities();
            List<Factura> fact = db.Factura.OrderByDescending(p => p.dtmFecha).ToList();

            ICollectionView facturas = CollectionViewSource.GetDefaultView(fact);
            dtgFacturasHistorico.ItemsSource = facturas;
            facturas.Filter = TextFilter;
        }

        private void bttBuscar_Click(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        public bool TextFilter(object o)
        {
            bool retValue = false;

            Factura p = (o as Factura);



            if (p == null)
                retValue = false;

            if (radTodos.IsChecked == true)
            {
                if (radFecha.IsChecked == true)
                {
                    if ((radTodos.IsChecked == true) && p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper()))
                        retValue = true;
                }

                if (radMes.IsChecked == true)
                {
                    if ((radTodos.IsChecked == true) && (p.dtmFecha.Month == cmbMes.SelectedIndex + 1 && p.dtmFecha.Year.ToString() == txtAaaa.Text && p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                        retValue = true;
                }


                if (radAno.IsChecked == true)
                {
                    if ((radTodos.IsChecked == true) && (p.dtmFecha.Year == cmbAaa.SelectedIndex + 1 && p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                        retValue = true;
                }

            }
            else
            {

                if (radFecha.IsChecked == true)
                {


                    if (radFacturas.IsChecked == true)
                    {
                        if ((p.intID_Tipo_CFD == 1) && (p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                            retValue = true;
                        else
                            retValue = false;
                    }


                    if (radCotizaciones.IsChecked == true)
                    {
                        if ((p.intID_Tipo_CFD == 2) && (p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                            retValue = true;
                        else
                            retValue = false;
                    }

                    if (radRemisiones.IsChecked == true)
                    {
                        if ((p.intID_Tipo_CFD == 3) && (p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                            retValue = true;
                        else
                            retValue = false;
                    }
                }
                else
                {
                    if (radFacturas.IsChecked == true)
                    {
                        if ((p.intID_Tipo_CFD == 1) && (p.dtmFecha.Month == cmbMes.SelectedIndex + 1 && p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                            retValue = true;
                        else
                            retValue = false;
                    }


                    if (radCotizaciones.IsChecked == true)
                    {
                        if ((p.intID_Tipo_CFD == 2) && (p.dtmFecha.Month == cmbMes.SelectedIndex + 1 && p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                            retValue = true;
                        else
                            retValue = false;
                    }

                    if (radRemisiones.IsChecked == true)
                    {
                        if ((p.intID_Tipo_CFD == 3) && (p.dtmFecha.Month == cmbMes.SelectedIndex + 1 && p.strFolio.Contains(txtFolio.Text) && p.Clientes.strNombreComercial.ToUpper().Contains(txtCliente.Text.ToUpper())))
                            retValue = true;
                        else
                            retValue = false;
                    }

                }
            }

            return retValue;
        }

        //private void dtpFin_Loaded(object sender, RoutedEventArgs e)
        //{
        //    FieldInfo fiTextBox = dtpFin.GetType()
        //        .GetField("_textBox", BindingFlags.Instance | BindingFlags.NonPublic);

        //    if (fiTextBox != null)
        //    {
        //        DatePickerTextBox dateTextBox =
        //          (DatePickerTextBox)fiTextBox.GetValue(dtpFin);

        //        if (dateTextBox != null)
        //        {
        //            PropertyInfo piWatermark = dateTextBox.GetType()
        //              .GetProperty("Watermark", BindingFlags.Instance | BindingFlags.NonPublic);

        //            if (piWatermark != null)
        //            {
        //                piWatermark.SetValue(dateTextBox, "-", null);
        //            }
        //        }
        //    }
        //}

        private void dtgFacturasHistorico_Loaded(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void CheckCFDStatus(DataGrid dataGrid)
        {
            Factura f = (Factura)dataGrid.SelectedItem;
            DisableMenuItems();

            if (f!=null)
            {
                switch (f.chrStatus)
                {
                    case "P":
                        {
                            mniAprovar.IsEnabled = true;
                            mniImprimir.IsEnabled = true;

                            // test cancelar
                            mniCancelar.IsEnabled = true;
                            //
                        }
                        break;
                    case "A":
                        {
                            mniXML.IsEnabled =
                            mniPDF.IsEnabled =
                            mniImprimir.IsEnabled =
                            mniEmail.IsEnabled =
                            mniCancelar.IsEnabled = true;

                        } break;
                    case "E":
                        {
                            mniEmail.IsEnabled = true;
                        }
                        break;
                    case "C": 
                        {
                            mniImprimir.IsEnabled = 
                            mniXML.IsEnabled =
                            mniPDF.IsEnabled = true;
                        } 
                        break;
                    default:

                        break;
            }

            
            }
        }

        private void DisableMenuItems()
        {
            mniAprovar.IsEnabled = mniCancelar.IsEnabled = mniImprimir.IsEnabled = mniEmail.IsEnabled =
                mniPDF.IsEnabled = mniXML.IsEnabled = false;
        }

        private void dtgFacturasHistorico_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (currentSortColumn != null)
            {
                currentSortColumn.SortDirection = currentSortDirection;
            }
        }

        //private void dtgFacturasHistorico_Sorting(object sender, DataGridSortingEventArgs e)
        //{
        //    e.Handled = true;

        //    PuntoVentaViewModel mainViewModel = (PuntoVentaViewModel)DataContext;

        //    string sortField = String.Empty;

        //    // Use a switch statement to check the SortMemberPath
        //    // and set the sort column to the actual column name. In this case,
        //    // the SortMemberPath and column names match.
        //    switch (e.Column.SortMemberPath)
        //    {
        //        case ("intID"):
        //            sortField = "intID";
        //            break;

        //        case ("Clientes.strNombreComercial"):
        //            sortField = "Clientes.strNombreComercial";
        //            break;
        //        case ("strTipoDocumento"):
        //            sortField = "strTipoDocumento";
        //            break;
        //        case ("intID_Empresa"):
        //            sortField = "intID_Empresa";
        //            break;
        //        case ("strSerie"):
        //            sortField = "strSerie";
        //            break;
        //        case ("strFolio"):
        //            sortField = "strFolio";
        //            break;
        //        case ("dtmFecha"):
        //            sortField = "dtmFecha";
        //            break;
        //        case ("dtmFechaAprovacion"):
        //            sortField = "dtmFechaAprovacion";
        //            break;
        //        case ("intID_Cliente"):
        //            sortField = "intID_Cliente";
        //            break;
        //        case ("strID_Cliente"):
        //            sortField = "strID_Cliente";
        //            break;
        //        case ("strForma_Pago"):
        //            sortField = "strForma_Pago";
        //            break;
        //        case ("strObervaciones"):
        //            sortField = "strObervaciones";
        //            break;
        //        case ("dcmSubTotal"):
        //            sortField = "dcmSubTotal";
        //            break;
        //        case ("dcmIVA"):
        //            sortField = "dcmIVA";
        //            break;
        //        case ("dcmTotal"):
        //            sortField = "dcmTotal";
        //            break;
        //    }

        //    ListSortDirection direction = (e.Column.SortDirection != ListSortDirection.Ascending) ?
        //        ListSortDirection.Ascending : ListSortDirection.Descending;

        //    bool sortAscending = direction == ListSortDirection.Ascending;

        //    mainViewModel.Sort(sortField, sortAscending);

        //    currentSortColumn.SortDirection = null;

        //    e.Column.SortDirection = direction;

        //    currentSortColumn = e.Column;
        //    currentSortDirection = direction;
        //}

        private void hplNuevaFactura_Click(object sender, RoutedEventArgs e)
        {
            PreFactura newPreFactura = new PreFactura(1);

            this.NavigationService.Navigate(newPreFactura);
        }

        private void mniAprovar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgFacturasHistorico.SelectedItem != null) 
            {
                Factura f = (Factura) dtgFacturasHistorico.SelectedItem;
                if ((f.intID_Tipo_CFD == 1) || (f.intID_Tipo_CFD == 2) || (f.intID_Tipo_CFD == 3) || (f.intID_Tipo_CFD == 4) || (f.intID_Tipo_CFD == 5) || (f.intID_Tipo_CFD == 6))
                {
                    if (f.chrStatus == "P")
                    {
                        MessageBoxResult result = MessageBox.Show("Desea aprobar el comprobante", "Aprobar",
                            MessageBoxButton.OKCancel, MessageBoxImage.Information);

                        if (result == MessageBoxResult.OK)
                        {

                            MessageBoxResult resultSAT = MessageBox.Show("Esta acción enviará su Comprobante al SAT, esta seguro? ", "Aprobar",
                            MessageBoxButton.OKCancel, MessageBoxImage.Information);

                            if (resultSAT == MessageBoxResult.OK)
                            {

                                eFacDBEntities db = new eFacDBEntities();

                                db.Connection.Open();

                                if ((f.intID_Tipo_CFD == 1) || (f.intID_Tipo_CFD == 2) || (f.intID_Tipo_CFD == 3) || (f.intID_Tipo_CFD == 4) || (f.intID_Tipo_CFD == 5))
                                {
                                    AprobarFactura(f, db, true);
                                }
                                if (f.intID_Tipo_CFD == 6)
                                {

                                    AprobarPago(f, db, true);
                                }

                                this.DataContext = null;

                                this.DataContext = new PuntoVentaViewModel();
                                dtgFacturasHistorico.ItemsSource = db.Factura.Where(mf => mf.chrStatus != "E").OrderByDescending(d => d.dtmFecha);

                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Solo se puede aprobar Comprobantes con valor Fiscal");
            }
        }

        private void AprobarFactura(Factura f, eFacDBEntities db, bool Aprobado)
        {
            try
            {
                string strUs = UserPac.user;
                string strValue = UserPac.passwd;
                string idEquipo = UserPac.idEquipo;





                //string strValue = string.Empty;
                //string strUs = string.Empty;

                //if (Aprobado)
                //{
                //    wsAdesoftSecurity.ServiceSecurityClient mySecurity = new wsAdesoftSecurity.ServiceSecurityClient();
                //    strValue = mySecurity.verifyUser(f.Empresa.strRFC, "adsoftsito", "Guebos1#", 1);
                //    strUs = string.Empty;
                //    if (strValue == string.Empty)
                //    {
                //        throw new Exception("Error de comunicacion con el Servidor, favor de contactar a su proveedor para verificar el estado de su cuenta.");
                //    }
                //    else
                //    {
                //        strUs = strValue.Split('|').ElementAt(0);
                //        strValue = strValue.Split('|').ElementAt(1);
                //    }
                //}

                Factura factura = db.Factura.Where(fac => fac.intID == f.intID).First();

                var direccionEmisor = pfvm.GetDireccionEmpresa(f.Empresa.intID);
                var direccionEmision = pfvm.GetDireccionEmpresaEmision(f.Empresa.intID);
                //var direccionEmisor = pfvm.GetDireccionCliente(f.Clientes1.intID);
                var direccionReceptor = pfvm.GetDireccionCliente(f.Clientes.intID);



                var conceptos = f.Detalle_Factura;

                //List<dlleFac.Concepto> c = new List<dlleFac.Concepto>();
                List<dlleFac.ComprobanteConcepto> myConceptos = new List<dlleFac.ComprobanteConcepto>();

                

                dlleFac.Comprobante myCFD20 = new dlleFac.Comprobante();
                FillCFD30(f, direccionEmisor,  direccionEmision,  direccionReceptor, myConceptos, myCFD20);


                
                dlleFac.Factura objFac;

                try
                {
                    //using (TransactionScope scope = new TransactionScope())
                   // {
                        dlleFac.MyFactE myf = new dlleFac.MyFactE();
                        objFac = null;

                        try
                        {
                            objFac = myf.createXML30(
                                f.intID_Tipo_CFD,
                           
                                f.Empresa.strRFC,
                                f.Certificates.strCertificadoSelloDigitalPath,
                                 f.Certificates.strLlaveCertificadoPath,
                                 f.Certificates.strContraseñaSAT,
                                 f.Empresa.strDirectorioXML,
                                 f.Empresa.strDirectorioPDF,
                                 myCFD20,                                 
                                 f.strObervaciones,
                                 f.strProveedor,
                                 f.strNumero,
                                 f.CFD.strDescripcion,
                                 Aprobado == true ? f.CFD.templateReportH : f.CFD.templateReportHdemo,
                                 Aprobado == true ? f.CFD.templateReport : f.CFD.templateReportDemo,
                                 Aprobado,
                                f.Origen,
                            f.RecogerEn,
                            f.Destino,
                            f.Destinatario,
                            f.rfcDestinatario,
                            f.domicilioDestinatario,
                            f.EntregarEn,
                            f.Clientes.idAddenda.Value > 0 ? true : false,
                            strUs,
                            strValue,
                            idEquipo
                                 );
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio el siguiente error: " + e.Message);
                        }


                        if (objFac != null)
                        {
                            string strQRCode = "";
                            Boolean valid = false;

                            if (objFac.UUID == "")
                            {

                                string strUUID = "00000000-0000-0000-0000-000000000000";


                                string strSello = "EbDUVW/pHFjejpFmvrYUnfk1OcSzVvYUBNHvKOmIAy2ZANnAkR5u5pCW1GYHhddbZZ2itKovWbBIeAVIDEjYg97OPQpwOk06MzFseKzK9eHG8rpLHDVoY/uh36C1R8ujRvPOfP9/KkOdX/PYx1L5OK7v4dy0X/F2wsh6AbLOwi0MyIsivZwTpGD+x6lYFFEU4EiGIZ8l+93XDPJNIHR76K53ip5MWL0HIZBi0Ocd0wLa2XqU5AGrkoeo4cdh4b4Snwr+mx/+jOo7MiZrguvZ3GN1tNHrw2QUzE7UzubnT5VjdGcZcobSCslDkLoYfNZllbHGRryIpnmCECr8sinvalor";

                                //Ejemplo:https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=5803EB8D-81CD-4557-8719-26632D2FA434&re=XOCD720319T86&rr=CARR861127SB0&tt=0000014300.000000&fe=rH8/bw==

                                 strQRCode = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + strUUID +//+ objFac.UUID +
                                                    "&re=" + myCFD20.Emisor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                                    "&rr=" + myCFD20.Receptor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                                    "&tt=" + myCFD20.Total.ToString("#0.000000").PadLeft(17, '0') +
                                                    "&fe=" + strSello.Substring(strSello.Length - 8, 8);
                                //"&fe=" + objFac.sello.Substring(objFac.sello.Length,-8);
                                 valid = false;

                            }
                            else {

                                 strQRCode = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + objFac.UUID +
                                                    "&re=" + myCFD20.Emisor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                                    "&rr=" + myCFD20.Receptor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                                    "&tt=" + myCFD20.Total.ToString("#0.000000").PadLeft(17, '0') +
                                                    "&fe=" + objFac.sello.Substring(objFac.sello.Length-8,8);
                                 valid = true;                           

                            
                            }




                            getQRCode(strQRCode, f.strFolio, f.strProveedor, valid);

                          
                            string myXMLPDF = myf.createPDF30(
                                f.intID_Tipo_CFD,
                                f.CFD.strDescripcion,
                                f.Empresa.strDirectorioXML,
                                f.Empresa.strDirectorioPDF,
                                f.Empresa.strRFC,
                                f.Clientes.strRFC,
                                Aprobado == true ? f.CFD.templateReportH : f.CFD.templateReportHdemo,
                                Aprobado == true ? f.CFD.templateReport : f.CFD.templateReportDemo,
                                Aprobado);
                            string[] words = myXMLPDF.Split('|');
                            string myXML = words[0];
                            string myPDF = words[1];


                            if (Aprobado)
                            {
                            
                                factura.chrStatus = "A";
                                factura.dtmFechaAprovacion = objFac.fechaAprobacion;
                                factura.strFolio = objFac.folio;
                                factura.strSerie = string.IsNullOrEmpty(objFac.serie) ? "": objFac.serie;
                                factura.strSelloDigital = objFac.UUID;
                                factura.Certificates.strNumeroCertificadoSelloDigital = objFac.noCertificado;
                                factura.strCadenaOriginal = objFac.cadenaOriginal;
                                factura.strXMLpath = myXML;
                                factura.strPDFpath = myPDF;
                                if (f.MetodoPago.Equals("PUE"))
                                {
                                    factura.strNumero = "PAGADA";
                                    factura.dtmFechaEnvio = objFac.fechaAprobacion;
                                }

                                

                                db.SaveChanges();

                                 sendMail(factura.strXMLpath, factura.strPDFpath, 
                                    f.Empresa.strNombreComercial,      
                                    f.strSerie,
                                    f.strFolio,
                                    f.Clientes.strEmail, f.Empresa.strEmail, f.Empresa.strEmail2,f.Empresa.strTelefono,f.Empresa.strTelefono2);

                                /**Guardar en BD Sia**/


                                 dlleFac.Comprobante myComprobante = DeserializeCFD32("c:\\myfacturae\\SIGN_adsoftOK.xml");

                                 XmlDocument xmlDoc = new XmlDocument();
                                 xmlDoc.Load("c:\\myfacturae\\SIGN_adsoftOK.xml");

                                 // Now create StringWriter object to get data from xml document.
                                 StringWriter sw = new StringWriter();
                                 XmlTextWriter xw = new XmlTextWriter(sw);
                                 xmlDoc.WriteTo(xw);
                                 String XmlString = sw.ToString();

                                 int value = 0;

                                 if (XmlString.Contains("<implocal:ImpuestosLocales"))
                                 {
                                     value = 1;
                                 }

                                        dlleFac.ComprobanteComplemento myComplemento = myComprobante.Complemento;
                                        XmlAttributeCollection myTFD = myComplemento.Any[value].Attributes;


                                        string myUUID = myTFD.GetNamedItem("UUID").Value; //myTFD[2].Value;
                                        string FechaTimbrado = myTFD.GetNamedItem("FechaTimbrado").Value;//myTFD[1].Value; //myTokenIzer[4];
                                        string SelloCFD = myTFD.GetNamedItem("SelloCFD").Value; //myTFD[4].Value;//myTokenIzer[7];
                                        string NoCertificadoSAT = myTFD.GetNamedItem("NoCertificadoSAT").Value;//myTFD[3].Value;// myTokenIzer[10];
                                        string SelloSAT = myTFD.GetNamedItem("SelloSAT").Value;//myTFD[5].Value;//myTokenIzer[13];
                                        string ImporteLetra = ConvertidorNumeroLetra.NumeroALetras(f.dcmTotal.ToString("F"), "PESOS");
                                        string urlQR  = "D:\\Sica© v6.4\\BDXML_Sica6.4\\qrcode\\cbb"+ f.strFolio + "_" + f.strProveedor + ".jpg";




                                        SaveDataDBSia(f.strProveedor, f.strFolio, FechaTimbrado, objFac.noCertificado, NoCertificadoSAT, myUUID, FechaTimbrado, ImporteLetra, objFac.cadenaOriginal, SelloCFD, SelloSAT, urlQR, f.dcmSubTotal,f.dcmIVA,f.dcmRetIEPS.Value,f.dcmTotal);


                                
                            }
                            else
                            {
                                factura.strPDFdemoPath = myPDF;
                                db.SaveChanges();
                                db.AcceptAllChanges();
                               
                            }


                            if (Aprobado)
                            {
                                MessageBox.Show("Se creo el archivo xml y PDF", objFac.filePath);
                                db.AcceptAllChanges();

                                pfvm.UpdateFolioActual(f.intID_Certificate, f.intID_Tipo_CFD);
                                //System.Windows.Application.Current.Shutdown();   // cerrar aplicacion


                            }
                        }
                        
                    
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                finally 
                {
                    db.Connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);   
            }
        }

        private void AprobarPago(Factura f, eFacDBEntities db, bool Aprobado)
        {
            try
            {

                string strUs = UserPac.user;
                string strValue = UserPac.passwd;
                string idEquipo = UserPac.idEquipo;



                Factura factura = db.Factura.Where(fac => fac.intID == f.intID).First();

                var direccionEmisor = pfvm.GetDireccionEmpresa(f.Empresa.intID);
                var direccionEmision = pfvm.GetDireccionEmpresaEmision(f.Empresa.intID);
                //var direccionEmisor = pfvm.GetDireccionCliente(f.Clientes1.intID);
                var direccionReceptor = pfvm.GetDireccionCliente(f.Clientes.intID);



                var conceptos = f.Detalle_Factura;

                //List<dlleFac.Concepto> c = new List<dlleFac.Concepto>();
                List<dlleFac.ComprobanteConcepto> myConceptos = new List<dlleFac.ComprobanteConcepto>();



                dlleFac.Comprobante myCFD20 = new dlleFac.Comprobante();


                FillCFDPago30(f, direccionEmisor, direccionEmision, direccionReceptor, myConceptos, myCFD20);



                dlleFac.Factura objFac;

                try
                {
                    //using (TransactionScope scope = new TransactionScope())
                    // {
                    dlleFac.MyFactE myf = new dlleFac.MyFactE();
                    objFac = null;

                    try
                    {
                        objFac = myf.createXML30(
                            f.intID_Tipo_CFD,
                            f.Empresa.strRFC,
                            f.Certificates.strCertificadoSelloDigitalPath,
                             f.Certificates.strLlaveCertificadoPath,
                             f.Certificates.strContraseñaSAT,
                             f.Empresa.strDirectorioXML,
                             f.Empresa.strDirectorioPDF,
                             myCFD20,
                             f.strObervaciones,
                             f.strProveedor,
                             f.strNumero,
                             f.CFD.strDescripcion,
                             Aprobado == true ? f.CFD.templateReport : f.CFD.templateReportHdemo,
                             Aprobado == true ? f.CFD.templateReport : f.CFD.templateReportDemo,
                             Aprobado,
                            f.Origen,
                        f.RecogerEn,
                        f.Destino,
                        f.Destinatario,
                        f.rfcDestinatario,
                        f.domicilioDestinatario,
                        f.EntregarEn,
                        false,
                        strUs,
                        strValue,
                        idEquipo

                             );
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocurrio el siguiente error: " + e.Message);
                    }


                    if (objFac != null)
                    {

                        string strQRCode = "";
                        Boolean valid = false;

                        if (objFac.UUID == "")
                        {

                            string strUUID = "00000000-0000-0000-0000-000000000000";


                            string strSello = "EbDUVW/pHFjejpFmvrYUnfk1OcSzVvYUBNHvKOmIAy2ZANnAkR5u5pCW1GYHhddbZZ2itKovWbBIeAVIDEjYg97OPQpwOk06MzFseKzK9eHG8rpLHDVoY/uh36C1R8ujRvPOfP9/KkOdX/PYx1L5OK7v4dy0X/F2wsh6AbLOwi0MyIsivZwTpGD+x6lYFFEU4EiGIZ8l+93XDPJNIHR76K53ip5MWL0HIZBi0Ocd0wLa2XqU5AGrkoeo4cdh4b4Snwr+mx/+jOo7MiZrguvZ3GN1tNHrw2QUzE7UzubnT5VjdGcZcobSCslDkLoYfNZllbHGRryIpnmCECr8sinvalor";

                            //Ejemplo:https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=5803EB8D-81CD-4557-8719-26632D2FA434&re=XOCD720319T86&rr=CARR861127SB0&tt=0000014300.000000&fe=rH8/bw==

                            strQRCode = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + strUUID +//+ objFac.UUID +
                                               "&re=" + myCFD20.Emisor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                               "&rr=" + myCFD20.Receptor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                               "&tt=" + myCFD20.Total.ToString("#0.000000").PadLeft(17, '0') +
                                               "&fe=" + strSello.Substring(strSello.Length - 8, 8);
                            //"&fe=" + objFac.sello.Substring(objFac.sello.Length,-8);

                            valid = false;
                        }
                        else
                        {

                            strQRCode = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + objFac.UUID +
                                               "&re=" + myCFD20.Emisor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                               "&rr=" + myCFD20.Receptor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                               "&tt=" + myCFD20.Total.ToString("#0.000000").PadLeft(17, '0') +
                                               "&fe=" + objFac.sello.Substring(objFac.sello.Length - 8, 8);

                            valid = true;


                        }





                        //getQRCode(strQRCode);
                        getQRCode(strQRCode, f.strFolio, f.strProveedor, valid);




                        string myXMLPDF = myf.createPDF30(
                            f.intID_Tipo_CFD,
                            f.CFD.strDescripcion,
                            f.Empresa.strDirectorioXML,
                            f.Empresa.strDirectorioPDF,
                            f.Empresa.strRFC,
                            f.Clientes.strRFC,
                            f.CFD.templateReportH,
                            f.CFD.templateReport,
                            Aprobado);

                        string[] words = myXMLPDF.Split('|');
                        string myXML = words[0];
                        string myPDF = words[1];

                        if (Aprobado)
                        {

                            factura.chrStatus = "A";
                            factura.dtmFechaAprovacion = objFac.fechaAprobacion;
                            factura.strFolio = objFac.folio;
                            factura.strSerie = objFac.serie;
                            factura.strSelloDigital = factura.strSelloDigital = objFac.UUID;
                            factura.Certificates.strNumeroCertificadoSelloDigital = objFac.noCertificado;
                            factura.strCadenaOriginal = objFac.cadenaOriginal;
                            factura.strXMLpath = myXML;// objFac.fileXMLpath;
                            factura.strPDFpath = myPDF;






                            db.SaveChanges();

                            sendMail(factura.strXMLpath, factura.strPDFpath,
                               f.Empresa.strNombreComercial,
                               f.strSerie,
                               f.strFolio,
                               f.Clientes.strEmail, f.Empresa.strEmail, f.Empresa.strEmail2, f.Empresa.strTelefono, f.Empresa.strTelefono2);
                            //      scope.Complete();
                        }
                        else
                        {
                            factura.strPDFdemoPath = myPDF;
                            db.SaveChanges();
                            db.AcceptAllChanges();
                        }



                        if (Aprobado)
                        {
                            MessageBox.Show("Se creo el archivo xml y PDF", objFac.filePath);
                            db.AcceptAllChanges();

                            pfvm.UpdateFolioActual(f.intID_Certificate, f.intID_Tipo_CFD);

                            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
                            txtAaaa.Text = DateTime.Now.Year.ToString();
                            buscar();

                        }
                    }


                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                finally
                {
                    db.Connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);   // Reforma Validador - update
            }
        }


          public dlleFac.Comprobante DeserializeCFD32(string xmlFile)
        {


            // Create an instance of the XmlSerializer specifying type and namespace.
            XmlSerializer serializer = new
            XmlSerializer(typeof(dlleFac.Comprobante));

            // A FileStream is needed to read the XML document.

            FileStream fs = new FileStream(xmlFile, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);

            // Declare an object variable of the type to be deserialized.
            dlleFac.Comprobante myComprobante = null;

            // Use the Deserialize method to restore the object's state.
            try
            {

                myComprobante = (dlleFac.Comprobante)serializer.Deserialize(reader);

            }
            catch (Exception e)
            {

            }
            fs.Close();
            reader.Close();

            return myComprobante;

        }


        private int sendMail(string xmlPath, string pdfPath, string empresa, string Serie, String Folio,
   string mailCliente, string mailRespaldo, string mailContador, string sendEmail, string passEmail)
        {

             System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
             System.Net.NetworkCredential cred = new System.Net.NetworkCredential(sendEmail, passEmail);

            //mail.To.Add("adesoft@live.com.mx");



            if (mailCliente != String.Empty) mail.CC.Add(mailCliente);
            if (mailContador != String.Empty) mail.CC.Add(mailContador);
            if (mailRespaldo != String.Empty) mail.CC.Add(mailRespaldo);


            /*
             * Attachments
             */

            mail.Attachments.Add(new Attachment(pdfPath));
            mail.Attachments.Add(new Attachment(xmlPath));

            string Asunto = empresa + " - CFDi ";
            
            if ((Serie != String.Empty) || (Folio != String.Empty))
                Asunto += Serie + Folio;

            mail.Subject = Asunto;

            mail.From = new System.Net.Mail.MailAddress(sendEmail);
            mail.IsBodyHtml = true;
            mail.Body = "Servicio proporcionado por ADESOFT " + "";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred;
            smtp.Port = 587;

            try
            {
                smtp.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }



            /*
            WPFEmailer mySendMail = new WPFEmailer();

            string Asunto = empresa + " - CFDi ";

            if ((Serie != String.Empty) || (Folio != String.Empty))
                Asunto += Serie + Folio;

            mySendMail.Host = "smtp.gmail.com";
            mySendMail.User = "adesoft.cfdi@gmail.com";
            mySendMail.Password = "superputote";
            mySendMail.UseSSL = false;
            mySendMail.Port = 587;
            mySendMail.Subject = Asunto;
            mySendMail.Body = "Servicio proporcionado por ADESOFT SA de CV" + " www.adesoft.com.mx";

            mySendMail.AttachmentPath1 = xmlPath;
            mySendMail.AttachmentPath2 = pdfPath;
            mySendMail.From = "ADESOFT CFDi - Comprobante Fiscal Digital por Internet";

            if (mailCliente != String.Empty) mySendMail.To = mailCliente; else mySendMail.To = String.Empty;
            if (mailContador != String.Empty) mySendMail.ccContador = mailContador; else mySendMail.ccContador = String.Empty;
            if (mailRespaldo != String.Empty) mySendMail.ccRespaldo = mailRespaldo; else mySendMail.ccRespaldo = string.Empty;


            mySendMail.ccAdesoft = "adesoft@live.com.mx";

            try
            {
                mySendMail.SendEmail();
                MessageBox.Show("Message send successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            */

            return 0;
        }


        /*
        private int sendMail(string xmlPath, string pdfPath, 
            string empresa, string Serie, String Folio,
            string mailCliente, string mailRespaldo, string mailContador)
        {
            WPFEmailer mySendMail = new WPFEmailer();

            string Asunto = empresa + " - CFDi ";

            if ((Serie != String.Empty) || (Folio != String.Empty))
                Asunto += Serie + Folio;

            mySendMail.Host = "mail.adesoft.com.mx";
            mySendMail.User = "adesoft@adesoft.com.mx";
            mySendMail.Password = "superputote";
            mySendMail.UseSSL = false;
            mySendMail.Port = 26;
            mySendMail.Subject = Asunto;
            mySendMail.Body = "Servicio proporcionado por ADESOFT SA de CV"  +  " www.adesoft.com.mx";

            mySendMail.AttachmentPath1 = xmlPath;
            mySendMail.AttachmentPath2 = pdfPath;
            mySendMail.From = "adesoft@adesoft.com.mx";

            if (mailCliente != String.Empty) mySendMail.To = mailCliente; else mySendMail.To = String.Empty;
            if (mailContador != String.Empty) mySendMail.ccContador = mailContador; else mySendMail.ccContador = String.Empty;
            if (mailRespaldo != String.Empty) mySendMail.ccRespaldo = mailRespaldo; else mySendMail.ccRespaldo = string.Empty;
            
            
            mySendMail.ccAdesoft = "adesoft@live.com.mx";

            try
            {
                mySendMail.SendEmail();
                MessageBox.Show("Message send successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
            
            
            return 0;
        }
        */

        private string getdv(string barCode)
        {
            int dv = 0, secuence = 0, dups = 0;
            char[] carray = new char[barCode.Length];
            carray = barCode.ToCharArray();
            secuence = 2;
            for (int i = barCode.Length - 1; i >= 0; i--)
            {

                dups = secuence * int.Parse(carray[i].ToString());
                if (dups > 10)
                {

                    char[] digits = new char[2];
                    digits = dups.ToString().ToCharArray();
                    dv += int.Parse(digits[0].ToString()) + int.Parse(digits[1].ToString());
                }
                else
                    dv += dups;
                if (secuence == 1)
                    secuence = 2;
                else
                    secuence--;
            }
            dv = dv % 10;
            if (!(dv == 0))
                dv = 10 - dv;
//            lblshowcode.Text = "Text to Encode: \n\t" + barCode + "\nand the dv is: " + dv;
            return dv.ToString();
        }


        private static void ExtraerImpuestos(List<dlleFac.Traslado> t, List<dlleFac.Retencion> ret, dlleFac.ComprobanteFiscalDigital cfd)
        {
            cfd.Impuestos = new dlleFac.Impuestos()
            {
                TotalTraslados = t.First().TotalImpuestosTraslados,
                Traslados = t,
                TotalRetenido = ret.First().TotalImpuestoRetenido,
                Retenciones = ret
            };

        }

        private static void LlenarReceptor(Factura f, Direcciones_Fiscales direccionReceptor, dlleFac.ComprobanteFiscalDigital cfd)
        {
            cfd.Receptor = new dlleFac.Receptor()
            {
                RFCReceptor = f.Clientes.strRFC,
                NombreReceptor = f.Clientes.strRazonSocial
            };

            cfd.DomicilioFiscalReceptor = new dlleFac.DomicilioFiscal()
            {
                Calle = direccionReceptor.strCalle,
                NumeroExterior = direccionReceptor.strNoExterior,
                Colonia = direccionReceptor.strColonia,
                Localidad = direccionReceptor.strPoblacionLocalidad,
                Referencia = null,
                Municipio = direccionReceptor.strMunicipio,
                Estado = direccionReceptor.Estado.strNombreEstado,
                Pais = direccionReceptor.Paises.strNombrePais,
                CodigoPostal = direccionReceptor.strCodigoPostal
            };
        }



        private string getQRCode(String strQrCode, string folioLocal,string FolioSia, Boolean valid)
        {
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

                String encoding = "Byte";
                int intSize = 4;
                int intVersion = 9;
                string strErrorCorrect = "M";

                if (encoding == "Byte")
                {
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                }
                else if (encoding == "AlphaNumeric")
                {
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                }
                else if (encoding == "Numeric")
                {
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                }
                try
                {
                    int scale = intSize;
                    qrCodeEncoder.QRCodeScale = scale;
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid size!");

                }
                try
                {
                    int version = intVersion;
                    qrCodeEncoder.QRCodeVersion = version;
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid version !");
                }

                string errorCorrect = strErrorCorrect;
                if (errorCorrect == "L")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                else if (errorCorrect == "M")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                else if (errorCorrect == "Q")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                else if (errorCorrect == "H")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

                System.Drawing.Image image;
                String data = strQrCode;

                image = qrCodeEncoder.Encode(data);

                System.Windows.Forms.PictureBox picEncode = new System.Windows.Forms.PictureBox();
                picEncode.Image = image;

                /**************/

                System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();

                if (valid)
                {
                    saveFileDialog.FileName = "c:\\myfacturae\\cbb.jpg";

                    saveFileDialog1.FileName = "D:\\Sica© v6.4\\BDXML_Sica6.4\\qrcode\\cbb" + folioLocal + "_" + FolioSia + ".jpg";
                }


                System.IO.FileStream fs =
                       (System.IO.FileStream)saveFileDialog1.OpenFile();
                System.IO.FileStream fs2 =
                       (System.IO.FileStream)saveFileDialog.OpenFile();

                picEncode.Image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();

                picEncode.Image.Save(fs2,
                               System.Drawing.Imaging.ImageFormat.Jpeg);
                fs2.Close();
            }
            catch (Exception e) { 
            
            
            }

            return "";
        }


        private void FillCFD30(Factura f, Direcciones_Fiscales direccionEmisor, Direcciones_Fiscales direccionEmision, Direcciones_Fiscales direccionReceptor, List<dlleFac.ComprobanteConcepto> myConceptos, dlleFac.Comprobante MyCFD20)
        {
            //Folios myFolio = f.Certificates.Folios.Where(p=>p.chrStatus == "A" && p.intIDtipoCFD == f.intID_Tipo_CFD).First();
            Folios myFolio = f.CFD.Folios; //.Where(p=>p.chrStatus == "A").First();
            DateTime fechaAprobacion = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss"));
              List<IpesVariable> iepsJson = new List<IpesVariable>();
              List<dlleFac.ComprobanteImpuestosTraslado> Mytraslado = new List<dlleFac.ComprobanteImpuestosTraslado>();
            decimal sumaRetIeps = 0;
            sumaRetIva = 0;
            sumaRetIsr = 0;
            decimal sumaSubtotal = 0;
            decimal sumaIva = 0;
            decimal sumaBaseIeps = 0;
            decimal sumaBaseIva16 = 0;
            decimal sumaBaseIva0 = 0;
            

            Boolean isIva0 = false;

            Boolean isIva16 = false;



            Boolean is08 = false;
            decimal baseieps08 = 0;

           

         
            




            MyCFD20.Fecha = fechaAprobacion;
            MyCFD20.LugarExpedicion = direccionEmisor.strCodigoPostal;
            //MyCFD20.NumCtaPago = string.IsNullOrEmpty(f.Clientes.strWebSite) ? "NO IDENTIFICADO" : f.Clientes.strWebSite;
            //MyCFD20.noAprobacion = myFolio.intNumero_Aprovacion.ToString();
            //MyCFD20.anoAprobacion = myFolio.strAño_Aprovacion;
            
            if ((f.intID_Tipo_CFD) == 1 || (f.intID_Tipo_CFD == 3) || ((f.intID_Tipo_CFD == 4)))
                MyCFD20.TipoDeComprobante = dlleFac.c_TipoDeComprobante.I;
            
            if ((f.intID_Tipo_CFD) == 2)
                MyCFD20.TipoDeComprobante = dlleFac.c_TipoDeComprobante.E;


            if ((f.intID_Tipo_CFD) == 5)
                MyCFD20.TipoDeComprobante = dlleFac.c_TipoDeComprobante.T;

            if (f.strSerie!="") {
                MyCFD20.Serie = f.strSerie;
            }
            
            MyCFD20.Folio = myFolio.intFolioActual.ToString();//f.strFolio;
           
            MyCFD20.FormaPago = f.strForma_Pago;
            MyCFD20.FormaPagoSpecified = true;
            MyCFD20.MetodoPago = f.MetodoPago;
            MyCFD20.MetodoPagoSpecified = true;
            
           // MyCFD20.MotivoDescuento = f.MotivoDesc;
           // MyCFD20.TipoCambio = decimal.Parse(f.TipoCambio.Value);
            MyCFD20.Moneda = "MXN";
            
            
            
            MyCFD20.Descuento = decimal.Parse(f.dcmDescuento.Value.ToString("#0.000000"));
            if (f.dcmDescuento > 0)
            {
                MyCFD20.DescuentoSpecified = true;
            }

            
           


            try
            {

                if (!string.IsNullOrEmpty(f.Origen) && !f.strCadenaOriginal.Contains("strImpLocaReten"))
                {
                    List<dlleFac.ComprobanteCfdiRelacionados> myRelacion = new List<dlleFac.ComprobanteCfdiRelacionados>();
                    {
                        List<dlleFac.ComprobanteCfdiRelacionadosCfdiRelacionado> myUUID = new List<dlleFac.ComprobanteCfdiRelacionadosCfdiRelacionado>();
                      //  List<string> uuids2 = new List<string>();
                        var lstuuid = f.Origen;


                        myUUID.Add(new dlleFac.ComprobanteCfdiRelacionadosCfdiRelacionado
                        {


                            UUID = lstuuid
                            
                            

                        });


                      //  eFacDBEntities db2 = new eFacDBEntities();
                      //  Factura factura = db2.Factura.Where(fac => fac.strFolio == lstuuid).First();
                        myRelacion.Add(new dlleFac.ComprobanteCfdiRelacionados
                        {
                            TipoRelacion = f.CondPago,
                            CfdiRelacionado = myUUID.ToArray()


                        });

            //MyCFD20.CfdiRelacionados.TipoRelacion = f.CondPago;
                     //  myRelacion.TipoRelacion = f.CondPago;
                       // MyCFD20.CfdiRelacionados.CfdiRelacionado = myUUID.ToArray();
                     //  myRelacion.CfdiRelacionado = myUUID.ToArray();

                       MyCFD20.CfdiRelacionados = myRelacion.ToArray(); //new dlleFac.ComprobanteCfdiRelacionados[];
                    }
                }
            }
            catch (Exception ex) { }
            

            /*
            dlleFac.ComprobanteEmisorRegimenFiscal myReg = new dlleFac.ComprobanteEmisorRegimenFiscal();

            List<dlleFac.ComprobanteEmisorRegimenFiscal> myRegimenFiscal = new List<dlleFac.ComprobanteEmisorRegimenFiscal>();
            myRegimenFiscal.Add ( new dlleFac.ComprobanteEmisorRegimenFiscal()
                {
                    Regimen = f.Empresa.strWebSite
                }
                );*/

            string strRegimen = "";
            if (string.IsNullOrEmpty(f.strNumeroContrato)) {

                strRegimen = f.Empresa.strWebSite.Substring(0, 3);
            
            }else{
            strRegimen = f.strNumeroContrato;
            }

            MyCFD20.Emisor = new dlleFac.ComprobanteEmisor
            {
                RegimenFiscal = strRegimen, //.ToArray(), 
                Rfc = f.Empresa.strRFC,
                Nombre = f.Empresa.strRazonSocial,
                
                /*
                DomicilioFiscal = new dlleFac.t_UbicacionFiscal
                {
                     calle = direccionEmisor.strCalle,
                      noInterior = direccionEmisor.strNoInterior,
                      noExterior = String.IsNullOrEmpty(direccionEmisor.strNoExterior.Trim()) ? "" : direccionEmisor.strNoExterior.Trim(),
                      pais = direccionEmisor.Paises.strNombrePais,
                      municipio = direccionEmisor.strMunicipio,
                      localidad = direccionEmisor.strPoblacionLocalidad,
                      estado = direccionEmisor.Estado.strNombreEstado,
                      codigoPostal = direccionEmisor.strCodigoPostal,
                       colonia = direccionEmisor.strColonia
                       
                },
                
                
                ExpedidoEn = new dlleFac.t_Ubicacion
                {
                 calle = direccionEmision.strCalle,
                 noInterior = direccionEmision.strNoInterior,
                 noExterior = direccionEmision.strNoExterior,
                 pais = direccionEmision.Paises.strNombrePais,
                 municipio = direccionEmision.strMunicipio,
                 localidad = direccionEmision.strPoblacionLocalidad,
                 estado = direccionEmision.Estado.strNombreEstado,
                 codigoPostal = direccionEmision.strCodigoPostal,
                 colonia = direccionEmision.strColonia 
                }*/
            };

            
            MyCFD20.Receptor = new dlleFac.ComprobanteReceptor
            {
                Rfc = f.Clientes.strRFC,
                Nombre = f.Clientes.strRazonSocial,
                UsoCFDI = f.intEstimacion,
                RegimenFiscalReceptor = f.Clientes.strTelefono,
                DomicilioFiscalReceptor = direccionReceptor.strCodigoPostal
                
                /*
                 Domicilio = new dlleFac.t_Ubicacion
                {
                    calle = direccionReceptor.strCalle,
                    noInterior = direccionReceptor.strNoInterior,
                    noExterior = direccionReceptor.strNoExterior,
                    pais = direccionReceptor.Paises.strNombrePais,
                    municipio = direccionReceptor.strMunicipio,
                    localidad = direccionReceptor.strPoblacionLocalidad,
                    estado = direccionReceptor.Estado.strNombreEstado,
                    codigoPostal = direccionReceptor.strCodigoPostal,
                     colonia = direccionReceptor.strColonia

                }*/
            };





          // var concepPG = dataConcepts.conceptosPrefactura.ToList();

            

            if (!f.strCadenaOriginal.Contains("XAXX010101000")) //REVISAR SI FUNCIONA

          // string strBytes = System.IO.File.ReadAllText("c:\\xml\\Factura.txt", UTF8Encoding.UTF8);

          // if (strBytes.Length == 0)
                
            {

                foreach (var item in f.Detalle_Factura)
                {

                    dlleFac.ComprobanteConceptoImpuestos comImpuestos = new dlleFac.ComprobanteConceptoImpuestos();

                    dlleFac.ComprobanteConceptoImpuestosTraslado myConceptoTranslado = new dlleFac.ComprobanteConceptoImpuestosTraslado();

                    dlleFac.ComprobanteConceptoImpuestosTraslado myConceptoTransladoIeps = new dlleFac.ComprobanteConceptoImpuestosTraslado();

                    decimal dcmRetIEPS = item.retIEPS.Value;
                    var value = iepsJson.Find(i => i.porcIeps == dcmRetIEPS);

                    //string dcmIVA = item.dcmIVA.Value; //(decimal.Parse(words[8]) - decimal.Parse("1.0000")).ToString();
                    decimal dcmVU = item.dcmPrecioUnitario; //decimal.Parse(words[6]);
                    decimal dcmImporte = item.dcmCantidad * dcmVU;
                    dcmImporte = decimal.Parse(dcmImporte.ToString("#0.000000"));

                    decimal opIeps = 0;
                    decimal BaseIeps = 0;
                    decimal total = 0;

                   

                    if (item.dcmIVA > 0)
                    {
                        isIva16 = true;
                        sumaBaseIva16 += dcmImporte;
                    }
                    if (item.dcmIVA == 0)
                    {
                        isIva0 = true;
                        sumaBaseIva0 += dcmImporte;
                    }

                    myConceptoTranslado.Impuesto = dlleFac.c_Impuesto.Item002;

                    myConceptoTranslado.TasaOCuota = decimal.Parse(item.dcmIVA.Value.ToString("#0.000000")); //item.dcmIVA.Value;
                    myConceptoTranslado.TasaOCuotaSpecified = true;

                    decimal BaseTraslado = dcmImporte; //item.dcmPrecioUnitario * item.dcmCantidad;

                    myConceptoTranslado.Base = dcmImporte;// decimal.Parse(BaseTraslado.ToString("#0.0000"));

                    decimal impuesto = myConceptoTranslado.Base * item.dcmIVA.Value;

                    myConceptoTranslado.Importe = decimal.Parse(impuesto.ToString("#0.000"));
                    myConceptoTranslado.ImporteSpecified = true;

                   
                    sumaIva += myConceptoTranslado.Importe;
                    sumaSubtotal += myConceptoTranslado.Base;

                    
                 
                    


                    if (value == null && dcmRetIEPS > 0)
                    {
                        opIeps = dcmImporte * dcmRetIEPS;
                        total += opIeps;
                        BaseIeps += dcmImporte;

                        iepsJson.Add(new IpesVariable()
                        {
                            sumaBaseIeps = BaseIeps,
                            porcIeps = dcmRetIEPS,
                            totalIeps = total

                        });
                    }
                    else
                    {
                        if (dcmRetIEPS > 0)
                        {
                            opIeps = dcmImporte * value.porcIeps;
                            total += value.totalIeps + opIeps;
                            BaseIeps += value.sumaBaseIeps + dcmImporte;

                            if (value.porcIeps == dcmRetIEPS)
                            {
                                value.sumaBaseIeps = BaseIeps;
                                value.totalIeps = total;


                            }
                        }

                    }

                   

                    List<dlleFac.ComprobanteConceptoImpuestosTraslado> myListTrans =
                     new List<dlleFac.ComprobanteConceptoImpuestosTraslado>();



                    dlleFac.ComprobanteConceptoImpuestosRetencion
                       myConceptoRetencionIva = new dlleFac.ComprobanteConceptoImpuestosRetencion();
                    dlleFac.ComprobanteConceptoImpuestosRetencion
                      myConceptoRetencionIrs = new dlleFac.ComprobanteConceptoImpuestosRetencion();


                    dlleFac.ComprobanteConceptoImpuestosRetencion
                      myConceptoRetencionIeps = new dlleFac.ComprobanteConceptoImpuestosRetencion();

                    List<dlleFac.ComprobanteConceptoImpuestosRetencion> myListReten =
                     new List<dlleFac.ComprobanteConceptoImpuestosRetencion>();



                    if (item.retIVA > 0)
                    {
                        myConceptoRetencionIva.Impuesto = dlleFac.c_Impuesto.Item002;
                        myConceptoRetencionIva.TasaOCuota = item.retIVA.Value; //dlleFac.c_TasaOCuota.Item0160000;
                    

                        myConceptoRetencionIva.Base = item.dcmPrecioUnitario * item.dcmCantidad;

                        decimal impuestoRetIva = myConceptoTranslado.Base * item.retIVA.Value;

                        myConceptoRetencionIva.Importe = decimal.Parse(impuestoRetIva.ToString("#0.000"));

                        sumaRetIva += myConceptoRetencionIva.Importe;
                    
                    
                        myListReten.Add(myConceptoRetencionIva);
                    }

                    if (item.retISR > 0)
                    {
                        myConceptoRetencionIrs.Impuesto = dlleFac.c_Impuesto.Item001;
                        myConceptoRetencionIrs.TasaOCuota = item.retISR.Value; //dlleFac.c_TasaOCuota.Item0160000;
                   

                        myConceptoRetencionIrs.Base = item.dcmPrecioUnitario * item.dcmCantidad;

                        decimal impuestoRetIsr = myConceptoTranslado.Base * item.retISR.Value;

                        myConceptoRetencionIrs.Importe = decimal.Parse(impuestoRetIsr.ToString("#0.00"));

                        sumaRetIsr += myConceptoRetencionIrs.Importe;
                    
                        myListReten.Add(myConceptoRetencionIrs);
                    }


                    myListTrans.Add(myConceptoTranslado);
                    /*
                    if (item.retIEPS > 0)
                    {
                        myConceptoRetencionIeps.Impuesto = dlleFac.c_Impuesto.Item003;
                        myConceptoRetencionIeps.TasaOCuota = item.retIEPS.Value; //dlleFac.c_TasaOCuota.Item0160000;
                    

                    myConceptoRetencionIeps.Base = item.dcmPrecioUnitario * item.dcmCantidad;

                    decimal impuestoRetIeps = myConceptoTranslado.Base * item.retIEPS.Value;
                    myConceptoRetencionIeps.Importe = impuestoRetIeps;


                    if (impuestoRetIeps > 0)
                        myListReten.Add(myConceptoRetencionIeps);



                    sumaRetIeps += impuestoRetIeps;
                   



                    }*/



                    foreach (var i in iepsJson)
                    {
                        if (dcmRetIEPS == i.porcIeps)
                        {


                            is08 = true;
                            myConceptoTransladoIeps.Impuesto = dlleFac.c_Impuesto.Item003;
                            myConceptoTransladoIeps.TasaOCuota = decimal.Parse(dcmRetIEPS.ToString("#0.000000")); //Math.Round(dcmRetIEPS, 6);
                            myConceptoTransladoIeps.TasaOCuotaSpecified = true;
                            myConceptoTransladoIeps.Base = dcmImporte; //item.dcmPrecioUnitario * item.intCantidad;
                            decimal impuestoRetIeps = myConceptoTransladoIeps.Base * dcmRetIEPS;//item.dcmIVA;
                            myConceptoTransladoIeps.Importe = decimal.Parse(impuestoRetIeps.ToString("#0.0000"));
                            myConceptoTransladoIeps.ImporteSpecified = true;



                            baseieps08 += myConceptoTransladoIeps.Importe;

                            myListTrans.Add(myConceptoTransladoIeps);


                        }
                       

                        //if (item.dcmIVA == 0) {

                        //    myConceptoTranslado.Impuesto = dlleFac.c_Impuesto.Item002;
                        //    myConceptoTranslado.TasaOCuota  = decimal.Parse(item.dcmIVA.Value.ToString("#0.000000"));
                        //    myConceptoTranslado.TasaOCuotaSpecified = true;
                        //    myConceptoTranslado.Base = dcmImporte; //item.dcmPrecioUnitario * item.intCantidad;
                        //    decimal impuestoIva = myConceptoTranslado.Base * item.dcmIVA.Value;//item.dcmIVA;
                        //    myConceptoTranslado.Importe = decimal.Parse(impuestoIva.ToString("#0.0000"));
                        //    myConceptoTranslado.ImporteSpecified = true;
                        
                        
                        //}
                    }






                    List<ImpuestosLocalesRetencionesLocales> myListImpLocal = new List<ImpuestosLocalesRetencionesLocales>();
                    ImpuestosLocales myImpLocal = new ImpuestosLocales();
                    if (f.strCadenaOriginal.Contains("strImpLocaReten"))
                    {

                        ImpLocales dataJson = JsonConvert.DeserializeObject<ImpLocales>(f.strCadenaOriginal);



                        myListImpLocal.Add(new ImpuestosLocalesRetencionesLocales
                        {

                            ImpLocRetenido = dataJson.strImpLocaReten,
                            Importe = dataJson.dcmImporteReten,
                            TasadeRetencion = dataJson.dcmTasaReten


                        });

                        myImpLocal.version = "1.0";
                        myImpLocal.TotaldeRetenciones = dataJson.dcmImporteReten;
                        myImpLocal.RetencionesLocales = myListImpLocal.ToArray();

                        sumaImpLocal = dataJson.dcmImporteReten;

                        MyCFD20.Complemento = new dlleFac.ComprobanteComplemento();

                        XmlDocument docImpLocal = new XmlDocument();
                        XmlSerializerNamespaces xmlNameSpceImpLocal = new XmlSerializerNamespaces();
                        xmlNameSpceImpLocal.Add("implocal", "http://www.sat.gob.mx/implocal");
                        using (XmlWriter writer = docImpLocal.CreateNavigator().AppendChild())
                        {
                            new XmlSerializer(myImpLocal.GetType()).Serialize(writer, myImpLocal, xmlNameSpceImpLocal);

                        }


                        MyCFD20.Complemento.Any = new XmlElement[1];
                        MyCFD20.Complemento.Any[0] = docImpLocal.DocumentElement;


                    }












                    if (f.Clientes.strRFC == "XAXX010101000")
                    {

                        /* PARA GLOBAL*/
                        dlleFac.ComprobanteInformacionGlobal myGlobal = new dlleFac.ComprobanteInformacionGlobal();

                        string[] arrayInfoGlobal = f.Destino.Split('/');
                        string strPeriocidad = arrayInfoGlobal[0].Split('-')[0];
                        string strMes = arrayInfoGlobal[1];
                        string strAno = arrayInfoGlobal[2];
                        myGlobal.Periodicidad = strPeriocidad;
                        myGlobal.Meses = strMes;
                        myGlobal.Año = short.Parse(strAno);

                        MyCFD20.InformacionGlobal = myGlobal;


                    }


                   
                  

                    comImpuestos.Traslados = myListTrans.ToArray();
                    
                    if (myListReten.Count > 0)
                    {
                        comImpuestos.Retenciones = myListReten.ToArray();
                    }
                    //string myClaveProduct = item.Productos.strNombre;

                    string[] arrunidad = item.strUnidad.Split('-');
                    string claveunidad = arrunidad[0];
                    string myuni = arrunidad[1];

                    myConceptos.Add(new dlleFac.ComprobanteConcepto
                    {
                        ObjetoImp = dlleFac.c_ObjetoImp.Item02,
                        Cantidad = decimal.Parse(item.dcmCantidad.ToString("#0.000")),
                        ClaveProdServ = item.Productos.strCodigoBarras,
                        Unidad = myuni,
                        ClaveUnidad = claveunidad,
                        NoIdentificacion = "1",//item.Productos.strCodigo,
                        Descripcion = item.strConcepto,
                        ValorUnitario = decimal.Parse(item.dcmPrecioUnitario.ToString("#0.000000")),
                        Importe = dcmImporte, //decimal.Parse(item.dcmImporte.ToString("#0.000000")),
                        Impuestos = comImpuestos

                    });
                }
            }
            else
            {

                System.IO.File.WriteAllText("c:\\xml\\Factura.txt", f.strCadenaOriginal, UTF8Encoding.UTF8);


               
                    int n = 1;

                    try
                    {
                        StreamReader re = File.OpenText("c:\\xml\\Factura.txt");
                        string input = null;

                      

                        //conSave = new ConnectorSave();

                        while ((input = re.ReadLine()) != null)
                        {
                            string[] words = input.Split('|');
                            if (words.Length > 1)
                            {
                                if (n > 3)
                                {

                                    string strIva = words[8];
                                 


                                    decimal dcmRetIEPS = decimal.Parse(words[10]);
                                    var value = iepsJson.Find(i => i.porcIeps == dcmRetIEPS);

                                    string dcmIVA = strIva; //(decimal.Parse(words[8]) - decimal.Parse("1.0000")).ToString();
                                    decimal dcmVU = decimal.Parse(words[6]);
                                    decimal dcmImporte = decimal.Parse(words[0]) * dcmVU ;
                                    dcmImporte = decimal.Parse(dcmImporte.ToString("#0.000000"));



                                    if ((strIva == "0") || (strIva == "1") || (strIva == "1.0"))
                                    {
                                        strIva = "0.000000";
                                        isIva0 = true;
                                        sumaBaseIva0 += dcmImporte;

                                    }



                                    if (strIva == "1.16")
                                    {
                                        strIva = "0.160000";
                                        sumaBaseIva16 += dcmImporte;
                                        isIva16 = true;

                                    }



                                    decimal opIeps = 0;
                                   
                                    decimal BaseIeps = 0;
                                        decimal total = 0;


                                    if (value == null && dcmRetIEPS > 0)
                                    {
                                        opIeps = dcmImporte * dcmRetIEPS;
                                        total += opIeps;
                                        BaseIeps += dcmImporte;
                                        iepsJson.Add(new IpesVariable()
                                        {
                                            sumaBaseIeps = BaseIeps,
                                            porcIeps = dcmRetIEPS,
                                            totalIeps = total

                                        });
                                    }
                                    else {
                                        if (dcmRetIEPS > 0)
                                        {
                                            opIeps = dcmImporte * value.porcIeps;
                                            total += value.totalIeps + opIeps;
                                            BaseIeps += value.sumaBaseIeps + dcmImporte;
                                            if (value.porcIeps == dcmRetIEPS)
                                            {
                                                value.sumaBaseIeps = BaseIeps;
                                                value.totalIeps = total;


                                            }
                                        }
                                    
                                    }



                                 







                                   dlleFac.ComprobanteConceptoImpuestos comImpuestos = new dlleFac.ComprobanteConceptoImpuestos();

                                   dlleFac.ComprobanteConceptoImpuestosTraslado myConceptoTransladoIeps = new dlleFac.ComprobanteConceptoImpuestosTraslado();
                                   dlleFac.ComprobanteConceptoImpuestosTraslado  myConceptoTranslado = new dlleFac.ComprobanteConceptoImpuestosTraslado();

                                    myConceptoTranslado.Impuesto = dlleFac.c_Impuesto.Item002;

                                    myConceptoTranslado.TasaOCuota = decimal.Parse(strIva);
                                    myConceptoTranslado.TasaOCuotaSpecified = true;


                                    myConceptoTranslado.Base = dcmImporte; //item.dcmPrecioUnitario * item.intCantidad;

                                    decimal impuesto = myConceptoTranslado.Base * decimal.Parse(strIva);//item.dcmIVA;

                                    var ImporteImpuesto = impuesto.ToString("#.0000");

                                    myConceptoTranslado.Importe = decimal.Parse(ImporteImpuesto);
                                    myConceptoTranslado.ImporteSpecified = true;


                                    sumaIva += decimal.Parse(ImporteImpuesto);
                                    sumaSubtotal += myConceptoTranslado.Base;

                                    List<dlleFac.ComprobanteConceptoImpuestosTraslado> myListTrans = new List<dlleFac.ComprobanteConceptoImpuestosTraslado>();

                                    myListTrans.Add(myConceptoTranslado);

                                    /* COMENTARIADO POR NO OCUPAR EN PUBLICO EN GENERAL */
                                    /*
                                    dlleFac.ComprobanteConceptoImpuestosRetencion
                                       myConceptoRetencionIva = new dlleFac.ComprobanteConceptoImpuestosRetencion();
                                    dlleFac.ComprobanteConceptoImpuestosRetencion
                                      myConceptoRetencionIrs = new dlleFac.ComprobanteConceptoImpuestosRetencion();


                                    dlleFac.ComprobanteConceptoImpuestosRetencion
                                      myConceptoRetencionIeps = new dlleFac.ComprobanteConceptoImpuestosRetencion();
                                    


                                    List<dlleFac.ComprobanteConceptoImpuestosRetencion> myListReten =
                                     new List<dlleFac.ComprobanteConceptoImpuestosRetencion>();
                                     * */

                                   
                                    foreach (var item in iepsJson)
                                    {
                                        
                                        if (dcmRetIEPS == item.porcIeps)
                                        {
                                         

                                            is08 = true;
                                            myConceptoTransladoIeps.Impuesto = dlleFac.c_Impuesto.Item003;
                                            myConceptoTransladoIeps.TasaOCuota = decimal.Parse(dcmRetIEPS.ToString("#0.000000")); //Math.Round(dcmRetIEPS, 6);
                                            myConceptoTransladoIeps.TasaOCuotaSpecified = true;
                                            myConceptoTransladoIeps.Base = dcmImporte; //item.dcmPrecioUnitario * item.intCantidad;
                                            decimal impuestoRetIeps = myConceptoTransladoIeps.Base * dcmRetIEPS;//item.dcmIVA;
                                            myConceptoTransladoIeps.Importe = decimal.Parse(impuestoRetIeps.ToString("#0.0000"));
                                            myConceptoTransladoIeps.ImporteSpecified = true;



                                            baseieps08 += myConceptoTransladoIeps.Importe;

                                            myListTrans.Add(myConceptoTransladoIeps);
                                        }

                                       
                                    }

                                    /* PARA GLOBAL*/
                                    dlleFac.ComprobanteInformacionGlobal myGlobal = new dlleFac.ComprobanteInformacionGlobal();

                                    string[] arrayInfoGlobal = f.Destino.Split('-');
                                    string strPeriocidad = arrayInfoGlobal[0];
                                    string strMes = arrayInfoGlobal[1];
                                    string strAno = arrayInfoGlobal[2];
                                    myGlobal.Periodicidad = strPeriocidad;
                                    myGlobal.Meses = strMes;
                                    myGlobal.Año = short.Parse(strAno);


                                    MyCFD20.InformacionGlobal = myGlobal;


                                    comImpuestos.Traslados = myListTrans.ToArray();
                                   // comImpuestos.Retenciones = myListReten.ToArray();
                                    //   string myunidad = item.Productos.UnidadMedida.strDescripcion;

                                    //string[] arrunidad = item.strUnidad.Split('-');
                                    string claveunidad = words[1];
                                    string myuni = words[2];

                                    myConceptos.Add(new dlleFac.ComprobanteConcepto
                                    {
                                        Cantidad = decimal.Parse(words[0]),
                                        ClaveProdServ = words[4],//item.Productos.strCodigoBarras,
                                        Unidad = myuni,
                                        ClaveUnidad = claveunidad,
                                        NoIdentificacion = "1",//item.Productos.strCodigo,
                                        Descripcion = words[5],
                                        ValorUnitario = decimal.Parse(dcmVU.ToString("#0.0000")),
                                        Importe = dcmImporte,
                                        ObjetoImp = dlleFac.c_ObjetoImp.Item02,
                                        Impuestos = comImpuestos
                                        
                                    });


                                }



                                n++;
                            }
                        }
                        re.Close();



                    }
                    catch (IOException e)
                    {

                    }

              //  }








            }

                MyCFD20.Conceptos = myConceptos.ToArray();

           // }

            decimal siva = 0;

                if (radOption1.IsChecked == true)
                {
                    siva = decimal.Parse(sumaIva.ToString("#0.00"));
                    sumaBaseIva16 = decimal.Parse(sumaBaseIva16.ToString("#0.00"));
                    sumaBaseIva0 = decimal.Parse(sumaBaseIva0.ToString("#0.00"));
                }

                if (radOption2.IsChecked == true)
                {
                    siva = Math.Truncate(100 * sumaIva) / 100;

                    sumaBaseIva16 = Math.Truncate(100 * sumaBaseIva16) / 100;
                    sumaBaseIva0 = Math.Truncate(100 * sumaBaseIva0) / 100;
                }




                 
                if (isIva16)
                {
                    dlleFac.ComprobanteImpuestosTraslado MyIvaT = new dlleFac.ComprobanteImpuestosTraslado()
                        {
                            Base = sumaBaseIva16,
                            Importe = siva,
                            ImporteSpecified = true,
                            Impuesto = dlleFac.c_Impuesto.Item002,
                            TipoFactor = dlleFac.c_TipoFactor.Tasa,
                            TasaOCuota = decimal.Parse("0.160000"),//dlleFac.c_TasaOCuota.Item0160000,
                            TasaOCuotaSpecified = true

                        };


                    Mytraslado.Add(MyIvaT);

                }


                if (isIva0)
                {

                    dlleFac.ComprobanteImpuestosTraslado MyIvaT0 = new dlleFac.ComprobanteImpuestosTraslado()
                        {
                        Base = sumaBaseIva0,
                        Importe = decimal.Parse("0.00"),
                        ImporteSpecified = true,
                        Impuesto = dlleFac.c_Impuesto.Item002,
                        TipoFactor = dlleFac.c_TipoFactor.Tasa,
                        TasaOCuota = decimal.Parse("0.000000"),
                        TasaOCuotaSpecified = true
                    
                    };
                    Mytraslado.Add(MyIvaT0);
            
                }
                



            decimal sumaIeps = 0; //baseieps01 + baseieps03 + baseieps10 + baseieps21 + baseieps04 + baseieps23 + baseieps120 + baseieps2605 + baseieps30 + baseieps53 + baseieps50 + baseieps160 + baseieps25 + baseieps09 + baseieps07 + baseieps06 + baseieps08;

            //var sieps = Math.Truncate(100 * sumaIeps) / 100;
            decimal iepsRed = 0; //decimal.Parse(baseieps08.ToString("#0.00"));
            decimal tasaIeps = 0;
            decimal baseTotalIeps = 0;
            foreach (var i in iepsJson)
            {

                 iepsRed = decimal.Parse(i.totalIeps.ToString("#0.00"));
                 baseTotalIeps = decimal.Parse(i.sumaBaseIeps.ToString("#0.00"));
                 tasaIeps = decimal.Parse(i.porcIeps.ToString("0.000000"));

                dlleFac.ComprobanteImpuestosTraslado MyIeps = new dlleFac.ComprobanteImpuestosTraslado()
                {
                    Base = baseTotalIeps, // CHECAR PARA AGREGAR BASE DE IEPS
                    Importe = iepsRed,//sieps,
                    ImporteSpecified = true,
                    Impuesto = dlleFac.c_Impuesto.Item003,
                    TipoFactor = dlleFac.c_TipoFactor.Tasa,
                    TasaOCuota = tasaIeps,//dlleFac.c_TasaOCuota.Item0160000 
                    TasaOCuotaSpecified = true
                };

                Mytraslado.Add(MyIeps);


                sumaIeps += iepsRed;
            }


            dlleFac.ComprobanteImpuestos Impuestos = new dlleFac.ComprobanteImpuestos()
            {
                TotalImpuestosTrasladados = siva + sumaIeps,
                Traslados = Mytraslado.ToArray(),
                TotalImpuestosTrasladadosSpecified = true,

               // Retenciones = MyRet.ToArray(),
               // totalImpuestosRetenidos = 203,
               // totalImpuestosRetenidosSpecified = true,

            };



            if ((f.intID_Tipo_CFD == 1) || (f.intID_Tipo_CFD == 2) || (f.intID_Tipo_CFD == 3))
            {
                List<dlleFac.ComprobanteImpuestosRetencion> MyRet = new List<dlleFac.ComprobanteImpuestosRetencion>();


                if (f.dcmRetIVA>0)
                {
                    dlleFac.ComprobanteImpuestosRetencion MyIvaRet = new dlleFac.ComprobanteImpuestosRetencion()
                    {
                        Importe = decimal.Parse(sumaRetIva.ToString("#0.00")),
                        Impuesto = dlleFac.c_Impuesto.Item002 //dlleFac.ComprobanteImpuestosRetencionImpuesto.IVA


                    };
                    MyRet.Add(MyIvaRet);
                }


                if (f.dcmRetISR >0)
                {

                    dlleFac.ComprobanteImpuestosRetencion MyIsrRet = new dlleFac.ComprobanteImpuestosRetencion()
                    {
                        Importe = decimal.Parse(sumaRetIsr.ToString("#0.00")),
                        Impuesto = dlleFac.c_Impuesto.Item001


                    };
                    MyRet.Add(MyIsrRet);

                }


                /*
                if (f.dcmRetIEPS > 0)
                {
                    dlleFac.ComprobanteImpuestosRetencion MyIepsRet = new dlleFac.ComprobanteImpuestosRetencion()
                    {
                        Importe = sumaRetIeps, //decimal.Parse(f.dcmRetISR.Value.ToString("#0.000000")),
                        Impuesto = dlleFac.c_Impuesto.Item003


                    };
                    MyRet.Add(MyIepsRet);
                }*/


               // Decimal rIva = f.dcmRetIVA.Value;
               // Decimal rIsr = f.dcmRetISR.Value;
                totalRet = sumaRetIva + sumaRetIsr + sumaRetIeps;

                Impuestos.TotalImpuestosRetenidosSpecified = false;
                if (totalRet > 0)
                {
                    Impuestos.TotalImpuestosRetenidosSpecified = true; /// cambiar en caso de usar retension
                                                                        /// 

                    Impuestos.TotalImpuestosRetenidos = decimal.Parse(totalRet.ToString("#0.00"));
                    Impuestos.Retenciones = MyRet.ToArray();
                }
                
              



            }
            

            MyCFD20.Impuestos = Impuestos;
            
            /*
            Addendas[] myAddendaFemsa = f.Addendas.ToArray();

            if (myAddendaFemsa.Length > 1)
            {
                dlleFac.ComprobanteAddendaDocumentoFacturaFemsa FacturaFemsa;

                //try
                // {
                FacturaFemsa = new dlleFac.ComprobanteAddendaDocumentoFacturaFemsa()
                {
                    noVersAdd = decimal.Parse(myAddendaFemsa[0].Default),
                    claseDoc = int.Parse(myAddendaFemsa[1].Default),
                    noSociedad = myAddendaFemsa[2].Default,
                    noProveedor = myAddendaFemsa[3].Default,
                    // noPedido = long.Parse(myAddendaFemsa[4].Default),
                    moneda = myAddendaFemsa[5].Default,
                    // noEntrada = long.Parse(myAddendaFemsa[6].Default),
                    //  noRemision = myAddendaFemsa[7].Default,
                    noSocio = myAddendaFemsa[8].Default,
                    centro = myAddendaFemsa[9].Default,
                    iniPerLiq = myAddendaFemsa[10].Default,
                    finPerLiq = myAddendaFemsa[11].Default,
                    retencion1 = myAddendaFemsa[12].Default,
                    retencion2 = myAddendaFemsa[13].Default,
                    retencion3 = myAddendaFemsa[14].Default,
                    email = myAddendaFemsa[15].Default,
                    datosAdicionales = myAddendaFemsa[16].Default,
                    tipoOperacion = myAddendaFemsa[17].Default
                };

                //           }
                //      catch(Exception exc)
                //       {
                //           MessageBox.Show(exc.Message);
                //       }
                /*
                ComprobanteAddendaDocumentoFacturaFemsa FacturaFemsa = new ComprobanteAddendaDocumentoFacturaFemsa()
                         {
                             noVersAdd = 1,
                             claseDoc = 1,
                             noSociedad = "0265",
                             noProveedor = "0013025786",
                             noPedido = 4502006231,
                             moneda = "MXN",
                             noEntrada = 5007896007,
                             noRemision = "00000000",
                             noSocio = "",
                             centro = "",
                             iniPerLiq = "",
                             finPerLiq = "",
                             retencion1 = "",
                             retencion2 = "",
                             retencion3 = "",
                             email = "chavoyamontajes@prodigy.net.mx",
                             datosAdicionales = "",
                             tipoOperacion = ""
                         };
               
                dlleFac.ComprobanteAddendaDocumento Documento = new dlleFac.ComprobanteAddendaDocumento()
                {

                    FacturaFemsa = FacturaFemsa

                };

                dlleFac.ComprobanteAddenda MyAddendaFemsa = new dlleFac.ComprobanteAddenda()
                {
                    Documento = Documento

                };


                MyCFD20.Addenda = MyAddendaFemsa;
                //  string strAddenda = MyAddendaFemsa
            }
            */


            decimal granTotal = siva + sumaIeps; //sumaSubtotal add despues siva 

            granTotal = decimal.Parse(granTotal.ToString("#0.00"));
            MyCFD20.SubTotal = decimal.Parse(sumaSubtotal.ToString("#0.00"));
            MyCFD20.Total = (MyCFD20.SubTotal + granTotal) - decimal.Parse(totalRet.ToString("#0.00")) - sumaImpLocal;

            eFacDBEntities db = new eFacDBEntities();
            f.dcmTotal = MyCFD20.Total;
            f.dcmRetIEPS = iepsRed;
            f.dcmSubTotal = MyCFD20.SubTotal;
            f.dcmIVA = siva;
            db.SaveChanges();

        }


        private void FillCFDPago30(Factura f, Direcciones_Fiscales direccionEmisor, Direcciones_Fiscales direccionEmision, Direcciones_Fiscales direccionReceptor, List<dlleFac.ComprobanteConcepto> myConceptos, dlleFac.Comprobante MyCFD20)
        {



            //Folios myFolio = f.Certificates.Folios.Where(p=>p.chrStatus == "A" && p.intIDtipoCFD == f.intID_Tipo_CFD).First();
            Folios myFolio = f.CFD.Folios; //.Where(p=>p.chrStatus == "A").First();
            DateTime fechaAprobacion = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss"));



            MyCFD20.Fecha = fechaAprobacion;

            //MyCFD20.noAprobacion = myFolio.intNumero_Aprovacion.ToString();
            //MyCFD20.anoAprobacion = myFolio.strAño_Aprovacion;

            MyCFD20.LugarExpedicion = direccionEmision.strCodigoPostal; ; //dlleFac.c_CodigoPostal.Item01276;
            //xxx MyCFD20.numCuentaPago = string.IsNullOrEmpty(f.Clientes.strWebSite) ? "NO IDENTIFICADO" : f.Clientes.strWebSite;


            MyCFD20.TipoDeComprobante = dlleFac.c_TipoDeComprobante.P;




            MyCFD20.Serie = f.strSerie;
            MyCFD20.Folio = f.strFolio;

            MyCFD20.Moneda = "XXX";





            MyCFD20.SubTotal = decimal.Parse("0");
            MyCFD20.Total = decimal.Parse("0");



            MyCFD20.Emisor = new dlleFac.ComprobanteEmisor
            {
                RegimenFiscal = f.Empresa.strWebSite.Split('-')[0],
                Rfc = f.Empresa.strRFC,
                Nombre = f.Empresa.strRazonSocial


            };


            MyCFD20.Receptor = new dlleFac.ComprobanteReceptor
            {
                Rfc = f.Clientes.strRFC,
                Nombre = f.Clientes.strRazonSocial,
                UsoCFDI = f.MotivoDesc,
                RegimenFiscalReceptor = f.Clientes.strTelefono,
                DomicilioFiscalReceptor = direccionReceptor.strCodigoPostal



            };
            eFacDBEntities db = new eFacDBEntities();
            //  var producPago = db.Productos.Where(p => p.strCodigo.Equals("84111506")&& p.strNombre.Contains("Pago")).FirstOrDefault();




            myConceptos.Add(new dlleFac.ComprobanteConcepto
            {


                Cantidad = decimal.Parse(("1")),
                ClaveProdServ = "84111506", //producPago.strCodigoBarras,
                ClaveUnidad = "ACT",
                Descripcion = "Pago",//producPago.strNombre,
                ValorUnitario = decimal.Parse("0"),
                Importe = decimal.Parse("0"),
                ObjetoImp = dlleFac.c_ObjetoImp.Item01


            });
            MyCFD20.Conceptos = myConceptos.ToArray();



            dllPag.Pagos Pago = new dllPag.Pagos();
            dllPag.PagosTotales totalesPago = new dllPag.PagosTotales();

            List<dllPag.PagosPago> myPagos = new List<dllPag.PagosPago>();

            List<dllPag.PagosPagoDoctoRelacionado> myPagoRel = null;
            string myFormaPago = "";

            if (f.strObervaciones == "FACTORAJE")
            {


                /***metodo 1***/


                foreach (var item in f.Detalle_Factura)
                {
                    myPagoRel = new List<dllPag.PagosPagoDoctoRelacionado>();


                    string[] words = item.strPatida.Split('|');
                    string myUUID = words[0];
                    string myFol = words[1];
                    string mySer = words[2];
                    myFormaPago = words[3];

                    myPagoRel.Add(new dllPag.PagosPagoDoctoRelacionado
                    {



                        IdDocumento = myUUID,
                        Serie = mySer,
                        Folio = myFol,
                        MonedaDR = "MXN",
                        //MetodoDePagoDR = "PPD",
                        NumParcialidad = f.CondPago,
                        ImpSaldoAnt = decimal.Parse(item.dcmPrecioUnitario.ToString("#0.00")),
                        // ImpSaldoAntSpecified = true,
                        ImpPagado = decimal.Parse(item.dcmImporte.ToString("#0.00")),
                        //ImpPagadoSpecified = true,
                        ImpSaldoInsoluto = decimal.Parse(item.dcmDescuento.ToString("#0.00")),
                        //ImpSaldoInsolutoSpecified = true,



                    });


                    myPagos.Add(new dllPag.PagosPago
                    {

                        CtaBeneficiario = f.Empresa.strCedula,
                        
                        CtaOrdenante = f.Clientes.strWebSite,
                        RfcEmisorCtaBen = f.Destino,
                        RfcEmisorCtaOrd = f.Origen,
                        NumOperacion = f.RecogerEn,
                        Monto = decimal.Parse(item.dcmImporte.ToString("#0.00")),
                        MonedaP = "MXN",
                        FormaDePagoP = myFormaPago.Substring(0, 2),

                        FechaPago = f.dtmFecha,
                        DoctoRelacionado = myPagoRel.ToArray()


                    });


                }

                totalesPago.MontoTotalPagos = decimal.Parse(f.dcmTotal.ToString("#0.00"));

            }


            /*** Metodo 2 ***/
            // List<dllPag.PagosPagoDoctoRelacionado> myPagoRel = new List<dllPag.PagosPagoDoctoRelacionado>();
            else
            {

                myPagoRel = new List<dllPag.PagosPagoDoctoRelacionado>();
                string strMoneda = "";
                string tipoCambio = "";
                //Boolean valueTC = false;
                foreach (var item in f.Detalle_Factura)
                {



                    string[] words = item.strPatida.Split('|');
                    string myUUID = words[0];
                    string myFol = words[1];
                    string mySer = words[2];
                    myFormaPago = words[3];
                    strMoneda = words[5].Split('-')[0];
                    tipoCambio = words[6];

                    //if (strMoneda == "USD") {
                    //     valueTC = true;             
                    //}


                    myPagoRel.Add(new dllPag.PagosPagoDoctoRelacionado
                    {



                        IdDocumento = myUUID,
                        Serie = mySer,
                        Folio = myFol,
                        MonedaDR = strMoneda,
                        // MetodoDePagoDR = "PPD",
                        NumParcialidad = f.CondPago,
                        ImpSaldoAnt = decimal.Parse(item.dcmPrecioUnitario.ToString("#0.00")),
                        //  ImpSaldoAntSpecified = true,
                        ImpPagado = decimal.Parse(item.dcmImporte.ToString("#0.00")),
                        //   ImpPagadoSpecified = true,
                        ImpSaldoInsoluto = decimal.Parse(item.dcmDescuento.ToString("#0.00")),
                        //   ImpSaldoInsolutoSpecified = true,
                        ObjetoImpDR = dllPag.c_ObjetoImp.Item01,

                        EquivalenciaDR = 1,
                        EquivalenciaDRSpecified = true


                    });
                }


                string CtaBeneficiario = f.Empresa.strCedula;
                string CtaOrdenante = f.Clientes.strWebSite;

                if (myFormaPago.Substring(0, 2) == "01") {
                    CtaBeneficiario = "";
                    CtaOrdenante = "";
                
                }

                myPagos.Add(new dllPag.PagosPago
                {
                    
                    CtaBeneficiario = CtaBeneficiario,
                    CtaOrdenante = CtaOrdenante,
                    RfcEmisorCtaBen = f.Destino,
                    RfcEmisorCtaOrd = f.Origen,
                    NumOperacion = f.RecogerEn,
                    Monto = decimal.Parse(f.dcmTotal.ToString("#0.00")),
                    MonedaP = strMoneda,

                    FormaDePagoP = myFormaPago.Substring(0, 2),
                    FechaPago = f.dtmFecha,
                    DoctoRelacionado = myPagoRel.ToArray(),
                    TipoCambioP = decimal.Parse(tipoCambio),
                    TipoCambioPSpecified = true,

                });


                totalesPago.MontoTotalPagos = decimal.Parse(f.dcmTotal.ToString("#0.00"));









            }

            Pago.Version = "2.0";
            Pago.Pago = myPagos.ToArray();
            Pago.Totales = totalesPago;


            // MyCFD20.Complemento = new dlleFac.ComprobanteComplemento[1];
            MyCFD20.Complemento = new dlleFac.ComprobanteComplemento();

            XmlDocument docPago = new XmlDocument();
            XmlSerializerNamespaces xmlNameSpcePago = new XmlSerializerNamespaces();
            xmlNameSpcePago.Add("pago20", "http://www.sat.gob.mx/Pagos20");
            using (XmlWriter writer = docPago.CreateNavigator().AppendChild())
            {
                new XmlSerializer(Pago.GetType()).Serialize(writer, Pago, xmlNameSpcePago);

            }


            MyCFD20.Complemento.Any = new XmlElement[1];
            MyCFD20.Complemento.Any[0] = docPago.DocumentElement;




            //  myComplemento.Pago = Pago;
            // MyCFD20.Complemento = new dlleFac.ComprobanteComplemento();
            //  MyCFD20.Complemento.Pago = Pago;



            //     dlleFac.ComprobanteComplemento myComplemento = new dlleFac.ComprobanteComplemento();
            //     myComplemento.Pago = Pago;
            //     MyCFD20.Complemento = myComplemento;




        }

        private static void LlenarEmisor(Factura f, Direcciones_Fiscales direccionEmisor, dlleFac.ComprobanteFiscalDigital cfd)
        {

            cfd.Emisor = new dlleFac.Emisor()
            {
                RFCEmisor = f.Empresa.strRFC,
                NombreEmisor = f.Empresa.strRazonSocial
            };

            cfd.DomicilioFiscalEmisor = new dlleFac.DomicilioFiscal()
            {
                Calle = direccionEmisor.strCalle,
                NumeroExterior = direccionEmisor.strNoExterior,
                Colonia = direccionEmisor.strColonia,
                Localidad = direccionEmisor.strPoblacionLocalidad,
                Referencia = null,
                Municipio = direccionEmisor.strMunicipio,
                Estado = direccionEmisor.Estado.strNombreEstado,
                Pais = direccionEmisor.Paises.strNombrePais,
                CodigoPostal = direccionEmisor.strCodigoPostal
            };

            cfd.ExpedidoEn = new dlleFac.DomicilioFiscal()
            {
                Calle = direccionEmisor.strCalle,
                NumeroExterior = direccionEmisor.strNoExterior,
                Colonia = direccionEmisor.strColonia,
                Localidad = direccionEmisor.strPoblacionLocalidad,
                Referencia = null,
                Municipio = direccionEmisor.strMunicipio,
                Estado = direccionEmisor.Estado.strNombreEstado,
                Pais = direccionEmisor.Paises.strNombrePais,
                CodigoPostal = direccionEmisor.strCodigoPostal
            };
        }

        private static void LlenarEncabezado(Factura f, dlleFac.ComprobanteFiscalDigital cfd, dlleFac.Comprobante MyCFD20)
        {
            cfd.Serie = f.strSerie;
            cfd.Folio = f.strFolio;
            cfd.Fecha = f.dtmFecha.ToString("yyyy-MM-dd") + "T" + f.dtmFecha.ToString("HH:mm:ss");
            cfd.NoAprobacion = f.Empresa.Folios.First(fol => fol.chrStatus == "A").intNumero_Aprovacion.ToString();
            cfd.AñoAprobacion = f.Certificates.dtmValidoDesde.Year.ToString();
            cfd.TipoComprobante = f.CFD.strDescripcion;
            cfd.FormaPago = f.strForma_Pago;
            cfd.Descuento = f.dcmDescuento.HasValue ? f.dcmDescuento.Value.ToString() : "0";
            cfd.SubTotal = f.dcmSubTotal.ToString();
            cfd.Total = f.dcmTotal.ToString();


        }

        private static void GetTraslados(Factura f, List<dlleFac.Traslado> t, decimal tasa, decimal importeTotalTraslado)
        {
            t.Add(new dlleFac.Traslado()
            {
                TipoImpuesto = "IVA",
                Tasa = tasa.ToString("F"),
                //Importe = f.Traslados.First().TotalImpuestoTrasladado.ToString(),
                TotalImpuestosTraslados = f.dcmIVA.ToString()
            });
        }

        private static void GetRetenciones(Factura f, List<dlleFac.Retencion> t,  decimal importeTotalRetenido)
        {
            t.Add(new dlleFac.Retencion()
            {
                
                TipoImpuesto = "IVA",
                //Importe = f.Traslados.First().dcmImporte.ToString()
                
            });

            t.Add(new dlleFac.Retencion()
            {

                TipoImpuesto = "ISR",
                //Importe = f.Traslados.Last().dcmImporte.ToString()

            });
        }
        private static void GetConceptos(System.Data.Objects.DataClasses.EntityCollection<Detalle_Factura> conceptos, List<dlleFac.Concepto> c, out decimal tasa, out decimal importeTotalTraslado)
        {
            tasa = 0;
            importeTotalTraslado = 0;

            foreach (var item in conceptos)
            {
                c.Add(new dlleFac.Concepto()
                {
                    Cantidad = item.dcmCantidad.ToString(),
                    UnidadMedida = item.strUnidad,//Productos.UnidadMedida.strDescripcion,
                    NoIdentificacion = item.Productos.strCodigo,
                    Descripcion = item.Productos.strNombre,
                    ValorUnitario = item.dcmPrecioUnitario.ToString(),
                    Importe = item.dcmImporte.ToString()
                });

                decimal importeTraslado = (item.dcmImporte * (item.dcmIVA.Value / 100));

                tasa = item.dcmIVA.Value;
                importeTotalTraslado += importeTraslado;
            }
        }

       

        private void dtgFacturasHistorico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckCFDStatus(dtgFacturasHistorico);
        }

        private void mniCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgFacturasHistorico.SelectedItem != null)
            {
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;

                if (f.chrStatus == "A")
                {
                    CancelaCFDi myCancelar = new CancelaCFDi(f);
                    

                    //MessageBoxResult result = MessageBox.Show("Desea cancelar el comprobante", "Cancelar",
                    //   MessageBoxButton.OKCancel, MessageBoxImage.Information);

                    if (myCancelar.ShowDialog().Value == true)
                    {
                        try
                        {

                            string urlSalida = PdfStampInExistingFile(f.strPDFpath);
                            eFacDBEntities db = new eFacDBEntities();

                            Factura factura = db.Factura.SingleOrDefault(fac => fac.intID == f.intID);

                            factura.chrStatus = "C";
                            factura.dtmFechaCancelacion = DateTime.Now;
                            factura.strNumero = "CANCELADA";
                            factura.dtmFechaEnvio = DateTime.Now;
                            factura.strPDFpath = urlSalida;
                            if (f.intID_Tipo_CFD == 6)
                            {

                                List<Detalle_Factura> detfact = db.Detalle_Factura.Where(df => df.intID_Factura == f.intID).ToList();// busca detalle de complemento


                                int idtem = 0;
                                foreach (var item in detfact)
                                {
                                    idtem = int.Parse(item.strConcepto);

                                    List<Detalle_Factura> getPag = db.Detalle_Factura.Where(df => df.strConcepto == item.strConcepto).ToList(); // obtiene pagos de factura para sumar monto

                                    decimal count = 0;

                                    foreach (var i in getPag)
                                    {

                                        count += i.dcmImporte;

                                    }


                                    Factura updateStatus = db.Factura.FirstOrDefault(fd => fd.intID == idtem);  // busca facturas de complemento

                                    updateStatus.strNumero = "";                                                // edita PAGADO O PARCIAL
                                    updateStatus.dtmFechaEnvio = null;                                          // elimina fecha de pago
                                    updateStatus.dcmDescuento = updateStatus.dcmTotal - count + item.dcmImporte;         // actualiza saldo pendiente




                                    item.strConcepto = "0";                                                     // cambia campo de id factura 

                                }


                            }

                            db.SaveChanges();

                            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
                            txtAaaa.Text = DateTime.Now.Year.ToString();
                            buscar();
                           
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message);
                        }

                        this.DataContext = null;

                        this.DataContext = new PuntoVentaViewModel();
                    }
                }
            }
        }

        private void mniImprimir_Click(object sender, RoutedEventArgs e)
        {

            if (this.dtgFacturasHistorico.SelectedItem != null)
            {
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;
                if ((f.chrStatus == "A") || (f.chrStatus == "C"))
                    App.Current.Properties["liga"] = f.strPDFpath;
                else
                {

                    eFacDBEntities db = new eFacDBEntities();

                    db.Connection.Open();
                    if ((f.intID_Tipo_CFD == 1) || (f.intID_Tipo_CFD == 2) || (f.intID_Tipo_CFD == 3) || (f.intID_Tipo_CFD == 4) || (f.intID_Tipo_CFD == 5))
                    {

                        AprobarFactura(f, db, false);
                    }
                    if (f.intID_Tipo_CFD == 6)
                    {

                        AprobarPago(f, db, false);
                    }

                   

                        this.DataContext = null;

                        this.DataContext = new PuntoVentaViewModel();


                        
                    Factura myfactura = db.Factura.Where(fac => fac.intID == f.intID).First();

                        App.Current.Properties["liga"] = myfactura.strPDFdemoPath;
                        //App.Current.Properties["liga"] = Directory.GetCurrentDirectory() + "c:\\adsoftOK.pdf";
                        //App.Current.Properties["liga"] = "c:\\adsoftOK.pdf";
                        //App.Current.Properties["liga"] = Directory.GetCurrentDirectory() + "\\factura.html";
                }

                Views.VinculosInteres.PdfViewer myW = new Views.VinculosInteres.PdfViewer();
                myW.WindowState = WindowState.Maximized;
                myW.ShowDialog();
                myW.Close();
            }
            
            }

            
        

        private List<Detalle_PreFactura> GetConceptosReporte(System.Data.Objects.DataClasses.EntityCollection<Detalle_Factura> entityCollection)
        {
            List<Detalle_PreFactura> result = new List<Detalle_PreFactura>();

            foreach (var item in entityCollection)
            {
                //Thest this should change to the data base

                result.Add(new Detalle_PreFactura()
                {
                    intCantidad = item.dcmCantidad,
                    dcmDescento = item.dcmDescuento,
                    dcmImporte = item.dcmImporte.ToString("N"),
                    strUnidad = item.strUnidad,//Productos.UnidadMedida.strDescripcion,
                    strConcepto = item.strConcepto,
                    dcmPrecioUnitario = item.dcmPrecioUnitario.ToString("N"),
                    strPartida = item.strPatida, //Thest
                    dcmIIVA = item.dcmIVA.Value.ToString("F")
                });
            }

            return result;
        }

        private void ShowReport(wpfEFac.Helpers.CFDReporte reporte)
        {
            wpfEFac.Views.Reports.CFD ventanaReporte = new Reports.CFD(reporte);
            ventanaReporte.Show();
        }

        private void mniXML_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgFacturasHistorico.SelectedItem != null)
            {
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;

                if (f.chrStatus == "A")
                {
                    try
                    {
                        dlleFac.MyFactE myf = new dlleFac.MyFactE();

                        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                        dlg.FileName = "XML" + "_" + f.Clientes.strRFC + "_" + f.dtmFecha.ToString("dd_MM_yyyy_HH_mm_ss"); // Default file name
                        dlg.DefaultExt = ".xml"; // Default file extension
                        dlg.Filter = "Documentos XML (.xml)|*.xml"; // Filter files by extension

                        // Show save file dialog box
                        Nullable<bool> result = dlg.ShowDialog();

                        var direccionEmisor = pfvm.GetDireccionEmpresa(f.Empresa.intID);

                        var direccionReceptor = pfvm.GetDireccionCliente(f.Clientes.intID);

                        List<dlleFac.Concepto> c = new List<dlleFac.Concepto>();

                        dlleFac.Impuestos impuesto = new dlleFac.Impuestos();

                        List<dlleFac.Traslado> tr = new List<dlleFac.Traslado>();

                        foreach (var item in f.Detalle_Factura)
                        {
                            c.Add(new dlleFac.Concepto()
                            {
                                Cantidad = item.dcmCantidad.ToString(),
                                UnidadMedida = item.strUnidad,//Productos.UnidadMedida.strDescripcion,
                                NoIdentificacion = item.Productos.strCodigo,
                                Descripcion = item.Productos.strNombre,
                                ValorUnitario = item.dcmPrecioUnitario.ToString(),
                                Importe = item.dcmImporte.ToString("F")
                            });
                        }

                        /*
                        foreach (var item in f.Traslados)
	                    {
                            tr.Add(new dlleFac.Traslado()
                            {
                                Importe = item.dcmImporte.ToString("F"),
                                TipoImpuesto = item.strTipoImpuesto,
                                TotalImpuestosTraslados = item.TotalImpuestoTrasladado.ToString("F"),
                                Tasa = item.dcmTasa.ToString("F")
                            });

                            impuesto.TotalTraslados = item.TotalImpuestoTrasladado.ToString("F");
	                    }*/

                        dlleFac.ComprobanteFiscalDigital cfd = new dlleFac.ComprobanteFiscalDigital()
                        {
                            Version = "2.0",
                            Serie = f.strSerie,
                            Folio = f.strFolio,
                            Fecha = f.dtmFecha.ToString("yyyy-MM-dd") + "T" + f.dtmFecha.ToString("HH:mm:ss"),
                            NoAprobacion = f.Empresa.Folios.First(fol => fol.chrStatus == "A").intNumero_Aprovacion.ToString(),
                            AñoAprobacion = f.Certificates.dtmValidoDesde.Year.ToString(),
                            TipoComprobante = f.CFD.strTipoCFD,
                            FormaPago = f.strForma_Pago,
                            SubTotal = f.dcmSubTotal.ToString("F"),
                            Total = f.dcmTotal.ToString("F"),
                            Emisor = new dlleFac.Emisor() { RFCEmisor = f.Empresa.strRFC, NombreEmisor = f.Empresa.strNombreComercial },
                            DomicilioFiscalEmisor = new dlleFac.DomicilioFiscal()
                            {
                                Calle = direccionEmisor.strCalle,
                                NumeroExterior = direccionEmisor.strNoExterior,
                                Colonia = direccionEmisor.strColonia,
                                Localidad = direccionEmisor.strPoblacionLocalidad,
                                Referencia = null,
                                Municipio = direccionEmisor.strMunicipio,
                                Estado = direccionEmisor.Estado.strNombreEstado,
                                Pais = direccionEmisor.Paises.strNombrePais,
                                CodigoPostal = direccionEmisor.strCodigoPostal
                            },

                            ExpedidoEn = new dlleFac.DomicilioFiscal()
                            {
                                Calle = direccionEmisor.strCalle,
                                NumeroExterior = direccionEmisor.strNoExterior,
                                Colonia = direccionEmisor.strColonia,
                                Localidad = direccionEmisor.strPoblacionLocalidad,
                                Referencia = null,
                                Municipio = direccionEmisor.strMunicipio,
                                Estado = direccionEmisor.Estado.strNombreEstado,
                                Pais = direccionEmisor.Paises.strNombrePais,
                                CodigoPostal = direccionEmisor.strCodigoPostal
                            },

                            Receptor = new dlleFac.Receptor()
                            {
                                RFCReceptor = f.Clientes.strRFC,
                                NombreReceptor = f.Clientes.strRazonSocial,
                            },

                            DomicilioFiscalReceptor = new dlleFac.DomicilioFiscal()
                            {
                                Calle = direccionReceptor.strCalle,
                                NumeroExterior = direccionReceptor.strNoExterior,
                                Colonia = direccionReceptor.strColonia,
                                Localidad = direccionReceptor.strPoblacionLocalidad,
                                Referencia = null,
                                Municipio = direccionReceptor.strMunicipio,
                                Estado = direccionReceptor.Estado.strNombreEstado,
                                Pais = direccionReceptor.Paises.strNombrePais,
                                CodigoPostal = direccionReceptor.strCodigoPostal
                            },

                            Conceptos = c,

                            Impuestos = new dlleFac.Impuestos() 
                            {
                                TotalTraslados = impuesto.TotalTraslados,
                                Traslados = tr
                            }
                        };

                        // Process save file dialog box results
                        if (result == true)
                        {
                            //myf.GetXML(f.strCadenaOriginal, f.strSelloDigital, f.Certificates.strNumeroCertificadoSelloDigital, dlg.FileName, cfd);
                            System.Diagnostics.Process.Start(dlg.FileName);
                        }
                            //dlleFac.Factura objFac = myf.execMyFactE(
                        //    f.Empresa.strRFC,
                        //    f.strFolio,
                        //    f.strCadenaOriginal,
                        //    "aaa010101aaa_CSD_01.cer", //DEMO
                        //     "aaa010101aaa_CSD_01.key", //DEMO
                        //     "a0123456789"); //DEMO

                        //MessageBox.Show("Se creo el archivo xml", objFac.filePath);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    
                }
            }

            
        }

        private void mniPDF_Click(object sender, RoutedEventArgs e)
        {

            if (this.dtgFacturasHistorico.SelectedItem != null)
            {
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;

                var direccionEmisor = pfvm.GetDireccionEmpresa(f.Empresa.intID);

                var direccionReceptor = pfvm.GetDireccionCliente(f.Clientes.intID);

                if (!f.Detalle_Factura.IsLoaded)
                {
                    f.Detalle_Factura.Load();
                }

                if (f.chrStatus == "A")
                {

                    DoPDFCFD(f, direccionEmisor, direccionReceptor);
                }
             }
        }

        private void DoPDFCFD(Factura f, Direcciones_Fiscales direccionEmisor, Direcciones_Fiscales direccionReceptor)
        {
            Helpers.CFDReporte infoReporte = new wpfEFac.Helpers.CFDReporte()
            {
                Folio = "Folio: " + f.strSerie + " " + f.strFolio,
                Fecha = "Fecha: " + f.dtmFecha.ToString("yyyy-MM-dd") + "T" + f.dtmFecha.ToString("HH:mm:ss"),
                NumeroCertificado = "Certificado: " + f.Certificates.strNumeroCertificadoSelloDigital,
                NumeroAprobacion = "No. Aprob. " + f.Empresa.Folios.First(fol => fol.chrStatus == "A").intNumero_Aprovacion,
                AnoArobacion = "Año aprobacion" + f.Certificates.dtmValidoDesde.Year,

                Logo = "file:///" + f.Empresa.strLogo,
                NombreEmisor = f.Empresa.strRazonSocial,
                DomicilioEmisor = direccionEmisor.strCalle + " " +
                direccionEmisor.strNoExterior + " " + direccionEmisor.strColonia + " " +
                direccionEmisor.strCodigoPostal + " " + direccionEmisor.strMunicipio + " " +
                direccionEmisor.Estado.strNombreEstado + " " + direccionEmisor.Paises.strNombrePais,
                RFCEmisor = f.Empresa.strRFC,
                Telefono = f.Empresa.strTelefono,

                NombreCliente = f.Clientes.strRazonSocial,
                DomicilioCliente = direccionReceptor.strCalle + " " +
                direccionReceptor.strNoExterior + " " + direccionReceptor.strColonia + " " +
                direccionReceptor.strCodigoPostal + " " + direccionReceptor.strMunicipio + " " +
                direccionReceptor.Estado.strNombreEstado + " " + direccionReceptor.Paises.strNombrePais,
                RFCCliente = f.Clientes.strRFC,

                Proveedor = "Proveedor " + f.strProveedor, // prueva
                NoPedido = "No. Pedido " + f.strNumero,
                NoContrato = "No. Contrato " + f.strNumeroContrato,
                Usuario = f.Usuarios.strNombre,
                Estimacion = "Estimación: " + f.intEstimacion,

                ImporteLetra = ConvertidorNumeroLetra.NumeroALetras(f.dcmTotal.ToString("F"), "PESOS"),
                SubTotal = f.dcmSubTotal.ToString("F"),

                IVA = f.dcmIVA.ToString("F"),
                Total = f.dcmTotal.ToString("F"),

                Observaciones = f.strObervaciones,

                Conceptos = GetConceptosReporte(f.Detalle_Factura),

                SelloDigital = f.strSelloDigital,

                CadenaOriginal = f.strCadenaOriginal,
                Cedula = "file:///" + f.Empresa.strCedula,
            };

            Reports.CFD pdfExporter = new Reports.CFD(infoReporte);

            wpfEFac.Views.Reports.CFD ventanaReporte = new Reports.CFD(infoReporte);

            ventanaReporte.DoPDF(infoReporte);

        }

        private void mniEmail_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgFacturasHistorico.SelectedItem != null)
            {
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;

                IList items = dtgFacturasHistorico.SelectedItems;

                List<Relacionados> itemsId = new List<Relacionados>();



                foreach (Factura item in items)
                {
                    itemsId.Add(new Relacionados
                    {
                        idFact = item.intID,
                        SF = item.strSerie + item.strFolio,
                        strXML = item.strXMLpath,
                        strPDF = item.strPDFpath

                    });
                }


                if (f.chrStatus == "A")
                {
                    EMail.Email emailwindow = new EMail.Email(itemsId);

                    emailwindow.Show();

                    Messenger.Default.Send(f);


                }
            }

        }

        private List<string> GetRecivers(ConfiguracionEmail configuracionEmail, string emailCliente)
        {
            return new List<string>()
            {
                emailCliente,
                configuracionEmail.strE_MailContador,
                configuracionEmail.strE_MailRespaldo,
                configuracionEmail.Empresa.strEmail
            };
        }

        private List<string> GetAttach()
        {
            return new List<string>()
            {
                "Muestra.pdf",//This has to change to the files generated by the app. 
                "Muestra.xml"
            };
        }

        private void bttEditarPreFactura_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgFacturasHistorico.SelectedItem != null)
            {
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;

                if (f.chrStatus == "P")
                {
                 

                        PreFactura pf = new PreFactura(f.intID, f.strSerie,
                           f.strFolio, f.Empresa, f.Clientes, f.strProveedor,
                           f.strNumero, f.strNumeroContrato, f.intEstimacion,
                            f.strObervaciones,
                           f.Detalle_Factura, f);

                        this.NavigationService.Navigate(pf);
                    
           


                   
                }
                else
                {
                    MessageBox.Show("El comprobante ya fue aprobada");
                }
            }
        }

        

        private void cmdReciboArr_Click(object sender, RoutedEventArgs e)
        {
            PreFactura newPreFactura = new PreFactura(3);

            this.NavigationService.Navigate(newPreFactura);
        }

        private void hplNuevaNotaCredito_Clik(object sender, RoutedEventArgs e)
        {
            PreFactura newPreFactura = new PreFactura(2);

            this.NavigationService.Navigate(newPreFactura);
        }

        private void hplNuevoReciboHonorarios_Click(object sender, RoutedEventArgs e)
        {
            PreFactura newPreFactura = new PreFactura(4);

            this.NavigationService.Navigate(newPreFactura);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void hplCotizacion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void hplRemision_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void hplNuevaCartaPorte_Click(object sender, RoutedEventArgs e)
        {
            PreFactura newPreFactura = new PreFactura(5);

            this.NavigationService.Navigate(newPreFactura);
        }

        private void bttEliminarPreFactura_Click(object sender, RoutedEventArgs e)
        {

            if (this.dtgFacturasHistorico.SelectedItem != null)
            {
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;

                if (f.chrStatus == "P")
                {

                    MessageBoxResult result = MessageBox.Show("¿ Esta seguro de eliminar esta Factura con estatus de Pendiente ?", "Eliminar",
                           MessageBoxButton.OKCancel, MessageBoxImage.Information);

                    if (result == MessageBoxResult.OK)
                    {
                        eFacDBEntities db = new eFacDBEntities();

                        Factura MyFacturaDeleted = db.Factura.FirstOrDefault(fd => fd.intID == f.intID);
                        MyFacturaDeleted.chrStatus = "E";

                        if (f.intID_Tipo_CFD == 6)
                        {
                            List<Detalle_Factura> detfact = db.Detalle_Factura.Where(df => df.intID_Factura == f.intID).ToList();// busca detalle de complemento 





                            int idtem = 0;
                            foreach (var item in detfact)
                            {
                                idtem = int.Parse(item.strConcepto);

                                List<Detalle_Factura> getPag = db.Detalle_Factura.Where(df => df.strConcepto == item.strConcepto).ToList();// obtiene pagos de factura para sumar monto

                                decimal count = 0;

                                foreach (var i in getPag)
                                {

                                    count += i.dcmImporte;

                                }


                                Factura updateStatus = db.Factura.FirstOrDefault(fd => fd.intID == idtem);  // busca facturas de complemento

                                updateStatus.strNumero = "";                                                // edita PAGADO O PARCIAL
                                updateStatus.dtmFechaEnvio = null;                                          // elimina fecha de pago
                                updateStatus.dcmDescuento = updateStatus.dcmTotal - count + item.dcmImporte;         // actualiza saldo pendiente




                                item.strConcepto = "0";                                                     // cambia campo de id factura 

                            }
                        }
                        db.SaveChanges();


                        // dtgFacturasHistorico.ItemsSource = db.Factura.Where(mf => mf.chrStatus != "E").OrderByDescending(d => d.dtmFecha);
                        cmbMes.SelectedIndex = DateTime.Now.Month - 1;
                        txtAaaa.Text = DateTime.Now.Year.ToString();
                        buscar();

                    }
                }

                else
                {
                    MessageBox.Show("No se pueden eliminar Facturas Aprobadas o Canceladas");

                }

            }

        }
        
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            buscar();
        }

        private void radTodos_Click(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void radMes_Click(object sender, RoutedEventArgs e)
        {
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
            cmbAaa.SelectedIndex = DateTime.Now.Year- 1;
            txtAaaa.Text = DateTime.Now.Year.ToString();
            buscar();
        }

        private void radFecha_Click(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void radFacturas_Click(object sender, RoutedEventArgs e)
        {
            buscar();
        }

        private void cmbMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            buscar();
        }

        private void cmbAaa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void radAno_Click(object sender, RoutedEventArgs e)
        {
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
            cmbAaa.SelectedIndex = DateTime.Now.Year - 1;
            txtAaaa.Text = DateTime.Now.Year.ToString();
            buscar();
        }
        
        private void SaveDataDBSia(string FolioSia,string FolioLocal,string fecha, string certificadoEmisor,string certificadoSat, string UUID, string fechaTimbrado,string ImporteLetra, string CadenaOriginal, string selloCFD, string selloSAT, string urlQR,decimal subtotal, decimal iva, decimal retIeps, decimal total )
        {

           OleDbConnection conn = new OleDbConnection();
          // using (OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mwool\\Desktop\\Uni\\3rd Year\\SEM 1\\AP\\Assignment\\Staff.accdb"))

           conn.ConnectionString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Sica© v6.4\BDXML_Sica6.4\BDXML_Sica64.mdb");
                


            try
            {
                conn.Open();
             //   String my_querry = "INSERT INTO T_Folios(Folio,FolioFactura,Ref,Fecha,Referencia,Hora,Clave,Articulo,Cantidad,Unidad,PU,Tasa_Descuento,ImpDescuento,Subtotal,TasaIEPS,ImpIEPS,Tasa_IVA,ImpIVA,Total,SAT_CvePS,SAT_CveUnidad,SAT_Pais,SAT_Moneda,SAT_TipoComprobante,SAT_RegimenFiscal,SAT_UsoCFDI,SAT_Impuesto,SAT_TipoFactor,SAT_TasaCuota,SAT_CveFormaPago,SAT_CveMetPago,SAT_LugarExpedicion,SAT_CertificadoEmisor,SAT_CertificadoSAT,SAT_FolioFiscal,SAT_FechaCertificacionCFDI,SAT_FechaEmisionComprobante,SAT_RazonSocialEmisor,SAT_RFCEmisor,SAT_RazonSocialReceptor,SAT_RFCReceptor,Observaciones,CantidadenLetra,SAT_CadenaOriginal,SAT_SelloDigitalEmisor,SAT_SelloDigitalSAT,CodigoQ)VALUES('"
             //+ int.Parse(FolioSia) + "','" + FolioLocal + "','" + "Ref" + "','" + fechaTimbrado + "','" + "Referencia" + "','" + "15:04" + "','" + "clave" + "','" + "articulo" + "','" + decimal.Parse("1.00") + "','" + "Unidad" + "','" + decimal.Parse("1.00") + "','" + decimal.Parse("0.00") + "','" + decimal.Parse("0.00") + "','" + decimal.Parse("500") + "','" + "tasas ieps" + "','" + decimal.Parse("0.00") + "','" + "0.160000" + "','" + decimal.Parse("153.00") + "','" + decimal.Parse("15456.00") + "','" + "clave producto" + "','" + "clave unidad" + "','" + "MEXICO" + "','" + "MXN" + "','" + "I-Ingreso" + "','" + "612-Personas Físicas con Actividades Empresariales y Profesionales" + "','" + "G03-Gastos en general" + "','" + "sat impuesto" + "','" + "sat tipo factor" + "','" + "0.160000" + "','" + "PUE-Pago en una sola exhibicion" + "','" + "01-Efectivo" + "','" + "91700" + "','" + certificadoEmisor + "','" + certificadoSat + "','" + UUID + "','" + fechaTimbrado + "','" + "06/07/2019 03:03:47 p. m." + "','" + "emisor" + "','" + "rfc emisor" + "','" + "receptor" + "','" + "rfc receptor" + "','" + "VENTA AL PUBLICO EN GENERAL DEL 05/07/2019 AL 05/07/2019" + "','" + ImporteLetra + "','" +CadenaOriginal + "','" + selloCFD + "','" + selloSAT + "','" + urlQR + "')";

                String my_querry = "INSERT INTO T_Folios(Folio,FolioFactura,SAT_CertificadoEmisor,SAT_CertificadoSAT,SAT_FolioFiscal,SAT_FechaEmisionComprobante,CantidadenLetra,SAT_CadenaOriginal,SAT_SelloDigitalEmisor,SAT_SelloDigitalSAT,CodigoQ,dcm_Subtotal,dcm_Iva,dcm_Ieps,dcm_Total)VALUES('"
                                                        + int.Parse(FolioSia) + "','" + FolioLocal + "','" + certificadoEmisor + "','" + certificadoSat + "','" + UUID + "','" + fechaTimbrado + "','" + ImporteLetra + "','" + CadenaOriginal + "','" + selloCFD + "','" + selloSAT + "','" + urlQR + "','" + subtotal + "','" + iva + "','" + retIeps + "','" + total + "')";


                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();

               // MessageBox.Show("Data saved successfuly...!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to " + ex.Message);
            }
            finally
            {
                conn.Close();
            }



        }

        private void mniPayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentFactura myPago = new PaymentFactura(null);


            if (myPago.ShowDialog().Value == true)
            {
                try
                {

                    radMes.IsChecked = true;
                    cmbMes.SelectedIndex = DateTime.Now.Month - 1;
                    txtAaaa.Text = DateTime.Now.Year.ToString();
                    buscar();


                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }

                this.DataContext = null;

                this.DataContext = new PuntoVentaViewModel();
            }
        }

        private void radOption1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void radOption2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mniReImprimir_Click(object sender, RoutedEventArgs e)
        {


            try
            {



                eFacDBEntities db = new eFacDBEntities();
                dlleFac.MyFactE myf = new dlleFac.MyFactE();
                Factura f = (Factura)dtgFacturasHistorico.SelectedItem;
                Complemento myComp = new Complemento();
                dlleFac.Comprobante myComprobante = DeserializeCFD32(f.strXMLpath);
                dlleFac.ComprobanteComplemento myComplemento = myComprobante.Complemento;
                XmlAttributeCollection myTFD = myComplemento.Any[0].Attributes;



                string strUUID = myTFD.GetNamedItem("UUID").Value;
                string strSello = myTFD.GetNamedItem("SelloCFD").Value;
                string dtmFechaTimbrado = myTFD.GetNamedItem("SelloCFD").Value;
                string SelloSAT = myTFD.GetNamedItem("SelloSAT").Value;


                string strQRCode = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + strUUID +
                                                      "&re=" + myComprobante.Emisor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                                      "&rr=" + myComprobante.Receptor.Rfc.Replace("Ñ", "N").Replace("ñ", "n") +
                                                      "&tt=" + myComprobante.Total.ToString("#0.000000").PadLeft(17, '0') +
                                                      "&fe=" + strSello.Substring(strSello.Length - 8, 8);


                string myCadenaTFD;

                //   myUUID + "|" +
                //                        FechaTimbrado + "|" +
                //                        SelloCFD + "|" +
                //                        NoCertificadoSAT +
                //             


                myCadenaTFD = "||1.1|" +
                                                   strUUID + "|" +
                                                   dtmFechaTimbrado + "|" +
                                                   strSello + "|" +
                                                   myTFD.GetNamedItem("NoCertificadoSAT").Value +
                                                   "||";


                myComp.UUID = strUUID.Trim();
                myComp.FechaTimbrado = myTFD.GetNamedItem("FechaTimbrado").Value;
                myComp.NoCertificadoSAT = myTFD.GetNamedItem("NoCertificadoSAT").Value;
                myComp.SelloCFD = strSello.Substring(0, strSello.Length / 2) + "\n" + strSello.Substring(strSello.Length / 2, strSello.Length / 2);
                myComp.SelloSAT = SelloSAT.Substring(0, SelloSAT.Length / 2) + "\n" + SelloSAT.Substring(SelloSAT.Length / 2, SelloSAT.Length / 2);

                myComp.TipoComprobante = "FACTURA";
                myComp.CadenaTFD = myCadenaTFD;
                myComp.CantidadLetra = ConvertidorNumeroLetra.NumeroALetras(myComprobante.Total.ToString(), "PESOS");
                myComp.Encabezado = "";
                myComp.Observaciones = f.strObervaciones;
                myComp.ImpuestosAdicionales = "";

                //    myComp.Origen = "";
                //   myComp.RecogerEn = recogerEn;

                //    myComp.Destino = destino;
                //    myComp.Destinatario = destinatario;
                //    myComp.RfcDestinatario = rfcDestinatario;
                //    myComp.DomicilioDestinatario = domicilioDestinatario;
                //    myComp.EntregarEn = entregarEn;

                generateXMLCFD20Complemento(myComp);




                getQRCode(strQRCode, f.strFolio, f.strProveedor, true);

                string pdfave = myf.createPDF30Re(f.intID_Tipo_CFD, f.CFD.strDescripcion,
                                     f.Empresa.strDirectorioXML,
                                     f.Empresa.strDirectorioPDF,
                                     f.Empresa.strRFC,
                                     f.Clientes.strRFC,
                                     f.CFD.templateReportH,
                                      f.CFD.templateReport,
                                     f.strXMLpath,
                                     true);
                Factura factura = db.Factura.SingleOrDefault(fac => fac.intID == f.intID);
                factura.strPDFpath = pdfave;
                db.SaveChanges();
                buscar();
                MessageBox.Show("El PDF se genero con exito!");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error genrar pdf " + ex);


            }

        }


        private string ExecuteCommandSync(object command)
        {
            string result = "";

            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                //MessageBox.Show(result);
            }
            catch (Exception objException)
            {
                // Log the exception
            }

            return result;
        }
        public XmlTextWriter generateXMLCFD20Complemento(Complemento myComp)
        {

            //  XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();



            XmlTextWriter xmlTextWriter = new XmlTextWriter("c:\\myfacturae\\cad.xml", Encoding.UTF8);

            xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
            XmlSerializer xs = new XmlSerializer(typeof(Complemento));

            xs.Serialize(xmlTextWriter, myComp, null);
            xmlTextWriter.Close();
            return xmlTextWriter;

        }

        public string PdfStampInExistingFile(string dirPdfEntrada)
        {

            string urlSalida = dirPdfEntrada.Replace(".pdf", "");

            urlSalida = urlSalida + "_cancelado.pdf";

            using (Stream inputPdfStream = new FileStream(dirPdfEntrada.Replace("_cancelado.pdf", ""), FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream inputImageStream = new FileStream(@"C:\MyFacturaE\cancelado.png", FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream outputPdfStream = new FileStream(urlSalida, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var reader = new PdfReader(inputPdfStream);
                var stamper = new PdfStamper(reader, outputPdfStream);
                var pdfContentByte = stamper.GetOverContent(1);

                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
                //image.SetAbsolutePosition(70f, 70f);
                image.SetAbsolutePosition((PageSize.A4.Width - image.ScaledWidth) / 2, (PageSize.A4.Height - image.ScaledHeight) / 2);

                pdfContentByte.AddImage(image);
                stamper.Close();
            }




            return urlSalida;


        }
     
    }
}
