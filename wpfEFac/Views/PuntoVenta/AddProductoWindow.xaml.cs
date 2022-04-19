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
using System.Globalization;

namespace wpfEFac.Views.PuntoVenta
{
    /// <summary>
    /// Interaction logic for AddProductoWindow.xaml
    /// </summary>
    public partial class AddProductoWindow : Window
    {
        public wpfEFac.Helpers.CarritoComprasEntry entry;
        private AgregarProductosViewModels ctx;
        public event EventHandler EntryAdd;
        

        public AddProductoWindow()
        {
            InitializeComponent();
            ctx = new AgregarProductosViewModels();
            entry = null;
        }

        public AddProductoWindow(CarritoComprasEntry c):this()
        {
            entry = c;
            IsEditMode = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (entry != null)
            {
                CargarProductosEditar();       
            }
            else
            {
                CargarProductos();
            }
        }

        private void CargarProductosEditar()
        {
            dtgProductos.ItemsSource = ctx.GetProductos();
            dtgProductos.SelectedValuePath = "strID";
            dtgProductos.SelectedValue = entry.intID;

            txtCantidad.Text = entry.Cantidad.ToString();
            txtUnidad.Text = entry.Unidad;
            txtIVA.Text = entry.IVA.ToString();
            txtPrecioUnitario.Text = entry.PrecioUnitario.ToString();
            txtDescuento.Text = entry.Descuento.ToString().Replace("%", string.Empty).Trim();
            txtImporte.Text = entry.Importe.ToString();
                
        }

        private void CargarProductos()
        {
            dtgProductos.ItemsSource = ctx.GetProductos();

            SeleccionarPrimerElementoGrid();
        }

        private void SeleccionarPrimerElementoGrid()
        {
            if (dtgProductos.Items.Count > 0)
            {
                dtgProductos.SelectedIndex = 0;
                txtCantidad.Text = "1";
                txtDescuento.Text = "0";
            }
        }

        private void txtCodigoProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigoProducto.Text != string.Empty)
            {
                dtgProductos.ItemsSource = null;
                dtgProductos.ItemsSource = ctx.BuscarPorCodigo(txtCodigoProducto.Text);
                SeleccionarPrimerElementoGrid();
            }
            else
            {
                CargarProductos();
            }
        }

        private void txtNombreProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNombreProducto.Text != string.Empty)
            {
                dtgProductos.ItemsSource = null;
                dtgProductos.ItemsSource = ctx.BuscarPorNombre(txtNombreProducto.Text);
                SeleccionarPrimerElementoGrid();
            }
            else
            {
                CargarProductos();
            }
        }

        private void btnAñadirContinuar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgProductos.SelectedItem != null)
            {
                wpfEFac.Models.Productos p = (wpfEFac.Models.Productos)dtgProductos.SelectedItem;
                if (ValoresValidos())
                {
                    if (!IsEditMode)
                    {
                        CreateEntry(p);
                        EntryAdd(this, EventArgs.Empty);
                    }
                    else
                    {
                        UpdateEntry(p);
                        IsEditMode = false;
                    }
                }
                else
                {
                    MessageBox.Show("Error de validacion verifique sus datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto del grid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private string GetDivisa()
        {
            if (rdbDolares.IsChecked.Value)
            {
                return "DOLARES";
            }
            else
            {
                return "PESOS";
            }
        }

        private void btnAñadirSalir_Click(object sender, RoutedEventArgs e)
        {
            if (dtgProductos.SelectedItem != null)
            {
                wpfEFac.Models.Productos p = (wpfEFac.Models.Productos)dtgProductos.SelectedItem;

                if (ValoresValidos())
                {
                    if (!IsEditMode)
                    {
                        CreateEntry(p);
                        EntryAdd(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        UpdateEntry(p);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Error de validacion por favor verifique sus datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto del grid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateEntry(wpfEFac.Models.Productos p)
        {
            FillEntry(p);
        }

        private void FillEntry(wpfEFac.Models.Productos p)
        {
            entry.intID = p.intID;
            entry.Cantidad = int.Parse(txtCantidad.Text);
            entry.Codigo = p.strCodigo;
            entry.Unidad = p.UnidadMedida.strDescripcion;
            entry.Nombre = txtNombre.Text;
            entry.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
            entry.FormatPrecioUnitario = decimal.Parse(txtPrecioUnitario.Text).ToString("N");
            entry.IVA = decimal.Parse(txtIVA.Text);
            entry.retIVA = decimal.Parse(txtRetIVA.Text);
            entry.retISR = decimal.Parse(txtRetISR.Text);
            entry.retIEPS = decimal.Parse(txtRetIEPS.Text);
            
            entry.Descuento = decimal.Parse(txtImporteDescuento.Text);
            entry.FormatDescuento = txtDescuento.Text + " %";
            entry.Importe = decimal.Parse(txtImporte.Text);
            entry.FormatImporte = (decimal.Parse(txtImporte.Text)).ToString("N");
            entry.Divisa = GetDivisa();
        }

        private void CreateEntry(wpfEFac.Models.Productos p)
        {
            entry = new Helpers.CarritoComprasEntry();
            entry.intID = p.intID;
            entry.Cantidad = decimal.Parse(txtCantidad.Text);
            entry.Codigo = p.strCodigo;
            entry.Unidad = p.UnidadMedida.strDescripcion;
            entry.Nombre = txtNombre.Text;
            entry.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);

            entry.FormatPrecioUnitario = decimal.Parse(txtPrecioUnitario.Text).ToString("N");
            entry.IVA = decimal.Parse(txtIVA.Text);
            entry.retIVA = decimal.Parse(txtRetIVA.Text);
            entry.retISR = decimal.Parse(txtRetISR.Text);
            entry.retIEPS = decimal.Parse(txtRetIEPS.Text);

            entry.Descuento = decimal.Parse(txtImporteDescuento.Text);
            entry.FormatDescuento = txtDescuento.Text + " %";
            entry.Importe = decimal.Parse(txtImporte.Text);
            entry.FormatImporte = (decimal.Parse(txtImporte.Text)).ToString("N");
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgProductos.SelectedItem != null)
            {
                wpfEFac.Models.Productos p = (wpfEFac.Models.Productos)dtgProductos.SelectedItem;

                

                entry = new CarritoComprasEntry();

                entry.Unidad = p.UnidadMedida.strDescripcion;
                entry.IVA = p.porcIva.Value;
                entry.retIVA = p.porcRetIva.Value;
                entry.retISR = p.porcRetIsr.Value;
                entry.retIEPS = p.porcIeps.Value;

                entry.Nombre = p.strNombre;
                entry.PrecioUnitario = p.dcmPrecio1.Value;
                entry.Descuento = p.dcmDescuent;

                /*
                 * 
                 * 
                 */
                txtCantidad.Text = "1";
                txtNombre.Text = entry.Nombre.ToString();
                txtPrecioUnitario.Text = entry.PrecioUnitario.ToString("N");
                txtUnidad.Text = entry.Unidad;
                txtIVA.Text = entry.IVA.ToString();
                txtRetIVA.Text = entry.retIVA.ToString();
                txtRetISR.Text = entry.retISR.ToString();
                txtRetIEPS.Text = entry.retIEPS.ToString();

                txtDescuento.Text = entry.Descuento.ToString();
            }

        }

        public void CalcularImporte()
        {
            if (dtgProductos.SelectedItem!= null)
            {
                if (ValoresValidos())
                {
                    decimal resultado = decimal.Parse(txtCantidad.Text) * decimal.Parse(txtPrecioUnitario.Text);

                    decimal porcentaje = decimal.Parse(txtDescuento.Text != string.Empty ? txtDescuento.Text : "0") / 100;

                    decimal descuento = resultado * porcentaje;

                    decimal importe = resultado - descuento;

                    entry.Importe = importe;
                    txtImporteDescuento.Text = descuento.ToString("N");
                    txtImporte.Text = importe.ToString("N");
                }    
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValoresValidos()
        {
            return ValidarCantidad() && ValidarPrecioUnitario() && ValidarDescuento();
        }

        private bool ValidarCantidad()
        {
            try
            {
                Validador.ClearError(txtCantidad);
                Validador.TextBoxNumeroDecimal(txtCantidad, "El valor dado no es un Numero Decimal, corregir error");
            }
            catch (Exception e)
            {
                Validador.ShowError(txtCantidad, e.Message);
                return false;
            }

            return true;
        }

        private bool ValidarPrecioUnitario()
        {
            try
            {
                Validador.ClearError(txtPrecioUnitario);
                Validador.TextBoxNumeroDecimal(txtPrecioUnitario, "El valor dado no es un Numero Decimal, corregir error");
            }
            catch (Exception e)
            {
                Validador.ShowError(txtPrecioUnitario, e.Message);
                return false;
            }

            return true;
        }

        private bool ValidarDescuento()
        {
            try
            {
                Validador.ClearError(txtDescuento);
                Validador.TextBoxNumeroDecimal(txtDescuento, "El valor dado no es un Numero Decimal, corregir error");
            }
            catch (Exception e)
            {
                Validador.ShowError(txtDescuento, e.Message);
                return false;
            }

            return true;
        }

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularImporte();
        }

        private void txtDescuento_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularImporte();
        }

        private void txtPrecioUnitario_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularImporte();
        }

        public bool IsEditMode { get; set; }
    }
}
