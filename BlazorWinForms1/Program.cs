using AutoUpdaterDotNET;

namespace BlazorWinForms1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/Hamoo17/BlazorWinForms1/main/BlazorWinForms1/UpdateInfo.xml");

            // ApplicationConfiguration.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm = new Form1();
            Startup._form1 = frm;
            Startup.Init();
            List<string> url = new List<string>();



            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(frm);




        }
    }
}