using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Xml;
using System.Collections;

namespace WFADoblones20.Librerias
{
    class LeerALS
    {
        private ArrayList variables;
        public bool exito;
        public LeerALS(string nombreSistema) {
            try
            {
                seguridadXML(nombreSistema);
                exito = true;
            }
            catch
            {
                exito = false;
            }
        }

        private void seguridadXML(string nombreSistema)
        {
            string numeroSerial = "";
            ManagementObjectSearcher
                query = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject bb in query.Get())
            {
                numeroSerial = bb.GetPropertyValue("SerialNumber").ToString();
            }
            Seguridad.desencriptarFile(nombreSistema, numeroSerial);
            XmlDocument keyXML = new XmlDocument();
            keyXML.Load(nombreSistema);
            XmlNode root = keyXML.DocumentElement;
            XmlNode nVariable = root.LastChild;
            XmlNodeList xnList = nVariable.ChildNodes;
            
            variables = new ArrayList();

            foreach (XmlNode xn in xnList)
            {
                ArrayList variable = new ArrayList();
                variable.Add(xn.ChildNodes[1].InnerText);
                variable.Add((String)xn.ChildNodes[2].InnerText);
                variable.Add(xn.ChildNodes[3].InnerText);
                variables.Add(variable);
            }
            Seguridad.encriptarFile(nombreSistema, numeroSerial);
        }

        public ArrayList Variables {
            get {
                return variables;
            }
        }
    }
}
