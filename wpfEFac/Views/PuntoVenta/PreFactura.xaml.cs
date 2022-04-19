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
using System.Windows.Shapes;
using wpfEFac.Models;
using wpfEFac.Views.General;
using wpfEFac.Helpers;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace wpfEFac.Views.PuntoVenta
{
    /// <summary>
    /// Interaction logic for NuevaFacturaWindow.xaml
    /// </summary>
    public partial class PreFactura : Page
    {
        private PreFacturaViewModel pfvm;
        private const string whiteSpace = " ";
        public bool IsEditMode { get; set; }
        private ObservableCollection<CarritoComprasEntry> conceptos;
        private int intID;
        private string strSerie;
        private string uuidSave;
        private string strFolio;
        private Models.Empresa empresa;
        private Models.Clientes clientes;
        private string strProveedor;
        private string strNumero;
        private string strNumeroContrato;
        private string intEstimacion;
        string strUsoCfdi = "G03";
        string strRegimenFiscal = "601";
        private System.Data.Objects.DataClasses.EntityCollection<Detalle_Factura> entityCollection;
        //public System.Data.Objects.DataClasses.EntityCollection<Traslados> traslados;
        private int intTipoComprobante;
        private string strRetencionIva;
        private string strRetencionIsr;
        private string jsonString = "";
        private string strTXT = "";
        public PreFactura()
        {
            InitializeComponent();
            pfvm = new PreFacturaViewModel();
            conceptos = new ObservableCollection<CarritoComprasEntry>();

            //LoadSerieAndFolio();

            dtgConceptos.ItemsSource = conceptos;
            conceptos.CollectionChanged += conceptos_CollectionChanged;

            // txbFecha.Text = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss");
        }


        public PreFactura(int intIdTipoComprobante)
        {
            InitializeComponent();
            pfvm = new PreFacturaViewModel();
            conceptos = new ObservableCollection<CarritoComprasEntry>();

            LoadSerieAndFolio(intIdTipoComprobante);

            dtgConceptos.ItemsSource = conceptos;
            conceptos.CollectionChanged += conceptos_CollectionChanged;

           // txbFecha.Text = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss");
            this.intTipoComprobante = intIdTipoComprobante;
            txtDivisa.Text = "MXN";

            
            eFacDBEntities mydb = new eFacDBEntities();

            
            if (this.intTipoComprobante == 1)
        
            {

                grpDatosFiscales.Header = "F A C T U R A";
                
                

              
            }

            if (this.intTipoComprobante == 2) 
            {
                grpDatosFiscales.Header = "N O T A   D E   C R E D I T O";
                
            }

            if (this.intTipoComprobante == 3) 
            {
                grpDatosFiscales.Header = "N O T A   D E   C A R G O";
                
              
            }
            if (this.intTipoComprobante == 4)
            {
                grpDatosFiscales.Header = "R E C I B O   D E   C O M I S I O N";
                
              
            }

            if (this.intTipoComprobante == 5)
            {
                grpDatosFiscales.Header = "C A R T A  P O R T E";
                
                grpDestino.Visibility = System.Windows.Visibility.Visible;
                lblRecogerEn.Visibility = System.Windows.Visibility.Visible;
                lblOrigen.Visibility = System.Windows.Visibility.Visible;
                txtRecogerEn.Visibility = System.Windows.Visibility.Visible;
                txtOrigen.Visibility = System.Windows.Visibility.Visible;
                
                lblEncabezado.Text = "VALOR UNIT. CUOTA CONV. POR TON. O CARGA FRAC.";
                lblObservaciones.Text = "VALOR DECLARADO";
                lblObservacionesAdicionales.Text = "OBSERVACIONES ADICIONALES";

            }

            if (this.intTipoComprobante == 6)
            {
                grpDestino.Visibility = System.Windows.Visibility.Visible;
                lblRecogerEn.Visibility = System.Windows.Visibility.Visible;
                lblOrigen.Visibility = System.Windows.Visibility.Visible;
                txtRecogerEn.Visibility = System.Windows.Visibility.Visible;
                txtOrigen.Visibility = System.Windows.Visibility.Visible;

                grpDatosFiscales.Header = "O R D E N   D E   C A R G A";
                
                lblRetIsr.Text = "Ret ISR";
                lblTotal.Text = "Total";

            }
            if (this.intTipoComprobante == 7)
            {
                grpDatosFiscales.Header = "R E M I S I O N";
                
                lblRetIsr.Text = "Ret ISR";
                lblTotal.Text = "Total";

            }

            
            
        }

        public PreFactura(int intID, string strSerie, string strFolio, Models.Empresa empresa,
            Models.Clientes clientes, string strProveedor, string strNumero,
            string strNumeroContrato, string intEstimaion, string strObservaciones,
            System.Data.Objects.DataClasses.EntityCollection<Detalle_Factura> conceptos,
            Factura f)
        {
            InitializeComponent();
            pfvm = new PreFacturaViewModel();

            LoadSerieAndFolio(f.intID_Tipo_CFD);
            this.conceptos = new ObservableCollection<CarritoComprasEntry>();
            dtgConceptos.ItemsSource = this.conceptos;

            if (f.Clientes.idAddenda > 0)
            {
                dtgAddenda.Visibility = System.Windows.Visibility.Visible;
                getAddendaFactura(f.intID);
                isAddenda = true;
            }
            else
                dtgAddenda.Visibility = System.Windows.Visibility.Collapsed;


            xpnDetalleFactura.Width = 600;
            xpnAddenda.Visibility = System.Windows.Visibility.Visible;
            xpnAddenda.Width = 450;


            this.conceptos.CollectionChanged += conceptos_CollectionChanged;
            this.intTipoComprobante = f.intID_Tipo_CFD;
            this.IsEditMode = true;
            // TODO: Complete member initialization
            this.intID = intID;
            this.strSerie = strSerie;
            this.strFolio = strFolio;



            //
            this.empresa = empresa;
            this.clientes = clientes;
            this.strProveedor = strProveedor;
            this.strNumero = strNumero;
            this.strNumeroContrato = strNumeroContrato;
            this.intEstimacion = intEstimaion;

            this.txtEncabezado.Text = strObservaciones;
            this.txtObservaciones.Text = strProveedor;
            this.txtImpuestosAdicionales.Text = strNumero;

            this.txtFolioSearch.Text = f.Origen;
            this.txtRecogerEn.Text = f.RecogerEn;
            this.txtDestino.Text = f.Destino;
            this.txtDestinatario.Text = f.Destinatario;
            this.txtRfcDestinatario.Text = f.rfcDestinatario;
            this.txtDomicilioDestinatario.Text = f.domicilioDestinatario;
            this.txtEntregarEn.Text = f.EntregarEn;
            strTXT = f.strCadenaOriginal;

            this.entityCollection = conceptos;
            this.txtSubtotal.Text = f.dcmSubTotal.ToString();
            this.txtIva.Text = f.dcmIVA.ToString();
            this.txtTotal.Text = f.dcmTotal.ToString();




            if (f.intEstimacion.Equals("G01"))
                cmbUsoCfdi.SelectedIndex = 0;
            if (f.intEstimacion.Equals("G02"))
                cmbUsoCfdi.SelectedIndex = 1;
            if (f.intEstimacion.Equals("G03"))
                cmbUsoCfdi.SelectedIndex = 2;
            if (f.intEstimacion.Equals("I01"))
                cmbUsoCfdi.SelectedIndex = 3;
            if (f.intEstimacion.Equals("I02"))
                cmbUsoCfdi.SelectedIndex = 4;
            if (f.intEstimacion.Equals("I03"))
                cmbUsoCfdi.SelectedIndex = 5;
            if (f.intEstimacion.Equals("I04"))
                cmbUsoCfdi.SelectedIndex = 6;
            if (f.intEstimacion.Equals("I05"))
                cmbUsoCfdi.SelectedIndex = 7;
            if (f.intEstimacion.Equals("I06"))
                cmbUsoCfdi.SelectedIndex = 8;
            if (f.intEstimacion.Equals("I07"))
                cmbUsoCfdi.SelectedIndex = 9;
            if (f.intEstimacion.Equals("I08"))
                cmbUsoCfdi.SelectedIndex = 10;
            if (f.intEstimacion.Equals("D01"))
                cmbUsoCfdi.SelectedIndex = 11;
            if (f.intEstimacion.Equals("D02"))
                cmbUsoCfdi.SelectedIndex = 12;
            if (f.intEstimacion.Equals("D03"))
                cmbUsoCfdi.SelectedIndex = 13;
            if (f.intEstimacion.Equals("D04"))
                cmbUsoCfdi.SelectedIndex = 14;
            if (f.intEstimacion.Equals("D05"))
                cmbUsoCfdi.SelectedIndex = 15;
            if (f.intEstimacion.Equals("D06"))
                cmbUsoCfdi.SelectedIndex = 16;
            if (f.intEstimacion.Equals("D07"))
                cmbUsoCfdi.SelectedIndex = 17;
            if (f.intEstimacion.Equals("D08"))
                cmbUsoCfdi.SelectedIndex = 18;
            if (f.intEstimacion.Equals("D09"))
                cmbUsoCfdi.SelectedIndex = 19;
            if (f.intEstimacion.Equals("D10"))
                cmbUsoCfdi.SelectedIndex = 20;
            if (f.intEstimacion.Equals("P01"))
                cmbUsoCfdi.SelectedIndex = 21;

           // strUsoCfdi = f.intEstimacion;
            strRegimenFiscal = f.strNumeroContrato;
            /*
             * 
             */
            txtSerie.Text = f.strSerie;
            txtFolio.Text = f.strFolio;
            if (f.MetodoPago.Equals("PUE"))
                cmbMetodoPago.SelectedIndex = 0;
            if (f.MetodoPago.Equals("PPD"))
                cmbMetodoPago.SelectedIndex = 1;
            //txtFormaPago.Text = f.Clientes.strTelefono;//f.strForma_Pago;
            txtCondicionesPago.Text = f.Clientes.strGiro; //f.CondPago;
            
            //cmbFormaPago.Text = f.Clientes.strContacto; //f.MetodoPago;

            if (f.strForma_Pago.Equals("01"))
                cmbFormaPago.SelectedIndex = 0;
            if (f.strForma_Pago.Equals("02"))
                cmbFormaPago.SelectedIndex = 1;
            if (f.strForma_Pago.Equals("03"))
                cmbFormaPago.SelectedIndex = 2;
            if (f.strForma_Pago.Equals("04"))
                cmbFormaPago.SelectedIndex = 3;
            if (f.strForma_Pago.Equals("05"))
                cmbFormaPago.SelectedIndex = 4;
            if (f.strForma_Pago.Equals("06"))
                cmbFormaPago.SelectedIndex = 5;
            if (f.strForma_Pago.Equals("08"))
                cmbFormaPago.SelectedIndex = 6;
            if (f.strForma_Pago.Equals("12"))
                cmbFormaPago.SelectedIndex = 7;
            if (f.strForma_Pago.Equals("13"))
                cmbFormaPago.SelectedIndex = 8;
            if (f.strForma_Pago.Equals("14"))
                cmbFormaPago.SelectedIndex = 9;
            if (f.strForma_Pago.Equals("15"))
                cmbFormaPago.SelectedIndex = 10;
            if (f.strForma_Pago.Equals("17"))
                cmbFormaPago.SelectedIndex = 11;
            if (f.strForma_Pago.Equals("23"))
                cmbFormaPago.SelectedIndex = 12;
            if (f.strForma_Pago.Equals("24"))
                cmbFormaPago.SelectedIndex = 13;
            if (f.strForma_Pago.Equals("25"))
                cmbFormaPago.SelectedIndex = 14;
            if (f.strForma_Pago.Equals("26"))
                cmbFormaPago.SelectedIndex = 15;
            if (f.strForma_Pago.Equals("27"))
                cmbFormaPago.SelectedIndex = 16;
            if (f.strForma_Pago.Equals("28"))
                cmbFormaPago.SelectedIndex = 17;
            if (f.strForma_Pago.Equals("29"))
                cmbFormaPago.SelectedIndex = 18;
            if (f.strForma_Pago.Equals("30"))
                cmbFormaPago.SelectedIndex = 19;
            if (f.strForma_Pago.Equals("31"))
                cmbFormaPago.SelectedIndex = 20;
            if (f.strForma_Pago.Equals("99"))
                cmbFormaPago.SelectedIndex = 21;


            txtMotivoDescuento.Text = f.MotivoDesc;
            txtDivisa.Text = f.Divisa;
            //txtTipoCambio.Text = f.TipoCambio.Value.ToString("#0.000000");

            /*
             * 
             */

            if (this.intTipoComprobante == 1) 
            {
                grpDatosFiscales.Header = "F A C T U R A";
                

            }

            if (this.intTipoComprobante == 2) 
            {
                grpDatosFiscales.Header = "N O T A   D E   C R E D I T O";
                

            }

            if (this.intTipoComprobante == 3)
            {
                grpDatosFiscales.Header = "A R R E N D A M I E N T O";
                

            }
            if (this.intTipoComprobante == 4)
            {
                grpDatosFiscales.Header = "H O N O R A R I O S";
                

            }
            if (this.intTipoComprobante == 5)
            {
                grpDatosFiscales.Header = "C A R T A  P O R T E";
                grpDestino.Visibility = System.Windows.Visibility.Visible;
                lblRecogerEn.Visibility = System.Windows.Visibility.Visible;
                lblOrigen.Visibility = System.Windows.Visibility.Visible;
                txtRecogerEn.Visibility = System.Windows.Visibility.Visible;
                txtOrigen.Visibility = System.Windows.Visibility.Visible;

                lblEncabezado.Text = "VALOR UNIT. CUOTA CONV. POR TON. O CARGA FRAC.";
                lblObservaciones.Text = "VALOR DECLARADO";
                lblObservacionesAdicionales.Text = "OBSERVACIONES ADICIONALES";

            }
            if (this.intTipoComprobante == 6)
            {
                grpDestino.Visibility = System.Windows.Visibility.Visible;
                lblRecogerEn.Visibility = System.Windows.Visibility.Visible;
                lblOrigen.Visibility = System.Windows.Visibility.Visible;
                txtRecogerEn.Visibility = System.Windows.Visibility.Visible;
                txtOrigen.Visibility = System.Windows.Visibility.Visible;

                grpDatosFiscales.Header = "O R D E N   D E   C A R G A";
                

            }
            if (this.intTipoComprobante == 7)
            {
                grpDatosFiscales.Header = "R E M I S I O N";
                
            }

            

        }

        private void LoadSerieAndFolio(int TipoComprobante)
        {
            
            try
            {

                eFacDBEntities mydb = new eFacDBEntities();
                Models.CFD MyCFD = mydb.CFD.FirstOrDefault(f => f.intID == TipoComprobante);
                String Serie = MyCFD.Folios.strSerie;
                int Folio = MyCFD.Folios.intFolioActual;
                txtSerie.Text = Serie;
                txtFolio.Text = Folio.ToString();

            }
            catch (Exception)
            {
                txtSerie.Text = "";
                txtFolio.Text = "";
            }
        }

        public void conceptos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (conceptos.Count>0)
            {
                CalcularTotal();
                /*
                if (this.intTipoComprobante == 1) CalcularTotal();
                if (this.intTipoComprobante == 2) CalcularTotal();
                
                if ((this.intTipoComprobante == 3) )   CalcularTotal_RecHon();
                if ((this.intTipoComprobante == 4)) CalcularTotal_RecHon();

                if ((this.intTipoComprobante == 5)) CalcularTotal_RecHon();

                

                if ((this.intTipoComprobante == 6) ) CalcularTotal();
                if ((this.intTipoComprobante == 7)) CalcularTotal();
                */
            }
            else
            {
                //txtNumeroLetra.Text =
                
            }
            ValidarConceptos();
        }

        private void CalcularTotal()
        {
            try
            {
                decimal importe = 0;
                decimal descuento = 0;
                decimal subtotal = 0;
                decimal iva = 0;
                decimal total = 0;
                decimal retIva = 0;
                decimal retIsr = 0;
                decimal retIeps = 0;
                decimal granTotal = 0;
                decimal dcmImpLoca = 0;


                txtRetIsr.Text = "0.00";
                txtRetIva.Text = "0.00";

                foreach (var item in conceptos)
                {
                    decimal importePartida = (Decimal.Parse(item.FormatImporte.ToString()));
                    //importe += (item.PrecioUnitario * item.Cantidad);
                    importe += importePartida; //(Decimal.Parse(item.FormatImporte.ToString()));
                    descuento += item.Descuento;

                    iva += (importePartida * item.IVA);
                    retIva += (importePartida * item.retIVA);
                    retIsr += (importePartida * item.retISR);
                    retIeps += (importePartida * item.retIEPS);
                }

                dcmImpLoca = decimal.Parse(txtMontoImp.Text);
                subtotal = importe - descuento;
                total = subtotal + iva;
                granTotal = total - (retIva + retIsr + retIeps + dcmImpLoca);

                txtImporte.Text = importe.ToString("N");
                txtDescuento.Text = descuento.ToString("N");

                txtSubtotal.Text = subtotal.ToString("N");
                txtIva.Text = iva.ToString("N");
                txtTotal.Text = total.ToString("N");


                txtRetIva.Text = retIva.ToString("N");
                txtRetIsr.Text = retIsr.ToString("N");
                txtRetIeps.Text = retIeps.ToString("N");

                txtGranTotal.Text = granTotal.ToString("N");



                //txtTotal.Text =total.ToString("N");

                ShowImporteConLetra(txtTotal.Text, "PESOS");
            }
            catch (Exception ex) { }
        }


        private void CalcularTotal_RecHon()
        {
            decimal importe = 0;
            decimal iva = 0;
            decimal subtotal = 0;

            decimal retIva = 0;
            decimal retIsr = 0;
            decimal total = 0;
            
            foreach (var item in conceptos)
            {
                importe += item.Importe;
                
            }

            iva = importe * (decimal)0.16;
            subtotal = importe + iva;

            if (this.strRetencionIva == "Si")
            {
                 retIva = importe * (decimal)0.04;
               // retIva = importe * (decimal)0.10666666;
            }
            else
                retIva = 0;

            if (this.strRetencionIsr == "Si")
                retIsr = importe * (decimal)0.10;
            else
                retIsr = 0;
            
            total = subtotal - (retIva + retIsr);
            
           // total = subtotal;


            txtSubtotal.Text = importe.ToString("N");
            txtIva.Text = iva.ToString("N");
            txtIva.Text = subtotal.ToString("N");

            txtRetIva.Text = retIva.ToString("N");
            txtRetIsr.Text = retIsr.ToString("N");
            
            

            txtTotal.Text = total.ToString("N");

            ShowImporteConLetra(txtTotal.Text, "PESOS");
        }
        private void ShowImporteConLetra(string numero, string divisa)
        {
            //txtNumeroLetra.Text = ConvertidorNumeroLetra.NumeroALetras(numero, divisa);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsEditMode)
            {
                ShowEmpresa();
                GetClientes();    
            }
            else
            {
                ShowEmpresa(empresa);
                GetClientes(clientes);
                ShowConceptos();
                ShowTraslados();
                ShowAdds();
            }
        }

        private void ShowTraslados()
        {
            //throw new NotImplementedException();
        }

        private void ShowAdds()
        {
            //txbSerie.Text = strSerie;
            
            //txbFolio.Text = strFolio;
            CalcularTotal();

            //txtObservaciones.Text = strObservaciones;
            /*
            if (this.intTipoComprobante==1)   CalcularTotal();
            if (this.intTipoComprobante == 2) CalcularTotal();


            if ((this.intTipoComprobante == 3)) CalcularTotal_RecHon();


            if ((this.intTipoComprobante == 4)) CalcularTotal_RecHon();

            if (this.intTipoComprobante == 5) CalcularTotal_RecHon();
            if (this.intTipoComprobante == 6) CalcularTotal();
            if (this.intTipoComprobante == 7) CalcularTotal();
             */
        }

        private void ShowConceptos()
        {
            foreach (var item in entityCollection)
            {
                CarritoComprasEntry entry = new CarritoComprasEntry();
                entry.Cantidad = item.dcmCantidad;
                entry.Unidad = item.strUnidad;
                entry.Codigo = item.Productos.strCodigo;
                entry.intID = item.Productos.intID;
                entry.Nombre = item.strConcepto;
                entry.PrecioUnitario = item.dcmPrecioUnitario;
                entry.FormatPrecioUnitario = item.dcmPrecioUnitario.ToString("N");
                
                entry.IVA = item.dcmIVA.Value;
                entry.retIVA = item.retIVA.Value;
                entry.retISR = item.retISR.Value;
                entry.retIEPS = item.retIEPS.Value;
                entry.Descuento = item.dcmDescuento;
                entry.FormatDescuento = item.dcmDescuento + " %";
                entry.Importe = item.dcmImporte;
                entry.FormatImporte = item.dcmImporte.ToString("N");

                conceptos.Add(entry);
            }
        }

        private void ShowEmpresa(Models.Empresa empresa)
        {
            var emp = empresa;
            /*
            txbNombreEmpresa.Text = emp.strRazonSocial;
            txbRFC.Text = emp.strRFC;

            var direccion = pfvm.GetDireccionEmpresa(emp.intID);

            txbDomicilio.Text = "Calle:" + direccion.strCalle + whiteSpace + "Numero: "
                + direccion.strNoInterior + whiteSpace + direccion.strNoExterior + whiteSpace
                + "Colonia: " + direccion.strColonia + whiteSpace +
                "CP:" + direccion.strCodigoPostal + whiteSpace + direccion.strPoblacionLocalidad +
                whiteSpace + direccion.strMunicipio + whiteSpace + direccion.Estado.strNombreEstado +
                whiteSpace + direccion.Paises.strNombrePais;
             */
        }

        private void ShowEmpresa()
        {
            try
            {
                /*
                var emp = pfvm.GetEmpresa(Convert.ToInt32(App.Current.Properties["idUsuario"]));
             
                txbNombreEmpresa.Text = emp.strRazonSocial;
                txbRFC.Text = emp.strRFC;

                var direccion = pfvm.GetDireccionEmpresa(emp.intID);

                txbDomicilio.Text = "Calle:" + direccion.strCalle + whiteSpace + "Numero: "
                    + direccion.strNoInterior + whiteSpace + direccion.strNoExterior + whiteSpace
                    + "Colonia: " + direccion.strColonia + whiteSpace +
                    "CP:" + direccion.strCodigoPostal + whiteSpace + direccion.strPoblacionLocalidad +
                    whiteSpace + direccion.strMunicipio + whiteSpace + direccion.Estado.strNombreEstado +
                    whiteSpace + direccion.Paises.strNombrePais;
                 */
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al cagar la empresa intentelo mas tarde (error: " + error.Message + ")");
            }
            
        }

        private void GetClientes(Models.Clientes clientes)
        {
            GetClientes();
            atcNombreCliente.Text = clientes.strNombreComercial;
            atcRFC.Text = clientes.strRFC;
            atcNombreCliente.SelectedItem = clientes;
        }

        private void GetClientes()
        {
            var clientes = pfvm.GetClientes();
            atcNombreCliente.ItemsSource = clientes;
            atcRFC.ItemsSource = clientes;
        }

        private void btnAgregarCarrito_Click(object sender, RoutedEventArgs e)
        {
            AddProductoWindow carrito = new AddProductoWindow();
            carrito.Show();
            carrito.EntryAdd += (s, args) =>
            {
                conceptos.Add(carrito.entry);
            };
        }

        bool isAddenda = false;

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarDatos()) 
            {
                if (!IsEditMode)
                {
                    try
                    {

                        if (chbAddImpLoc.IsChecked == true)
                        {

                            
                            fillImpLocal();

                        }


                        if (isAddenda) getConceptosAddenda();

                        CFDModels cfd = new CFDModels();
                        Models.Empresa emisor;
                        Models.Clientes receptor;
                        Direcciones_Fiscales direccionEmisor;
                        Direcciones_Fiscales direccionReceptor;
                        GetEncabezadoCFD(out emisor, out receptor, out direccionEmisor, out direccionReceptor);
                        dlleFac.ComprobanteFiscalDigital co = new dlleFac.ComprobanteFiscalDigital();
                        List<dlleFac.Concepto> conceptosDll = new List<dlleFac.Concepto>();
                        List<ConceptoPreFactura> conceptosPrefactura = new List<ConceptoPreFactura>();

                        RetriveComprobanteFiscalDigital(this.intTipoComprobante, cfd, emisor, receptor, direccionEmisor, direccionReceptor, co, conceptosDll, conceptosPrefactura);

                        string subtotal = "";
                        string descuento = "";
                        string iva = "";
                        string total = "";
                        string retIva = "";
                        string retIsr = "";
                        string retIeps = "";

                            descuento = txtDescuento.Text;
                            
                            subtotal = txtSubtotal.Text;
                        
                            iva = txtIva.Text;
                            total = txtGranTotal.Text;

                            retIva = txtRetIva.Text;
                            retIsr = txtRetIsr.Text;
                            retIeps = txtRetIeps.Text;
                            
                        

                        if (cfd.SaveFactura(this.intTipoComprobante,
                            emisor.intID,
                            co.Serie,
                            co.Folio,
                            DateTime.Parse(co.Fecha.Replace("T", " ")),
                            Convert.ToInt32(App.Current.Properties["idUsuario"]),
                            receptor.intID,
                            cmbFormaPago.Text.Substring(0, 2),//co.FormaPago,
                            txtEncabezado.Text,
                            decimal.Parse(subtotal),
                            decimal.Parse(descuento),
                            decimal.Parse(iva),
                            decimal.Parse(total),
                            txtObservaciones.Text,
                            "PENDIENTE",
                            string.Empty,
                            cmbUsoCfdi.Text.Substring(0, 3), //string.Empty,
                            emisor.CFD.First().intID,
                            jsonString,
                            conceptosPrefactura,
                            decimal.Parse(retIva),
                            decimal.Parse(retIsr),
                            decimal.Parse(retIeps),
                            cmbTipoRelacion.Text.Substring(0, 2),//txtCondicionesPago.Text,
                            cmbMetodoPago.Text.Substring(0, 3),
                            txtMotivoDescuento.Text,
                            txtDivisa.Text,
                            decimal.Parse("1.0"),
                            txtFolioSearch.Text,
                            txtRecogerEn.Text,
                            txtDestino.Text,
                            txtDestinatario.Text,
                            txtRfcDestinatario.Text,
                            txtDomicilioDestinatario.Text,
                            txtEntregarEn.Text, myAddenda
                            
                            ))
                        {
                            
                            MessageBox.Show("Guardado con exito", "Guardar", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.NavigationService.Navigate(new DefaultPuntoVenta());
                        }
                        else
                        {
                            MessageBox.Show("Lo sentimos ocurrio un error intentelo de nuevo", "Guardar",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Lo sentimos ocurrio un error inesperado: " + error.Message, "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    try
                    {

                        if (isAddenda) getConceptosAddenda();

                        CFDModels cfd = new CFDModels();
                        Models.Empresa emisor;
                        Models.Clientes receptor;
                        Direcciones_Fiscales direccionEmisor;
                        Direcciones_Fiscales direccionReceptor;
                        GetEncabezadoCFD(out emisor, out receptor, out direccionEmisor, out direccionReceptor);
                        dlleFac.ComprobanteFiscalDigital co = new dlleFac.ComprobanteFiscalDigital();
                        List<dlleFac.Concepto> conceptosDll = new List<dlleFac.Concepto>();
                        List<ConceptoPreFactura> conceptosPrefactura = new List<ConceptoPreFactura>();
                       
                        RetriveComprobanteFiscalDigital(this.intTipoComprobante, cfd, emisor, receptor, direccionEmisor, direccionReceptor, co, conceptosDll, conceptosPrefactura);

                        string subtotal = "";
                        string descuento = "";
                        string iva = "";
                        string total = "";
                        string retIva = "";
                        string retIsr = "";
                        string retIeps = "";

                        descuento = txtDescuento.Text;

                        subtotal = txtSubtotal.Text;

                        iva = txtIva.Text;
                        total = txtGranTotal.Text;

                        retIva = txtRetIva.Text;
                        retIsr = txtRetIsr.Text;
                        retIeps = txtRetIeps.Text;
                        

                        

                        if (cfd.UpdateFactura(intID, this.intTipoComprobante,
                            emisor.intID,
                            co.Serie,
                            co.Folio,
                            DateTime.Parse(co.Fecha.Replace("T", " ")),
                            Convert.ToInt32(App.Current.Properties["idUsuario"]),
                            receptor.intID,
                            cmbFormaPago.Text.Substring(0,2),
                            txtEncabezado.Text,
                            decimal.Parse(subtotal),
                            decimal.Parse(descuento),
                            decimal.Parse(iva),
                            decimal.Parse(total),
                            txtObservaciones.Text,
                            "PENDIENTE",
                            strRegimenFiscal,
                            cmbUsoCfdi.Text.Substring(0, 3),
                            emisor.CFD.First().intID,
                            strTXT,
                            conceptosPrefactura,
                            decimal.Parse(retIva),
                            decimal.Parse(retIsr),
                            decimal.Parse(retIeps),
                            cmbTipoRelacion.Text.Substring(0, 2),//txtCondicionesPago.Text,
                            cmbMetodoPago.Text.Substring(0,3),
                            txtMotivoDescuento.Text,
                            txtDivisa.Text,
                            decimal.Parse("1.0"),
                            txtFolioSearch.Text,
                            txtRecogerEn.Text,
                            txtDestino.Text,
                            txtDestinatario.Text,
                            txtRfcDestinatario.Text,
                            txtDomicilioDestinatario.Text,
                            txtEntregarEn.Text, myAddenda
                            
                            
                           ))
                        {
                            MessageBox.Show("Guardado con exito", "Guardar", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.NavigationService.Navigate(new DefaultPuntoVenta());
                        }
                        else
                        {
                            MessageBox.Show("Lo sentimos ocurrio un error intentelo de nuevo", "Guardar",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception exp)
                    {

                    }
                }
            }
        }


        List<AddendaEntry> myAddenda = new List<AddendaEntry>();


        private void getAddendaFactura(int idFactura)
        {

            eFacDBEntities db = new eFacDBEntities();
            List<Addendas> myDicAddenda = db.Addendas.Where(a => a.idFactura == idFactura).ToList();

            List<AddendaEntry> myListAddenda = new List<AddendaEntry>();


            foreach (Addendas item in myDicAddenda)
            {
                myListAddenda.Add(new AddendaEntry()
                {
                    idAddenda = item.idAddenda,
                    idPos = item.idPos,
                    Descripcion = item.Descripcion,
                    Default = item.Default
                }
                );
            }

            dtgAddenda.ItemsSource = myListAddenda;
        }

        private void getAddendaDefault(int idAddenda)
        {

            eFacDBEntities db = new eFacDBEntities();
            List<DicAddenda> myDicAddenda = db.DicAddenda.Where(a => a.idAddenda == idAddenda).ToList();

            List<AddendaEntry> myListAddenda = new List<AddendaEntry>();

            foreach (DicAddenda item in myDicAddenda)
            {
                myListAddenda.Add(new AddendaEntry()
                {
                    idAddenda = item.idAddenda,
                    idPos = item.idPos,
                    Descripcion = item.Descripcion,
                    Default = item.Default
                }
                );
            }

            dtgAddenda.ItemsSource = myListAddenda;
        }

        private void getConceptosAddenda()
        {

            foreach (var item in dtgAddenda.Items)
            {
                AddendaEntry concepto = item as AddendaEntry;
                if (concepto != null)
                {
                    myAddenda.Add(new AddendaEntry()
                    {
                        idAddenda = concepto.idAddenda,
                        idPos = concepto.idPos,
                        Descripcion = concepto.Descripcion,
                        Default = concepto.Default
                    });
                }


            }
        }


        private void RetriveComprobanteFiscalDigital(int intTipoComprobante, CFDModels cfd, Models.Empresa emisor, Models.Clientes receptor, Direcciones_Fiscales direccionEmisor, Direcciones_Fiscales direccionReceptor, dlleFac.ComprobanteFiscalDigital co, List<dlleFac.Concepto> conceptos, List<ConceptoPreFactura> conceptoPrefactura)
        {
            GetConceptosFromGrid(conceptos, conceptoPrefactura);

            //dlleFac.Impuestos impuestos;
            dlleFac.Emisor emisorCFD;
            dlleFac.DomicilioFiscal domicilioEmisor;
            dlleFac.DomicilioFiscal expedidoEn;
            dlleFac.Receptor receptorCFD;
            dlleFac.DomicilioFiscal domicilioFiscalReceptor;

            GetValuesCFD(cfd, emisor, receptor, direccionEmisor, direccionReceptor, co, conceptos, out emisorCFD, out domicilioEmisor, out expedidoEn, out receptorCFD, out domicilioFiscalReceptor);

            //string emisorNumeroAprovacion = emisor.Folios.SingleOrDefault(f => f.chrStatus == "A" && f.intIDtipoCFD == intTipoComprobante).intNumero_Aprovacion.ToString();
            string emisorNumeroAprovacion = emisor.CFD.SingleOrDefault(f => f.intID == intTipoComprobante).Folios.intNumero_Aprovacion.ToString();
            //string emisorAñoAprobacion = emisor.Folios.SingleOrDefault(f => f.chrStatus == "A" && f.intIDtipoCFD == intTipoComprobante).strAño_Aprovacion.ToString();
            string emisorAñoAprobacion = emisor.CFD.SingleOrDefault(f => f.intID == intTipoComprobante).Folios.strAño_Aprovacion.ToString();
            cfd.FillComprobanteFiscal(
                co,
                "3.0",
                txtSerie.Text,
                txtFolio.Text,
                DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                emisorNumeroAprovacion,
                emisorAñoAprobacion, // No HardCode
                emisor.CFD.First().strTipoCFD,
                cmbFormaPago.Text,
                decimal.Parse(txtSubtotal.Text).ToString(),
                decimal.Parse(txtIva.Text).ToString(),
                co.Total = decimal.Parse(txtTotal.Text).ToString(),
                emisorCFD,
                domicilioEmisor,
                expedidoEn,
                receptorCFD,
                domicilioFiscalReceptor,
                conceptos
                
                );
        }

        private void GetValuesCFD(CFDModels cfd, Models.Empresa emisor, Models.Clientes receptor, Direcciones_Fiscales direccionEmisor,
            Direcciones_Fiscales direccionReceptor, dlleFac.ComprobanteFiscalDigital co, List<dlleFac.Concepto> conceptos,
            out dlleFac.Emisor emisorCFD, out dlleFac.DomicilioFiscal domicilioEmisor, 
            out dlleFac.DomicilioFiscal expedidoEn, out dlleFac.Receptor receptorCFD, out dlleFac.DomicilioFiscal domicilioFiscalReceptor)
        {
            //impuestos = new dlleFac.Impuestos();
            
            //impuestos.Traslados = new List<dlleFac.Traslado>();
            
            //impuestos.Retenciones = new List<dlleFac.Retencion>();
            
            
            //decimal totalTraslado = decimal.Parse(txtIVA_Subtotal.Text);
            
            
            //impuestos.TotalTraslados = totalTraslado.ToString();

            //impuestos.TotalRetenido = (decimal.Parse(txtRetIsr.Text.ToString()) + decimal.Parse(txtTotal_RetIva.Text.ToString())).ToString();
            
            decimal tasa = 0;
            decimal importeTotal = 0;

            foreach (var item in dtgConceptos.Items)
            {
                CarritoComprasEntry concepto = item as CarritoComprasEntry;
                decimal conceptoIVA = decimal.Parse(concepto.IVA.ToString());
                decimal importeTraslado = (concepto.Importe * (concepto.IVA / 100));
                decimal totalImpuestoTraslado = decimal.Parse(txtIva.Text);
                tasa = decimal.Parse(concepto.IVA.ToString());
                importeTotal += importeTraslado;
            }

            /*
            dlleFac.Traslado tr = new dlleFac.Traslado();
            tr.TipoImpuesto = "IVA";
            tr.Tasa = tasa.ToString("F");
            tr.Importe = importeTotal.ToString("F");
            tr.TotalImpuestosTraslados = totalTraslado.ToString("F");


            dlleFac.Retencion retIVA = new dlleFac.Retencion();
            retIVA.TipoImpuesto = "IVA";
            retIVA.Importe = txtTotal_RetIva.Text.ToString();


            dlleFac.Retencion retISR = new dlleFac.Retencion();
            retISR.TipoImpuesto = "ISR";
            retISR.Importe = txtRetIsr.Text.ToString();
            

            co.Impuestos = impuestos;

            co.Impuestos.Traslados.Add(tr);
            co.Impuestos.Retenciones.Add(retIVA);
            co.Impuestos.Retenciones.Add(retISR);
            */
            emisorCFD = new dlleFac.Emisor() { RFCEmisor = emisor.strRFC, NombreEmisor = emisor.strRazonSocial };

            domicilioEmisor = new dlleFac.DomicilioFiscal()
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

            expedidoEn = new dlleFac.DomicilioFiscal()
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

            receptorCFD = new dlleFac.Receptor()
            {
                RFCReceptor = receptor.strRFC,
                NombreReceptor = receptor.strRazonSocial
            };

            domicilioFiscalReceptor = new dlleFac.DomicilioFiscal()
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


            cfd.FillComprobanteFiscal(co, "3.0", txtSerie.Text,
                txtFolio.Text,
                DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss"),
                emisor.Folios.First(f => f.chrStatus == "A").intNumero_Aprovacion.ToString(),
                emisor.Folios.First(f => f.chrStatus == "A").strAño_Aprovacion.ToString(), // No HardCode
                emisor.CFD.First().strTipoCFD,
                cmbFormaPago.Text,
                decimal.Parse(txtSubtotal.Text).ToString(),
                decimal.Parse(txtIva.Text).ToString(),
                co.Total = decimal.Parse(txtTotal.Text).ToString(),
                emisorCFD,
                domicilioEmisor,
                expedidoEn,
                receptorCFD,
                domicilioFiscalReceptor,
                conceptos
                );
        }

        private void GetEncabezadoCFD(out Models.Empresa emisor, out Models.Clientes receptor, out Direcciones_Fiscales direccionEmisor, out Direcciones_Fiscales direccionReceptor)
        {
            emisor = pfvm.GetEmpresa(Convert.ToInt32(App.Current.Properties["idUsuario"]));
          //  emisor = (wpfEFac.Models.Clientes)atcNombreCliente1.SelectedItem;
            receptor = (wpfEFac.Models.Clientes)atcNombreCliente.SelectedItem;
            direccionEmisor = pfvm.GetDireccionEmpresa(emisor.intID);
            direccionReceptor = pfvm.GetDireccionCliente(receptor.intID);
        }

        private void GetConceptosFromGrid(List<dlleFac.Concepto> conceptos, List<ConceptoPreFactura> conceptosPrefactura)
        {
            foreach (var item in dtgConceptos.Items)
            {
                CarritoComprasEntry concepto = item as CarritoComprasEntry;

                conceptos.Add(new dlleFac.Concepto()
                {
                    Cantidad = concepto.Cantidad.ToString(),
                    UnidadMedida = concepto.Unidad,
                    NoIdentificacion = concepto.Codigo,
                    Descripcion = concepto.Nombre,
                    Descuento = concepto.Descuento.ToString(),
                    ValorUnitario = concepto.PrecioUnitario.ToString(),
                    //Importe = concepto.Importe.ToString()
                    Importe = concepto.FormatImporte.ToString()
                });

                ConceptoPreFactura conceptoPrefactura =
                                new ConceptoPreFactura();

                conceptoPrefactura.intIdProducto = concepto.intID;
                conceptoPrefactura.intCantidad = concepto.Cantidad;
                conceptoPrefactura.dcmDescuento = decimal.Parse(concepto.Descuento.ToString().Replace("%", string.Empty).Trim());
                conceptoPrefactura.dcmImporte = decimal.Parse(concepto.FormatImporte);
                conceptoPrefactura.strUnidad = concepto.Unidad;
                conceptoPrefactura.strConcepto = concepto.Nombre;
                conceptoPrefactura.dcmPrecioUnitario = concepto.PrecioUnitario;
                conceptoPrefactura.dcmIVA = concepto.IVA;
                conceptoPrefactura.dcmRetIVA = concepto.retIVA;
                conceptoPrefactura.dcmRetISR = concepto.retISR;
                conceptoPrefactura.dcmRetIEPS = concepto.retIEPS;

                conceptoPrefactura.strPartida = string.Empty;

                conceptosPrefactura.Add(conceptoPrefactura);
            }
        }

        private bool ValidarDatos()
        {
            bool cliente = ValidarCliente();
            bool concepto = ValidarConceptos();
            return (cliente && concepto);

        }

        private bool ValidarConceptos()
        {
            if (dtgConceptos.Items.Count > 0) 
            {
                dtgConceptos.BorderBrush = new DataGrid().BorderBrush;
                return true;
            }
            else
            {
                MessageBox.Show("No hay ningun concepto");
                dtgConceptos.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
        }

        private bool ValidarCliente()
        {
            if (atcNombreCliente.SelectedItem != null)
	        {
                atcNombreCliente.BorderBrush = new SolidColorBrush(Colors.Gray);
                return true;
	        }
            else
            {
                MessageBox.Show("No selecciono un cliente");
                atcNombreCliente.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            
        }

        private List<Detalle_Factura> GetConceptosReporte(ItemCollection itemCollection)
        {
            List<Detalle_Factura> result = new List<Detalle_Factura>();

            foreach (var item in itemCollection)
            {
                CarritoComprasEntry concepto = item as CarritoComprasEntry;
                //Thest this should change to the data base

                result.Add(new Detalle_Factura()
                {
                    dcmCantidad = concepto.Cantidad,
                    dcmDescuento = decimal.Parse(concepto.Descuento.ToString().Replace(" %", string.Empty)),
                    dcmImporte = concepto.Importe,
                    strUnidad = concepto.Unidad,
                    strConcepto = concepto.Nombre,
                    dcmPrecioUnitario = concepto.PrecioUnitario,
                    dcmIVA = concepto.IVA
                });
            }

            return result;
        }

        private List<string> GetAttach()
        {
            return new List<string>()
            {
                //"Muestra.pdf",//This has to change to the files generated by the app. 
                //"Muestra.xml"
            };
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

        private void atcRFC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (atcRFC.SelectedItem != null)
            {
                atcNombreCliente.SelectedItem = atcRFC.SelectedItem;
                
                txtDestinatario.Text = atcNombreCliente.Text;

                ShowDireccionCliente(((wpfEFac.Models.Clientes)(atcRFC.SelectedItem)).intID);
            }
        }

        private void atcNombreCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidarCliente();
            if (atcNombreCliente.SelectedItem != null)
            {
                wpfEFac.Models.Clientes myc = ((wpfEFac.Models.Clientes)atcNombreCliente.SelectedItem);
                
                this.strRetencionIva = myc.chrRetencionIVA;
                this.strRetencionIsr = myc.chrRetencionISR;

                ShowAdds();

                atcRFC.SelectedItem = atcNombreCliente.SelectedItem;
                ShowDireccionCliente(((wpfEFac.Models.Clientes)atcNombreCliente.SelectedItem).intID);
            }
        }

        private void ShowDireccionCliente(int idCliente)
        {
            var direccion = pfvm.GetDireccionCliente(idCliente);

            if (direccion.Estado!= null)
            {
                
                txtDomicilioCliente.Text = direccion.strCalle + whiteSpace  
                + direccion.strNoInterior + whiteSpace + direccion.strNoExterior + whiteSpace
                +  direccion.strColonia + whiteSpace + direccion.strPoblacionLocalidad +
                 whiteSpace + direccion.strMunicipio + whiteSpace +
                direccion.Estado.strNombreEstado + whiteSpace +"C.P."+ direccion.strCodigoPostal +
                whiteSpace + direccion.Paises.strNombrePais;

                txtDomicilioDestinatario.Text = txtDomicilioCliente.Text;
            }

        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            BuscarClienteWindow buscarCliente = new BuscarClienteWindow();
            if (buscarCliente.ShowDialog().Value) 
            {
                atcRFC.Text = buscarCliente.RFCCliente;
                txtRfcDestinatario.Text = atcRFC.Text;

                atcRFC.Text = buscarCliente.RFCCliente;
                int idAddenda = ((wpfEFac.Models.Clientes)atcNombreCliente.SelectedItem).idAddenda.Value;
                if (idAddenda > 0)
                {
                    isAddenda = true;
                    getAddendaDefault(idAddenda);
                    xpnDetalleFactura.Width = 550;
                    xpnAddenda.Visibility = System.Windows.Visibility.Visible;
                    xpnAddenda.Width = 380;

                }
                else
                {
                    isAddenda = false;
                    //dtgAddenda.Items.Clear();
                    xpnDetalleFactura.Width = 900;
                    xpnAddenda.Width = 0;
                    xpnAddenda.Visibility = System.Windows.Visibility.Hidden;

                }
            }
        }


        private void EditarEntry_Click(object sender, RoutedEventArgs e)
        {
            if (dtgConceptos.SelectedItem != null)
            {
                AddProductoWindow carrito =
                    new AddProductoWindow((CarritoComprasEntry)dtgConceptos.SelectedItem);
                carrito.Show();
            }
        }

        private void BorrarEntry_Click(object sender, RoutedEventArgs e)
        {
            if (dtgConceptos.SelectedItem!=null)
            {
                conceptos.Remove((CarritoComprasEntry)dtgConceptos.SelectedItem);
                CalcularTotal();
            }
        }

        private void atcNombreCliente_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void atcRFC_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBuscarDestino_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void cmbMetodoPago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void fillImpLocal()
        {

            try
            {
                ImpLocales myImpLocal = new ImpLocales();

                myImpLocal.strImpLocaReten = txtImpLoc.Text;
                myImpLocal.dcmImporteReten = decimal.Parse(txtMontoImp.Text);
                myImpLocal.dcmTasaReten = decimal.Parse(txtTasa.Text);

                jsonString = JsonConvert.SerializeObject(myImpLocal);

            }
            catch (Exception ex)
            {
            }

        }

        private void chbAddImpLoc_Unchecked(object sender, RoutedEventArgs e)
        {
            txbImpLoc.Visibility = System.Windows.Visibility.Collapsed;
            txtImpLoc.Visibility = System.Windows.Visibility.Collapsed;
            txbMonto.Visibility = System.Windows.Visibility.Collapsed;
            txtMontoImp.Visibility = System.Windows.Visibility.Collapsed;
            txbTasa.Visibility = System.Windows.Visibility.Collapsed;
            txtTasa.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void chbAddImpLoc_Checked(object sender, RoutedEventArgs e)
        {

            txbImpLoc.Visibility = System.Windows.Visibility.Visible;
            txtImpLoc.Visibility = System.Windows.Visibility.Visible;
            txbMonto.Visibility = System.Windows.Visibility.Visible;
            txtMontoImp.Visibility = System.Windows.Visibility.Visible;
            txbTasa.Visibility = System.Windows.Visibility.Visible;
            txtTasa.Visibility = System.Windows.Visibility.Visible;

        }

        private void txtMontoImp_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularTotal();
        }
    }
}
