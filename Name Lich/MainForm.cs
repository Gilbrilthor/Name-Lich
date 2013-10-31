using Name_Lich_Backend;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Name_Lich
{
    public partial class MainForm : Form
    {
        private AbstractNameReader reader;
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
        /// Generates a number of names and populates the listBox with them.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
#if DEBUG
            var watch = Stopwatch.StartNew();
#endif
            // Clear the old names
            lbGeneratedNames.Items.Clear();

            // Get the selected generator
            var generator = cbNameType.SelectedItem as AbstractNameGenerator;

            // Check the generator
            if (generator != null)
            {
                // Create a list of ListViewItems from names generated
                var generatedNames =
                    (from number in Enumerable.Range(0, (int)nNameNumber.Value)
                     select generator.GenerateName());

                // Add all the generated names to the list view
                foreach (var name in generatedNames)
                {
                    lbGeneratedNames.Items.Add(name);
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

        /// <summary>
        /// Shows the about form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new NameLichAboutBox();

            aboutBox.ShowDialog();
        }

        /// <summary>
        /// Copies the selected indices of the Generated Names to the clipboard.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string statusText;

            var numNames = lbGeneratedNames.SelectedItems.Count;

            // Make sure that there are some names to be selected
            if (numNames > 0)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < numNames - 1; i++)
                {
                    var name = lbGeneratedNames.SelectedItems[i];

                    sb.AppendLine((string)name);
                }
                sb.Append(lbGeneratedNames.SelectedItems[numNames - 1]);

                Clipboard.SetText(sb.ToString());
                statusText = string.Format("{0} name{1} copied to the clipboard", numNames, numNames == 1 ? "" : "s");
            }
            else
            {
                // There were no names selected. Let the user know
                statusText = "No names are selected!";
            }

            // Display the text that needs to be displayed
            toolStatusLblLeft.Text = statusText;
        }

        /// <summary>
        /// Detects when the mouse button is released in the form list box. If not on an index, deselect everything.
        /// If the right mouse, show the context menu.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void lbGeneratedNames_RightMouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Mouse button released in list box!");

            var index = lbGeneratedNames.IndexFromPoint(e.Location);

            if (index < 0)
                lbGeneratedNames.SelectedIndices.Clear();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Debug.WriteLine("Right mouse button released in list box!");

                if (index >= 0)
                {
                    // If they click outside the selection, clear it and just pick that one
                    if (!lbGeneratedNames.SelectedIndices.Contains(index))
                    {
                        lbGeneratedNames.SelectedIndices.Clear();
                        lbGeneratedNames.SelectedIndices.Add(index);
                    }

                    cMenuNameMenu.Show(lbGeneratedNames.PointToScreen(e.Location));
                }
            }
        }

        /// <summary>
        /// Regenerates the selected names.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void regenerateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbGeneratedNames.SelectedIndices.Count > 0)
            {
                var generator = cbNameType.SelectedItem as AbstractNameGenerator;

                if (generator != null)
                {
                    var indices = new List<int>(lbGeneratedNames.SelectedIndices.Count);

                    // Copy the selected indices. Changing them destroys the integrity of the SelectedIndices collection
                    foreach (int index in lbGeneratedNames.SelectedIndices)
                    {
                        indices.Add(index);
                    }

                    // Change the names that are selected.
                    foreach (int index in indices)
                    {
                        lbGeneratedNames.Items[index] = generator.GenerateName();
                    }

                    // Reselect the old indices
                    lbGeneratedNames.SelectedIndices.Clear();
                    foreach (int index in indices)
                    {
                        lbGeneratedNames.SelectedIndices.Add(index);
                    }
                }
            }
        }
    }
}