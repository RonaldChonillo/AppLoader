using System.Runtime.InteropServices;

class APICall
{

    [DllImport( "kernel32.dll" , SetLastError = true )]
    static extern uint WinExec( string command , uint uCmdShow );
    static public string strApp = "";
    //static public void Exec( string file )
    static public void Exec()
    {        
        WinExec( strApp , 1 );
        int errorCode = Marshal.GetLastWin32Error();
        //Console.WriteLine( "APICall.WinExec: " + errorCode );
    }

}

