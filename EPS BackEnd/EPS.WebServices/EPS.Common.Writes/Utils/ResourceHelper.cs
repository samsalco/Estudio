using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace EPS.Common.Writes
{
    public static class ResourceHelper
    {
        public const string PROVIDER_NAME_SQLSERVER = "sqlserver";
        public const string STRINGS_RESOURCE_NAME = "strings"; // Strings.es.resx
        /// <summary>Nombre del archivo de recursos</summary>
        public const string XML_RESOURCE_NAME = "service"; // Service.es.resx
        /// <summary>Nombre del archivo de recursos de los mensajes</summary>
        public const string MESSAGE_RESOURCE = "Messages"; // Messages.xml
        /// <summary>Nombre del archivo de recursos de los queries</summary>
        public const string QUERY_RESOURCE = "Queries"; // Queries.xml

        public static string GetQuery(byte[] resource, string provider, string queryId)
        {
            using (MemoryStream memoryStream = new MemoryStream(resource))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(memoryStream);
                return GetQuery(null, xml, provider, queryId, false, String.Empty);
            }
        }


        private static string GetQuery(
         Assembly assembly, XmlDocument xmlDocument, string provider, string queryId, bool isSpecialQuery, string queryPostfix)
        {
            // queryId = queryId.Trim();
            string providerId;

            if (string.IsNullOrWhiteSpace(provider))
                throw new ApplicationException("El proveedor de datos no fue suministrado");

           
                    providerId = "SqlClient";
         


            // 2010-02-09 cmazo
            if (isSpecialQuery)
                providerId += queryPostfix;

            // Se obtiene el nodo del query
            string xmlQuery = String.Format("descendant::query[@id='{0}']", queryId);
            if (xmlDocument == null)
                throw new ApplicationException("El xml de queries no fue suministrado");

            XmlNode queryNode = xmlDocument.SelectSingleNode(xmlQuery);

            if (queryNode == null)
            {
                if (assembly != null)
                {
                    throw new ApplicationException(String.Format(
                        "El query '{0}' no existe en el recurso '{1}\\{2}' del ensamblado '{3}' con el proveedor '{4}'",
                        queryId, XML_RESOURCE_NAME, QUERY_RESOURCE, assembly.FullName, providerId));
                }
                else
                {
                    throw new ApplicationException(String.Format(
                            "El query '{0}' no existe en el recurso '{1}' con el proveedor {2}.",
                            queryId, QUERY_RESOURCE, providerId));
                }
            }

            // Se obtiene el elemento del proveedor
            xmlQuery = String.Format("descendant::provider[@{0}='yes']", providerId);
            XmlNode providerNode = queryNode.SelectSingleNode(xmlQuery);

            if (providerNode == null)
            {
                if (assembly != null)
                {
                    throw new ApplicationException(String.Format(
                        "El query '{0}' del proveedor '{1}' no existe en el recurso '{2}\\{3}' del ensamblado '{4}'",
                        queryId, providerId, XML_RESOURCE_NAME, QUERY_RESOURCE, assembly.FullName));
                }
                else
                {
                    throw new ApplicationException(String.Format(
                        "El query '{0}' del proveedor '{1}' no existe en el recurso '{2}'",
                        queryId, providerId, QUERY_RESOURCE));
                }
            }
            //jflorez evaluar rendimiento
            // Obtener el query
            //string sqlText = providerNode.InnerText;           
            //sqlText = sqlText.Replace(Environment.NewLine, " ")
            //    .Replace("\r", " ")
            //    .Replace("\n", " ");

            //  return sqlText;
            return providerNode.InnerText;
        }


    }
}
