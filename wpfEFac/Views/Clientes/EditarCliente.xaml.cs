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

namespace wpfEFac.Views.Clientes
{
    /// <summary>
    /// Interaction logic for EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {
        private eFacDBEntities entidad;
        private wpfEFac.Models.EditarClienteViewModel cliente;
        private int id;

        public EditarCliente(int id)
        {
            InitializeComponent();
            this.id = id;
            entidad = new eFacDBEntities();
            cliente = new Models.EditarClienteViewModel();
            this.Loaded += EditarCliente_Loaded;


            try
            {
                txtTelefono.Items.Clear();
                txtTelefono.ItemsSource = FactCat.getListRegimen();
                txtTelefono.DisplayMemberPath = "descripcion";
                txtTelefono.SelectedValuePath = "clave";
            }
            catch (Exception ex) { }
     

            var cli = cliente.GetCliente(id);
            //var RFC = cliente.GetRFC(cli.strRFC);
            //var Razon = cliente.GetRazonSocial(cli.strRazonSocial);
            //var comercial = cliente.GetNombreComercial(cli.strNombreComercial);
            //var giro = cliente.GetGiro(cli.strGiro);
            //var tipo = cliente.GetTipoInscripcion(cli.strTipodeInscripcion);
            var calle = cliente.GetCalle(cli.intID);
            //var telefono = cliente.GetTelefono(cli.strTelefono);
            //var telefonomovil = cliente.GetTelefonoMovil(cli.strTelefonoMovil);
            //var Email = cliente.GetEmail(cli.strEmail);
            //var contacto = cliente.GetContacto(cli.strContacto);
            //var web = cliente.GetWeb(cli.strWebSite);

            //*******************************************************************
            txtRFC.Text = cli.strRFC;
            txtRazonSocial.Text = cli.strRazonSocial;
            txtNombreComercial.Text = cli.strNombreComercial;
            txtGiro.Text = cli.strGiro;
            if (cli.strTipodeInscripcion == "Persona Moral")
                cmbTipoComprobante.SelectedIndex = 1;
            else
                cmbTipoComprobante.SelectedIndex = 0;
             txtCalleReceptor.Text = calle.strCalle;
            txtNoExterior.Text = calle.strNoExterior;
            txtNoInterior.Text = calle.strNoInterior == null ? "<No tiene>" : calle.strNoInterior;
            txtColonia.Text = calle.strColonia == null ? "<No tiene>" : calle.strColonia;
            txtMunicipio.Text = calle.strMunicipio == null ? "<No tiene>" : calle.strMunicipio;
            txtPoblacion.Text = calle.strPoblacionLocalidad == null ? "<No tiene>" : calle.strPoblacionLocalidad;
            txtCP.Text = calle.strCodigoPostal == null ? "<No tiene>" : calle.strCodigoPostal;
            txtTelefono.SelectedValue = cli.strTelefono;
            txtCelular.Text = cli.strTelefonoMovil == null ? "<No tiene>" : cli.strTelefonoMovil;
            txtEmail1.Text = cli.strEmail;
            txtContacto.Text = cli.strContacto;
            if (cli.chrRetencionIVA == "Si")
            cmbRetencionIVA.SelectedIndex = 0;
            else
            cmbRetencionIVA.SelectedIndex = 1;
            txtWebSite.Text = cli.strWebSite;
            cmbPais.ItemsSource = entidad.Paises;
            cmbPais.DisplayMemberPath = "strNombrePais";
            cmbEstado.ItemsSource = entidad.Estado;
            cmbEstado.DisplayMemberPath = "strNombreEstado";
            cmbPais.SelectedValuePath = "intID";
            cmbEstado.SelectedValuePath = "intID";

            cmbPais.SelectedValue = calle.Paises.intID;
            cmbEstado.SelectedValue = calle.Estado.intID;
            cmbAddenda.SelectedIndex = cli.idAddenda.Value;
        }

        protected void EditarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            
            var cli = cliente.GetCliente(id);
            //var RFC = cliente.GetRFC(cli.strRFC);
            //var Razon = cliente.GetRazonSocial(cli.strRazonSocial);
            //var comercial = cliente.GetNombreComercial(cli.strNombreComercial);
            //var giro = cliente.GetGiro(cli.strGiro);
            //var tipo = cliente.GetTipoInscripcion(cli.strTipodeInscripcion);
            var calle = cliente.GetCalle(cli.intID);
            //var telefono = cliente.GetTelefono(cli.strTelefono);
            //var telefonomovil = cliente.GetTelefonoMovil(cli.strTelefonoMovil);
            //var Email = cliente.GetEmail(cli.strEmail);
            //var contacto = cliente.GetContacto(cli.strContacto);
            //var web = cliente.GetWeb(cli.strWebSite);

            //*******************************************************************
            txtRFC.Text = cli.strRFC;
            txtRazonSocial.Text = cli.strRazonSocial;
            txtNombreComercial.Text = cli.strNombreComercial;
            txtGiro.Text = cli.strGiro;
            if (cli.strTipodeInscripcion == "Persona Moral")
                cmbTipoComprobante.SelectedIndex = 1;
            else
                cmbTipoComprobante.SelectedIndex = 0;
            txtCalleReceptor.Text = calle.strCalle;
            txtNoExterior.Text = calle.strNoExterior;
            txtNoInterior.Text = calle.strNoInterior == null ? "<No tiene>" : calle.strNoInterior;
            txtColonia.Text = calle.strColonia == null ? "<No tiene>" : calle.strColonia;
            txtMunicipio.Text = calle.strMunicipio == null ? "<No tiene>" : calle.strMunicipio;
            txtPoblacion.Text = calle.strPoblacionLocalidad == null ? "<No tiene>" : calle.strPoblacionLocalidad;
            txtCP.Text = calle.strCodigoPostal == null ? "<No tiene>" : calle.strCodigoPostal;
            txtTelefono.SelectedValue = cli.strTelefono;
            txtCelular.Text = cli.strTelefonoMovil == null ? "<No tiene>" : cli.strTelefonoMovil;
            txtEmail1.Text = cli.strEmail;
            txtContacto.Text = cli.strContacto;
            
            if (cli.chrRetencionIVA == "Si")
                cmbRetencionIVA.SelectedIndex = 0;
            else
                cmbRetencionIVA.SelectedIndex = 1;

            if (cli.chrRetencionISR == "Si")
                cmbRetencionISR.SelectedIndex = 0;
            else
                cmbRetencionISR.SelectedIndex = 1;

            txtWebSite.Text = cli.strWebSite;
            cmbPais.ItemsSource = entidad.Paises;
            cmbPais.DisplayMemberPath = "strNombrePais";            
            cmbEstado.ItemsSource = entidad.Estado;
            cmbEstado.DisplayMemberPath = "strNombreEstado";
            cmbPais.SelectedValuePath = "intID";
            cmbEstado.SelectedValuePath = "intID";

            cmbPais.SelectedValue = calle.Paises.intID;
            cmbEstado.SelectedValue = calle.Estado.intID;
        }

        private void bttGuardar_Click(object sender, RoutedEventArgs e)
        {
            int ID = id;
            string RFC = txtRFC.Text;
            string Razon = txtRazonSocial.Text;
            string Comercial = txtNombreComercial.Text;
            string Giro = txtGiro.Text;
            string Tipo = cmbTipoComprobante.Text;
            string Calle = txtCalleReceptor.Text;
            string Exterior = txtNoExterior.Text;
            string Interior = txtNoInterior.Text;
            string Colonia = txtColonia.Text;
            int Pais = Convert.ToInt32(cmbPais.SelectedValue.ToString());
            int Estado = Convert.ToInt32(cmbEstado.SelectedValue.ToString());
            string Municipio = txtMunicipio.Text;
            string Poblacion = txtPoblacion.Text;
            string Codigo = txtCP.Text;
            string Casa = txtTelefono.SelectedValue.ToString();
            string Oficina = txtCelular.Text;
            string Email = txtEmail1.Text;
            string Contacto = txtContacto.Text;
            string IVA = cmbRetencionIVA.Text;
            string ISR = cmbRetencionISR.Text;
            string Web = txtWebSite.Text;
            int Addenda = cmbAddenda.SelectedIndex;

            BusClientes bus = new BusClientes();
            if (bus.EditarCliente(id,RFC, Razon, Comercial, Giro, Tipo, Calle, Exterior, Interior, Colonia, Pais, Estado,
                Municipio, Poblacion, Codigo, Casa, Oficina, Email, Contacto, IVA, ISR, Web, Addenda))
            {
                MessageBox.Show("El Cliente se Edito Correctamente", "Editado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio un Error durante la Edicion, por favor vuelva a intentarlo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DialogResult = true;
        }

        private void bttCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }        
    }
}
