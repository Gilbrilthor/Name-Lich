namespace Name_Lich
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbNameType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nNameNumber = new System.Windows.Forms.NumericUpDown();
            this.lvGeneratedNames = new System.Windows.Forms.ListView();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblNames = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nNameNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type of Name";
            // 
            // cbNameType
            // 
            this.cbNameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNameType.FormattingEnabled = true;
            this.cbNameType.Location = new System.Drawing.Point(13, 30);
            this.cbNameType.Name = "cbNameType";
            this.cbNameType.Size = new System.Drawing.Size(121, 21);
            this.cbNameType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Names";
            // 
            // nNameNumber
            // 
            this.nNameNumber.Location = new System.Drawing.Point(13, 71);
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
            // lvGeneratedNames
            // 
            this.lvGeneratedNames.Font = new System.Drawing.Font("Liberation Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGeneratedNames.Location = new System.Drawing.Point(140, 30);
            this.lvGeneratedNames.Name = "lvGeneratedNames";
            this.lvGeneratedNames.Size = new System.Drawing.Size(127, 185);
            this.lvGeneratedNames.TabIndex = 4;
            this.lvGeneratedNames.UseCompatibleStateImageBehavior = false;
            this.lvGeneratedNames.View = System.Windows.Forms.View.List;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(13, 147);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 39);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(13, 192);
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
            this.lblNames.Location = new System.Drawing.Point(140, 12);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(40, 13);
            this.lblNames.TabIndex = 7;
            this.lblNames.Text = "Names";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 227);
            this.Controls.Add(this.lblNames);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lvGeneratedNames);
            this.Controls.Add(this.nNameNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNameType);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Name Lich";
            ((System.ComponentModel.ISupportInitialize)(this.nNameNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNameType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nNameNumber;
        private System.Windows.Forms.ListView lvGeneratedNames;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblNames;
    }
}

