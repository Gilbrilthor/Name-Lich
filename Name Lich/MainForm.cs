using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Name_Lich_Backend;
using System.Deployment.Application;

#if DEBUG
using System.Diagnostics;
#endif

namespace Name_Lich
{
    public partial class MainForm : Form
    {

        AbstractNameReader reader;
        private static Random random;
        private const string NAM_LOCATION = @"/NamFiles";
        private List<AbstractNameGenerator> generators;

        public MainForm()
        {
            InitializeComponent();

            random = new Random();
            reader = new NamFileNameReader(random);

            string path;

            try
            {
                path = ApplicationDeployment.CurrentDeployment.DataDirectory;
            }
            catch (InvalidDeploymentException ex)
            {
                Debug.WriteLine("Exception Caught: {0}", ex);
                path = ".";
            }

            try
            {
                generators = reader.ReadNameParts(path + NAM_LOCATION);
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Error! {0} is not a valid location.", path + NAM_LOCATION));
                Application.Exit();
            }

            cbNameType.DataSource = generators;
        }

        /// <summary>
        /// Generates a number of names and populates the listview with them.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {

#if DEBUG
            var watch = Stopwatch.StartNew();
#endif
            // Clear the old names
            lvGeneratedNames.Clear();

            // Get the selected generator
            var generator = cbNameType.SelectedItem as AbstractNameGenerator;

            // Check the generator
            if (generator != null)
            {
                // Create a list of ListViewItems from names generated
                var generatedNames = 
                    (from number in Enumerable.Range(0, (int)nNameNumber.Value)
                         select new ListViewItem(generator.GenerateName(), 0));

                // Add all the generated names to the list view
                foreach (var name in generatedNames)
                {
                    lvGeneratedNames.Items.Add(name);
                }
            }

#if DEBUG
            watch.Stop();
            Debug.WriteLine("{0} executed in time {1}.", "GenerateNames", watch.Elapsed);
#endif
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new NameLichAboutBox();

            aboutBox.ShowDialog();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lvGeneratedNames.Items.Count - 1; i++)
            {
                var name = lvGeneratedNames.Items[i];

                sb.AppendLine(name.Text);
            }

            sb.Append(lvGeneratedNames.Items[lvGeneratedNames.Items.Count - 1].Text);

            Clipboard.SetText(sb.ToString());
            var statusText = string.Format("{0} names copied to the clipboard", lvGeneratedNames.Items.Count);
            toolStatusLblLeft.Text = statusText;
        }
    }
}
