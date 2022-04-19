<xsl:stylesheet version = '1.0'
    xmlns:xsl='http://www.w3.org/1999/XSL/Transform'
    xmlns:cfdi='http://www.sat.gob.mx/cfd/3'
    xmlns:tfd='http://www.sat.gob.mx/sitio_internet/TimbreFiscalDigital/TimbreFiscalDigital.xsd'
                >

  <xsl:output method = "html" />
  <xsl:param name="id" select="."/>

  <xsl:template match="//cfdi:Comprobante">
    <html>
      <head>
        <link rel="STYLESHEET" media="screen" type="text/css" href="factura.css"/>
        <title>
          Factura Electronica <xsl:value-of select="@serie"/><xsl:value-of select="@folio"/>
        </title>
      </head>

      <fieldset>

        <body>

<legend>
  <font color="black" face="arial" size="1">
    <b>
      CFDi - Comprobante Fiscal Digital por Internet
    </b>
  </font>
</legend>
          <table border="0" bordercolor="blue">
            <tr>
              <td class="h2" align="center">
                <center>
                  <font  size="2">
                    <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/TipoComprobante"/>
                  </font>
                </center>
              </td>
            </tr>
          </table>

            <table width="100%">
            <tr>
              <td colspan ="2">
                <img src="c:\myfacturae\encabezado.jpg" weigth="1200" heigth="200"/>
              </td>
            </tr>
            <tr>
              <td width="65%">


                <fieldset>

                  <table width="100%" border="0">
                    <legend>
                      <font face="Britannic Bold"  size="2">
                        DATOS FISCALES
                      </font>
                    </legend>
                    <!--
                    <tr>
                      <th colspan="2" class="h1">DATOS FISCALES</th>
                    </tr>
-->
                    <tr width="100%">

                      <td>
                         <font size="1">
                           Serie/Folio:     

                         </font>
                      </td>
                      <td>
                        <font size="1">
                          <b>
                          <xsl:value-of select="@Serie"/>-
                          <xsl:value-of select="@Folio"/>
                            </b>
                        </font>
                      </td>


                      <td>
                        <font  size="1">
                          Uso de Cfdi:
                        </font>
                      </td>
                      <td>
                        <font  size="1">
                          <b>
                            <xsl:value-of select="cfdi:Receptor/@UsoCFDI"/>
                          </b>


                        </font>
                      </td>
                      
                      

                      <!-- <td>
                        <font  size="1">
                          Regimen Fiscal:
                        </font>
                      </td>
                      <td>
                        <font  size="1">
                          <b>
                            <xsl:value-of select="cfdi:Emisor/cfdi:RegimenFiscal/@Regimen"/>
                          </b>


                        </font>
                      </td>
                      
                      
                      <td>
                        <font size="1">
                          Tasa de Cambio: 
                        </font>
                      </td>
                      <td>
                        <font  size="1">
                          <b>
                            <xsl:value-of select="@TipoCambio"/>
                          </b>


                        </font>
                      </td>-->
                   
                    </tr>

                    <tr width="100%">

                      <td>
                        <font size="1">
                         Lugar de Expedicion: 
                        </font>
                      </td>
                      <td>
                        <font size="1" >
                          <b>
                            <xsl:value-of select="@LugarExpedicion"/>
                          </b>
                        </font>
                      </td>
                      <td>
                        <font  size="1">
                          Regimen Fiscal:
                        </font>
                      </td>
                      <td>
                        <font  size="1">
                          <b>
                            <xsl:value-of select="cfdi:Emisor/@RegimenFiscal"/>
                          </b>


                        </font>
                      </td>



                      <!--<td>
                        <font size="1">
                          Motivo Descuento:
                        </font>
                      </td>
                      <td>
                        <font size="1">
                          <b>
                          <xsl:value-of select="@motivoDescuento"/>
                          </b>
                        </font>
                      </td>
                      -->
                    </tr>

                    <tr width="100%">

                      <td>
                        <font  size="1">
                          Tipo de Comprobante:
                        </font>
                      </td>
                      <td>
                        <font size="1">
                         <b> <xsl:value-of select="@TipoDeComprobante"/>
                           </b>
                        </font>
                      </td>


                      <td>
                        <font size="1">
                          Método de Pago:
                        </font>
                      </td>
                      <td>
                        <font size="1">
                          <b>
                            <xsl:value-of select="@MetodoPago"/>
                          </b>
                        </font>
                      </td>
                    </tr>

                    <tr width="100%">

                      <td>
                        <font size="1">
                          Certificado Emisor:
                        </font>
                      </td>
                      <td>
                        <font size="1">
                          <b><xsl:value-of select="@NoCertificado"/>
                            </b>
                        </font>
                      </td>


                      <td>
                        <font size="1">
                          Forma de Pago:
                        </font>
                      </td>
                      <td>
                        <font  size="1">
                          <b>
                          <xsl:value-of select="@FormaPago"/>
                            </b>
                        </font>
                      </td>
                    </tr>

                    

                    <tr width="100%">

                      <td>
                        <font size="1">
                          Divisa:
                        </font>
                      </td>
                      <td>
                        <font size="1">
                          <b> <xsl:value-of select="@Moneda"/>
                            </b>
                        </font>
                      </td>


                      <td>
                        <font  size="1">
                          Condiciones de pago:
                        </font>
                      </td>
                      <td>
                        <font  size="1">
                          <b>
                          <xsl:value-of select="@CondicionesDePago"/>
                            </b>
                        </font>
                      </td>
                    </tr>
                    
                
                  </table>
                </fieldset>
              </td>




              <td width="35%">
                <fieldset>

                  <table width="100%" border="0">

                    
                      <legend>
                        <font face="Britannic Bold"  size="2">
                         DATOS DE TIMBRADO
                        </font>
                      </legend>
                    
                    
                    <tr>
                      <td>
                        <font  size="1">
                          Certificado SAT:
                          <br></br>
                            <b>
                              <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/NoCertificadoSAT"/>
                            </b>
                        </font>
                      </td>
                    </tr>

                    <tr>
                      <td>
                        <font  size="1">
                          Folio Fiscal:
                          <br></br>
                          <b>

                            <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/UUID"/>
                            </b>
                        </font>  
                      </td> 
                    </tr>

                    <tr>
                      <td>
                        <font size="1">
                    Fecha de Certificación del CFDi:
                    <br></br>
                        <b>

                          <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/FechaTimbrado"/>
                          </b>
                        </font>
                      </td>
                    </tr>

                    <tr>
                      <td>
                        <font size="1">
                          Fecha Emision de Comprobante:
                          <br></br>
                          <b>

                            <xsl:value-of select="@Fecha"/>
                          </b>
                        </font>
                      </td>
                    </tr>                    
                    
                    
                  </table>
                </fieldset>


              </td>
            </tr>
          </table>
          
             <table width="100%">

                <!--<tr>
                  <td width="100%" Colspan ="2">


                    <fieldset border="0">
                      <legend>
                        <font face="Britannic Bold"  size="2">
                          LUGAR DE EXPEDICION
                        </font>
                        
                      </legend>

                      <font  size="1">
                      <b>
                        <xsl:value-of select="@LugarExpedicion"/>
                      </b>                        
                        </font>

                    </fieldset>
                  </td>

                </tr>-->
              <tr>
              <td width="50%">


                <fieldset border="0">

                  <table width="100%" border="0">

                    <legend>
                      <font face="Britannic Bold"  size="2">
                        EMISOR
                      </font>
                    </legend>

                    <tr width="100%">

                      <td>

                        <font  size="1">
                          Nombre :
                          <b>
                            <xsl:value-of select="cfdi:Emisor/@Nombre"/>                          
                            </b>
                        </font>
                      </td>
                    </tr>

                    <tr width="100%">
                      <td>
                        <font size="1">
                          RFC :
                          <b>
                            <xsl:value-of select="cfdi:Emisor/@Rfc"/>                          
                            </b>
                        </font>
                      </td>
                    </tr>
                    <font  size="1">
                      <b>
                      <!--<xsl:apply-templates select="//cfdi:DomicilioFiscal"/>-->
                        </b>
                    </font>

                  </table>
                </fieldset>
              </td>




              <td width="50%">
                <fieldset>
                  <table width="100%" border="0">
                    <legend>
                      <font face="Britannic Bold"  size="2">
                        RECEPTOR
                      </font>
                    </legend>

                    <tr width ="100%">
                      
                      <td width="75%">
                        <font  size="1">
                         Nombre: <b>
                           <xsl:value-of select="cfdi:Receptor/@Nombre"/>
                          
                        </b>
                        </font>
                      </td>
                    </tr>


                    <tr>
                      
                      <td>
                        
                        <font size="1">
                          RFC: <b>
                            <xsl:value-of select="cfdi:Receptor/@Rfc"/>
                        </b>
                        </font>
                      </td>
                    </tr>

                    <font size="1">
                      <b> <!--<xsl:apply-templates select="//cfdi:Domicilio"/>-->
                        </b>
                    </font>

                  </table>
                </fieldset>
              </td>
            </tr>


          </table>

        </body>
      </fieldset>
    </html>

  </xsl:template>



  
  
  <xsl:template match="//cfdi:DomicilioFiscal">


    
    <tr>
      <td colspan="2">
        <font   size="1">
          Domicilio:
          <b>
          <xsl:value-of select="@calle"/><font color="white" face="Courier New" size="1">,</font>
            
            
          <xsl:value-of select="@noExterior"/><font color="white" face="Courier New" size="1">,</font>
            
          <xsl:value-of select="@noInterior"/><font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@colonia"/><font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@municipio"/><font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@estado"/><font color="white" face="Courier New" size="1">,</font>
          
          C.P. <xsl:value-of select="@codigoPostal"/>
        </b>
        </font>

      </td>


    </tr>

    
   
    


  </xsl:template>





  <xsl:template match="//cfdi:Domicilio">

    
    <tr>
      <td colspan="2">
        <font  size="1">
    
          Domicilio: 
          <b>
          <xsl:value-of select="@calle"/>
            <font color="white" face="Courier New" size="1">,</font>

          <xsl:value-of select="@noExterior"/>
            <font color="white" face="Courier New" size="1">,</font>

          <xsl:value-of select="@noInterior"/>
            <font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@colonia"/>
            <font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@municipio"/>
            <font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@estado"/>
            <font color="white" face="Courier New" size="1">,</font>
           
            <font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@codigoPostal"/>
        </b>
        </font>
      </td>
    </tr>

 
 
 
  </xsl:template>

  <xsl:template match="//cfdi:ExpedidoEn">



    <xsl:value-of select="@calle"/><font color="white" face="Courier New" size="1">,</font>


    <xsl:value-of select="@noExterior"/><font color="white" face="Courier New" size="1">,</font>

    <xsl:value-of select="@noInterior"/><font color="white" face="Courier New" size="1">,</font>
    <xsl:value-of select="@colonia"/><font color="white" face="Courier New" size="1">,</font>
    <xsl:value-of select="@municipio"/><font color="white" face="Courier New" size="1">,</font>
    <xsl:value-of select="@estado"/><font color="white" face="Courier New" size="1">,</font>
     
    C.P. <xsl:value-of select="@codigoPostal"/>






  </xsl:template>




</xsl:stylesheet>






