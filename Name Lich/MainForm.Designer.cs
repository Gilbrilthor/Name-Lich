namespace Name_Lich
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbNameType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nNameNumber = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNames = new System.Windows.Forms.Label();
            this.msTopMenu = new System.Windows.Forms.MenuStrip();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStatusLblLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbGeneratedNames = new System.Windows.Forms.ListBox();
            this.cMenuNameMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.regenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.nNameNumber)).BeginInit();
            this.msTopMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cMenuNameMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type of Name";
            // 
            // cbNameType
            // 
            this.cbNameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNameType.FormattingEnabled = true;
            this.cbNameType.Location = new System.Drawing.Point(13, 50);
            this.cbNameType.Name = "cbNameType";
            this.cbNameType.Size = new System.Drawing.Size(121, 21);
            this.cbNameType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Names";
            // 
            // nNameNumber
            // 
            this.nNameNumber.Location = new System.Drawing.Point(13, 91);
            this.nNameNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nNameNumber.Name = "nNameNumber";
            this.nNameNumber.Size = new System.Drawing.Size(48, 20);
            this.nNameNumber.TabIndex = 3;
            this.nNameNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(13, 167);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 39);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(13, 212);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Location = new System.Drawing.Point(140, 32);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(40, 13);
            this.lblNames.TabIndex = 7;
            this.lblNames.Text = "Names";
            // 
            // msTopMenu
            // 
            this.msTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.msTopMenu.Location = new System.Drawing.Point(0, 0);
            this.msTopMenu.Name = "msTopMenu";
            this.msTopMenu.Size = new System.Drawing.Size(279, 24);
            this.msTopMenu.TabIndex = 8;
            this.msTopMenu.Text = "menuStrip1";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatusLblLeft});
            this.statusStrip1.Location = new System.Drawing.Point(0, 251);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(279, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStatusLblLeft
            // 
            this.toolStatusLblLeft.Name = "toolStatusLblLeft";
            this.toolStatusLblLeft.Size = new System.Drawing.Size(0, 17);
            // 
            // lbGeneratedNames
            // 
            this.lbGeneratedNames.FormattingEnabled = true;
            this.lbGeneratedNames.Location = new System.Drawing.Point(141, 49);
            this.lbGeneratedNames.Name = "lbGeneratedNames";
            this.lbGeneratedNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbGeneratedNames.Size = new System.Drawing.Size(120, 186);
            this.lbGeneratedNames.TabIndex = 10;
            this.lbGeneratedNames.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbGeneratedNames_RightMouseClick);
            // 
            // cMenuNameMenu
            // 
            this.cMenuNameMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regenerateToolStripMenuItem});
            this.cMenuNameMenu.Name = "cMenuNameMenu";
            this.cMenuNameMenu.Size = new System.Drawing.Size(134, 26);
            // 
            // regenerateToolStripMenuItem
            // 
            this.regenerateToolStripMenuItem.Name = "regenerateToolStripMenuItem";
            this.regenerateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.regenerateToolStripMenuItem.Text = "&Regenerate";
            this.regenerateToolStripMenuItem.Click += new System.EventHandler(this.regenerateToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 273);
            this.Controls.Add(this.lbGeneratedNames);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.nNameNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNameType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msTopMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msTopMenu;
            this.Name = "MainForm";
            this.Text = "Name Lich";
            ((System.ComponentModel.ISupportInitialize)(this.nNameNumber)).EndInit();
            this.msTopMenu.ResumeLayout(false);
            this.msTopMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cMenuNameMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNameType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nNameNumber;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.MenuStrip msTopMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusLblLeft;
        private System.Windows.Forms.ListBox lbGeneratedNames;
        private System.Windows.Forms.ContextMenuStrip cMenuNameMenu;
        private System.Windows.Forms.ToolStripMenuItem regenerateToolStripMenuItem;
    }
}

