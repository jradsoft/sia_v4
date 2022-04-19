﻿<xsl:stylesheet version = '1.0'
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
  <font color="red" face="arial" size="6">
    <b>
      
    </b>
  </font>
</legend>
          <table border="0" bordercolor="blue">
            <tr>
              <td class="h2" align="center">
                <center>
                  <font color="#0B0B6" face="arial" size="6">
                    <!--<xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/TipoComprobante"/>-->
                  </font>
                </center>
              </td>
            </tr>
          </table>

            <table width="50">
            <tr>
              <td colspan ="2">
                <img src="c:\myfacturae\encabezado.png" weigth="600" heigth="200"/>
              </td>
            </tr>
            <tr>
              <td width="65%">


                <fieldset>

                  <table width="100%" border="0">
                    <legend>DATOS FISCALES</legend>
                    <!--
                    <tr>
                      <th colspan="2" class="h1">DATOS FISCALES</th>
                    </tr>
-->
                    <tr width="100%">

                      <td>
                         <font color="#0B0B6" face="Courier New" size="5">
                           Serie/Folio:     

                         </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          <b>
                          <xsl:value-of select="@serie"/>
                          <xsl:value-of select="@folio"/>
                            </b>
                        </font>
                      </td>
                      
                      
                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          Tasa de Cambio: 
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          <b>
                            <xsl:value-of select="@TipoCambio"/>
                            <xsl:value-of select="@NumCtaPago"/>
                          </b>


                        </font>
                      </td>
                    </tr>

                    <tr width="100%">

                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          Fecha Emisión de Comprobante: 
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="5" >
                          <b>
                            <xsl:value-of select="@fecha"/>
                          </b>
                        </font>
                      </td>


                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          Motivo Descuento:
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          <b>
                          <xsl:value-of select="@motivoDescuento"/>
                          </b>
                        </font>
                      </td>
                    </tr>

                    <tr width="100%">

                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          Tipo de Comprobante:
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                         <b> <xsl:value-of select="@tipoDeComprobante"/>
                           <xsl:value-of select="@NumCtaPago"/>
                           </b>
                        </font>
                      </td>


                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          Método de Pago:
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          <b>
                            <xsl:value-of select="@metodoDePago"/>
                          </b>
                        </font>
                      </td>
                    </tr>

                    <tr width="100%">

                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          Certificado Emisor:
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          <b><xsl:value-of select="@noCertificado"/>
                            </b>
                        </font>
                      </td>


                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          Forma de Pago:
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="5">
                          <b>
                          <xsl:value-of select="@formaDePago"/>
                            </b>
                        </font>
                      </td>
                    </tr>

                    

                    <tr width="100%">

                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          Divisa:
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          <b> <xsl:value-of select="@Moneda"/>
                            </b>
                        </font>
                      </td>


                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          Condiciones de pago:
                        </font>
                      </td>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          <b>
                          <xsl:value-of select="@condicionesDePago"/>
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

                    
                      <legend>DATOS DE TIMBRADO</legend>
                    
                    
                    <tr>
                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
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
                        <font color="#0B0B6" face="Courier New" size="3">
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
                        <font color="#0B0B6" face="Courier New" size="3">
                    Fecha de Certificación del CFDi:
                    <br></br>
                        <b>

                          <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/FechaTimbrado"/>
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

            <tr>
              <td width="50%">


                <fieldset border="0">

                  <table width="100%" border="0">

                    <legend>
                      EMISOR
                    </legend>

                    <tr width="100%">

                      <td>

                        <font color="#0B0B6" face="Courier New" size="3">
                          RFC :
                          <b>
                          <xsl:value-of select="cfdi:Emisor/@rfc"/>
                            </b>
                        </font>
                      </td>
                    </tr>

                    <tr width="100%">
                      <td>
                        <font color="#0B0B6" face="Courier New" size="3">
                          Nombre :
                          <b>

                          <xsl:value-of select="cfdi:Emisor/@nombre"/>
                            </b>
                        </font>
                      </td>
                    </tr>
                    <font color="#0B0B6" face="Courier New" size="3">
                      <b>
                      <xsl:apply-templates select="//cfdi:DomicilioFiscal"/>
                        </b>
                    </font>

                  </table>
                </fieldset>
              </td>




              <td width="50%">
                <fieldset>
                  <table width="100%" border="0">
                    <legend>
                      RECEPTOR
                    </legend>

                    <tr width ="100%">
                      
                      <td width="75%">
                        <font color="#0B0B6" face="Courier New" size="3">
                         RFC: <b>
                          <xsl:value-of select="cfdi:Receptor/@rfc"/>
                        </b>
                        </font>
                      </td>
                    </tr>


                    <tr>
                      
                      <td>
                        
                        <font color="#0B0B6" face="Courier New" size="3">
                          Nombre: <b>
                          <xsl:value-of select="cfdi:Receptor/@nombre"/>
                        </b>
                        </font>
                      </td>
                    </tr>

                    <font color="#0B0B6" face="Courier New" size="3">
                      <b> <xsl:apply-templates select="//cfdi:Domicilio"/>
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
        <font color="#0B0B6" face="Courier New" size="3">
          Domicilio:
          <b>
          <xsl:value-of select="@calle"/><font color="white" face="Courier New" size="3">,</font>
            
            
          <xsl:value-of select="@noExterior"/><font color="white" face="Courier New" size="3">,</font>
            
          <xsl:value-of select="@noInterior"/><font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@colonia"/><font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@municipio"/><font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@estado"/><font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@pais"/><font color="white" face="Courier New" size="3">,</font>
          C.P. <xsl:value-of select="@codigoPostal"/>
        </b>
        </font>

      </td>


    </tr>

    
   
    


  </xsl:template>





  <xsl:template match="//cfdi:Domicilio">

    
    <tr>
      <td colspan="2">
        <font color="#0B0B6" face="Courier New" size="3">
    
          Domicilio: 
          <b>
          <xsl:value-of select="@calle"/>
            <font color="white" face="Courier New" size="3">,</font>

          <xsl:value-of select="@noExterior"/>
            <font color="white" face="Courier New" size="3">,</font>

          <xsl:value-of select="@noInterior"/>
            <font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@colonia"/>
            <font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@municipio"/>
            <font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@estado"/>
            <font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@pais"/>
            <font color="white" face="Courier New" size="3">,</font>
          <xsl:value-of select="@codigoPostal"/>
        </b>
        </font>
      </td>
    </tr>

 
 
 
  </xsl:template>





</xsl:stylesheet>






