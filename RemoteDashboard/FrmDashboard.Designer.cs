namespace Rakutenwinapp
{
    partial class FrmDashboard
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
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comCommand = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Location = new System.Drawing.Point(237, 60);
            this.txtDeviceId.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(684, 38);
            this.txtDeviceId.TabIndex = 0;
            this.txtDeviceId.Text = "john-drone-01";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device id:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(981, 60);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(235, 48);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Command:";
            // 
            // comCommand
            // 
            this.comCommand.Enabled = false;
            this.comCommand.FormattingEnabled = true;
            this.comCommand.Items.AddRange(new object[] {
            "Takeoff",
            "Land",
            "Left",
            "Right",
            "Forward",
            "Back"});
            this.comCommand.Location = new System.Drawing.Point(237, 157);
            this.comCommand.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comCommand.Name = "comCommand";
            this.comCommand.Size = new System.Drawing.Size(684, 39);
            this.comCommand.TabIndex = 4;
            this.comCommand.Text = "Takeoff";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(981, 155);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(235, 48);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(75, 245);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1141, 781);
            this.lblStatus.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 1164);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.comCommand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDeviceId);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Remote Dashboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comCommand;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblStatus;
    }
}

