namespace Name_Lich
{
    partial class PreferencesForm
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
            this.checkboxShouldLog = new System.Windows.Forms.CheckBox();
            this.prefToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // checkboxShouldLog
            // 
            this.checkboxShouldLog.AutoSize = true;
            this.checkboxShouldLog.Location = new System.Drawing.Point(13, 13);
            this.checkboxShouldLog.Name = "checkboxShouldLog";
            this.checkboxShouldLog.Size = new System.Drawing.Size(100, 17);
            this.checkboxShouldLog.TabIndex = 0;
            this.checkboxShouldLog.Text = "Enable Logging";
            this.checkboxShouldLog.UseVisualStyleBackColor = true;
            this.checkboxShouldLog.CheckedChanged += new System.EventHandler(this.checkboxShouldLog_CheckedChanged);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.checkboxShouldLog);
            this.Name = "PreferencesForm";
            this.Text = "PreferencesForm";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxShouldLog;
        private System.Windows.Forms.ToolTip prefToolTip;
    }
}