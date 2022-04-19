using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpfEFac.Models
{
    class ConnectorSIA
    {

        ConnectorImportCsv myConnector = new ConnectorImportCsv();

        public int importSia(string csvFile)
            {

            string strBytes = System.IO.File.ReadAllText(csvFile, UTF8Encoding.UTF8);
            
            if (strBytes.Length > 0)
            {
                myConnector.importCsv(csvFile, "Cliente");
                myConnector.importCsv(csvFile, "Datos");
                myConnector.importCsv(csvFile, "Producto");
                myConnector.importCsv(csvFile, "Totales");
                myConnector.savePrefactura(strBytes);
               // if (!ValuesParameters.rfcCliente.Equals("XAXX010101000"))
               //  {
                 System.IO.File.WriteAllText(csvFile, String.Empty, UTF8Encoding.UTF8);
              //  }
            }

            

            return 0;
        }

    }
}
