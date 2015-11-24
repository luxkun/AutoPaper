namespace AutoPaper
{
    partial class ConfigForm
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
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.policyBComboBox = new System.Windows.Forms.ComboBox();
            this.policyAComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wallpaper change delay (minutes):";
            // 
            // delayTextBox
            // 
            this.delayTextBox.Location = new System.Drawing.Point(537, 12);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(389, 38);
            this.delayTextBox.TabIndex = 1;
            this.delayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(815, 288);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 56);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(690, 288);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(119, 56);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pick Policy:";
            // 
            // policyBComboBox
            // 
            this.policyBComboBox.FormattingEnabled = true;
            this.policyBComboBox.Location = new System.Drawing.Point(705, 69);
            this.policyBComboBox.Name = "policyBComboBox";
            this.policyBComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.policyBComboBox.Size = new System.Drawing.Size(221, 39);
            this.policyBComboBox.TabIndex = 5;
            // 
            // policyAComboBox
            // 
            this.policyAComboBox.FormattingEnabled = true;
            this.policyAComboBox.Location = new System.Drawing.Point(537, 69);
            this.policyAComboBox.Name = "policyAComboBox";
            this.policyAComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.policyAComboBox.Size = new System.Drawing.Size(150, 39);
            this.policyAComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Filter (by title):";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(537, 128);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(389, 38);
            this.filterTextBox.TabIndex = 8;
            this.filterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // styleComboBox
            // 
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(537, 185);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.styleComboBox.Size = new System.Drawing.Size(389, 39);
            this.styleComboBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Style:";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(938, 356);
            this.Controls.Add(this.styleComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filterTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.policyAComboBox);
            this.Controls.Add(this.policyBComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Text = "AutoPaper Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox policyBComboBox;
        private System.Windows.Forms.ComboBox policyAComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label label4;
    }
}