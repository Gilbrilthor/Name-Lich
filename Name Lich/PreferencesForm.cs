using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Name_Lich
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {

            InitializeComponent();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            // Read the settings from the settings file
            checkboxShouldLog.Checked = Properties.Settings.Default.ShouldLog; // Currently fires SetShouldLog. Might need to change that.

            // Set the tool tips on all the settings.
            prefToolTip.SetToolTip(checkboxShouldLog, "Logging helps me to focus on the things most important to you!");
        }

        private void checkboxShouldLog_CheckedChanged(object sender, EventArgs e)
        {
            var shouldLog = checkboxShouldLog.Checked;

            SetShouldLog(shouldLog);
        }

        private void SetShouldLog(bool shouldLog)
        {
            Properties.Settings.Default.ShouldLog = shouldLog;
            Program.Logger.ShouldLog = shouldLog;
        }
    }
}
