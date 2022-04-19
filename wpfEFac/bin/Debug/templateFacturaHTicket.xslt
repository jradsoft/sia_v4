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
  <font color="black" face="arial" size="3">
    <b>
      CFDi - Comprobante Fiscal Digital por Internet
    </b>
  </font>
</legend>
          <table border="0" bordercolor="blue">
            <tr>
              <td class="h2" align="center">
                <center>
                  <font  face="arial" size="3">
                    <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/TipoComprobante"/>
                  </font>
                </center>
              </td>
            </tr>
          </table>

            <table width="100">
            <!--<tr>-->
              <td width="25%" valign="top">
                <img src="c:\myfacturae\encabezado.jpg" weigth="1200" heigth="200"/>
              </td>


              
                

              <td width="50%" align="center">
                <fieldset border="0">
                <table width="100%" border="0" align="center">

                  
                  <legend >
                    <font face="Britannic Bold" size="2">
                      
                        DATOS DE TIMBRADO
                        
                  </font>    
                      </legend>


                  <tr>
                    <td>
                      <font  face="Courier New" size="3">
                        Serie/Folio
                        <br></br>
                        <b>
                          <xsl:value-of select="@serie"/> -
                          <xsl:value-of select="@folio"/>
                          <!--<xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/NoCertificadoSAT"/>-->
                        </b>
                      </font>
                    </td>
                  </tr>


                  <tr>
                    <td>
                      <font  face="Courier New" size="1">
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
                      <font  face="Courier New" size="1">
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
                      <font  face="Courier New" size="1">
                        Certificado Emisor:
                        <br></br>
                        <b>

                          <xsl:value-of select="@noCertificado"/>
                        </b>
                      </font>
                    </td>
                  </tr>

                  <tr>
                    <td>
                      <font face="Courier New" size="1">
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
              
              
            <!--</tr>-->
            <!--<tr>
              <td width="65%">


                <fieldset>

                  <table width="100%" border="0">
                    <legend>DATOS FISCALES</legend>
                    --><!--
                    <tr>
                      <th colspan="2" class="h1">DATOS FISCALES</th>
                    </tr>
--><!--
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
            </tr>-->
          </table>
          
              <table width="100%">

            <tr>
              <td width="50%">


                <fieldset border="0">

                  <table width="100%" border="0">

                    <legend>
                      <font  face="Britannic Bold" size="2">
                        DATOS FISCALES
                      </font>
                    </legend>
                    <tr>
                    <td colspan="2">
                      <font  face="Courier New" size="1">
                        Fecha Emisión:
                      </font>
                    </td>
                    <td>
                      <font  face="Courier New" size="1" >
                        <b>
                          <xsl:value-of select="@fecha"/>
                        </b>
                      </font>
                    </td>
                    <td colspan="2">
                      <font  face="Courier New" size="1">
                       Condiciones Pago:
                      </font>
                    </td>
                    <td>
                      <font  face="Courier New" size="1" >
                        <b>
                          <xsl:value-of select="@condicionesDePago"/>
                        </b>
                      </font>
                    </td>
                      </tr>

                    <tr>
                      <td colspan="2">
                        <font face="Courier New" size="1">
                          Metodo Pago:
                        </font>
                      </td>
                      <td>
                        <font face="Courier New" size="1" >
                          <b>
                            <xsl:value-of select="@metodoDePago"/>
                          </b>
                        </font>
                      </td>
                      <td colspan="2">
                        <font face="Courier New" size="1">
                          Forma Pago:
                        </font>
                      </td>
                      <td>
                        <font  face="Courier New" size="1" >
                          <b>
                            <xsl:value-of select="@formaDePago"/>
                          </b>
                        </font>
                      </td>
                    </tr>


                    <tr>
                      <td colspan="2">
                        <font face="Courier New" size="1">
                          N° Cuenta:
                        </font>
                      </td>
                      <td>
                        <font  face="Courier New" size="1" >
                          <b>
                            <xsl:value-of select="@NumCtaPago"/>
                          </b>
                        </font>
                      </td>
                      <td colspan="2">
                        <font  face="Courier New" size="1">
                          Expedido en:
                        </font>
                      </td>
                      <td>
                        <font  face="Courier New" size="1" >
                          <b>
                            <xsl:value-of select="@LugarExpedicion"/>
                          </b>
                        </font>
                      </td>
                    </tr>

                  


                    
                    
                    
                    <!--<tr width="100%">

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
                    </font>-->

                  </table>
                </fieldset>
              </td>




              <td width="50%">
                <fieldset>
                  <table width="100%" border="0">
                    <legend>
                      <font  face="Britannic Bold" size="2">
                      RECEPTOR
                      </font>
                    </legend>

                    <tr width ="100%">
                      
                      <td width="75%">
                        <font  face="Courier New" size="1">
                         RFC: <b>
                          <xsl:value-of select="cfdi:Receptor/@rfc"/>
                        </b>
                        </font>
                      </td>
                    </tr>


                    <tr>
                      
                      <td>
                        
                        <font  face="Courier New" size="1">
                          Nombre: <b>
                          <xsl:value-of select="cfdi:Receptor/@nombre"/>
                        </b>
                        </font>
                      </td>
                    </tr>

                    <font  face="Courier New" size="1">
                      <b> <xsl:apply-templates select="//cfdi:Domicilio"/>
                        </b>
                    </font>

                  </table>
                </fieldset>
              </td>
            </tr>


          </table>

          <table width="100%">


            <xsl:if test="//cfdi:CfdiRelacionados">
              <tr>



                <th>Tipo de Relación</th>

                <th>CFDi Relacionados</th>

              </tr>

              <tr>

                <td align="center">
                  <font color="#000000" face="Courier New" size="3">
                    <b>

                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='01')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Notas de Crédito de Documentos Relacionados
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='02')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Notas de Débito de los Documentos Relacionados
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='03')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Devolución de Mercancías sobre Facturas o Traslados Previos
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='04')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Sustitución de los CFDI Previos
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='05')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Traslados de Mercancías Facturados Previamente
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='06')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Factura Generada por los Traslados Previos
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='07')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-CFDI por Aplicación de Anticipo
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='08')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Facturas Generadas por Pagos en Parcialidades
                      </xsl:if>
                      <xsl:if test="(//cfdi:CfdiRelacionados/@TipoRelacion='09')">
                        <xsl:value-of select="//cfdi:CfdiRelacionados/@TipoRelacion"/>-Factura Generada por Pagos Diferidos
                      </xsl:if>
                    </b>
                  </font>
                </td>

                <td align="center">
                  <font color="#000000" face="Courier New" size="3" align="center">
                    <b>

                      <xsl:for-each select="//cfdi:CfdiRelacionados/cfdi:CfdiRelacionado">
                        <xsl:value-of select="@UUID"/>
                        <br></br>
                      </xsl:for-each>

                    </b>
                  </font>
                </td>



              </tr>
            </xsl:if>



          </table>

        </body>
      </fieldset>
    </html>

  </xsl:template>



  
  
  <xsl:template match="//cfdi:DomicilioFiscal">


    
    <tr>
      <td colspan="2">
        <font  face="Courier New" size="3">
          Domicilio:
          <b>
          <xsl:value-of select="@calle"/><font color="white" face="Courier New" size="1">,</font>
            
            
          <xsl:value-of select="@noExterior"/><font color="white" face="Courier New" size="1">,</font>
            
          <xsl:value-of select="@noInterior"/><font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@colonia"/><font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@municipio"/><font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@estado"/><font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@pais"/><font color="white" face="Courier New" size="1">,</font>
          C.P. <xsl:value-of select="@codigoPostal"/>
        </b>
        </font>

      </td>


    </tr>

    
   
    


  </xsl:template>





  <xsl:template match="//cfdi:Domicilio">

    
    <tr>
      <td colspan="2">
        <font  face="Courier New" size="1">
    
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
          <xsl:value-of select="@pais"/>
            <font color="white" face="Courier New" size="1">,</font>
          <xsl:value-of select="@codigoPostal"/>
        </b>
        </font>
      </td>
    </tr>

 
 
 
  </xsl:template>





</xsl:stylesheet>






