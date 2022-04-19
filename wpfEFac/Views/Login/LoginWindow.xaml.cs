﻿using System;
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
using System.Net.Http;
using System.Net.Http.Headers;

namespace wpfEFac.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginViewModel ctx;
        eFacDBEntities db = new eFacDBEntities();
        public LoginWindow()
        {
            InitializeComponent();
            ctx = new LoginViewModel();

           

            try
            {
                cmbEmpresa.ItemsSource = ctx.GetEmpresas();
                cmbEmpresa.SelectedValuePath = "intID";
                cmbEmpresa.DisplayMemberPath = "strRazonSocial";
                if (cmbEmpresa.Items.Count > 0)
                {
                    cmbEmpresa.SelectedIndex = 0;
                }

               // getCFD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void bttOK_Click(object sender, RoutedEventArgs e)
        {
            int idUsuario;

            if (ValidarLogin())
            {
                try
                {
                    int idEmpresa = int.Parse(cmbEmpresa.SelectedValue.ToString());
                    idUsuario = ctx.DoLogin(
                        txtUsuario.Text,
                        pwbContraseña.Password,
                        idEmpresa
                        );

                    getUser();
                }
                catch (Exception)
                {
                    idUsuario = default(int);
                }

                if (idUsuario != 0)
                {
                    this.Topmost = false;
                    App.Current.Properties["idUsuario"] = idUsuario;
                    App.Current.Properties["idEmpresa"] = cmbEmpresa.SelectedValue;
                    MainWindow mw = new MainWindow();
                    mw.Owner = this;
                    mw.Show();
                    this.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("El usuario no existe por favor verifique sus datos", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } 
        }

        private bool ValidarLogin()
        {
            return (ValidarUsuario() &&
            ValidarPassword());
        }

        private bool ValidarPassword()
        {
            if (string.IsNullOrWhiteSpace(pwbContraseña.Password))
            {
                lblPassword.Content = "*Debes introducir la contraseña de Usuario";
                lblPassword.Foreground = new SolidColorBrush(Colors.Red);
                pwbContraseña.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            else
            {
                lblPassword.Content = string.Empty;
                pwbContraseña.BorderBrush = new PasswordBox().BorderBrush;
            }

            return true;
        }

        private bool ValidarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                lblUsuario.Content = "*Debes introducir un Nombre de Usuario";
                lblUsuario.Foreground = new SolidColorBrush(Colors.Red);
                txtUsuario.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
            else
            {
                lblUsuario.Content = string.Empty;
                txtUsuario.BorderBrush = new TextBox().BorderBrush;
            }
            return true;
        }

        private void bttCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pwbContraseña_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidarPassword();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarUsuario();
        }

        private void getUser()
        {
            string strRFC = UserPac.rfc;


            const string URL = "http://adesoft-ws.appspot.com/getuser";
            string urlParameters = "?rfc=" + strRFC;


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                string strValue = dataObjects.ToString();

                string strUs = strValue.Split('|').ElementAt(0);
                string strPass = strValue.Split('|').ElementAt(1);
                string idEquipo = strValue.Split('|').ElementAt(2);

                UserPac.user = strUs;
                UserPac.passwd = strPass;
                UserPac.idEquipo = idEquipo;
            }
            else
            {
                MessageBox.Show((int)response.StatusCode + " - " + response.ReasonPhrase);
            }
        }

        private void getCFD() {

            try
            {
                var myCFD = db.CFD.SingleOrDefault(c => c.intID == 6);
                myCFD.strDescripcion = "PAGO";
                myCFD.strTipoCFD = "pago";
                myCFD.intIdFolio = 6;
                myCFD.templateReportH = "templateFacturaHPago_33.xslt";
                myCFD.templateReportHdemo = "templateFacturaHPago_33.xslt";
                myCFD.templateReport = "templatePagoConceptos33";
                myCFD.templateReportDemo = "templatePagoConceptos33";
                db.SaveChanges();
               

            }
            catch (Exception ex) {

                wpfEFac.Models.CFD p = new wpfEFac.Models.CFD();
                p.intID = 6;
                p.strDescripcion = "PAGO";
                p.strTipoCFD = "pago";
                p.intId_Empresa = 1;
                p.intIdFolio = 6;
                p.templateReportH = "templateFacturaHPago_33.xslt";
                p.templateReportHdemo = "templateFacturaHPago_33.xslt";
                p.templateReport = "templatePagoConceptos33";
                p.templateReportDemo = "templatePagoConceptos33";
                p.iva = decimal.Parse("0.16");
                p.retIva = decimal.Parse("0.00");
                p.retIsr = decimal.Parse("0.00");

                db.CFD.AddObject(p);
                db.SaveChanges();

                
            
            }

         //   Factura factura = db.Factura.SingleOrDefault(fac => fac.intID == f.intID);// busca y edita status de comprobante

        //    factura.chrStatus = "C";
         //   factura.dtmFechaCancelacion = DateTime.Now;
          //  factura.strNumero = "CANCELADA";
          //  factura.dtmFechaEnvio = DateTime.Now; 
        
        }
    }
}
