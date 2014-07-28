using LoggerLib;
using System;
using System.Windows.Forms;

namespace Name_Lich
{
    internal static class Program
    {
        internal static readonly Logger Logger = new Logger("Log-NameLich", shouldLog:Properties.Settings.Default.ShouldLog);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(System.Deployment.Application.InvalidDeploymentException))
                {
                    Logger.LogException(ex,
                    ex.GetType() != typeof(System.Deployment.Application.InvalidDeploymentException));
                }
            }

            Logger.Dispose();
        }
    }
}