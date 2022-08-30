using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using Ionic.Zip;
using WService;
using System.Web.Services.Protocols;


namespace dlleFac
{
    public class MyFactE
    {
        string strAddenda;
        bool isAddenda;

        public Factura createXML30(int intTipoComprobante, string RFC, string fileCer, string fileKey, string passwd, string path, string path2,
            dlleFac.Comprobante cfd,
            string strEncabezado, string strObservaciones, string strImpuestosAdicionales,
            string strTipoComprobante, string templateReportHeader, string templateReport, bool CFDAprobado,
            
         string origen,
         string recogerEn, 
        
         string destino,
         string destinatario,
         string rfcDestinatario,
         string domicilioDestinatario,
         string entregarEn,
            bool isAddenda,
            string strUs,
            string strValue,
            string idEquipo
            )
        {

            this.isAddenda = isAddenda;

            string fechaActual = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') +
                "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');

            
            string strFileCER = fileCer;
            string strFileKEY = fileKey;
            string strCadenaOriginal = "";
            string strFileCERPEM =  fileCer + ".PEM";
            string strFileKEYPEM =  fileKey + ".PEM";
            
            string strPasswd = passwd;
            string myUUID="";
            int value = 0;
            Complemento myComp = new Complemento();


            string fileName = "c:\\myfacturae\\adesoft.xml";




            string fileNameXMLtemp = "";

            string fileNameOK; //= path + "\\" + "XML_" + cfd.folio + "_" + RFC + "_" + fechaActual + "_OK.xml";
            string fileNamepdfOK; //= path + "\\" + "PDF_" + cfd.folio + "_" + RFC + "_" + fechaActual + "_OK.pdf";
            //string fileNameHTMLOK = "";

            if (CFDAprobado)
            {
                //fileNameHTMLOK = path + "\\" + "HTML_" + cfd.folio + "_" + RFC + "_" + fechaActual + "_OK.html";
                fileNameXMLtemp = "c:\\myfacturae\\adesoft.xml";
                //fileNameOK = path + "\\" + "XML_" + cfd.folio + "_" + RFC + "_" + fechaActual + "_OK.xml";
                fileNameOK = "c:\\myfacturae\\adsoftOK.xml";
                fileNamepdfOK = path + "\\" + strTipoComprobante.Replace(' ', '_') +  "_" + cfd.Folio + "_" + RFC + "_" + fechaActual + "_OK.pdf";

            }
            else
            {

                fileNameXMLtemp = "c:\\myfacturae\\adesoft.xml";
                fileNameOK = "c:\\myfacturae\\adsoftOK.xml";

                fileNamepdfOK = path2 + "\\" + strTipoComprobante.Replace(' ', '_') + "_" + cfd.Folio + "_" + RFC + "_" + fechaActual + "_OK.pdf";
            }

            string strNoCertificado;
            strNoCertificado = getCertificado(strFileCER, strPasswd);

            ExecuteCommandSync("c:\\myfacturae\\openssl enc -base64 -in " + strFileCER + " -out c:\\myfacturae\\certificado.txt");

            string strCertificado;
            strCertificado = System.IO.File.ReadAllText("c:\\myfacturae\\certificado.txt", UTF8Encoding.UTF8);
            strCertificado = strCertificado.Replace("\n", "");
            cfd.Certificado = strCertificado;
            cfd.NoCertificado = strNoCertificado;


            generateXMLCFD20(fileNameXMLtemp, cfd, intTipoComprobante);


            ExecuteCommandSync("c:\\myfacturae\\openssl pkcs8 -inform DER -in " + strFileKEY + "  -out " + strFileKEYPEM + " -passin pass:" + strPasswd);


           // ExecuteCommandSync("c:\\myfacturae\\xsltproc c:\\myfacturae\\deleteNull.xslt" + fileNameXMLtemp + " > " + fileNameOK);
            ExecuteCommandSync("c:\\myfacturae\\xsltproc c:\\myfacturae\\deleteNull.xslt " + fileNameXMLtemp + " > " + fileNameOK);
            //ExecuteCommandSync("c:\\myfacturae\\xsltproc c:\\myfacturae\\cadenaoriginal_3_2.xslt " + fileNameOK + " > c:\\myfacturae\\cadena.txt");
            //ExecuteCommandSync("c:\\myfacturae\\xsltproc c:\\myfacturae\\cadenaoriginal_3_2.xslt " + fileNameOK + " | c:\\myfacturae\\openssl dgst -sha1 -sign " + strFileKEYPEM + " | c:\\myfacturae\\openssl enc -base64 -A > c:\\myfacturae\\sello.txt");


            ExecuteCommandSync("c:\\myfacturae\\xsltproc c:\\myfacturae\\cadenaoriginal40.xslt " + fileNameOK + " > c:\\myfacturae\\cadena.txt");
            ExecuteCommandSync("c:\\myfacturae\\xsltproc c:\\myfacturae\\cadenaoriginal40.xslt " + fileNameOK + " | c:\\myfacturae\\openssl dgst -sha256 -sign " + strFileKEYPEM + " | c:\\myfacturae\\openssl enc -base64 -A > c:\\myfacturae\\sello.txt");

                                                                                     
            strCadenaOriginal = System.IO.File.ReadAllText("c:\\myfacturae\\cadena.txt", UTF8Encoding.UTF8);


            string strSello;
            strSello = System.IO.File.ReadAllText("c:\\myfacturae\\sello.txt", UTF8Encoding.UTF8);
            cfd.Sello = strSello;

            generateXMLCFD20(fileNameXMLtemp, cfd,intTipoComprobante);

            //if (CFDAprobado) 
                
            //else
             //   cfd.sello = "MuestraFiscalSinValorMuestraFiscalSinValorMuestraFiscalSinValorMuestraFiscalSinValorMuestraFiscalSinValorMuestraFiscalSinValorMuestraFiscalSinValorMuestraFiscalSinValor";
            //cfd.sello = "ijj/6sdCwrCbsxBOoL07muE32MgO+FlMpGMs0fc9piT0YkiV7I8U0MI9sSjmoYyoi+BCwC+EEiTDaUGv3ygujsGl3AKnuz+uCfWicgaTZuBn8CuZhkc58ktdHYKCCtAzFJ3HYlST5sMrqdd8jvlCFD47Buas/aSmACUesJzul5Y=";

          
            ExecuteCommandSync("c:\\myfacturae\\xsltproc c:\\myfacturae\\deleteNull.xslt " + fileNameXMLtemp + " > " + fileNameOK);
            updateEncoding(fileNameOK);
            AppendAttribute(fileNameOK, intTipoComprobante);

            Boolean sucess;
            
            sucess = true;
            
            /*******************************************************/

            if ((intTipoComprobante == 1) || (intTipoComprobante == 2) || (intTipoComprobante == 3) || (intTipoComprobante == 4) || (intTipoComprobante == 5) || (intTipoComprobante == 6))
            {
                
                
                    if (CFDAprobado)
                    {
                       
                        ExecuteCommandSync("c:\\myfacturae\\zip c:\\myfacturae\\adesoftCfdi.zip -o -j " + fileNameOK);
                       // ExecuteCommandSync("c:\\myfacturae\\zip -o c:\\myfacturae\\adesoftCfdi.zip adsoftOK.xml"); 
                        byte[] rawData = File.ReadAllBytes("c:\\myfacturae\\adesoftCfdi.zip");
                        //SIFEIService myService = new SIFEIService(); // Sifei
                        //CFDiService myService = new CFDiService(); //Edicomn
                        ServicioTimbradoWS myService = new ServicioTimbradoWS();//facturalo productivo
                        //ServicioTimbradoWS myServiceTest = new ServicioTimbradoWS();//facturalo Test
                        //byte[] MyCfdiTimbrado = null;
                        byte[] MyTFD = null;

                        RespuestaTimbrado MyCfdiTimbrado = null; //timbralo

                        // Load the xml file into XmlDocument object.
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(fileNameOK);

                        // Now create StringWriter object to get data from xml document.
                        StringWriter sw = new StringWriter();
                        XmlTextWriter xw = new XmlTextWriter(sw);
                        xmlDoc.WriteTo(xw);
                        String XmlString = sw.ToString();
                        try
                        {
                            ExecuteCommandSync("delete c:\\myfacturae\\adesoftCfdi.zip");


                            MyCfdiTimbrado = myService.timbrar(idEquipo, XmlString);  //Productivo

                           // MyCfdiTimbrado = myServiceTest.timbrar("0955d485e26c486392909ee79f5ad5c3", XmlString);  //test



                            ExecuteCommandSync("delete c:\\myfacturae\\timbreCFDi.xml");

                            if (intTipoComprobante == 6)
                            {
                                value = 1;
                            }

                            if (MyCfdiTimbrado.data.Contains("<cartaporte20:CartaPorte"))
                            {
                                value = 1;
                            }

                            if (MyCfdiTimbrado.data.Contains("<implocal:ImpuestosLocales"))
                            {
                                value = 1;
                            }

                            //Stream stream = new MemoryStream(MyCfdiTimbrado);
                            //using (ZipFile zip = ZipFile.Read(stream))
                            //{
                            //    MemoryStream mystream = new MemoryStream();
                            //    foreach (ZipEntry e in zip)
                            //    {
                            //        e.Extract(mystream);
                            //        System.IO.File.WriteAllBytes("c:\\myfacturae\\SIGN_adsoftOK.xml", mystream.ToArray());
                            //    }
                            //}

                   

                                
                                    try
                                    {
                                        if (MyCfdiTimbrado.code == "200")
                                        {
                                            System.IO.File.WriteAllText("c:\\myfacturae\\SIGN_adsoftOK.xml", MyCfdiTimbrado.data);

                                            fileNameOK = "c:\\myfacturae\\SIGN_adsoftOK.xml";


                                            System.IO.File.WriteAllText("c:\\xml\\Factura.txt", String.Empty, UTF8Encoding.UTF8);

                                            Comprobante myComprobante = DeserializeCFD32(fileNameOK);

                                            ComprobanteComplemento myComplemento = myComprobante.Complemento;
                                            XmlAttributeCollection myTFD = myComplemento.Any[value].Attributes;


                                            myUUID = myTFD.GetNamedItem("UUID").Value; //myTFD[2].Value;
                                            string FechaTimbrado = myTFD.GetNamedItem("FechaTimbrado").Value;//myTFD[1].Value; //myTokenIzer[4];
                                            string SelloCFD = myTFD.GetNamedItem("SelloCFD").Value; //myTFD[4].Value;//myTokenIzer[7];
                                            string NoCertificadoSAT = myTFD.GetNamedItem("NoCertificadoSAT").Value;//myTFD[3].Value;// myTokenIzer[10];
                                            string SelloSAT = myTFD.GetNamedItem("SelloSAT").Value;//myTFD[5].Value;//myTokenIzer[13];

                                            string strCadenaOriginalTFD = getCadenaTFD(myTFD);


                                            myComp.UUID = myUUID.Trim();
                                            myComp.FechaTimbrado = FechaTimbrado;
                                            myComp.NoCertificadoSAT = NoCertificadoSAT;
                                            myComp.SelloCFD = SelloCFD.Substring(0, SelloCFD.Length / 2) + "\n" + SelloCFD.Substring(SelloCFD.Length / 2, SelloCFD.Length / 2);
                                            myComp.SelloSAT = SelloSAT.Substring(0, SelloSAT.Length / 2) + "\n" + SelloSAT.Substring(SelloSAT.Length / 2, SelloSAT.Length / 2);


                                            myComp.CadenaTFD = strCadenaOriginalTFD.Substring(0, strCadenaOriginalTFD.Length / 2) + "\n" +
                                            strCadenaOriginalTFD.Substring(strCadenaOriginalTFD.Length / 2, strCadenaOriginalTFD.Length / 2);
                                        }
                                        else {

                                            throw new Exception( MyCfdiTimbrado.message);
                                        }


                                    }
                                    catch (Exception e)
                                    {


                                        sucess = false;
                                        throw new Exception(e.Message+" "+ MyCfdiTimbrado.message);
                                    }


                        //    }


                        }
                        catch (SoapException ex)
                        {
                            sucess = false;
                            throw new Exception(ex.Detail.InnerText + " " + MyCfdiTimbrado.message);
                        }
                        
                    }
                    else
                    {
                        
                        myComp.UUID = "00000000-0000-0000-0000-000000000000";
                        myComp.FechaTimbrado = "1900-01-01T00:00:00";
                        myComp.NoCertificadoSAT = "000000000000000";
                        myComp.SelloCFD = "muestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalor";
                        myComp.SelloSAT = "muestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalor";
                        myComp.CadenaTFD = "muestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalor" + "\n" +
                        "muestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalormuestrafiscalsinvalor";
                        

                        //MyCfdiTimbrado = myService.getCfdiTest("ADE1004192V6", "smkoecfpw", rawData);
                        //MyTFD = myService.getTimbreCfdiTest("ADE1004192V6", "smkoecfpw", rawData);

                        
                    }

               

            }


            /*******************************************************/

            Factura myf;

            if (sucess)
            {

                myComp.TipoComprobante = strTipoComprobante;
                myComp.Cadena = strCadenaOriginal;
                myComp.CantidadLetra = ConvertidorNumeroLetra.NumeroALetras(cfd.Total.ToString(), "PESOS");
                myComp.Encabezado = strEncabezado;
                myComp.Observaciones = strObservaciones;
                myComp.ImpuestosAdicionales = strImpuestosAdicionales;

                myComp.Origen = origen;
                myComp.RecogerEn = recogerEn;

                myComp.Destino = destino;
                myComp.Destinatario = destinatario;
                myComp.RfcDestinatario = rfcDestinatario;
                myComp.DomicilioDestinatario = domicilioDestinatario;
                myComp.EntregarEn = entregarEn;

                generateXMLCFD20Complemento(myComp);



                myf = new Factura()
                {
                    sello = strSello,
                    certificado = strCertificado,
                    noCertificado = strNoCertificado,
                    xml = generateXMLCFD20(fileNameXMLtemp, cfd,intTipoComprobante),
                    filePath = fileNameOK,
                    cadenaOriginal = strCadenaOriginal,
                    fileXMLpath = fileNameOK,
                    filePDFpath = fileNamepdfOK,
                    serie = cfd.Serie,
                    folio = cfd.Folio,
                    fechaAprobacion = cfd.Fecha,
                    UUID = myUUID.Trim()
                };

            }
            else
                myf = null;
            
            return (myf);
            
            
        }

        public string getCadenaTFD(XmlAttributeCollection myTFD)
        {
            string myCadenaTFD;

            //   myUUID + "|" +
            //                        FechaTimbrado + "|" +
            //                        SelloCFD + "|" +
            //                        NoCertificadoSAT +
            //             


            myCadenaTFD = "||1.1|" +
                                               myTFD.GetNamedItem("UUID").Value + "|" +
                                               myTFD.GetNamedItem("FechaTimbrado").Value + "|" +
                                               myTFD.GetNamedItem("SelloCFD").Value + "|" +
                                               myTFD.GetNamedItem("NoCertificadoSAT").Value +
                                               "||";
            return myCadenaTFD;
        }
        public Comprobante DeserializeCFD32(string xmlFile)
        {


            // Create an instance of the XmlSerializer specifying type and namespace.
            XmlSerializer serializer = new
            XmlSerializer(typeof(Comprobante));

            // A FileStream is needed to read the XML document.

            FileStream fs = new FileStream(xmlFile, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);

            // Declare an object variable of the type to be deserialized.
            Comprobante myComprobante = null;

            // Use the Deserialize method to restore the object's state.
            try
            {

                myComprobante = (Comprobante)serializer.Deserialize(reader);

            }
            catch (Exception e)
            {

            }
            fs.Close();
            reader.Close();

            return myComprobante;

        }



        private void updateEncoding(string xmlFile)
        {


            if (File.Exists(xmlFile))
            {
                try
                {
                    string strXML;

                    Char comilla = '"';
                    strXML = System.IO.File.ReadAllText(xmlFile, UTF8Encoding.UTF8);

                    strXML = strXML.Replace("?>", " encoding=" + comilla + "utf-8" + comilla + "?>");


                    System.IO.File.WriteAllText(xmlFile, strXML, UTF8Encoding.UTF8);

                }



                catch (Exception e)
                {
                }
            }
        }
        private void AppendAttribute(string xmlFile, int intTipoComprobante)
        {

            XmlDocument xmlDoc = new XmlDocument();

            if (File.Exists(xmlFile))
            {

                xmlDoc.Load(xmlFile);

                //XmlNodeList list = xmlDoc.GetElementsByTagName("cfdi:Comprobante");

                int i = 0;
                try
                {


                    XmlAttribute newAttr = xmlDoc.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance");
                    if ((intTipoComprobante == 1) || (intTipoComprobante == 2) || (intTipoComprobante == 3) || (intTipoComprobante == 4) || (intTipoComprobante == 5) || (intTipoComprobante == 7))
                    {

                        newAttr.Value = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/CartaPorte http://www.sat.gob.mx/sitio_internet/cfd/CartaPorte/CartaPorte.xsd http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd";
                    }

                    if (intTipoComprobante == 6)
                    {

                        newAttr.Value = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/Pagos20 http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos20.xsd ";
                    }



                    // }

                    XmlAttributeCollection attrColl = xmlDoc.DocumentElement.Attributes;
                    attrColl.InsertBefore(newAttr, attrColl[0]);
                    //attrColl.InsertBefore(newAttr_nom12, attrColl[0]);

                    xmlDoc.Save(xmlFile);
                }
                catch (Exception e)
                {
                }
            }

        }

        public string createPDF30(int intTipoComprobante, string strTipoComprobante, string path, string path2, string emisor, string receptor, string templateReportHeader, string templateReport, bool CFDAprobado)
        {
            //string fileNameXMLtemp="";
            string fechaActual = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') +
             "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');

            string fileNameOK = "";
            string fileNamepdfOK = "";
            string fileNameXmlOK = "";

            if (CFDAprobado)
            {
                
              //  fileNameXMLtemp = "adesoft.xml";

                fileNameOK = "c:\\myfacturae\\SIGN_adsoftOK.xml";
                
                fileNameXmlOK = path + "\\CFDi_" + strTipoComprobante.Replace(' ', '_') + "_" + emisor + "_" + receptor + "_" + fechaActual + ".xml";
                fileNameXmlOK = fileNameXmlOK.Replace("&", "");

                ExecuteCommandSync("copy c:\\myfacturae\\SIGN_adsoftOK.xml " + fileNameXmlOK);
                ExecuteCommandSync("copy c:\\myfacturae\\timbreCFDi.xml " + path + "\\TIMBRE_" + strTipoComprobante.Replace(' ', '_') + "_" + emisor + "_" + receptor + "_" + fechaActual + ".xml");
                fileNamepdfOK = path + "\\CFDi_"  + strTipoComprobante.Replace(' ', '_') + "_" + emisor + "_" + receptor + "_" + fechaActual + ".pdf";

            }
            else
            {

               // fileNameXMLtemp = "adesoft.xml";
                fileNameOK = "c:\\myfacturae\\adsoftOK.xml";

                fileNamepdfOK = path2 + "\\" + strTipoComprobante.Replace(' ', '_') + "TEST_"  + emisor + "_" + receptor + "_" + "_" + fechaActual + ".pdf";
            }
            fileNamepdfOK = fileNamepdfOK.Replace("&", "");

            ExecuteCommandSync("c:\\myfacturae\\xsltproc " + "c:\\myfacturae\\" + templateReportHeader + " " + fileNameOK + " > c:\\myfacturae\\header.html");
            ExecuteCommandSync("c:\\myfacturae\\xsltproc " + "c:\\myfacturae\\" + templateReport + " " + fileNameOK + " > c:\\myfacturae\\conceptos.html");
           
                ExecuteCommandSync("c:\\myfacturae\\wkhtmltopdf.exe --footer-html c:\\myfacturae\\footer.html --footer-spacing 2 --margin-bottom 40mm --header-html  c:\\myfacturae\\header.html --header-spacing 2 --margin-top 90mm --margin-left 2mm --margin-right 2mm c:\\myfacturae\\conceptos.html " + fileNamepdfOK);

            return fileNameXmlOK + "|" + fileNamepdfOK;
        }

        public string createPDF30Re(int intTipoComprobante, string strTipoComprobante, string path, string path2, string emisor, string receptor, string templateReportHeader, string templateReport, string UrlXML, bool CFDAprobado)
        {



            //string fileNameXMLtemp="";
            string fechaActual = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') +
             "_" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');

            string fileNameOK = "";
            string fileNamepdfOK = "";
            string fileNameXmlOK = "";

            if (CFDAprobado)
            {

                //  fileNameXMLtemp = "adesoft.xml";

                fileNameOK = UrlXML;

                //  fileNameXmlOK = path + "\\CFDi_" + strTipoComprobante.Replace(' ', '_') + "_" + emisor + "_" + receptor + "_" + fechaActual + ".xml";
                //  fileNameXmlOK = fileNameXmlOK.Replace("&", "");

                ExecuteCommandSync("copy c:\\myfacturae\\" + fileNameOK + fileNameXmlOK);
                // ExecuteCommandSync("copy c:\\myfacturae\\timbreCFDi.xml " + path + "\\TIMBRE_" + strTipoComprobante.Replace(' ', '_') + "_" + emisor + "_" + receptor + "_" + fechaActual + ".xml");
                fileNamepdfOK = path + "\\CFDi_" + strTipoComprobante.Replace(' ', '_') + "_" + emisor + "_" + receptor + "_" + fechaActual + ".pdf";

            }

            fileNamepdfOK = fileNamepdfOK.Replace("&", "");

            ExecuteCommandSync("c:\\myfacturae\\xsltproc " + "c:\\myfacturae\\" + templateReportHeader + " " + fileNameOK + " > c:\\myfacturae\\header.html");
            ExecuteCommandSync("c:\\myfacturae\\xsltproc " + "c:\\myfacturae\\" + templateReport + " " + fileNameOK + " > c:\\myfacturae\\conceptos.html");

            ExecuteCommandSync("c:\\myfacturae\\wkhtmltopdf.exe --footer-html c:\\myfacturae\\footer.html --footer-spacing 6 --margin-bottom 50mm --header-html  c:\\myfacturae\\header.html --header-spacing 2 --margin-top 80mm --margin-left 2mm --margin-right 2mm c:\\myfacturae\\conceptos.html " + fileNamepdfOK);

            return fileNamepdfOK;
        }
       


        public XmlTextWriter generateXMLCFD20Complemento(Complemento myComp)
        {

            //  XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();



            XmlTextWriter xmlTextWriter = new XmlTextWriter("c:\\myfacturae\\cad.xml", Encoding.UTF8);

            xmlTextWriter.Formatting = Formatting.Indented;
            XmlSerializer xs = new XmlSerializer(typeof(Complemento));

            xs.Serialize(xmlTextWriter, myComp, null);
            xmlTextWriter.Close();
            return xmlTextWriter;

        }
        public string getCertificado(string strFileCER, string strPasswd)
        {
            /*
             * Obtencion del CERTIFICADO
             */

            X509Certificate2 objCert = new X509Certificate2(strFileCER, strPasswd);
            StringBuilder objSB = new StringBuilder("Detalle del certificado: \n\n");
            /*
            objSB.AppendLine("Persona = " + objCert.Subject);
            objSB.AppendLine("Emisor = " + objCert.Issuer);
            objSB.AppendLine("Válido desde = " + objCert.NotBefore.ToString());
            objSB.AppendLine("Válido hasta = " + objCert.NotAfter.ToString());
            objSB.AppendLine("Tamaño de la clave = " + objCert.PublicKey.Key.KeySize.ToString());*/
            objSB.AppendLine("Número de serie = " + objCert.SerialNumber);
            //objSB.AppendLine("Hash = " + objCert.Thumbprint);

            string DatoHex = objCert.SerialNumber;
            string Data1 = "";
            string Resultado = "";

            while (DatoHex.Length > 0)
            {
                Data1 = System.Convert.ToChar(System.Convert.ToUInt32(DatoHex.Substring(0, 2), 16)).ToString();
                Resultado = (Resultado + Data1);
                DatoHex = DatoHex.Substring(2, DatoHex.Length - 2);
            }

           
            return (Resultado);
        }




        public string GetSello() 
        {
            return null;
        }





        public XmlTextWriter generateXMLCFD20(string fileName, dlleFac.Comprobante cfd, int idComprobante) 
        {
            
            
            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            
            
            
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/4");
            xmlNameSpace.Add("implocal", "http://www.sat.gob.mx/implocal");

            if (idComprobante == 6)
            {
                xmlNameSpace.Add("pago20", "http://www.sat.gob.mx/Pagos20");
            }

           

            

            XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName, Encoding.UTF8);
            
            xmlTextWriter.Formatting = Formatting.Indented;
            XmlSerializer xs = new XmlSerializer(typeof(dlleFac.Comprobante));
            
            xs.Serialize(xmlTextWriter, cfd, xmlNameSpace);
            xmlTextWriter.Close();
            return xmlTextWriter;
            
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



   

        


    }
}
