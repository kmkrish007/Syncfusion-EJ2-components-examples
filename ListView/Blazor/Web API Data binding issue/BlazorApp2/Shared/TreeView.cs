using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp2.Shared
{
    public class TreeView
    {
       
            public class VistaArbol
            {
                public string IdVista { get; set; }
                public string Nombre { get; set; }
                public string Icon { get; set; }
                public bool Expanded { get; set; }
                public List<VistaArbol> Hijos { get; set; }
            }
            public static List<VistaArbol> GetAllRecords()
            {

                List<VistaArbol> m_templateData1;
                List<VistaArbol> m_templateData2;
                List<VistaArbol> m_templateData3;
                List<VistaArbol> m_templateData4;
                List<VistaArbol> m_templateData5;
                List<VistaArbol> m_templateData6;
                m_templateData1 = new List<VistaArbol>();
                m_templateData5 = new List<VistaArbol>();
                m_templateData6 = new List<VistaArbol>();

                m_templateData5.Add(new VistaArbol { IdVista = "01-01", Nombre = "Carpeta 1", Icon = "folder", Expanded = false, Hijos = m_templateData6 });
                m_templateData5.Add(new VistaArbol { IdVista = "01-02", Nombre = "Carpeta 2", Icon = "folder", Expanded = false });
                m_templateData6.Add(new VistaArbol { IdVista = "01-01-03", Nombre = "SubCarpeta 3", Icon = "folder", Expanded = false });
                m_templateData1.Add(new VistaArbol { IdVista = "01", Nombre = "Vista 1", Hijos = m_templateData5, Icon = "eye", Expanded = false });
                m_templateData1.Add(new VistaArbol { IdVista = "02", Nombre = "Vista 2", Icon = "eye", Expanded = false });
                m_templateData1.Add(new VistaArbol { IdVista = "02", Nombre = "Vista 3", Icon = "eye", Expanded = false });
                // this.Child = "Child";
                return m_templateData1;
            }
        }
    
}
