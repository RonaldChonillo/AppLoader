using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;

namespace AppLoader
{
    static class AppEnvironment
    {
        static public string strConfigFile = "cfgApp.xml";
        static public string strDefaultPath = @"\\192.168.0.104\shared\apps\releases\config";
        static public string strListFile = "filelstl.xml";
        static public string strListFileTest = "filelstlTest.xml";
    }

    static class AppConfig
	{

		/// <summary>
		/// Crear un nuevo archivo de configuración.
		/// </summary>
		/// <returns></returns>
        /*
		[
		//Category("_Extends"),
		Description("Crear un nuevo archivo de configuración."),
		]
		public static int saveConfigXML()
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml("<?xml version='1.0' encoding='utf-8' ?><root></root>");
			//doc.DocumentElement.AppendChild(doc.CreateElement("servers"));			
			//doc.DocumentElement.AppendChild(doc.CreateElement("settings"));
			doc.DocumentElement.AppendChild(doc.CreateElement("others"));			

			XmlElement newElem;
			
			newElem = doc.CreateElement("UpdatePath");
			newElem.InnerText = AppEnvironment.strDefaultPath;
			doc.DocumentElement["others"].AppendChild(newElem);

            newElem = doc.CreateElement("CompList");
			newElem.InnerText = AppEnvironment.strListFile;
			doc.DocumentElement["others"].AppendChild(newElem);

            newElem = doc.CreateElement("CompListTest");
            newElem.InnerText = AppEnvironment.strListFileTest;
            doc.DocumentElement["others"].AppendChild(newElem);

            doc.PreserveWhitespace = true;
			doc.Save( @AppDomain.CurrentDomain.BaseDirectory + @"\" + AppEnvironment.strConfigFile );
			return 0;
		}
        */

		/// <summary>
		/// Guarda la nueva configuración en el archivo existente.
		/// </summary>
		/// <param name="icbServers"></param>
		/// <param name="strUser"></param>
		/// <returns></returns>
		[
		//Category("_Extends"),
		Description("Guarda la nueva configuración en el archivo existente."),
		]
		public static int saveConfigXML( string strPath )
		{
			XmlDocument doc = new XmlDocument();

			doc.DocumentElement["others"].ChildNodes[0].InnerText = strPath ;			
			
			doc.Save( @AppDomain.CurrentDomain.BaseDirectory + @"\" + AppEnvironment.strConfigFile );

			return(0);
		}

        //Copia localmente el archivo de listados de actualizacion
        static public string getAppPath(bool test)
		{
			string sources="";
            string listfile="";
            string listfiletest = "";

            try
            {
			    XmlDocument doc = new XmlDocument();
			    doc.Load( @AppDomain.CurrentDomain.BaseDirectory + @"\" + AppEnvironment.strConfigFile );
			    sources = doc.DocumentElement["others"].ChildNodes[0].InnerText;
                listfile = doc.DocumentElement["others"].ChildNodes[1].InnerText;
                listfiletest = doc.DocumentElement["others"].ChildNodes[2].InnerText;

                if (test)
                {
                    listfile = listfiletest;
                }

                sources = sources + listfile ;
                File.Copy(sources, Application.StartupPath + @"\" + listfile, true);                

                XmlDocument doc1 = new XmlDocument();
                AppEnvironment.strListFile = Application.StartupPath +  @"\" + listfile;
			    doc.Load( AppEnvironment.strListFile );
                sources = doc.DocumentElement["others"].ChildNodes[0].InnerText;                
            }
            catch ( IOException e )
            {
                //saveConfigXML();
                sources = "";//AppEnvironment.strDefaultPath;
                Console.Out.WriteLine ( "Error: " + e.Message );
            }

            return sources;			
		}

        static public string getCompList(bool test)
		{
			string sources="";			
            try
            {
			    XmlDocument doc = new XmlDocument();

                if (test)
                {
                    doc.Load(AppEnvironment.strListFileTest);
                }
                else
                {
                    doc.Load(AppEnvironment.strListFile);
                }
			    

			    sources = doc.DocumentElement["others"].ChildNodes[1].InnerText;
            }
            catch ( System.IO.IOException e )
            {
                //saveConfigXML();
                sources = AppEnvironment.strDefaultPath;
                Console.Out.WriteLine ( "Error: " + e.Message );
            }

            return sources;			
		}

    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run( new frmSplash() );
        }
    }
}