<xsl:stylesheet version = '1.0'
    xmlns:xsl='http://www.w3.org/1999/XSL/Transform'
    xmlns:cfdi='http://www.sat.gob.mx/cfd/3'>
 
<xsl:output method = "html" /> 
<xsl:param name="id" select="."/>
 
<xsl:template match="//cfdi:Comprobante">
   <html>
     <head>
       <meta charset="utf-8"/>
       
       
       
     </head>


     <table  width="100%">
       <tr>
              <td >
                <img src="c:\myfacturae\encabezadoTicket.jpg"/>
              </td>
       </tr>
     </table>
        


         <table cellpadding="2"  width="100%" border="0" valign="top">





       <tr width="100%">
         <td>
           <font color="black" face="arial" size="9">

             <b>

               <xsl:value-of select="cfdi:Emisor/@Nombre"/>
             </b>
           </font>
         </td>
       </tr>

       <tr width="100%">
         <td>
           <font color="black" face="arial" size="9">
             RFC :
             <b>
               <xsl:value-of select="cfdi:Emisor/@Rfc"/>
             </b>
           </font>
         </td>
       </tr>

       <tr>
         <!--<td width="100%">
           <font color="black" face="arial" size="9">
             <b>
               <xsl:apply-templates select="//cfdi:DomicilioFiscal"/>
             </b>
           </font>
         </td>-->
       </tr>

     </table>
     
     <br/>

     <table width="100%" border="0" valign="top">

       <tr width="100%">
         <td>
           <font color="black" face="arial" size="9">
             <b>
               DATOS DEL CLIENTE
             </b>
           </font>
         </td>
       </tr>
     </table>
     
     
     <table width="100%" border="0" valign="top">
       <tr width="100%">

         <td>

           <font color="black" face="arial" size="9">
             <b>
               Cliente:
               <xsl:value-of select="cfdi:Receptor/@Nombre"/>
             </b>
           </font>
         </td>
       </tr>


       <tr width ="100%">

         <td>
           <font color="black" face="arial" size="9">
             RFC: <b>
               <xsl:value-of select="cfdi:Receptor/@Rfc"/>
             </b>
           </font>
         </td>
       </tr>



       <font color="black" face="arial" size="9">
         <b>
           <!--<xsl:apply-templates select="//cfdi:Domicilio"/>-->
         </b>
       </font>



     </table>

     <br/>
     <br/>

     <table width="100%" border="0" valign="top">
       <tr width ="100%">

         <td width ="50%">
           <font color="black" face="arial" size="9">
             Lugar Expedicion<b>

             </b>
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@LugarExpedicion"/>
             </b>
           </font>
         </td>

         <td width ="50%" >
           <font color="black" face="arial" size="9">
             Forma de Pago<b>

             </b>
           </font>
         </td>

         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@FormaPago"/>
             </b>
           </font>
         </td>
       </tr>
       
     </table>

     <table width="100%" border="0" valign="top">
       <tr width ="100%">
         <td width ="50%">
           <font color="black" face="arial" size="9">
             Regimen Fiscal:
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="cfdi:Emisor/@RegimenFiscal"/>
             </b>
           </font>
         </td>

         <td  width ="50%">
           <font color="black" face="arial" size="9">
             Tipo de Comprobante:
           </font>
         </td>
         <td >
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@TipoDeComprobante"/>
             </b>
           </font>
         </td>
       </tr>       
     </table>
     
     <table width="100%" border="0" valign="top">
   
       <tr border="1"  width ="100%">
         <td width ="50%">
           <font color="black" face="arial" size="9">
             Fecha de Certificacion:
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/FechaTimbrado"/>
             </b>
           </font>
         </td>

         <td width ="50%">
           <font color="black" face="arial" size="9">
             Fecha Emision:
           </font>
         </td>
         <td >
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@Fecha"/>
             </b>
           </font>
         </td>

       </tr>

      

       <tr width ="100%">
         <td>
           <font color="black" face="arial" size="9">
             Certificado SAT:
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/NoCertificadoSAT"/>
             </b>
           </font>
         </td>

         <td>
           <font color="black" face="arial" size="9">
             Certificado de Emisor:
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@NoCertificado"/>
             </b>
           </font>
         </td>
       </tr>
      

     </table>

     <table width="100%" border="0" valign="top">
      
       <tr width ="100%">
         <td width="50%">
           <font color="black" face="arial" size="9">
             Serie/Folio:
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@Serie"/>
               <xsl:value-of select="@Folio"/>
             </b>
           </font>
         </td>

         <td width="50%">
           <font color="black" face="arial" size="9">
             Método de Pago:
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@MetodoPago"/>
             </b>
           </font>
         </td>
       </tr>


     </table>

     <table width="100%" border="0" valign="top">
       <tr width ="100%">

         <td width="50%">
           <font color="black" face="arial" size="9">
             Folio Fiscal<b>

             </b>
           </font>
         </td>

         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/UUID"/>
             </b>
           </font>
         </td>

         <td width="50%">
           <font color="black" face="arial" size="9">
             Divisa:
           </font>
         </td>
         <td>
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="@Moneda"/>
             </b>
           </font>
         </td>
       </tr>
     </table>
   
   

     <br/>
     <table width="100%" border="1" valign="top">




       <tr   width ="100%">
         <td width ="10%">
           <font color="black" face="arial" size="9">
             <b>
               Codigo
             </b>
           </font>
         </td>
         <td width ="10%">
           <font color="black" face="arial" size="9">
             <b>
               Cantidad
             </b>
           </font>
         </td>
         <td width ="10%">
           <font color="black" face="arial" size="9">
             <b>
               Clave_Unidad
             </b>
           </font>
         </td>
         <td width ="10%">
           <font color="black" face="arial" size="9">
             <b>
              Unidad
             </b>
           </font>
         </td>

         <td width ="40%">
           <font color="black" face="arial" size="9">
             <b>
               Descripcion
             </b>
           </font>
         </td>
         <td width ="20%" >
           <font color="black" face="arial" size="9">
             <b>
               Precio Unitario
             </b>
           </font>
         </td>
         <td width ="20%">
           <font color="black" face="arial" size="9">
             <b>
               Importe
             </b>
           </font>
         </td>

       </tr>



       <tr width ="100%">
         
           <td>
             <font color="black" face="arial" size="9">
               <b>
                 <xsl:apply-templates select="//cfdi:Concepto"/>
                 <xsl:for-each select="Concepto">
                 </xsl:for-each>
               </b>
             </font>
           </td>
       
       </tr>


     </table>


   

     <table width="100%" align="right" border="0" valign="top">

       <tr>
         <td></td>
         <td align="right">
           <font color="black" face="arial" size="9">
             <b>
               Subtotal:
               <font color="#FFFFFF" >_</font>
               <xsl:value-of select='format-number(@SubTotal,"$###,###,###.00")'/>
             </b>
           </font>
         </td>
       </tr>

       <xsl:if test="@Descuento > 0 ">
         <tr>
           <td></td>
           <td align="right">
             <font color="black" face="arial" size="9">
               <b>
                 Descuento:
                 <font color="#FFFFFF" >_</font>
                 <xsl:value-of select='format-number(@Descuento,"$###,###,###.00")'/>
               </b>
             </font>
           </td>
         </tr>
       </xsl:if>

       <tr>
         <td></td>
         <td align="right">
           <font color="black" face="arial" size="9">
             <b>
               <xsl:value-of select="//cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado/@Impuesto"/>-IVA:
              
               <font color="#FFFFFF" >_</font>
               <xsl:value-of select='format-number(//cfdi:Impuestos/@TotalImpuestosTrasladados,"$###,###,###.00")' />
             </b>
           </font>
         </td>
       </tr>

    



       <!--<tr>
        
           <font color="black" face="arial" size="9">
             <xsl:apply-templates select="//cfdi:Traslado"/>
             <xsl:for-each select="Traslado">
             </xsl:for-each>
           </font>
        
       </tr>
       <tr>
         <font color="black" face="arial" size="9">
           <b>
             <xsl:apply-templates select="//cfdi:Retencion"/>
             <xsl:for-each select="Retencion">
             </xsl:for-each>
           </b>
         </font>
       </tr>-->

       <tr>
         <td></td>
         <td align="right">

           <font color="black" face="arial" size="9">

             <b>
               Total:
                <font color="#FFFFFF" >_</font><xsl:value-of select='format-number(@Total,"$###,###,###.00")'/>
             </b>

           </font>


         </td>
       </tr>
       


     </table>

     <br/>

     <table width="100%" border="0" valign="top">
       <tr width ="100%">


         <td  width ="100%">
           <font color="black" face="arial" size="9">
             <b>Cantidad con Letra
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/CantidadLetra"/>
             </b>
           </font>
         </td>
       </tr>
     </table>

     
     <!--QR-->

    

     <table width="100%" border="0" valign="top">
       <tr width ="50%">


         <td >
           <img width="500" height="500"  src="c:\myfacturae\cbb.jpg"/>
         </td>

       </tr>
    
       
     </table>
     <table width="100%" border="0" valign="top">
       <tr width ="10%">
         <center>
         <font color="black" align-="center" face="arial" size="5">

           <b> ESTE DOCUMENTO ES UNA REPRESENTACION IMPRESA DE UN CFDi </b>
           <br/>
             EL REGISTRO DE ESTE DOCUMENTO PUEDE SER VERIFICADO EN LA PAGINA DE INTERNET DEL SAT
             <br/>
               <b> https://verificacfdi.facturaelectronica.sat.gob.mx/ </b>
               <br/>
                 <br/>
                  <br/>
         </font>
          </center>
         
       </tr>


     </table>









     <table width="100%" border="0" valign="top">
       <tr width ="100%">


         <td>

           <font color="black" align-="center" face="arial" size="6">
             <b>
               Cadena Original SAT:
             </b>
           </font>
             <font color="black" face="arial" size="6">
             
             <br></br>
             <b>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD, 0, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD, 60, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD, 120, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD, 180, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD, 240, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD, 300, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD, 360, 60)"/>


               <!--<xsl:value-of select="substring(cfdi:Addenda/Documento/FacturaAdesoft/@selloSAT, 0, 160)"/>
               <br></br>
               <xsl:value-of select="substring(cfdi:Addenda/Documento/FacturaAdesoft/@selloSAT, 160)"/>-->


             </b>
           </font>
         </td>
       </tr>
       
       <tr width ="100%">
         <td>

           <font color="black" align-="center" face="arial" size="6">
             <b>
               Sello Digital:
             </b>
           </font>
           <font color="black" face="arial" size="6">

             <br></br>
             <b>
              
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloCFD, 0, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloCFD, 60, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloCFD, 120, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloCFD, 180, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloCFD, 240, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloCFD, 360, 60)"/>
               
               
             </b>
           </font>
         </td>
       </tr>

       <tr width ="100%">
         <td>

           <font color="black" align-="center" face="arial" size="6">
             <b>
               Sello SAT:
             </b>
           </font>
           <font color="black" face="arial" size="6">

             <br></br>
             <b>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloSAT, 0, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloSAT, 60, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloSAT, 120, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloSAT, 180, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloSAT, 240, 60)"/>
               <br></br>
               <xsl:value-of select="substring(document('c:/myfacturae/cad.xml')/Complemento/SelloSAT, 360)"/>
               
             </b>
           </font>
         </td>
       </tr>
       
       
     </table>

     <br/>
     <br/>
     <br/>
     <br/>





     <!--<tr>
     
      
       <hr></hr>
       <br></br>
       <b>
       <th>
         <font color="black" face="arial" size="9">
           Cantidad
         </font>
       </th>

       <th>
         <font color="black" face="arial" size="9">
           Unidad
         </font>
       </th>

       <th>
         <font color="black" face="arial" size="9">
           Descripcion
         </font>

       </th>
       <br></br>
       <th>
         <font color="black" face="arial" size="9">
           Precio Unitario
         </font>

       </th>
       <th>
         <font color="black" face="arial" size="9">
           Importe
         </font>
       </th>
       </b>
     </tr>

     <br></br>
     <hr></hr>


 <tr>
   <td>
     <font color="black" face="arial" size="9">
       <b>
         <xsl:apply-templates select="//cfdi:Concepto"/>
         <xsl:for-each select="Concepto">
         </xsl:for-each>
       </b>
     </font>
   </td>
 </tr>

     <hr></hr>
     <tr>
     <td>
       <font color="black" face="arial" size="9">
         <pre>
           <b>
             observ: <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/Observaciones"/>
           </b>
         </pre>
       </font>
     </td>
     </tr>

     <table>
     <tr>

     <td align="right">
       
         <font color="black" face="arial" size="9">

           <b>
             Subtotal:<xsl:value-of select='format-number(@subTotal,"$###,###,###.00")'/>
           </b>

         </font>
       

     </td>

     </tr>
     
     <tr>
       <td>
         <font color="black" face="arial" size="9">
           <xsl:apply-templates select="//cfdi:Traslado"/>
         </font>

         <font color="black" face="arial" size="9">
           <xsl:for-each select="Traslado">
           </xsl:for-each>
         </font>

       </td>    
     </tr>

     <tr>

       <td align="right">

         <font color="black" face="arial" size="9">

           <b>
             Total:<xsl:value-of select='format-number(@total,"$###,###,###.00")'/>
           </b>

         </font>


       </td>

     </tr>
       
       <br></br>
       </table>
     <tr>
       <td>
         <font color="black" face="arial" size="9">
           <b>
             <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/CantidadLetra"/>
           </b>
         </font>
       </td>
     </tr>

     <table>
     <tr>
       <td width="60%">
         <img src="cbb.jpg"/>
         <BR></BR>
         
         <font color="black" face="arial" size="9">
           
             ESTE DOCUMENTO ES UNA <br></br>
             REPRESENTACION IMPRESA DE UN CFDi<br></br>
           <br></br>
             PAGO EN UNA SOLA <br></br>
             EXHIBICION
             
           
         </font>
       </td>
       
     </tr>
       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Metodo Pago:
             <b>
             <xsl:value-of select="@metodoDePago"/>
             </b>
           </font>
         </td>
         
       </tr>

       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Cond Pago:
             <b>
               <xsl:value-of select="@condicionesDePago"/>
             </b>
           </font>
         </td>
       </tr>

       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Num Cta:
             <b>
               <xsl:value-of select="@NumCtaPago"/>
             </b>
           </font>
         </td>
       </tr>
       
       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Certificado de Emisor
             <br></br>
             <b>

               <xsl:value-of select="@noCertificado"/>
             </b>
           </font>
         </td>
       </tr>
       <tr>
         <td>
           <font color="black" face="arial" size="9">
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
           <font color="black" face="arial" size="9">
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
           <font color="black" face="arial" size="9">
             Fecha de Certificacion del CFDi:
             <br></br>
             <b>

               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/FechaTimbrado"/>
             </b>
           </font>
         </td>
       </tr>
       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Regimen:
             <br></br>
             <b>

               <xsl:value-of select="cfdi:Emisor/cfdi:RegimenFiscal/@Regimen"/>
             </b>
           </font>
         </td>
       </tr>

       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Sello Digital:
             <br></br>
             <b>
               
             </b>
           </font>
         </td>
       </tr>

       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Sello SAT:
             <br></br>
             <b>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/SelloSAT"/>
             </b>
           </font>
         </td>
       </tr>

       <tr>
         <td>
           <font color="black" face="arial" size="9">
             Cadena Original SAT:
             <br></br>
             <b>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD"/>
             </b>
           </font>
         </td>
       </tr>
       
       
     </table>-->



<!-- hasta aqui     -->


     <!--<head>
   <link rel="STYLESHEET" media="screen" type="text/css" href="factura.css"/>
   <title>Factura Electronica <xsl:value-of select="@serie"/><xsl:value-of select="@folio"/></title>
   </head>

    
   <body background="fondo.jpg">
     <fieldset>
    <legend>
      <font color="black" face="arial" size="9">
        CONCEPTOS
      </font>
    </legend>
       <table width="100%" border="0">


         


           <tr>

             <th>
               <font color="black" face="arial" size="9">
                 Cantidad 
               </font>
             </th>
             
             <th>
               <font color="black" face="arial" size="9">
                 Unidad
               </font>
                 </th>
               
                 <th>
                   <font color="black" face="arial" size="9">
                     Descripcion
                   </font>
                     
                     </th>
                 <th>
                   <font color="black" face="arial" size="9">
                    Precio Unitario
                   </font>
                                  
                 </th>
                 <th>
                   <font color="black" face="arial" size="9">
                     Importe
                   </font>
                     </th>
             </tr>

         <font color="black" face="arial" size="9">

           <PRE>
             <b>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/Encabezado"/>
             </b>
           </PRE>

         </font>



         <tr>

           <td> </td>

           <td align="left">
             

           </td>

           <td> </td>
           <td align="right"></td>

         </tr>


         
         <font color="black" face="arial" size="10">
           <b>
           <xsl:apply-templates select="//cfdi:Concepto"/>
           <xsl:for-each select="Concepto">             
           </xsl:for-each>
           </b>

         </font>



         <tr>

           <td> </td>

           <td align="left">
             <font color="black" face="arial" size="9">
               <PRE>
                 <b>
                 <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/Observaciones"/>
                 </b>
               </PRE>
             </font>

           </td>

           
           

         </tr>



         <table width="100%" border="0" style="background:url('fondoo.jpg') no-repeat bottom">

           


           <tr>
             <th width="90%"></th>
             <th width="10%"></th>


           </tr>


           
           
           <tr>

             <td align="right">
               <font color="black" face="arial" size="9">
                 <p style="word-spacing: 2em;">
                   <b>
                     SUBTOTAL:
                   </b>
                 </p>
               </font>
                 </td>
             <td align="right" >
               <font color="black" face="arial" size="9">
                 <b>
                 <xsl:value-of select='format-number(@subTotal,"$###,###,###.00")'/>
                 </b>
               </font>
             </td>
           </tr>


           <font color="black" face="arial" size="9">
             <xsl:apply-templates select="//cfdi:Traslado"/>
           </font>

           <font color="black" face="arial" size="9">
             <xsl:for-each select="Traslado">
             </xsl:for-each>
           </font>

           <font color="black" face="arial" size="9">
             <b>
             <xsl:apply-templates select="//cfdi:Retencion"/>
             <xsl:for-each select="Retencion">
             </xsl:for-each>
             </b>
           </font>

           <tr>
             <td align="right">
               <font color="black" face="arial" size="9">
                 <b>
                   TOTAL: 
                 </b>
               </font>
                 </td>
             <td align="right">
               <font color="black" face="arial" size="9">
                 <b>
                   <xsl:value-of select='format-number(@total,"$###,###,###.00")'/>
                 </b>
               </font>
             </td>
           </tr>



           <tr>

             <td> </td>

             <td align="left">
               <font color="black" face="arial" size="9">
                 <b>
                   <PRE>
                     <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/ImpuestosAdicionales"/>
                   </PRE>
                 </b>
               </font>
             </td>

             <td> </td>
             <td align="right"></td>

           </tr>


         </table>




       </table>
         
	
       
        <hr/>


       <table width="100%" border="0">


         <tr>
           <td>
             <center>
               <font color="black" face="arial" size="9">
                 <b>
                   <pre> E F E C T O S   F I S C A L E S   A L   P A G O </pre>
                 </b>
               </font>
             </center>
           </td>
         </tr>



   



         <tr>
           <th>
             <font color="black" face="arial" size="9">
               Cantidad con letra
             </font>
               </th>
         </tr>

         <tr>
           <td>
             <font color="black" face="arial" size="9">
               <b>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/CantidadLetra"/>
               </b>
             </font>
           </td>
         </tr>


      
         
             <tr>
               <th>
                 <font color="black" face="arial" size="9">
               Cadena Original del Complemento de certificación digital del SAT
               </font>
               </th>
             </tr>
             <tr>
               <td>
                 <font color="black" face="arial" size="9">
                   <pre>
                     <b>
                       <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/CadenaTFD"/>
                     </b>
                     </pre>
                 </font>
                 
               </td>
             </tr>
             
              <tr>
               <th>
                 <font color="black" face="arial" size="9">
                 Sello Digital Emisor
                   </font>
                   </th>
             </tr>

             <tr>
               <td>
                 <font color="black" face="arial" size="9">
                   <pre>
                   <b>
                     <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/SelloCFD"/>
                   </b>
                     </pre>
                 </font>
               </td>
             </tr>


         


         <tr width="100%">

           <th >
             <font color="black" face="arial" size="9">
             Sello Digital SAT
               </font>
               </th>
         </tr>
         <tr>
           <td width="50%">
             <font color="black" face="arial" size="9">
               <pre>
                 <b>
                   <center>
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/SelloSAT"/>
                   </center>
               </b>
               </pre>

             </font>
           </td>
           
         </tr>


        

         <tr>

           <td>
             <br></br>
             <font color="black" face="arial" size="9">
               <b>  </b>
             </font>
           </td>
           

         </tr>



       </table>
        
     
        <br></br>





     </fieldset>
     
   </body>-->

 </html>

</xsl:template>


  <xsl:template match="//cfdi:DomicilioFiscal">



    <tr>
      <td colspan="1" width="100%">
        <font color="black" face="arial" size="9">

          <b>
            <xsl:value-of select="@calle"/><font color="white" face="arial" size="9">,</font>
            

            <xsl:value-of select="@noExterior"/><font color="white" face="arial" size="9">,</font>

            <xsl:value-of select="@noInterior"/><font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@colonia"/><font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@municipio"/><font color="white" face="arial" size="9">,</font>
          
            <xsl:value-of select="@estado"/><font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@pais"/><font color="white" face="arial" size="9">,</font>
            C.P. <xsl:value-of select="@codigoPostal"/>
          </b>
        </font>

      </td>


    </tr>






  </xsl:template>





  <xsl:template match="//cfdi:Domicilio">


    <tr>
      <td colspan="1">
        <font color="black" face="arial" size="9">

          Domicilio:
          <b>
            <xsl:value-of select="@calle"/>
            <font color="white" face="arial" size="9">,</font>
            
            <xsl:value-of select="@noExterior"/>
            <font color="white" face="arial" size="9">,</font>

            <xsl:value-of select="@noInterior"/>
            <font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@colonia"/>
            <font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@municipio"/>
            
            <font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@estado"/>
            <font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@pais"/>
            <font color="white" face="arial" size="9">,</font>
            <xsl:value-of select="@codigoPostal"/>
          </b>
        </font>
      </td>
    </tr>




  </xsl:template>

  <xsl:template match="//cfdi:ExpedidoEn">



    <xsl:value-of select="@calle"/><font color="white" face="arial" size="9">,</font>


    <xsl:value-of select="@noExterior"/><font color="white" face="arial" size="9">,</font>

    <xsl:value-of select="@noInterior"/><font color="white" face="arial" size="9">,</font>
    <xsl:value-of select="@colonia"/><font color="white" face="arial" size="9">,</font>
    <xsl:value-of select="@municipio"/><font color="white" face="arial" size="9">,</font>
    <xsl:value-of select="@estado"/><font color="white" face="arial" size="9">,</font>
    <xsl:value-of select="@pais"/><font color="white" face="arial" size="9">,</font>
    C.P. <xsl:value-of select="@codigoPostal"/>






  </xsl:template>




  <xsl:template match="//cfdi:Concepto">

    <tr width ="100%">
      <td width ="10%">
        <font color="black" face="arial" size="9">
          <b>
            <xsl:value-of select="@ClaveProdServ"/>
          </b>
        </font>
      </td>
      
      <td width ="10%">
        <font color="black" face="arial" size="9">
          <b>
          <xsl:value-of select='@Cantidad'/>
          </b>
        </font>
      </td>
      <td width ="10%">
        <font color="black" face="arial" size="9">
          <b>
          <xsl:value-of select='@ClaveUnidad'/>
          </b>
        </font>
      </td>
      <td width ="10%">
        <font color="black" face="arial" size="9">
          <b>
            <xsl:value-of select="@Unidad"/>
          </b>
        </font>
      </td>

      <td width ="40%">
        <font color="black" face="arial" size="9">
          <b>
          <xsl:value-of select="@Descripcion"/>
          </b>
        </font>
      </td>
      <td width ="20%">
        <font color="black" face="arial" size="9">
          <b>
            <xsl:value-of select='format-number(@ValorUnitario,"$###,###,###.00")'/>
          </b>
        </font>
      </td>
      <td width ="20%">
        <font color="black" face="arial" size="9">
          <b>
          <xsl:value-of select='format-number(@Importe,"$###,###,###.00")'/>
          </b>
        </font>
      </td>
    </tr>

  
</xsl:template>





  
  <xsl:template match="//cfdi:Traslado">
 
  
    <tr>

      <td align="right">
    
      </td>
      <td align="right">
        <font color="black" face="arial" size="9">
          <b>
            <xsl:value-of select="@impuesto"/>
            <font color="#FFFFFF" >_</font>
            <xsl:value-of select='format-number(@importe,"$###,###,###.00")' />
          </b>
        </font>
      </td>
    </tr>
  </xsl:template>


  <xsl:template match="//cfdi:Retencion">
    <tr>

      <td align="right">
        <font color="black" face="arial" size="9">

         

        </font>
      </td>
      <td align="right">
        <font color="black" face="arial" size="9">
          <b>
            RET. <xsl:value-of select="@impuesto"/>
            <font color="#FFFFFF" >_</font>
          <xsl:value-of select='format-number(@importe,"$###,###,###.00")'/>
          </b>
        </font>
      </td>

    </tr>
  </xsl:template>



</xsl:stylesheet>

 



