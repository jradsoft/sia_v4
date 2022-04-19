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
using GalaSoft.MvvmLight.Messaging;
using wpfEFac.Models;
using wpfEFac.ViewModel;
using System.Net.Mail;

namespace wpfEFac.Views.EMail
{
    /// <summary>
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Window
    {
        private Factura f;

        private EmailViewModel vm;

        public Email()
        {
            InitializeComponent();

            this.Enviado = false;
            this.stpXmlAttachment.Visibility = Visibility.Collapsed;

            vm = (EmailViewModel)this.LayoutRoot.DataContext;

            Action xmlDispacher = null;

            Messenger.Default.Register<Factura>(this,
        m =>
        {
            this.f = m;
            vm.ToEmail = f.Clientes.strEmail + ";";
            vm.FromEmail = f.Empresa.strEmail;
            vm.Empresa = f.Empresa;
            vm.Subject = f.CFD.strDescripcion + " " + f.strFolio + " - " + f.Empresa.strRazonSocial;
            vm.Message = "Saludos Cordiales, espero sus comentarios respecto a esta " + f.CFD.strDescripcion;



            if (f.intID_Tipo_CFD == 1)
            {
                vm.ToEmail += f.Empresa.strEmail2;
                vm.PDFAttachement = f.strPDFpath;
                vm.XMLAttachement = f.strXMLpath;

                /*
                Action pdfDispacher = () => vm.CreatePDFFile(f);
                this.Dispatcher.BeginInvoke(pdfDispacher);

                        
                xmlDispacher = () => vm.CreateXMLFile(f);
                this.Dispatcher.BeginInvoke(xmlDispacher);
                */
                this.stpXmlAttachment.Visibility = Visibility.Visible;
            }
            else
            {

                Action pdfDispacher = () => vm.CreatePDFFile(f);
                this.Dispatcher.BeginInvoke(pdfDispacher);

                //xmlDispacher = () => vm.CreateXMLFile(f);
                //this.Dispatcher.BeginInvoke(xmlDispacher);
                this.stpXmlAttachment.Visibility = Visibility.Visible;
            }


        });

            Messenger.Default.Register<bool>(this,
                m =>
                {
                    if (m)
                    {
                        if (!this.Enviado)
                        {
                            this.Enviado = true;
                            MessageBox.Show("Envio con exito", "Correo", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error al enviar verifique sus datos de configuracion de correo", "Correo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }


        public Email(Factura fact)
        {
            InitializeComponent();

            this.Enviado = false;
            //this.stpXmlAttachment.Visibility = Visibility.Collapsed;

            this.f = fact;

            txtEmailCliente.Text = f.Clientes.strEmail;

            //if (f.intID_Tipo_CFD == 1)
            //{
            //    vm.ToEmail += f.Empresa.strEmail2;
            //    vm.PDFAttachement = f.strPDFpath;
            //    vm.XMLAttachement = f.strXMLpath;

            //    /*
            //    Action pdfDispacher = () => vm.CreatePDFFile(f);
            //    this.Dispatcher.BeginInvoke(pdfDispacher);


            //    xmlDispacher = () => vm.CreateXMLFile(f);
            //    this.Dispatcher.BeginInvoke(xmlDispacher);
            //    */
            //   // this.stpXmlAttachment.Visibility = Visibility.Visible;
            //}
            //else
            //{


            //    this.stpXmlAttachment.Visibility = Visibility.Visible;
            //}





        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public bool Enviado { get; private set; }

        private void cmdEnviarEmail_Click(object sender, RoutedEventArgs e)
        {
            sendMail(f.strXMLpath, f.strPDFpath,
                              f.Empresa.strNombreComercial,
                              f.strSerie,
                              f.strFolio,
                              txtEmailCliente.Text, f.Empresa.strEmail, f.Empresa.strEmail2,f.Empresa.strTelefono,f.Empresa.strTelefono2);
        }


        private int sendMail(string xmlPath, string pdfPath, string empresa, string Serie, String Folio,
      string mailCliente, string mailRespaldo, string mailContador, string emailRespaldo, string passEmail)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential(emailRespaldo, passEmail);

            mail.To.Add(emailRespaldo);



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

            mail.From = new System.Net.Mail.MailAddress(emailRespaldo);
            mail.IsBodyHtml = true;
            mail.Body = "Servicio proporcionado por ADESOFT SA de CV" + " www.adesoft.com.mx";

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred;
            smtp.Port = 587;
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Factura enviada : " + mailCliente);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }


            return 0;
        }

    }
}