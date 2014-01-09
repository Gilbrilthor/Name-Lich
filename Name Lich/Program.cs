using LoggerLib;
using System;
using System.Windows.Forms;

namespace Name_Lich
{
    internal static class Program
    {
        internal static Logger logger = new Logger("Log-NameLich");

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
                    logger.LogException(ex,
                    ex.GetType() != typeof(System.Deployment.Application.InvalidDeploymentException));
                }
            }

            logger.Dispose();
        }
    }
}