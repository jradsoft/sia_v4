<xsl:stylesheet version = '1.0'
    xmlns:xsl='http://www.w3.org/1999/XSL/Transform'
    xmlns:cfdi='http://www.sat.gob.mx/cfd/3'
    xmlns:tfd='http://www.sat.gob.mx/TimbreFiscalDigital'
    xmlns:implocal='http://www.sat.gob.mx/implocal'>
 
<xsl:output method = "html" /> 
<xsl:param name="id" select="."/>
 
<xsl:template match="//cfdi:Comprobante">
   <html>
   <head>
     <link rel="STYLESHEET" media="screen" type="text/css" href="c:\MyFacturaE\factura.css"/>
   <title>Factura Electronica <xsl:value-of select="@serie"/><xsl:value-of select="@folio"/></title>
   </head>

    
   <body background="fondo.jpg">
     <fieldset>
       <legend>
         <font face="Britannic Bold"  size="2">
           CONCEPTOS
         </font>
       </legend>
       <table width="100%" border="0">


         


           <tr>

             <th align="center">
               <font  size="2">
                 Codigo
               </font>

             </th>
             
             <th>
               <font  size="2">
                 Cantidad
               </font>
                 </th>

             <th align="center">
               <font  size="2">
               Clave Unidad
               </font>

             </th>
             
             <th  align="center">
                   <font  size="2">
              Unidad Medida         
                   </font>
                     
                     </th>
                 <th>
                   <font  size="2">
                     Descripcion
                   </font>
                                  
                 </th>


             <th>
               <font  size="2">
                 Precio
               </font>
             </th>

             <th>
               <font size="2">
                 Descuento
               </font>
             </th>
          
           <th>
                   <font size="2">
                     Importe
                   </font>
                     </th>
             </tr>

  
    


         
         <font  size="3">
           <b>
           <xsl:apply-templates select="//cfdi:Concepto"/>
           <xsl:for-each select="Concepto">             
           </xsl:for-each>
           </b>
         </font>





         <table width="100%" border="0" style="background:url('fondoo.jpg') no-repeat bottom">

           


           <tr>
             <th width="90%"></th>
             <th width="10%"></th>


           </tr>

           <table width="100%" border="0">
             <tr>

               <td width="70%">
               
                 <tr align="left" width="70%" height="50">
                   
                   <td  width="150%" height="100" >
                     <fieldset>
                       <legend>
                         <font face="Britannic Bold" size="3">
                           OBSERVACIONES
                       </font>
                       </legend>  
                    
                     <font  size="3">
               <PRE>
                 <b>
                 <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/Encabezado"/>
                 </b>
               </PRE>
             </font>
                     </fieldset>
                   </td>
                   

                   

                     <td width="30%" rowspan="2" align="right">
                       
                         <table border="1" >
                           <tr align="center"  >
                             <th class="h1" align="right"  >
                               <font size="3">Subtotal:</font>
                             </th>

                             <td align="right" >
                               <font  size="3">
                                 <xsl:value-of select='format-number(@SubTotal,"$###,###,###.00")'/>
                               </font>
                             </td>
                           </tr>

                           <xsl:if test="@Descuento > 0 ">
                             <td align="right">

                               <font color="#000000" face="Courier New" size="8">
                                 <p style="word-spacing: 2em;">
                                   <b>
                                     Descuento:
                                   </b>
                                 </p>
                               </font>
                             </td>
                             <td align="right" >
                               <font color="#000000" face="Courier New" size="8">
                                 <b>
                                   <xsl:value-of select='format-number(@Descuento,"$###,###,###.00")'/>
                                 </b>
                               </font>
                             </td>
                           </xsl:if>

                           <!--Traslados-->


                           <xsl:for-each select="./cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado">


                             <xsl:if test="@Impuesto = '003' ">
                               <tr>

                                 <td align="right">
                                   <font color="#000000" face="Courier New" size="3">
                                     <b>
                                       <xsl:value-of select='@Impuesto' />_IEPS
                                     </b>

                                     <!--<font color="White" face="Courier New" size="3">_</font>-->


                                   </font>
                                 </td>
                                 <td align="right">
                                   <font color="#000000" face="Courier New" size="3">
                                     <b>
                                       <xsl:value-of select='format-number(@Importe,"$###,###,###.00")' />
                                     </b>
                                   </font>
                                 </td>
                               </tr>

                             </xsl:if>
                             
                             
                             
                             <xsl:if test="@Impuesto = '002' ">
                           <tr>

                             <td align="right">
                               <font color="#000000" face="Courier New" size="3">
                                 <b>
                                   <xsl:value-of select='@Impuesto' />_IVA
                                 </b>

                                 <!--<font color="White" face="Courier New" size="3">_</font>-->


                               </font>
                             </td>
                             <td align="right">
                               <font color="#000000" face="Courier New" size="3">
                                 <b>
                                   <xsl:value-of select='format-number(@Importe,"$###,###,###.00")' />
                                 </b>
                               </font>
                             </td>
                           </tr>

                             </xsl:if>
                           </xsl:for-each>
                           
                               

                           <!--Retenciones-->


                           <font color="#000000" face="Courier New" size="3">
                             <b>

                               <xsl:for-each select="./cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion">
                                 <xsl:if test="@Impuesto = '001'  ">
                                   <tr>
                                     <td align="right">
                                       <font color="#000000" face="Courier New" size="3">
                                         <b>
                                           <xsl:value-of select="@Impuesto"/>-RET ISR
                                         </b>
                                       </font>
                                     </td>

                                     <td align="right">
                                       <font color="#000000" face="Courier New" size="3">
                                         <b>
                                           <xsl:value-of select='format-number(@Importe,"$###,###,###.00")'/>
                                         </b>
                                       </font>
                                     </td>
                                   </tr>
                                 </xsl:if>

                                 <xsl:if test="@Impuesto = '002' ">
                                   <tr>
                                     <td align="right">
                                       <font color="#000000" face="Courier New" size="3">
                                         <b>
                                           <xsl:value-of select="@Impuesto"/>-RET IVA
                                         </b>
                                       </font>
                                     </td>





                                     <td align="right">
                                       <font color="#000000" face="Courier New" size="3">
                                         <b>
                                           <xsl:value-of select='format-number(@Importe,"$###,###,###.00")'/>
                                         </b>
                                       </font>
                                     </td>
                                   </tr>
                                 </xsl:if>
                               </xsl:for-each>

                             </b>

                           </font>


                           <!--Impuesto Local-->


                           <xsl:for-each select="//implocal:ImpuestosLocales/implocal:RetencionesLocales">
                           
                               <tr>

                                 <td align="right">
                                   <font color="#000000" face="Courier New" size="3">
                                     <b>
                                       %<xsl:value-of select='@TasadeRetencion' />_<xsl:value-of select='@ImpLocRetenido' />
                                     </b>
                                   </font>
                                 </td>
                                 <td align="right">
                                   <font color="#000000" face="Courier New" size="3">
                                     <b>
                                       <xsl:value-of select='format-number(@Importe,"$###,###,###.00")' />
                                     </b>
                                   </font>
                                 </td>
                               </tr>                                                       
         
                           </xsl:for-each>





                           <tr align="center"  >
                             <th class="h1" align="right"  >
                               <font size="3">Total:</font>
                             </th>

                             <td align="right" >
                               <font  size="3">
                                 <xsl:value-of select='format-number(@Total,"$###,###,###.00")'/>
                               </font>
                             </td>
                           </tr>

                          
                       
                         </table>
                         
                         
                       
                     </td>
                 </tr>
               </td>
             </tr>

           </table>
           
           

           



           <tr>

           
             <td align="left">
               <font  size="3">
                 <b>

                   <PRE>
                     <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/ImpuestosAdicionales"/>
                   </PRE>
                 </b>
               </font>
             </td>

            

           </tr>


         </table>




       </table>
         
	
       
        <hr/>


       <table width="100%" border="0">


         <tr>
           <td>
             <center>
               <font  size="1">
                 <b>
                   <pre> E F E C T O S   F I S C A L E S   A L   P A G O </pre>
                 </b>
               </font>
             </center>
           </td>
         </tr>



   



         <tr>
           <th>
             <font  size="1">
               Cantidad con letra
             </font>
               </th>
         </tr>

         <tr>
           <td>
             <font  size="1">
               <xsl:value-of select="document('c:/myfacturae/cad.xml')/Complemento/CantidadLetra"/>
             </font>
           </td>
         </tr>


      
         
             <tr>
               <th>
                 <font  size="1">
               Cadena Original del Complemento de certificación digital del SAT
               </font>
               </th>
             </tr>
             <tr>
               <td align="center">
                 <font  size="1">
                   <pre>
                     <b>
                       <xsl:value-of select="substring(document('cad.xml')/Complemento/CadenaTFD, 0, 160)"/>
                       <br></br>
                       <xsl:value-of select="substring(document('cad.xml')/Complemento/CadenaTFD, 160, 160)"/>
                       <br></br>
                       <xsl:value-of select="substring(document('cad.xml')/Complemento/CadenaTFD, 320, 160)"/>
                       <br></br>
                       <xsl:value-of select="substring(document('cad.xml')/Complemento/CadenaTFD, 480, 60)"/>

                     </b>
                     </pre>
                 </font>
                 
               </td>
             </tr>
             
              <tr>
               <th>
                 <font  size="1">
                 Sello Digital Emisor
                   </font>
                   </th>
             </tr>

             <tr>
               <td align="center">
                 <font  size="1">
                   
                   <b>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 0, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 160, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 320, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 480, 160)"/>
                   </b>
                     
                 </font>
               </td>
             </tr>


         


         <tr width="100%">

           <th >
             <font  size="1">
             Sello Digital SAT
               </font>
               </th>
         </tr>
         <tr>
           <td width="50%" align="center">
             <font  size="1">
               <pre>               <b>
                 <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 0, 160)"/>
                 <br></br>
                 <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 160, 160)"/>
                 <br></br>
                 <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 320, 160)"/>
                 <br></br>
                 <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 480, 160)"/> </b>
               </pre>

             </font>
           </td>
           
         </tr>


       </table>
        
     </fieldset>
     
   </body>

 </html>

</xsl:template>



  <xsl:template match="//cfdi:Concepto">

    <tr>

      <td align="center" width="10%">
        <font color="#000000" face="Courier New" size="3">
          <b>
            <xsl:value-of select="@ClaveProdServ"/>
          </b>
        </font>
      </td>

      <td align="center" width="10%">


        <font color="#000000" face="Courier New" size="3">
          <b>
            <xsl:value-of select='format-number(@Cantidad,"###,###,###.00")'/>
            
          </b>

        </font>
      </td>

      <td align="center" width="10%">


        <font color="#000000" face="Courier New" size="3">
          <b>
            <xsl:value-of select="@ClaveUnidad"/>
          </b>
        </font>
      </td>

      <td align="center" width="20%">


        <font color="#000000" face="Courier New" size="3">
          <b>
            <xsl:value-of select="@Unidad"/>
          </b>
        </font>
      </td>

      <td width="40%">
        <font color="#000000" face="Courier New" size="3">
          <pre>
            <b>
              <xsl:value-of select="@Descripcion"/>
            </b>
          </pre>
        </font>
      </td>

      <td align="center" width="20%">
        <font color="#000000" face="Courier New" size="3">
          <b>
            <xsl:value-of select='format-number(@ValorUnitario,"$###,###,###.00")'/>
          
          </b>
        </font>

      </td>

      <td align="center" width="20%">
        <font color="#000000" face="Courier New" size="3">
          <b>
            <xsl:if test="@Descuento > 0 ">
              <xsl:value-of select='format-number(@Descuento,"$###,###,###.00")'/>
            </xsl:if>
            <xsl:if test="not(@Descuento)">
              0.00
            </xsl:if>

          </b>
        </font>
      </td>

      <td align="right" width="20%">
        <font color="#000000" face="Courier New" size="3">

          <b>
            <xsl:if test="@Descuento > 0 ">
              <xsl:value-of select='format-number(@Importe - @Descuento,"$###,###,###.00")'/>
            </xsl:if>
            <xsl:if test="not(@Descuento)">
              <xsl:value-of select='format-number(@Importe,"$###,###,###.00")'/>
            </xsl:if>
          </b>
        </font>
      </td>
    </tr>
    <!--<tr width='100%'>
      <td width='100%' colspan='7'>
        <hr></hr>
      </td>
    </tr>-->

  </xsl:template>





  
  <xsl:template match="//cfdi:Traslado">
 
  
    <tr>
      <xsl:if test="@impuesto = 'IEPS' and (@importe > 0)">
        <!--<xsl:value-of select='format-number(@importe,"$###,###,###.000000")'/>-->
      

      <td align="right">
        <font  size="3">
          <xsl:value-of select="@impuesto"/>
        </font>
      </td>
      <td align="right">
        <font  size="3">
          <xsl:value-of select='format-number(@importe,"$###,###,###.00")' />
        </font>
      </td>
      </xsl:if>
      <xsl:if test="@impuesto = 'IVA'">
        <!--<xsl:value-of select='format-number(@importe,"$###,###,###.000000")'/>-->


        <td align="right">
          <font  size="3">
            <xsl:value-of select="@impuesto"/>
          </font>
        </td>
        <td align="right">
          <font  size="3">
            <xsl:value-of select='format-number(@importe,"$###,###,###.00")' />
          </font>
        </td>
      </xsl:if>
    </tr>
  </xsl:template>


  <xsl:template match="//cfdi:Retencion">
    <tr>

      <td align="right">
        <font  size="3">
          RET. <xsl:value-of select="@impuesto"/>
        </font>
      </td>
      <td align="right">
        <font  size="3">
          <xsl:value-of select='format-number(@importe,"$###,###,###.00")'/>
        </font>
      </td>

    </tr>
  </xsl:template>



</xsl:stylesheet>

 



