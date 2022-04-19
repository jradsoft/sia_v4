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
using wpfEFac.Helpers;

namespace wpfEFac.Views.Clientes
{
    /// <summary>
    /// Interaction logic for AgregarCliente.xaml
    /// </summary>
    public partial class AgregarCliente : Window
    {
        private eFacDBEntities entidad;
        private EditarClienteViewModel data;
        public AgregarCliente()
        {
            InitializeComponent();
            entidad = new eFacDBEntities();
            data = new EditarClienteViewModel();
        }

        private void bttGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValoresValidos())
            {
                DirectorioClientes directorio = new DirectorioClientes();
                

                //int id = Convert.ToInt32(new Object());
                //throw new NotImplementedException();
                string rfc = txtRFC.Text;
                string Razon = txtRazonSocial.Text;
                string Nombre = txtNombreComercial.Text;
                string Giro = txtGiro.Text;
                string Tipo = cmbTipoComprobante.Text;
                string Telefono = txtTelefono.Text;
                string Movil = txtCelular.Text;
                string Email = txtEmail1.Text;
                string Contacto = txtContacto.Text;
                string Retencion = cmbRetencionIVA.Text;
                string RetencionISR = cmbRetencionISR.Text;
                string Web = txtWebSite.Text;
                int addendda = 0;
                if (cmbAdenda.Text == "Sivesa")
                    addendda = 1;


                string Calle = txtCalleReceptor.Text;
                string NoExterior = txtNoExterior.Text;
                string NoInterior = txtNoInterior.Text;
                string Colonia = txtColonia.Text;
                int Pais = Convert.ToInt32(cmbPais.SelectedValue);
                int Estado = Convert.ToInt32(cmbEstado.SelectedValue.ToString());
                string Municipio = txtMunicipio.Text;
                string Poblacion = txtPoblacion.Text;
                string Codigo = txtCP.Text;
                BusClientes clientes = new BusClientes();
                if (clientes.AgregarCliente(rfc, Razon, Nombre, Giro, Tipo, Telefono, Movil, Email, Convert.ToString(Retencion), Convert.ToString(RetencionISR), Contacto, Web,
                    Calle, NoExterior, NoInterior, Colonia, Pais, Estado, Municipio, Poblacion, Codigo, Convert.ToInt32(App.Current.Properties["idEmpresa"]), addendda))
                {
                    MessageBox.Show("\"El Cliente ha sido Registrado Exitosamente\"", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("\"Error al intentar Registrar el cliente, vuelva a intentarlo\"", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
   
            }
        }

        private bool ValoresValidos()
        {
            bool rfc;

            rfc = ValidarRFC();

            bool razonSocial;

            razonSocial = ValidarRazonSocial();

            return rfc && razonSocial;
        }

        private bool ValidarRazonSocial()
        {
            bool razonSocial;
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                lblRazonSocial.Content = "*Campo requerido, ingresa el Nombre o Razon Social";
                lblRazonSocial.Foreground = new SolidColorBrush(Colors.Red);
                txtRazonSocial.BorderBrush = new SolidColorBrush(Colors.Red);
                razonSocial = false;
            }
            else
            {
                lblRazonSocial.Content = string.Empty;
                lblRazonSocial.Foreground = new Label().Foreground;
                txtRazonSocial.BorderBrush = new TextBox().BorderBrush;
                razonSocial = true;
            }
            return razonSocial;
        }

        private bool ValidarRFC()
        {
            bool rfc;
            if (Validador.ValidarRFC(txtRFC.Text))
            {
                lblRFC.Content = "*Campo requerido, debes poner tu RFC";
                lblRFC.Foreground = new SolidColorBrush(Colors.Red);
                txtRFC.BorderBrush = new SolidColorBrush(Colors.Red);
                rfc = false;
            }
            else
            {
                lblRFC.Content = string.Empty;
                lblRFC.Foreground = new Label().Foreground;
                txtRFC.BorderBrush = new TextBox().BorderBrush;
                rfc = true;
            }
            return rfc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            wpfEFac.Models.Estado es = new wpfEFac.Models.Estado();
            wpfEFac.Models.Paises p = new Models.Paises();
            cmbPais.ItemsSource = entidad.Paises;
            cmbPais.DisplayMemberPath = "strNombrePais";
            cmbPais.SelectedValuePath = "intID";
            cmbPais.SelectedValue = p.intID;
            cmbEstado.ItemsSource = entidad.Estado;
            cmbEstado.DisplayMemberPath = "strNombreEstado";
            cmbEstado.SelectedValuePath = "intID";
            cmbEstado.SelectedValue = es.intID;
        }

        private void bttCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
