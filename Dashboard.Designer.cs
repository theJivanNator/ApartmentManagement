
namespace ApartmentManagement
{
    partial class Dashboard
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
            this.cmbUnits = new System.Windows.Forms.ComboBox();
            this.lstComplaints = new System.Windows.Forms.ListBox();
            this.btnMakeNewComplaint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUpdateDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbUnits
            // 
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.Location = new System.Drawing.Point(145, 84);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(179, 23);
            this.cmbUnits.TabIndex = 0;
            this.cmbUnits.SelectedIndexChanged += new System.EventHandler(this.cmbUnits_SelectedIndexChanged);
            // 
            // lstComplaints
            // 
            this.lstComplaints.FormattingEnabled = true;
            this.lstComplaints.HorizontalScrollbar = true;
            this.lstComplaints.ItemHeight = 15;
            this.lstComplaints.Location = new System.Drawing.Point(21, 171);
            this.lstComplaints.Name = "lstComplaints";
            this.lstComplaints.Size = new System.Drawing.Size(456, 304);
            this.lstComplaints.TabIndex = 1;
            // 
            // btnMakeNewComplaint
            // 
            this.btnMakeNewComplaint.Location = new System.Drawing.Point(336, 115);
            this.btnMakeNewComplaint.Name = "btnMakeNewComplaint";
            this.btnMakeNewComplaint.Size = new System.Drawing.Size(141, 43);
            this.btnMakeNewComplaint.TabIndex = 2;
            this.btnMakeNewComplaint.Text = "New Complaint";
            this.btnMakeNewComplaint.UseVisualStyleBackColor = true;
            this.btnMakeNewComplaint.Click += new System.EventHandler(this.btnMakeNewComplaint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dashboard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Your Units";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Your Unit Complaints";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(423, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUpdateDetails
            // 
            this.btnUpdateDetails.Location = new System.Drawing.Point(393, 55);
            this.btnUpdateDetails.Name = "btnUpdateDetails";
            this.btnUpdateDetails.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateDetails.TabIndex = 7;
            this.btnUpdateDetails.Text = "UpdateDetails";
            this.btnUpdateDetails.UseVisualStyleBackColor = true;
            this.btnUpdateDetails.Click += new System.EventHandler(this.btnUpdateDetails_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 487);
            this.Controls.Add(this.btnUpdateDetails);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMakeNewComplaint);
            this.Controls.Add(this.lstComplaints);
            this.Controls.Add(this.cmbUnits);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUnits;
        private System.Windows.Forms.ListBox lstComplaints;
        private System.Windows.Forms.Button btnMakeNewComplaint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnUpdateDetails;
    }
}