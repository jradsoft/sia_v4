<xsl:stylesheet version = '1.0'
    xmlns:xsl='http://www.w3.org/1999/XSL/Transform'
    xmlns:cfdi='http://www.sat.gob.mx/cfd/3'>
 
<xsl:output method = "html" /> 
<xsl:param name="id" select="."/>
 
<xsl:template match="//cfdi:Comprobante">
   <html>
   <head>
   <link rel="STYLESHEET" media="screen" type="text/css" href="factura.css"/>
   <title>Factura Electronica <xsl:value-of select="@Serie"/><xsl:value-of select="@Folio"/></title>
   </head>

    
   <body background="fondo.jpg">
     <fieldset>
    <legend>
      <font color="#000000" face="Century Gothic" size="6">
        CONCEPTOS
      </font>
    </legend>

       <table width="100%" border="0">


           <tr>

             <th>
               <font color="#000000" face="Century Gothic" size="8">
                 Cantidad 
               </font>
             </th>
             
             <th>
               <font color="#000000" face="Century Gothic" size="8">
                 Unidad
               </font>
                 </th>
             <th>
               <font color="#000000" face="Century Gothic" size="8">
                 Codigo
               </font>
             </th>
               
                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                     Descripcion
                   </font>
                     
                     </th>
                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                    Precio Unitario
                   </font>
                                  
                 </th>
                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                     Importe
                   </font>
                     </th>
             </tr>

         <font color="#000000" face="Courier New" size="7">

           <PRE>
             <b>
               <xsl:value-of select="document('cad.xml')/Complemento/Encabezado"/>
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


         
         <font color="#000000" face="Courier New" size="10">
           <b>
           <xsl:apply-templates select="//cfdi:Concepto"/>
           <xsl:for-each select="Concepto">             
           </xsl:for-each>
           </b> 

         </font>


 <table width="100%" border="1">
         
           <tr>

          
                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                     Fecha/Hora pago
                   </font>
                     
                     </th>


                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                    Forma de Pago
                   </font>
                                  
                 </th>

                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                    Total pago
                   </font>
                                  
                 </th>


             </tr>


	<tr>

           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                    <xsl:value-of select="document('cad.xml')/Complemento/Comppago_fechapago"/>
                   </b>
                  </PRE>
                </font>
	   </td>
           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                     <xsl:value-of select="document('cad.xml')/Complemento/Comppago_formapago"/>
                   </b>
                  </PRE>
                </font>

	   </td>

           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                     <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_totalpago"/>
		</b>
                  </PRE>
                </font>

  	    </td>


	</tr>
	</table>


	<tr>
  	  <td>
            <font color="#000000" face="Courier New" size="10">

		CFDI's 
 	    </font>
	  </td>
	  <td>

            <font color="#000000" face="Courier New" size="10">

		relacionados
 	    </font>

  	  </td>
	  <td></td>
	  <td></td>
	</tr>

       <table width="100%" border="1">
         
           <tr>

             <th>
               <font color="#000000" face="Century Gothic" size="8">
                 UUID
               </font>
             </th>
          
                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                     Folio
                   </font>
                     
                     </th>


                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                    Metodo Pago
                   </font>
                                  
                 </th>

                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                    Total
                   </font>
                                  
                 </th>

                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                    Saldo anterior
                   </font>
                                  
                 </th>
                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                     Saldo Pendiente
                   </font>
                     </th>
                 <th>
                   <font color="#000000" face="Century Gothic" size="8">
                     Monto pagado
                   </font>
                     </th>

             </tr>


	<tr>

           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                    <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_uuid"/>
                   </b>
                  </PRE>
                </font>
	   </td>
           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                    <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_serie"/>
		    <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_folio"/>
                   
                   </b>
                  </PRE>
                </font>

	   </td>

           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                   <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_metodopago"/>
                    
		</b>
                  </PRE>
                </font>

  	    </td>


  	     <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                    <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_totalpago"/>
                   </b>
                  </PRE>
                </font>

	  </td>
     
           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                    <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_saldoanterior"/>
                   </b>
                  </PRE>
                </font>

	  </td>

           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                    <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_saldopendiente"/>
                   </b>
                  </PRE>
                </font>

	  </td>


           <td> 
		<font color="#000000" face="Courier New" size="8">
                  <PRE>
                   <b>
                    <xsl:value-of select="document('cad.xml')/Complemento/Cfdirel_montopagado"/>
                   </b>
                  </PRE>
                </font>

	  </td>

	</tr>
	</table>






         <tr>

           <td> </td>

           <td align="left">
             <font color="#000000" face="Courier New" size="8">
               <PRE>
                 <b>
                 <xsl:value-of select="document('cad.xml')/Complemento/Observaciones"/>
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


           
           
           <!--<tr>

             <td align="right">
               <font color="#000000" face="Courier New" size="9">
                 <p style="word-spacing: 2em;">
                   <b>
                     SUBTOTAL:
                   </b>
                 </p>
               </font>
                 </td>
             <td align="right" >
               <font color="#000000" face="Courier New" size="9">
                 <b>
                 <xsl:value-of select='format-number(@SubTotal,"$###,###,###.00")'/>
                 </b>
               </font>
             </td>
           </tr>


           <font color="#000000" face="Courier New" size="9">
             <xsl:apply-templates select="//cfdi:Traslado"/>
           </font>

           <font color="#000000" face="Courier New" size="9">
             <xsl:for-each select="Traslado">
             </xsl:for-each>
           </font>

           <font color="#000000" face="Courier New" size="9">
             <b>
             <xsl:apply-templates select="//cfdi:Retencion"/>
             <xsl:for-each select="Retencion">
             </xsl:for-each>
             </b>
           </font>

           <tr>
             <td align="right">
               <font color="#000000" face="Courier New" size="9">
                 <b>
                   TOTAL: 
                 </b>
               </font>
                 </td>
             <td align="right">
               <font color="#000000" face="Courier New" size="9">
                 <b>
                   <xsl:value-of select='format-number(@Total,"$###,###,###.00")'/>
                 </b>
               </font>
             </td>
           </tr>-->



           <tr>

             <td> </td>

             <td align="left">
               <font color="#000000" face="Courier New" size="9">
                 <b>
                   <PRE>
                     <xsl:value-of select="document('cad.xml')/Complemento/ImpuestosAdicionales"/>
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
               <font color="#000000" face="Courier New" size="8">
                 <b>
                   <pre> E F E C T O S   F I S C A L E S   A L   P A G O </pre>
                 </b>
               </font>
             </center>
           </td>
         </tr>



   



         <tr>
           <th>
             <font color="#000000" face="Courier New" size="8">
               Cantidad con letra
             </font>
               </th>
         </tr>

         <tr>
           <td>
             <font color="#000000" face="Courier New" size="9">
               <b>
               <xsl:value-of select="document('cad.xml')/Complemento/CantidadLetra"/>
               </b>
             </font>
           </td>
         </tr>


      
         
             <tr>
               <th>
                 <font color="#000000" face="Courier New" size="9">
               Cadena Original del Complemento de certificación digital del SAT
               </font>
               </th>
             </tr>
             <tr>
               <td>
                 <font color="#000000" face="Courier New" size="6">
                   <pre>
                     <b>
                       <!--<xsl:value-of select="document('cad.xml')/Complemento/CadenaTFD"/>-->
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
                 <font color="#000000" face="Courier New" size="9">
                 Sello Digital Emisor
                   </font>
                   </th>
             </tr>

             <tr>
               <td>
                 <font color="#000000" face="Courier New" size="6">
                   <pre>
                   <b>
                     <!--<xsl:value-of select="document('cad.xml')/Complemento/SelloCFD"/>-->
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 0, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 160, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 320, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloCFD, 480, 160)"/>
                   </b>
                     </pre>
                 </font>
               </td>
             </tr>


         


         <tr width="100%">

           <th >
             <font color="#000000" face="Courier New" size="8">
             Sello Digital SAT
               </font>
               </th>
         </tr>
         <tr>
           <td width="50%">
             <font color="#000000" face="Courier New" size="6">
               <pre>
                 <b>
                   <center>
               <!--<xsl:value-of select="document('cad.xml')/Complemento/SelloSAT"/>-->
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 0, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 160, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 320, 160)"/>
                     <br></br>
                     <xsl:value-of select="substring(document('cad.xml')/Complemento/SelloSAT, 480, 160)"/>
                   </center>
               </b>
               </pre>

             </font>
           </td>
           
         </tr>


        

         <tr>

           <td>
             <br></br>
             <font color="#000000" face="Courier New" size="8">
               <b>  </b>
             </font>
           </td>
           

         </tr>



       </table>
        
     
        <br></br>





     </fieldset>
     
   </body>

 </html>

</xsl:template>
 
     
 
<xsl:template match="//cfdi:Concepto">

    <tr>

      <td align="center" width="10%">


        <font color="#000000" face="Courier New" size="9">
          <b>
          <xsl:value-of select='format-number(@Cantidad,"###,###,###")'/>
          </b>
          
        </font>
      </td>
      
      <td align="center" width="10%">
        
        
        <font color="#000000" face="Courier New" size="9">
          <b>
          <xsl:value-of select="@Unidad"/>
          </b>
        </font>
      </td>
      <td align="center" width="10%">


        <font color="#000000" face="Courier New" size="9">
          <b>
            <xsl:value-of select="@ClaveProdServ"/>
          </b>
        </font>
      </td>
      
      <td width="50%">
        <font color="#000000" face="Courier New" size="10">
          <pre>
            <b>
          <xsl:value-of select="@Descripcion"/>
            </b>
          </pre>
        </font>
      </td>
      
      <td align="center" width="20%">       
        <font color="#000000" face="Courier New" size="9">
          <b>
          <xsl:value-of select='format-number(@ValorUnitario,"$###,###,###.00")'/>
          </b>
        </font>
        
      </td>
      
      <td align="right" width="20%">
        <font color="#000000" face="Courier New" size="11">

          <b>
            <xsl:value-of select='format-number(@Importe,"$###,###,###.00")'/>
          </b>
        </font>
      </td>

    </tr>

  <tr width='100%'>
    <td width='100%' colspan='5'>
      <hr></hr>
    </td>
  </tr>
  
</xsl:template>





  
  <xsl:template match="//cfdi:Traslado">
 
  
    <tr>

      <td align="right">
        <font color="#000000" face="Courier New" size="8">
          <b>
            <xsl:value-of select="@Impuesto"/>
          </b>

          <font color="White" face="Courier New" size="8">_</font>
          
          
        </font>
      </td>
      <td align="right">
        <font color="#000000" face="Courier New" size="8">
          <b>
          <xsl:value-of select='format-number(@Importe,"$###,###,###.00")' />
          </b>
        </font>
      </td>
    </tr>
  </xsl:template>


  <xsl:template match="//cfdi:Retencion">
    <tr>

      <td align="right">
        <font color="#000000" face="Courier New" size="8">

         

        </font>
      </td>
      <td align="right">
        <font color="#000000" face="Courier New" size="8">
          <b>
          <xsl:value-of select='format-number(@Importe,"$###,###,###.00")'/>
          </b>
        </font>
      </td>

    </tr>
  </xsl:template>



</xsl:stylesheet>

 



