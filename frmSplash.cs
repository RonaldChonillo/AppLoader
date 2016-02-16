using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using System.Net;

namespace AppLoader
{
    public partial class frmSplash : Form
    {
        public delegate void ChangeItemStatus(Label label, String strText);

        //private int intCount;
        private ChangeItemStatus m_ChangeItemStatus;
        private Thread thread1;
        private Thread thread2;
        private bool test = false;

        private void InvokeChangeItemStatus(Label label, String strText)
        {
            try
            {
                this.Invoke(this.m_ChangeItemStatus,
                            new Object[]
                            {
                            label,
                            strText
                            }
                           );
            }
            catch(System.InvalidOperationException e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
        }

        private void LChangeItemStatus(Label label, String strText)
        {
            label.Text = strText;
            label.Refresh();
            label.Update();
        }

        public frmSplash()
        {
            InitializeComponent();
        }


        [        
        Description("Inicia la ejecucion de la aplicacion principal."),
        ]
        public void Launch()
        {
            string strCompPath = "";
            //string strCompPath2 = "";

            string strApp = "";
            string strAppDest = "";
            string strPCache = "";
            string strAppLaunch = "";
            string[] strCompList;
            //string[] strCompList2;
            int intIndex;

            
            if (!File.Exists(AppEnvironment.strConfigFile))
            {
                //AppConfig.saveConfigXML();
                MessageBox.Show("Error en archivo de configuracion");
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }

            }

            strCompPath = AppConfig.getAppPath(test);
            strCompList = AppConfig.getCompList(test).Split('|');
            //strCompPath2 = AppConfig.getAppPath2();
            //strCompList2 = AppConfig.getCompList2().Split('|');

            string strTestPath = ".Test";

            if (!test)
                strTestPath = "";


            try
            {
                Directory.CreateDirectory(@AppDomain.CurrentDomain.BaseDirectory + @"\Cache" + strTestPath);
                strPCache = @AppDomain.CurrentDomain.BaseDirectory + @"Cache" + strTestPath + @"\";
            }
            catch (Exception e)
            {
                InvokeChangeItemStatus(lblErrorInfo, "Error:" + e.Message);
            }

            InvokeChangeItemStatus(lblInfo, "Buscando actualizacion en " + strCompPath);


            //if (IsIpLan("192.168.14.88"))
            //    MessageBox.Show("SIMON");

            string SIP = Directory.GetDirectoryRoot(strCompPath);
            string SIP24 = "";
            SIP = SIP.Substring(0, SIP.LastIndexOf('\\')).Replace("\\", "");
            SIP24=SIP.Substring(0, SIP.LastIndexOf('.'));
            
            //MessageBox.Show(SIP);

            //IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            //bool blFoundValid = false;
            //string LIP = "";
            
            //string RLIP = "";

            //// test if any host IP equals to any local IP or to localhost
            //foreach (IPAddress hostIP in localIPs)
            //{
            //    //if (IPAddress.IsLoopback(hostIP)) return true;
            //    int sIndex = 0;
            //    LIP = hostIP.ToString();

            //    sIndex = LIP.LastIndexOf('.');
            //    if (sIndex > -1)
            //    {
            //        LIP = LIP.Substring(0, sIndex);

            //        if (SIP24.Equals(LIP))
            //        {
            //            //MessageBox.Show("VALIDO: " + SIP24 + "--" + LIP);
            //            blFoundValid = true;
            //            break;
            //        }
            //        else
            //        {
            //            //MessageBox.Show(LIP + ": NOOOO VALIDO");

            //            string LSIP24 = "";
            //            string LIP24 = "";

            //            LSIP24 = SIP24.Substring(0, SIP24.LastIndexOf('.'));
            //            LIP24 = LIP.Substring(0, LIP.LastIndexOf('.'));

            //            //MessageBox.Show(LSIP24 + ":" + LIP24);

            //            if (LSIP24.Equals(LIP24))
            //                RLIP = LIP;
            //                //MessageBox.Show(LSIP24 + ":" + LIP24 + " PARA CAMBIO");

            //        }
            //    }
            //}

            //if (!blFoundValid)
            //{
            //    strCompPath = strCompPath.Replace(SIP24, LIP);
            //}

            int intAgency = 0;

            string LIP = "";
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress hostIP in localIPs)
            {
                //if (IPAddress.IsLoopback(hostIP)) return true;
                int sIndex = 0;
                LIP = hostIP.ToString();

                sIndex = LIP.LastIndexOf('.');
                if (sIndex > -1)
                {
                    LIP = LIP.Substring(0, sIndex);

                    if (LIP.Contains("192.168.0"))
                    {
                        intAgency = 1;
                        break;
                    }
                    if (LIP.Contains("192.168.1"))
                    {
                        intAgency = 2;
                        break;
                    }
                    if (LIP.Contains("192.168.3"))
                    {
                        intAgency = 3;
                        break;
                    }
                }
            }


            switch (intAgency)
            {
                case 1://Guayaquil
                    {
                        //MessageBox.Show("Guayaquil");
                        if(!SIP.Equals("192.168.0.104"))
                            strCompPath = strCompPath.Replace(SIP, "192.168.0.104");
                    }                    
                    break;
                //case 2://Quito
                //    {
                //        //MessageBox.Show("Quito");
                //        if (!SIP.Equals("192.168.1.6"))
                //            strCompPath = strCompPath.Replace(SIP, "192.168.1.6");
                //    }
                //    break;
                //case 3://Portoviejo
                //    {
                //        //MessageBox.Show("Portoviejo");
                //        if (!SIP.Equals("192.168.3.6"))
                //            strCompPath = strCompPath.Replace(SIP, "192.168.3.6");
                //    }
                //    break;
            }

            //MessageBox.Show(strCompPath);

            for (intIndex = 0; intIndex < strCompList.Length; intIndex++)
            {
                strApp = strCompPath + @"\" + strCompList[intIndex];
                strAppDest = strPCache + strCompList[intIndex];
                
                InvokeChangeItemStatus(lblInfo, "Buscando actualizacion de " + strAppDest);
                
                if (Path.GetExtension(strAppDest) == ".exe")
                {
                    if (strAppLaunch == "")
                    {
                        strAppLaunch = strAppDest;
                    }
                }                    

                if (File.Exists(strAppDest))
                {
                    if (File.GetLastWriteTime(strAppDest).ToString() !=
                            File.GetLastWriteTime(strApp).ToString())
                    {
                        InvokeChangeItemStatus(lblInfo, "Actualizando desde " + strApp +
                                    " hasta " + strAppDest);
                        try
                        {
                                File.Copy(strApp, strAppDest, true);
                        }
                        catch (Exception e)
                        {
                            InvokeChangeItemStatus(lblErrorInfo, "Error:" + e.Message);
                        }
                        //wclObj.DownloadFile( uURL , strAppDest );
                    }
                }
                else
                {
                    if (File.Exists(strApp))
                    {
                        InvokeChangeItemStatus(lblInfo, "Copiando desde " + strApp +
                                        " hasta " + strAppDest);

                        try
                        {
                            File.Copy(strApp, strAppDest, true);
                        }
                        catch (Exception e)
                        {
                            InvokeChangeItemStatus(lblErrorInfo, "Error:" + e.Message);
                        }
                    }
                    else
                    {
                        InvokeChangeItemStatus(lblInfo, "[No existe o no accesible] Archivo origen " + strApp);
                    }
                }
            }

            InvokeChangeItemStatus(lblInfo, "Terminada la busqueda de actualizaciones...");

            Thread.Sleep(3000);

            if (strAppLaunch != "")
            {
                try
                {
                    InvokeChangeItemStatus(lblInfo, "Iniciando Aplicación");
                    string args = "test on";

                    if (!test)
                        args = "";

                    //Process.Start(strAppLaunch, args);

                    var psi = new ProcessStartInfo();
                    psi.FileName = strAppLaunch;

                    //TODO: COMENTADO PARA EMAPAD -- Estimando eliminar API de windows APICall.cs No esta siendo utilizado
                    //if (Environment.OSVersion != null)
                        //psi.Verb = Environment.OSVersion.Version.Major <= 5 ? "open" : "runas"; //Como administrador
                    //COMENTADO PARA EMAPAD

                    psi.Arguments = args;
                    var process = new Process();
                    process.StartInfo = psi;
                    process.Start();

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al ejecutar el programa. " +
                        "Es probable que no exista en el directorio, " +
                        "verifique la ruta de actualización.\n" + e.Message);

                }
            }

            //Application.ExitThread();
            Application.Exit();
            Environment.Exit(0);
        }

        public static bool IsIpLan(string IP)
        {
            try
            { 
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                // test if any host IP equals to any local IP or to localhost
                foreach (IPAddress hostIP in localIPs)
                {                    
                    //if (IPAddress.IsLoopback(hostIP)) return true;
                    //MessageBox.Show(hostIP.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
            }
            return false;
        }

        public static bool IsLocalIpAddress(string host)
        {
            try
            { // get host IP addresses
                IPAddress[] hostIPs = Dns.GetHostAddresses(host);
                // get local IP addresses
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                // test if any host IP equals to any local IP or to localhost
                foreach (IPAddress hostIP in hostIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(hostIP)) return true;
                    // is local address
                    foreach (IPAddress localIP in localIPs)
                    {
                        if (hostIP.Equals(localIP)) return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e.Message);
            }
            return false;
        }

        //public void Launch2()
        //{
        //    string strCompPath = "";
        //    //string strCompPath2 = "";

        //    string strApp = "";
        //    string strAppDest = "";
        //    string strPCache = "";
        //    string strAppLaunch = "";
        //    string[] strCompList;
        //    //string[] strCompList2;
        //    int intIndex;

        //    try
        //    {
        //        if (!File.Exists(AppEnvironment.strConfigFile))
        //        {
        //            AppConfig.saveConfigXML();
        //        }

        //        strCompPath = AppConfig.getAppPath(test);
        //        strCompList = AppConfig.getCompList(test).Split('|');
        //        //strCompPath2 = AppConfig.getAppPath2();
        //        //strCompList2 = AppConfig.getCompList2().Split('|');

        //        string strTestPath = ".Test";

        //        if (!test)
        //            strTestPath = "";

        //        Directory.CreateDirectory(@AppDomain.CurrentDomain.BaseDirectory + @"\Cache" + strTestPath);
        //        strPCache = @AppDomain.CurrentDomain.BaseDirectory + @"Cache" + strTestPath + @"\";

        //        InvokeChangeItemStatus(lblInfo, "Buscando actualizacion en " + strCompPath);

        //        for (intIndex = 0; intIndex < strCompList.Length; intIndex++)
        //        {

        //            strApp = strCompPath + @"\" + strCompList[intIndex];
        //            strAppDest = strPCache + strCompList[intIndex];

        //            InvokeChangeItemStatus(lblInfo, "Buscando actualizacion de " + strAppDest);

        //            if (Path.GetExtension(strAppDest) == ".exe")
        //            {
        //                if (strAppLaunch == "")
        //                {
        //                    strAppLaunch = strAppDest;
        //                }
        //            }

        //            File.Copy(strApp, strAppDest + ".upd", true);

        //            if (File.Exists(strAppDest))
        //            {

        //                if (File.GetLastWriteTime(strAppDest).ToString() !=
        //                        File.GetLastWriteTime(strAppDest + ".upd").ToString())
        //                {
        //                    InvokeChangeItemStatus(lblInfo, "Actualizando desde " + strApp +
        //                                " hasta " + strAppDest);

        //                    File.Copy(strAppDest + ".upd", strAppDest, true);
        //                    //wclObj.DownloadFile( uURL , strAppDest );
        //                }
        //            }
        //            else
        //            {
        //                InvokeChangeItemStatus(lblInfo, "Copiando desde " + strApp +
        //                                " hasta " + strAppDest);

        //                File.Copy(strAppDest + ".upd", strAppDest, true);
        //            }
        //            File.Delete(strAppDest + ".upd");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //MessageBox.Show("Error: Verifique la ruta de actualización.  " + strApp + " : " + e.Message);
        //        InvokeChangeItemStatus(lblErrorInfo, "Error:" + e.Message);

        //        //lblInfo.ForeColor = Color.Red;
        //    }

        //    if (strAppLaunch != "")
        //    {
        //        try
        //        {
        //            InvokeChangeItemStatus(lblInfo, "Iniciando Aplicación");
        //            string args = "test on";

        //            if (!test)
        //                args = "";

        //            //Process.Start(strAppLaunch, args);

        //            var psi = new ProcessStartInfo();
        //            psi.FileName = strAppLaunch;

        //            if (Environment.OSVersion != null)
        //                psi.Verb = Environment.OSVersion.Version.Major <= 5 ? "open" : "runas";

        //            psi.Arguments = args;
        //            var process = new Process();
        //            process.StartInfo = psi;
        //            process.Start();

        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show("Error al ejecutar el programa. " +
        //                "Es probable que no exista en el directorio, " +
        //                "verifique la ruta de actualización.\n" + e.Message);

        //        }
        //    }

        //    //Application.ExitThread();
        //    Application.Exit();
        //    Environment.Exit(0);
        //}

        private void frmSplash_Load(object sender, EventArgs e)
        {
            m_ChangeItemStatus = new ChangeItemStatus(LChangeItemStatus);
            //intCount = 0;
            lblFwV.Text = " Framework: " + Environment.Version.ToString();
            lblOsV.Text = Environment.OSVersion.ToString();

            thread1 = new Thread(new ThreadStart(Launch));
            thread1.Start();
        }
        
        
        private void lblConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void mniLoadTest_Click(object sender, EventArgs e)
        {
            if (test)
                return;

            thread1.Suspend();
            thread1.Interrupt();
            
            thread1 = null;
            InvokeChangeItemStatus(lblInfo, "Cancelando la carga...");
            lblInfo2.Font = this.Font = new Font(this.Font, FontStyle.Bold);
            lblInfo2.ForeColor = Color.LightYellow;
            lblInfo2.Text = "Iniciando aplicación de prueba";
            lblInfo2.Refresh();
            lblInfo2.Update();
            test = true;
            thread2 = new Thread(new ThreadStart(Launch));
            thread2.Start();
            
            return;
        }

        private void lblOsV_Click(object sender, EventArgs e)
        {

        }
    }
}