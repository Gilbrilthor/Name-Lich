using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Name_Lich
{
    public partial class ScratchPad : Form
    {
        public ScratchPad()
        {
            InitializeComponent();
        }

        public void AddNames(IEnumerable<string> nameList)
        {
            int itemsAdded = 0, // Items added to the list
            itemsSkipped = 0;   // Items skipped because they are already in the list
            foreach (string name in nameList)
            {
                // If the box doesn't already include the name, add it
                if (!lbNames.Items.Contains(name))
                {
                    lbNames.Items.Add(name);
                    itemsAdded++;
                }
                else
                {
                    itemsSkipped++;
                }
            }

            updateNameCount();
        }

        public void CopySelectedNames()
        {
            copy(lbNames.SelectedItems.Cast<string>());
        }

        public void CopyAllNames()
        {
            copy(lbNames.Items.Cast<string>());
        }

        private void copy(IEnumerable<string> list)
        {
            int namesCount = 0;

            var sb = new StringBuilder();

            string statusText;

            foreach (string name in list)
            {
                sb.AppendLine(name);
                namesCount++;
            }

            // Make sure there is something actually selected
            if (namesCount > 0)
            {
                // Include correct grammar regarding 1 name vs multiple names
                statusText = string.Format("{0} name{1} copied to the clipboard!", namesCount, namesCount != 1 ? "s" : "");

                Clipboard.SetText(sb.ToString());
            }
            else
            {
                statusText = "No names were selected!";
            }

            statusLabel.Text = statusText;
        }

        private void deleteSelected()
        {
            int numSelected = lbNames.SelectedItems.Count;

            string statusText;

            if (numSelected > 0)
            {
                List<string> names = new List<string>(lbNames.SelectedItems.Cast<string>());

                foreach (var name in names)
                {
                    lbNames.Items.Remove(name);
                }

                statusText = string.Format("{0} name{1} deleted from the list.", numSelected, numSelected != 1 ? "s" : "");
            }
            else
            {
                statusText = "No names were selected!";
            }

            statusLabel.Text = statusText;
        }

        private void deleteAll()
        {
            int numNames = lbNames.Items.Count;

            string statusText;

            if (numNames > 0)
            {
                List<string> names = new List<string>(lbNames.Items.Cast<string>());

                foreach (var name in names)
                {
                    lbNames.Items.Remove(name);
                }

                statusText = string.Format("{0} name{1} deleted from the list.", numNames, numNames != 1 ? "s" : "");
            }
            else
            {
                statusText = "No names were selected!";
            }

            statusLabel.Text = statusText;
        }

        private void scratchPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.logger.Info("Scratch pad closed!");
            e.Cancel = true;

            this.Hide();
        }

        private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.logger.Info("Copy Selected names clicked");
            CopySelectedNames();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.logger.Info("Copy all names item selected");
            CopyAllNames();
        }

        private void selectedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.logger.Info("Delete selected names in scratchpad selected");
            int numSelected = lbNames.SelectedItems.Count;
            if (numSelected > 0)
            {
                if (MessageBox.Show(string.Format(
            "Are you sure you want to remove the {0} selected names? This cannot be undone.", numSelected),
            "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    deleteSelected();
                    updateNameCount();
                }
            }
            else
            {
                statusLabel.Text = "There are no names selected!";
            }
        }

        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.logger.Info("Delete all names in scratch pad selected");
            int numSelected = lbNames.Items.Count;
            if (numSelected > 0)
            {
                if (MessageBox.Show(string.Format(
            "Are you sure you want to remove all the names in the list? This cannot be undone."),
            "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    deleteAll();
                    updateNameCount();
                }
            }
            else
            {
                statusLabel.Text = "There are no names on the scratch pad!";
            }
        }

        private void updateNameCount()
        {
            statusNameCountLabel.Text = string.Format("{0} name{1}", lbNames.Items.Count, lbNames.Items.Count != 1 ? "s" : "");
        }
    }
}