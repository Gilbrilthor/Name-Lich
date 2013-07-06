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

namespace Name_Lich
{
    public partial class Form1 : Form
    {

        AbstractNameReader reader;
        private static Random random;
        private const string NAM_LOCATION = @"D:\Users\Matthew\Dropbox\Jerianne and Matthew\NameMage\Names";
        private List<AbstractNameGenerator> generators;


        public Form1()
        {
            InitializeComponent();

            random = new Random();
            reader = new NamFileNameReader(random);

            generators = reader.ReadNameParts(NAM_LOCATION);

            cbNameType.DataSource = generators;

        }

        /// <summary>
        /// Generates a number of names and populates the listview with them.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
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
    }
}
